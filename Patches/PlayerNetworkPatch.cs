using HarmonyLib;
using HighlightPlus;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(PlayerNetwork))]
public class PlayerNetworkPatch {
    private static PlayerNetwork pNetwork = null;

    [HarmonyPatch(typeof(PlayerNetwork), nameof(PlayerNetwork.OnStartClient))]
    [HarmonyPrefix]
    private static bool OptimizePricesOnSpawn() {
        OptimizeProductPrices();
        return true;
    }

    [HarmonyPatch("Start"), HarmonyPrefix]
    private static void StartPatch(PlayerNetwork __instance) {
        if (__instance.isLocalPlayer) {
            pNetwork = __instance;
        }
    }

    [HarmonyPatch("Update"), HarmonyPostfix]
    private static void UpdatePatch(PlayerNetwork __instance, ref float ___pPrice, TextMeshProUGUI ___marketPriceTMP, ref TextMeshProUGUI ___yourPriceTMP) {

        if (!FsmVariables.GlobalVariables.GetFsmBool("InChat").Value == false) {
            return;
        } else {
            if (BetterSMT.PricingGunToggle.Value == true) {
                if (BetterSMT.PricingGunHotkey.Value.IsDown()) {
                    __instance.CmdChangeEquippedItem(2);
                }
            }
            if (BetterSMT.BroomToggle.Value == true) {
                if (BetterSMT.BroomHotkey.Value.IsDown()) {
                    __instance.CmdChangeEquippedItem(5);
                }
            }

            if (BetterSMT.DLCTabletToggle.Value == true) {
                if (BetterSMT.DLCTabletHotkey.Value.IsDown()) {
                    __instance.CmdChangeEquippedItem(3);
                }
            }

            if (BetterSMT.PricingGunToggle.Value == true || BetterSMT.BroomToggle.Value == true || BetterSMT.DLCTabletToggle.Value == true) {
                if (Input.GetKeyDown(KeyCode.R)) {
                    __instance.CmdChangeEquippedItem(0);
                }
            }
        }
        if (BetterSMT.ToggleDoublePrice.Value == true) {
            if (BetterSMT.doublePrice && ___marketPriceTMP != null) {
                if (float.TryParse(___marketPriceTMP.text[1..].Replace(',', '.'),
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out float market)) {
                    ___pPrice = market * 2;

                    if (BetterSMT.roundDown.Value) {
                        ___pPrice = BetterSMT.NearestTen.Value ? (float)(Math.Floor(___pPrice * 10) / 10) : (float)(Math.Floor(___pPrice * 20) / 20);
                    }

                    ___yourPriceTMP.text = "$" + ___pPrice;
                }
            }
        }
    }

    public static void OptimizeProductPrices() {
        if (BetterSMT.AutoAdjustPriceDaily.Value == true) {
            GameObject[] products = ProductListing.Instance.productPrefabs;
            ProductListing productListing = ProductListing.Instance;
            List<float> basePriceList = [];

            for (int i = 0; i < products.Length; i++) {
                if (i < products.Length) {
                    Data_Product product = products[i].GetComponent<Data_Product>();
                    basePriceList.Add(product.basePricePerUnit);
                }
            }

            float[] basePrices = [.. basePriceList];
            float[] inflationMultiplier = productListing.tierInflation;
            float priceMultiplier = BetterSMT.AutoAdjustPriceDailyValue.Value;
            _ = new float[basePrices.Length];

            for (int i = 0; i < basePrices.Length; i++) {
                Data_Product productToUpdate = products[i].GetComponent<Data_Product>();
                float calculatedPrice = basePrices[i] * inflationMultiplier[productToUpdate.productTier] * priceMultiplier;
                float newPrice = Mathf.Floor(calculatedPrice * 100) / 100;
                productListing.CmdUpdateProductPrice(i, newPrice);
            }
        }
    }

    [HarmonyPatch("ChangeEquipment"), HarmonyPostfix]
    private static void ChangeEquipmentPatch(int newEquippedItem) {
        if (newEquippedItem == 0) {
            ClearHighlightedShelves();
        }
    }

    [HarmonyPatch("UpdateBoxContents"), HarmonyPostfix]
    private static void UpdateBoxContentsPatch(int productIndex) {
        HighlightShelvesByProduct(productIndex);
    }

    public static int GetProductFromRaycast() {
        int productID = -1;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo3, 4f, pNetwork.interactableMask)) {
            if (hitInfo3.transform.gameObject.name == "SubContainer") {
                int siblingIndex = hitInfo3.transform.GetSiblingIndex();
                if (!hitInfo3.transform?.parent?.transform?.parent) {
                    return productID;
                }

                Data_Container component = hitInfo3.transform.parent.transform.parent.GetComponent<Data_Container>();
                if (component != null && component.containerClass < 20) {
                    productID = component.productInfoArray[siblingIndex * 2];
                }
            }
        } else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 4f, pNetwork.lMask)) {
            if (hitInfo.transform.gameObject.tag == "Interactable" && hitInfo.transform.GetComponent<BoxData>()) {
                BoxData boxData = hitInfo.transform.GetComponent<BoxData>();
                if (boxData != null) {
                    productID = boxData.productID;
                }
            } else {
                int siblingIndex = hitInfo.transform.GetSiblingIndex();
                if (!hitInfo.transform?.parent?.transform?.parent) {
                    return productID;
                }

                Data_Container component = hitInfo.transform.parent.transform.parent.GetComponent<Data_Container>();
                if (component != null && component.containerClass == 69) // STORAGE SHELF
                {
                    int num = component.productInfoArray[siblingIndex * 2];
                    productID = num;
                }
            }
        }

        return productID;
    }

    public static void HighlightShelvesByProduct(int productID) {
        if (BetterSMT.Highlighting.Value == true) {
            GameObject shelvesOBJ = GameObject.Find("Level_SupermarketProps/Shelves");

            for (int i = 0; i < shelvesOBJ.transform.childCount; i++) {
                Transform child = shelvesOBJ.transform.GetChild(i);
                Data_Container container = child.gameObject.GetComponent<Data_Container>();
                if (container == null) {
                    continue;
                }

                int[] productInfoArray = container.productInfoArray;
                int num = productInfoArray.Length / 2;
                bool highlightShelf = false;
                for (int j = 0; j < num; j++) {
                    int num2 = productInfoArray[j * 2];

                    bool highlightLabel = num2 == productID;
                    Transform labels = child.Find("Labels");
                    if (labels == null || labels.childCount <= j) {
                        continue;
                    }

                    Transform label = labels.GetChild(j);
                    if (highlightLabel) {
                        highlightShelf = true;
                    }

                    HighlightShelf(label, highlightLabel, Color.yellow);
                }
                HighlightShelf(child, highlightShelf, Color.red);
            }

            GameObject storageShelvesOBJ = GameObject.Find("Level_SupermarketProps/StorageShelves");

            for (int i = 0; i < storageShelvesOBJ.transform.childCount; i++) {
                Transform child = storageShelvesOBJ.transform.GetChild(i);
                int[] productInfoArray = child.gameObject.GetComponent<Data_Container>().productInfoArray;
                int num = productInfoArray.Length / 2;
                for (int j = 0; j < num; j++) {
                    int num2 = productInfoArray[j * 2];

                    bool highlightBox = num2 == productID;
                    Transform boxs = child.Find("BoxContainer");
                    if (boxs == null || boxs.childCount <= j) {
                        continue;
                    }

                    Transform box = boxs.GetChild(j);
                    HighlightShelf(box, highlightBox, Color.yellow);
                }
            }
        }
    }

    public static void ClearHighlightedShelves() {
        GameObject shelvesOBJ = GameObject.Find("Level_SupermarketProps/Shelves");

        for (int i = 0; i < shelvesOBJ.transform.childCount; i++) {
            Transform child = shelvesOBJ.transform.GetChild(i);
            int[] productInfoArray = child.gameObject.GetComponent<Data_Container>().productInfoArray;
            int num = productInfoArray.Length / 2;
            for (int j = 0; j < num; j++) {
                Transform labels = child.Find("Labels");
                if (labels == null || labels.childCount <= j) {
                    continue;
                }

                Transform label = labels.GetChild(j);
                HighlightShelf(label, false);
            }
            HighlightShelf(child, false);
        }

        GameObject storageShelvesOBJ = GameObject.Find("Level_SupermarketProps/StorageShelves");

        for (int i = 0; i < storageShelvesOBJ.transform.childCount; i++) {
            Transform child = storageShelvesOBJ.transform.GetChild(i);
            int[] productInfoArray = child.gameObject.GetComponent<Data_Container>().productInfoArray;
            int num = productInfoArray.Length / 2;
            for (int j = 0; j < num; j++) {
                Transform boxContainer = child.Find("BoxContainer");
                if (boxContainer == null) {
                    continue;
                }

                Transform box = boxContainer.GetChild(j);
                if (box == null) {
                    continue;
                }

                HighlightShelf(box, false);
            }
        }
    }

    public static void HighlightShelf(Transform t, bool value, Color? color = null) {
        HighlightEffect highlightEffect = t.GetComponent<HighlightEffect>() ?? t.gameObject.AddComponent<HighlightEffect>();
        if (color != null) {
            highlightEffect.outlineColor = (Color)color;
        }

        highlightEffect.outlineQuality = HighlightPlus.QualityLevel.High;
        highlightEffect.outlineVisibility = Visibility.AlwaysOnTop;
        highlightEffect.outlineContourStyle = ContourStyle.AroundObjectShape;
        highlightEffect.outlineIndependent = true;

        highlightEffect.outline = value ? 1f : 0f;
        highlightEffect.glow = value ? 0f : 1f;

        highlightEffect.enabled = true;
        highlightEffect.SetHighlighted(value);

        highlightEffect.Refresh();
        highlightEffect.highlighted = value;
        highlightEffect._highlighted = value;
    }
}
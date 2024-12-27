using HarmonyLib;
using HighlightPlus;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        if (__instance.marketPriceTMP) {
            __instance.marketPriceTMP.text = BetterSMT.ReplaceCommas(__instance.marketPriceTMP.text);
        }

        if (__instance.yourPriceTMP) {
            __instance.yourPriceTMP.text = BetterSMT.ReplaceCommas(__instance.yourPriceTMP.text);
        }

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
    [HarmonyPatch("PriceSetFromNumpad"), HarmonyPrefix]
    private static void PriceSetFromNumpadPrePatch(ref int productID) {
        if (BetterSMT.OrderingPriceGun.Value == true) {
            if (BetterSMT.OrderingPriceGunHotkey.Value.IsDown()) {
                Data_Product data = ProductListing.Instance.productPrefabs[productID].GetComponent<Data_Product>();
                float tinflactionFactor = ProductListing.Instance.GetComponent<ProductListing>().tierInflation[data.productTier];
                int maxItemsPerBox = data.maxItemsPerBox;
                float basePricePerUnit = data.basePricePerUnit;
                basePricePerUnit *= tinflactionFactor;
                basePricePerUnit = Mathf.Round(basePricePerUnit * 100f) / 100f;
                float num = basePricePerUnit * maxItemsPerBox;
                num = Mathf.Round(num * 100f) / 100f;

                GameData.Instance.GetComponent<ManagerBlackboard>().AddShoppingListProduct(productID, num);
                string key = "product" + productID;
                string localizationString = LocalizationManager.instance.GetLocalizationString(key);

                BetterSMT.CreateCanvasNotification($"Added {localizationString}[{data.productBrand}] to shopping list");
            }
        }
    }

    [HarmonyPatch("PriceSetFromNumpad"), HarmonyPostfix]
    private static void PriceSetFromNumpadPostPatch(PlayerNetwork __instance) {
        __instance.yourPriceTMP.text = BetterSMT.ReplaceCommas(__instance.yourPriceTMP.text);
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

    [HarmonyPatch("Update"), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator) {
        List<CodeInstruction> newInstructions = instructions.ToList();

        // TOP RIGHT CANVAS PRODUCT
        int index = newInstructions.FindIndex(instruction => instruction.opcode == OpCodes.Ldloca_S && instruction.operand is LocalBuilder { LocalIndex: 0 }) - 6;

        _ = newInstructions[index + 42].MoveLabelsFrom(newInstructions[index]);
        newInstructions.RemoveRange(index, 42);

        object nextOperand = newInstructions[index].operand;
        newInstructions.InsertRange(index, [
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(PlayerNetworkPatch), nameof(PlayerNetworkPatch.GetProductFromRaycast))).MoveLabelsFrom(newInstructions[index]),
            new(OpCodes.Stloc_S, nextOperand)
        ]);

        int jumpBackIndex = newInstructions.FindIndex(i => i.opcode == OpCodes.Ldfld && i.operand == (object)AccessTools.Field(typeof(Data_Container), nameof(Data_Container.productInfoArray))) + 6;
        Label jumpBack = generator.DefineLabel();
        _ = newInstructions[jumpBackIndex].WithLabels(jumpBack);

        index = new CodeMatcher(newInstructions).MatchForward
            (
                false,
                new CodeMatch(OpCodes.Ldarg_0),
                new CodeMatch(OpCodes.Ldc_I4_S, (sbyte)-5),
                new CodeMatch(OpCodes.Stfld, AccessTools.Field(typeof(PlayerNetwork), nameof(PlayerNetwork.oldProductID)))
            ).Pos;

        int component2Loc = (newInstructions[newInstructions.FindLastIndex(i => i.Calls(AccessTools.Method(typeof(UnityEngine.Component), nameof(UnityEngine.Component.GetComponent), generics: [typeof(Data_Container)]))) + 1].operand as LocalBuilder).LocalIndex;
        int num3Loc = ((LocalBuilder)newInstructions[jumpBackIndex].operand).LocalIndex;

        newInstructions.InsertRange(index, [
            new CodeInstruction(OpCodes.Ldnull).MoveLabelsFrom(newInstructions[index]),
            new CodeInstruction(OpCodes.Stloc_S, component2Loc),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(PlayerNetworkPatch), nameof(PlayerNetworkPatch.GetProductFromRaycast))),
            new CodeInstruction(OpCodes.Stloc, num3Loc),
            new CodeInstruction(OpCodes.Ldloc, num3Loc),
            new CodeInstruction(OpCodes.Ldc_I4_M1),
            new CodeInstruction(OpCodes.Bgt, jumpBack)
        ]);

        int nullCheckIndex = newInstructions.FindIndex(jumpBackIndex, i => i.opcode == OpCodes.Ldloc_S && i.operand is LocalBuilder localBuilder && localBuilder.LocalIndex == component2Loc) - 5;

        Label skip = generator.DefineLabel();

        newInstructions.InsertRange(nullCheckIndex, [
            new CodeInstruction(OpCodes.Ldloc_S, component2Loc).MoveLabelsFrom(newInstructions[nullCheckIndex]),
            new CodeInstruction(OpCodes.Ldnull),
            new CodeInstruction(OpCodes.Bgt_S, skip),

            new CodeInstruction(OpCodes.Ret),

            new CodeInstruction(OpCodes.Nop).WithLabels(skip)
        ]);

        return newInstructions;
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
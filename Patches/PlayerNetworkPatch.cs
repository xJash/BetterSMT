using HarmonyLib;
using HighlightPlus;
using HutongGames.PlayMaker;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Timers;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(PlayerNetwork))]
public class PlayerNetworkPatch {
    private static readonly Stopwatch stopwatch = new();
    private static PlayerNetwork pNetwork = null;
    private static UpgradesManager upgradesManager;
    public enum ShelfType {
        ProductDisplay,
        Storage
    }

    private struct ShelfData {
        public string highlightsName;
        public string highlightsOriginalName;
        public ShelfType shelfType;

        public ShelfData(ShelfType shelfType) {
            if (shelfType == ShelfType.ProductDisplay) {
                highlightsName = "Labels";
                highlightsOriginalName = "";
                this.shelfType = ShelfType.ProductDisplay;
            } else {
                highlightsName = "HighlightsMarker";
                highlightsOriginalName = "Highlights";
                this.shelfType = ShelfType.Storage;
            }
        }
    }

    [HarmonyPatch(typeof(PlayerNetwork), "UserCode_CmdChangeEquippedItem__Int32")]
    public static class PatchEquippedItemChange {
        [HarmonyPrefix]
        public static void Prefix(int selectedItem) {
            UnityEngine.Debug.Log(selectedItem);
        }
    }


    [HarmonyPatch("Update"), HarmonyPostfix]
    private static void UpdatePatch(PlayerNetwork __instance, ref float ___pPrice, TextMeshProUGUI ___marketPriceTMP, ref TextMeshProUGUI ___yourPriceTMP) {
        if (BetterSMT.AutoSaveEnabled.Value == true) {
            if (GameData.Instance.isServer) {
                if (!stopwatch.IsRunning)
                    stopwatch.Start();
                if (stopwatch.Elapsed.TotalSeconds > BetterSMT.AutoSaveTimer.Value) {
                    stopwatch.Restart();
                    if (BetterSMT.AutoSaveDuringDay.Value || !GameData.Instance.NetworkisSupermarketOpen) {
                        UnityEngine.Debug.Log("saved");
                        GameData.Instance.StartCoroutine(GameDataPatch.SaveGame());
                    }
                }
            }
        }

        if (!FsmVariables.GlobalVariables.GetFsmBool("InChat").Value == false) {
            return;
        } else {
            if (BetterSMT.SledgeToggle.Value == true) {
                if (BetterSMT.SledgeHotkey.Value.IsDown()) {
                    __instance.CmdChangeEquippedItem(7);
                }
            }
            if (BetterSMT.OsMartToggle.Value == true) {
                if (BetterSMT.OsMartHotkey.Value.IsDown()) {
                    __instance.CmdChangeEquippedItem(6);
                }
            }
            if (BetterSMT.TrayToggle.Value == true) {
                if (BetterSMT.TrayHotkey.Value.IsDown()) {
                    __instance.CmdChangeEquippedItem(9);
                }
            }
            if (BetterSMT.SalesToggle.Value == true) {
                if (BetterSMT.SalesHotkey.Value.IsDown()) {
                    __instance.CmdChangeEquippedItem(10);
                }
            }
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
            if (BetterSMT.PricingGunToggle.Value == true || BetterSMT.BroomToggle.Value == true || BetterSMT.DLCTabletToggle.Value == true || BetterSMT.SledgeToggle.Value == true || BetterSMT.OsMartToggle.Value == true || BetterSMT.TrayToggle.Value == true || BetterSMT.SalesToggle.Value == true) {
                if (BetterSMT.EmptyHandsHotkey.Value.IsDown()) {
                    __instance.CmdChangeEquippedItem(0);
                }
            }

            if (BetterSMT.ClockToggle.Value == true) {
                if (BetterSMT.ClockHotkey.Value.IsDown()) {
                    if (upgradesManager == null) {
                        TimeAccelerationWatcher watcher = UnityEngine.Object.FindObjectOfType<TimeAccelerationWatcher>();
                        if (watcher != null) {
                            upgradesManager = watcher.GetComponent<UpgradesManager>();
                        }
                    }

                    if (upgradesManager != null) {
                        bool newState = !upgradesManager.NetworkacceleratedTime;
                        upgradesManager.NetworkacceleratedTime = newState;
                        upgradesManager.RpcTimeAcceleration(newState);
                    }
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

    [HarmonyPatch("ChangeEquipment"), HarmonyPostfix]
    private static void ChangeEquipmentPatch(int newEquippedItem) {
        if (newEquippedItem == 0) {
            ClearHighlightedShelves();
        }
    }

    private static readonly Dictionary<int, Transform> highlightObjectCache = [];

    public static bool IsHighlightCacheUsed { get; set; } = true;

    [HarmonyPatch("Start"), HarmonyPrefix]
    private static void StartPatch(PlayerNetwork __instance) {
        if (__instance.isLocalPlayer) {
            pNetwork = __instance;
        }
    }

    [HarmonyPatch("UpdateBoxContents"), HarmonyPostfix]
    private static void UpdateBoxContentsPatch(int productIndex) {
        HighlightShelvesByProduct(productIndex);
    }

    [HarmonyPatch(typeof(Data_Container), "BoxSpawner")]
    [HarmonyPostfix]
    private static void BoxSpawnerPatch(Data_Container __instance) {
        AddHighlightMarkersToStorage(__instance.transform);
    }

    [HarmonyPatch(typeof(NetworkSpawner), "UserCode_CmdSpawn__Int32__Vector3__Vector3")]
    [HarmonyPostfix]
    private static void NewBuildableConstructed(NetworkSpawner __instance, int prefabID) {
        if (BetterSMT.Highlighting.Value == false)
            return;

        GameObject buildable = __instance.buildables[prefabID];

        if (buildable.name.Contains("StorageShelf")) {
            int index = buildable.GetComponent<Data_Container>().parentIndex;
            Transform buildableParent = __instance.levelPropsOBJ.transform.GetChild(index);
            GameObject lastStorageObject = buildableParent.GetChild(buildableParent.childCount - 1).gameObject;

            AddHighlightMarkersToStorage(lastStorageObject.transform);
        }
    }

    public static int GetProductFromRaycast() {
        if (BetterSMT.Highlighting.Value == false)
            return -1;

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
                if (component != null && component.containerClass == 69) {
                    int num = component.productInfoArray[siblingIndex * 2];
                    productID = num;
                }
            }
        }

        return productID;
    }

    public static void HighlightShelvesByProduct(int productID) {
        if (BetterSMT.Highlighting.Value == false)
            return;
        HighlightShelfTypeByProduct(productID, Color.yellow, ShelfType.ProductDisplay);
        HighlightShelfTypeByProduct(productID, Color.red, ShelfType.Storage);
    }

    public static void ClearHighlightedShelves() {
        if (BetterSMT.Highlighting.Value == false)
            return;
        if (IsHighlightCacheUsed) {
            foreach (KeyValuePair<int, Transform> item in highlightObjectCache) {
                HighlightShelf(item.Value, false);
            }
            highlightObjectCache.Clear();
        } else {
            ClearHighlightShelvesByProduct(ShelfType.ProductDisplay);
            ClearHighlightShelvesByProduct(ShelfType.Storage);
        }
    }

    private static void ClearHighlightShelvesByProduct(ShelfType shelfType) {
        HighlightShelfTypeByProduct(-1, Color.white, shelfType);
    }

    private static void HighlightShelfTypeByProduct(int productID, Color shelfHighlightColor, ShelfType shelfType) {
        if (BetterSMT.Highlighting.Value == false)
            return;
        GameObject shelvesObject = GameObject.Find(GetGameObjectStringPath(shelfType));

        for (int i = 0; i < shelvesObject.transform.childCount; i++) {
            Transform shelf = shelvesObject.transform.GetChild(i);
            int[] productInfoArray = shelf.gameObject.GetComponent<Data_Container>().productInfoArray;
            int num = productInfoArray.Length / 2;
            bool enableShelfHighlight = false;

            for (int j = 0; j < num; j++) {
                bool enableSlotHighlight = productID >= 0 && productInfoArray[j * 2] == productID;
                if (enableSlotHighlight) {
                    enableShelfHighlight = true;

                    ShelfData shelfData = new(shelfType);
                    Transform highlightsMarker = shelf.Find(shelfData.highlightsName);

                    if (highlightsMarker != null) {
                        Transform specificHighlight = shelfType == ShelfType.Storage ? highlightsMarker.GetChild(j).GetChild(0) : highlightsMarker.GetChild(j);
                        HighlightShelf(specificHighlight, true, Color.yellow);
                    }
                }
            }

            HighlightShelf(shelf, enableShelfHighlight, shelfHighlightColor);
        }
    }

    public static string GetGameObjectStringPath(ShelfType shelfType) {
        return shelfType switch {
            ShelfType.ProductDisplay => "Level_SupermarketProps/Shelves",
            ShelfType.Storage => "Level_SupermarketProps/StorageShelves",
            _ => throw new NotImplementedException(),
        };
    }

    public static void HighlightShelf(Transform t, bool isEnableHighlight, Color? color = null) {
        if (BetterSMT.Highlighting.Value == false)
            return;
        HighlightEffect highlightEffect = t.GetComponent<HighlightEffect>() ?? t.gameObject.AddComponent<HighlightEffect>();

        if (IsHighlightCacheUsed) {
            if (isEnableHighlight == highlightEffect.highlighted) {
                return;
            }

            if (isEnableHighlight) {
                if (!highlightObjectCache.ContainsKey(t.GetInstanceID())) {
                    highlightObjectCache.Add(t.GetInstanceID(), t);
                }
            }

            MeshRenderer meshRender = t.GetComponent<MeshRenderer>();
            if (meshRender != null) {
                meshRender.allowOcclusionWhenDynamic = !isEnableHighlight;
            }
        }

        if (color != null) {
            highlightEffect.outlineColor = (Color)color;
        }
        highlightEffect.outlineQuality = HighlightPlus.QualityLevel.High;
        highlightEffect.outlineVisibility = Visibility.AlwaysOnTop;
        highlightEffect.outlineContourStyle = ContourStyle.AroundObjectShape;

        highlightEffect.outlineIndependent = true;
        highlightEffect.outline = isEnableHighlight ? 1f : 0f;
        highlightEffect.glow = isEnableHighlight ? 0f : 1f;

        highlightEffect.Refresh();
        highlightEffect.highlighted = isEnableHighlight;

        foreach (Transform child in t) {
            if (child.name.Contains("PriceLabel")) {
                HighlightEffect childHighlightEffect = child.GetComponent<HighlightEffect>() ?? child.gameObject.AddComponent<HighlightEffect>();

                if (color != null) {
                    childHighlightEffect.outlineColor = (Color)color;
                }
                childHighlightEffect.outlineQuality = HighlightPlus.QualityLevel.High;
                childHighlightEffect.outlineVisibility = Visibility.AlwaysOnTop;
                childHighlightEffect.outlineContourStyle = ContourStyle.AroundObjectShape;

                childHighlightEffect.outlineIndependent = true;
                childHighlightEffect.outline = isEnableHighlight ? 1f : 0f;
                childHighlightEffect.glow = isEnableHighlight ? 0f : 1f;

                childHighlightEffect.Refresh();
                childHighlightEffect.highlighted = isEnableHighlight;
            }
        }
    }


    public static void AddHighlightMarkersToStorage(Transform storage) {
        if (BetterSMT.Highlighting.Value == false)
            return;
        ShelfData shelfData = new(ShelfType.Storage);

        Transform highlightsMarker = storage.transform.Find(shelfData.highlightsName);

        if (highlightsMarker != null) {
            return;
        }

        highlightsMarker = UnityEngine.Object.Instantiate(storage.Find(shelfData.highlightsOriginalName).gameObject, storage).transform;
        highlightsMarker.name = shelfData.highlightsName;

        for (int i = 0; i < highlightsMarker.childCount; i++) {
            highlightsMarker.GetChild(i).gameObject.SetActive(true);

            Transform highlight = highlightsMarker.GetChild(i).GetChild(0);
            highlight.gameObject.SetActive(true);

            HighlightShelf(highlight, false, null);
        }
    }
}

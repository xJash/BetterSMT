using HarmonyLib;
using HighlightPlus;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(PlayerNetwork))]
public class PlayerNetworkPatch
{

    private static readonly Stopwatch stopwatch = new();
    private static PlayerNetwork pNetwork = null;
    private static UpgradesManager upgradesManager;

    [HarmonyPatch("PriceSetFromNumpad")]
    [HarmonyPrefix]
    private static bool PriceSetFromNumpadPrefix(PlayerNetwork __instance, int productID)
    {
        if (!BetterSMT.NumberKeys.Value)
        {
            return true;
        }

        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete))
        {
            if (__instance.basefloatString.Length != 0)
            {
                __instance.basefloatString = __instance.basefloatString[..^1];
                __instance.yourPriceTMP.text = "$" + __instance.basefloatString;
            }
            return false;
        }

        if (__instance.basefloatString.Length >= 7) return false;

        for (int i = 0; i <= 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i) || Input.GetKeyDown(KeyCode.Keypad0 + i))
            {
                if (__instance.basefloatString.Contains(","))
                {
                    string[] parts = __instance.basefloatString.Split(',');
                    if (parts.Length > 1 && parts[1].Length >= 2) return false;
                }

                __instance.basefloatString += i.ToString();
                __instance.yourPriceTMP.text = "$" + __instance.basefloatString;
                return false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Period) || Input.GetKeyDown(KeyCode.Comma) || Input.GetKeyDown(KeyCode.KeypadPeriod))
        {
            if (__instance.basefloatString.Length != 0 && !__instance.basefloatString.Contains(","))
            {
                __instance.basefloatString += ",";
                __instance.yourPriceTMP.text = "$" + __instance.basefloatString;
            }
            return false;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (__instance.basefloatString.Length != 0 &&
                !__instance.basefloatString.EndsWith(",") &&
                float.TryParse(__instance.basefloatString, out float result))
            {
                result = Mathf.Round(result * 100f) / 100f;
                if (ProductListing.Instance.productPlayerPricing[productID] != result)
                {
                    __instance.CmdPlayPricingSound();
                    __instance.pPrice = result;
                    ProductListing.Instance.CmdUpdateProductPrice(productID, __instance.pPrice);
                }
            }
            return false;
        }

        return true;
    }


    private static void HandleAutoSave()
    {
        if (BetterSMT.AutoSaveEnabled?.Value != true || !GameData.Instance.isServer)
        {
            return;
        }

        if (!stopwatch.IsRunning)
        {
            stopwatch.Start();
        }

        if (stopwatch.Elapsed.TotalSeconds <= BetterSMT.AutoSaveTimer?.Value)
        {
            return;
        }

        stopwatch.Restart();

        if (BetterSMT.AutoSaveDuringDay?.Value == true || !GameData.Instance.NetworkisSupermarketOpen)
        {
            _ = GameData.Instance.StartCoroutine(GameDataPatch.SaveGame());
        }
    }

    [HarmonyPatch("Update"), HarmonyPostfix]
    private static void UpdatePatch(PlayerNetwork __instance, ref float ___pPrice, TextMeshProUGUI ___marketPriceTMP, ref TextMeshProUGUI ___yourPriceTMP)
    {
        HandleAutoSave();
        #region Hotkeys
        if (!FsmVariables.GlobalVariables.GetFsmBool("InChat").Value == false)
        {
            return;
        }
        else
        {
            bool usedTool = false;
            (bool?, BepInEx.Configuration.KeyboardShortcut?, int)[] toolHotkeys = [
                (BetterSMT.SledgeToggle?.Value,      BetterSMT.SledgeHotkey?.Value,      7),
                (BetterSMT.OsMartToggle?.Value,      BetterSMT.OsMartHotkey?.Value,      6),
                (BetterSMT.TrayToggle?.Value,        BetterSMT.TrayHotkey?.Value,        9),
                (BetterSMT.SalesToggle?.Value,       BetterSMT.SalesHotkey?.Value,       10),
                (BetterSMT.PricingGunToggle?.Value,  BetterSMT.PricingGunHotkey?.Value,  2),
                (BetterSMT.BroomToggle?.Value,       BetterSMT.BroomHotkey?.Value,       3),
                (BetterSMT.LadderToggle?.Value,      BetterSMT.LadderHotkey?.Value,      8),
                (BetterSMT.DLCTabletToggle?.Value,   BetterSMT.DLCTabletHotkey?.Value,   5),
            ];

            foreach ((bool? toggle, BepInEx.Configuration.KeyboardShortcut? hotkey, int itemId) in toolHotkeys)
            {
                if (toggle == true && hotkey?.IsDown() == true)
                {
                    __instance.CmdChangeEquippedItem(itemId);
                    usedTool = true;
                    break;
                }
            }

            if (!usedTool && BetterSMT.EmptyHandsHotkey.Value.IsDown())
            {
                __instance.CmdChangeEquippedItem(0);
            }


            if (BetterSMT.ClockToggle?.Value == true && BetterSMT.ClockHotkey?.Value.IsDown() == true)
            {
                upgradesManager ??= UnityEngine.Object.FindObjectOfType<TimeAccelerationWatcher>()?.GetComponent<UpgradesManager>();
                upgradesManager.NetworkacceleratedTime = !upgradesManager.acceleratedTime;
                upgradesManager.GetComponent<TimeAccelerationWatcher>().enabled = upgradesManager.acceleratedTime;
                upgradesManager.RpcTimeAcceleration(upgradesManager.acceleratedTime);
            }


        }

        if (BetterSMT.ToggleDoublePrice.Value == true)
        {
            if (BetterSMT.doublePrice && ___marketPriceTMP != null)
            {
                if (float.TryParse(___marketPriceTMP.text[1..].Replace(',', '.'),
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out float market))
                {
                    ___pPrice = market * 2;

                    if (BetterSMT.roundDown.Value)
                    {
                        ___pPrice = BetterSMT.NearestTen.Value ? (float)(Math.Floor(___pPrice * 10) / 10) : (float)(Math.Floor(___pPrice * 20) / 20);
                    }

                    ___yourPriceTMP.text = "$" + ___pPrice;
                }
            }
        }
        #endregion
    }

    #region Highlighting
    [HarmonyPatch("ChangeEquipment"), HarmonyPostfix]
    private static void ChangeEquipmentPatch(int newEquippedItem)
    {
        if (newEquippedItem == 0)
        {
            ClearHighlightedShelves();
        }
    }
    public enum ShelfType
    {
        ProductDisplay,
        Storage
    }

    private struct ShelfData
    {
        public string highlightsName;
        public string highlightsOriginalName;
        public ShelfType shelfType;

        public ShelfData(ShelfType shelfType)
        {
            if (shelfType == ShelfType.ProductDisplay)
            {
                highlightsName = "Labels";
                highlightsOriginalName = "";
                this.shelfType = ShelfType.ProductDisplay;
            }
            else
            {
                highlightsName = "HighlightsMarker";
                highlightsOriginalName = "Highlights";
                this.shelfType = ShelfType.Storage;
            }
        }
    }

    private static readonly Dictionary<int, Transform> highlightObjectCache = [];

    public static bool IsHighlightCacheUsed { get; set; } = true;

    [HarmonyPatch("Start"), HarmonyPrefix]
    private static void StartPatch(PlayerNetwork __instance)
    {
        if (__instance.isLocalPlayer)
        {
            pNetwork = __instance;
        }
    }

    [HarmonyPatch("UpdateBoxContents"), HarmonyPostfix]
    private static void UpdateBoxContentsPatch(int productIndex)
    {
        HighlightShelvesByProduct(productIndex);
    }

    [HarmonyPatch(typeof(Data_Container), "BoxSpawner")]
    [HarmonyPostfix]
    private static void BoxSpawnerPatch(Data_Container __instance)
    {
        AddHighlightMarkersToStorage(__instance.transform);
    }

    [HarmonyPatch(typeof(NetworkSpawner), "UserCode_CmdSpawn__Int32__Vector3__Vector3")]
    [HarmonyPostfix]
    private static void NewBuildableConstructed(NetworkSpawner __instance, int prefabID)
    {
        if (BetterSMT.StorageHighlighting.Value == false)
        {
            return;
        }

        GameObject buildable = __instance.buildables[prefabID];

        if (buildable.name.Contains("StorageShelf"))
        {
            int index = buildable.GetComponent<Data_Container>().parentIndex;
            Transform buildableParent = __instance.levelPropsOBJ.transform.GetChild(index);
            GameObject lastStorageObject = buildableParent.GetChild(buildableParent.childCount - 1).gameObject;

            AddHighlightMarkersToStorage(lastStorageObject.transform);
        }
    }

    public static int GetProductFromRaycast()
    {
        if (BetterSMT.StorageHighlighting.Value == false)
        {
            return -1;
        }

        int productID = -1;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo3, 4f, pNetwork.interactableMask))
        {
            if (hitInfo3.transform.gameObject.name == "SubContainer")
            {
                int siblingIndex = hitInfo3.transform.GetSiblingIndex();
                if (!hitInfo3.transform?.parent?.transform?.parent)
                {
                    return productID;
                }

                Data_Container component = hitInfo3.transform.parent.transform.parent.GetComponent<Data_Container>();
                if (component != null && component.containerClass < 20)
                {
                    productID = component.productInfoArray[siblingIndex * 2];
                }
            }
        }
        else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 4f, pNetwork.lMask))
        {
            if (hitInfo.transform.gameObject.tag == "Interactable" && hitInfo.transform.GetComponent<BoxData>())
            {
                BoxData boxData = hitInfo.transform.GetComponent<BoxData>();
                if (boxData != null)
                {
                    productID = boxData.productID;
                }
            }
            else
            {
                int siblingIndex = hitInfo.transform.GetSiblingIndex();
                if (!hitInfo.transform?.parent?.transform?.parent)
                {
                    return productID;
                }

                Data_Container component = hitInfo.transform.parent.transform.parent.GetComponent<Data_Container>();
                if (component != null && component.containerClass == 69)
                {
                    int num = component.productInfoArray[siblingIndex * 2];
                    productID = num;
                }
            }
        }

        return productID;
    }

    public static void HighlightShelvesByProduct(int productID)
    {
        if (BetterSMT.StorageHighlighting.Value == false)
        {
            return;
        }

        HighlightShelfTypeByProduct(productID, Color.yellow, ShelfType.ProductDisplay);
        HighlightShelfTypeByProduct(productID, Color.red, ShelfType.Storage);
    }

    public static void ClearHighlightedShelves()
    {
        if (BetterSMT.StorageHighlighting.Value == false)
        {
            return;
        }

        if (IsHighlightCacheUsed)
        {
            foreach (KeyValuePair<int, Transform> item in highlightObjectCache)
            {
                HighlightShelf(item.Value, false);
            }
            highlightObjectCache.Clear();
        }
        else
        {
            ClearHighlightShelvesByProduct(ShelfType.ProductDisplay);
            ClearHighlightShelvesByProduct(ShelfType.Storage);
        }
    }

    private static void ClearHighlightShelvesByProduct(ShelfType shelfType)
    {
        HighlightShelfTypeByProduct(-1, Color.white, shelfType);
    }

    private static void HighlightShelfTypeByProduct(int productID, Color shelfHighlightColor, ShelfType shelfType)
    {
        if (BetterSMT.StorageHighlighting.Value == false)
        {
            return;
        }

        GameObject shelvesObject = GameObject.Find(GetGameObjectStringPath(shelfType));

        for (int i = 0; i < shelvesObject.transform.childCount; i++)
        {
            Transform shelf = shelvesObject.transform.GetChild(i);
            int[] productInfoArray = shelf.gameObject.GetComponent<Data_Container>().productInfoArray;
            int num = productInfoArray.Length / 2;
            bool enableShelfHighlight = false;

            for (int j = 0; j < num; j++)
            {
                bool enableSlotHighlight = productID >= 0 && productInfoArray[j * 2] == productID;
                if (enableSlotHighlight)
                {
                    enableShelfHighlight = true;

                    ShelfData shelfData = new(shelfType);
                    Transform highlightsMarker = shelf.Find(shelfData.highlightsName);

                    if (highlightsMarker != null)
                    {
                        Transform specificHighlight = shelfType == ShelfType.Storage ? highlightsMarker.GetChild(j).GetChild(0) : highlightsMarker.GetChild(j);
                        HighlightShelf(specificHighlight, true, Color.yellow);
                    }
                }
            }

            HighlightShelf(shelf, enableShelfHighlight, shelfHighlightColor);
        }
    }

    public static string GetGameObjectStringPath(ShelfType shelfType)
    {
        return shelfType switch
        {
            ShelfType.ProductDisplay => "Level_SupermarketProps/Shelves",
            ShelfType.Storage => "Level_SupermarketProps/StorageShelves",
            _ => throw new NotImplementedException(),
        };
    }

    public static void HighlightShelf(Transform t, bool isEnableHighlight, Color? color = null)
    {
        if (BetterSMT.StorageHighlighting.Value == false)
        {
            return;
        }

        HighlightEffect highlightEffect = t.GetComponent<HighlightEffect>() ?? t.gameObject.AddComponent<HighlightEffect>();

        if (IsHighlightCacheUsed)
        {
            if (isEnableHighlight == highlightEffect.highlighted)
            {
                return;
            }

            if (isEnableHighlight)
            {
                if (!highlightObjectCache.ContainsKey(t.GetInstanceID()))
                {
                    highlightObjectCache.Add(t.GetInstanceID(), t);
                }
            }

            MeshRenderer meshRender = t.GetComponent<MeshRenderer>();
            if (meshRender != null)
            {
                meshRender.allowOcclusionWhenDynamic = !isEnableHighlight;
            }
        }

        if (color != null)
        {
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

        foreach (Transform child in t)
        {
            if (child.name.Contains("PriceLabel"))
            {
                HighlightEffect childHighlightEffect = child.GetComponent<HighlightEffect>() ?? child.gameObject.AddComponent<HighlightEffect>();

                if (color != null)
                {
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


    public static void AddHighlightMarkersToStorage(Transform storage)
    {
        if (BetterSMT.StorageHighlighting.Value == false)
        {
            return;
        }

        ShelfData shelfData = new(ShelfType.Storage);

        Transform highlightsMarker = storage.transform.Find(shelfData.highlightsName);

        if (highlightsMarker != null)
        {
            return;
        }

        highlightsMarker = UnityEngine.Object.Instantiate(storage.Find(shelfData.highlightsOriginalName).gameObject, storage).transform;
        highlightsMarker.name = shelfData.highlightsName;

        for (int i = 0; i < highlightsMarker.childCount; i++)
        {
            highlightsMarker.GetChild(i).gameObject.SetActive(true);

            Transform highlight = highlightsMarker.GetChild(i).GetChild(0);
            highlight.gameObject.SetActive(true);

            HighlightShelf(highlight, false, null);
        }
    }
}
#endregion
using HarmonyLib;
using HutongGames.PlayMaker;
using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(PlayerNetwork))]
public class PlayerNetworkPatch {

    private static readonly Stopwatch stopwatch = new();
    private static UpgradesManager upgradesManager;

    [HarmonyPatch("PriceSetFromNumpad")]
    [HarmonyPrefix]
    private static bool PriceSetFromNumpadPrefix(PlayerNetwork __instance,int productID) {
        if(!BetterSMT.NumberKeys.Value) {
            return true;
        }

        if(Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete)) {
            if(__instance.basefloatString.Length != 0) {
                __instance.basefloatString = __instance.basefloatString[..^1];
                __instance.yourPriceTMP.text = "$" + __instance.basefloatString;
            }
            return false;
        }

        if(__instance.basefloatString.Length >= 7) {
            return false;
        }

        for(int i = 0; i <= 9; i++) {
            if(Input.GetKeyDown(KeyCode.Alpha0 + i) || Input.GetKeyDown(KeyCode.Keypad0 + i)) {
                if(__instance.basefloatString.Contains(",")) {
                    string[] parts = __instance.basefloatString.Split(',');
                    if(parts.Length > 1 && parts[1].Length >= 2) {
                        return false;
                    }
                }

                __instance.basefloatString += i.ToString();
                __instance.yourPriceTMP.text = "$" + __instance.basefloatString;
                return false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Period) || Input.GetKeyDown(KeyCode.Comma) || Input.GetKeyDown(KeyCode.KeypadPeriod)) {
            if(__instance.basefloatString.Length != 0 && !__instance.basefloatString.Contains(",")) {
                __instance.basefloatString += ",";
                __instance.yourPriceTMP.text = "$" + __instance.basefloatString;
            }
            return false;
        }

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
            if(__instance.basefloatString.Length != 0 &&
                !__instance.basefloatString.EndsWith(",") &&
                float.TryParse(__instance.basefloatString,out float result)) {
                result = Mathf.Round(result * 100f) / 100f;
                if(ProductListing.Instance.productPlayerPricing[productID] != result) {
                    __instance.CmdPlayPricingSound();
                    __instance.pPrice = result;
                    ProductListing.Instance.CmdUpdateProductPrice(productID,__instance.pPrice);
                }
            }
            return false;
        }

        return true;
    }

    [HarmonyPatch("Update"), HarmonyPostfix]
    private static void UpdatePatch(PlayerNetwork __instance,ref float ___pPrice,TextMeshProUGUI ___marketPriceTMP,ref TextMeshProUGUI ___yourPriceTMP) {
        #region Hotkeys
        if(!FsmVariables.GlobalVariables.GetFsmBool("InChat").Value == false) {
            return;
        } else {
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

            foreach((bool? toggle, BepInEx.Configuration.KeyboardShortcut? hotkey, int itemId) in toolHotkeys) {
                if(toggle == true && hotkey?.IsDown() == true) {
                    __instance.CmdChangeEquippedItem(itemId);
                    usedTool = true;
                    break;
                }
            }

            if(!usedTool && BetterSMT.EmptyHandsHotkey.Value.IsDown()) {
                __instance.CmdChangeEquippedItem(0);
            }


            if(BetterSMT.ClockToggle?.Value == true && BetterSMT.ClockHotkey?.Value.IsDown() == true) {
                upgradesManager ??= UnityEngine.Object.FindObjectOfType<TimeAccelerationWatcher>()?.GetComponent<UpgradesManager>();
                upgradesManager.NetworkacceleratedTime = !upgradesManager.acceleratedTime;
                upgradesManager.GetComponent<TimeAccelerationWatcher>().enabled = upgradesManager.acceleratedTime;
                upgradesManager.RpcTimeAcceleration(upgradesManager.acceleratedTime);
            }


        }

        if(BetterSMT.ToggleDoublePrice.Value == true) {
            if(BetterSMT.doublePrice && ___marketPriceTMP != null) {
                if(float.TryParse(___marketPriceTMP.text[1..].Replace(',','.'),
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out float market)) {
                    ___pPrice = market * 2;

                    if(BetterSMT.roundDown.Value) {
                        ___pPrice = BetterSMT.NearestTen.Value ? (float)(Math.Floor(___pPrice * 10) / 10) : (float)(Math.Floor(___pPrice * 20) / 20);
                    }

                    ___yourPriceTMP.text = "$" + ___pPrice;
                }
            }
        }
        #endregion
    }

    [HarmonyPatch("UpdateBoxContents"), HarmonyPostfix]
    private static void UpdateBoxContentsPatch(int productIndex) {
        int notificationHolder = 0;
        if(BetterSMT.StorageHighlighting.Value == true && notificationHolder == 0) {
            BetterSMT.CreateImportantNotification("Highlighting feature has been moved to SuperQoLity. Disable this message by disabling highlighting.");
            return;
        }
    }
}
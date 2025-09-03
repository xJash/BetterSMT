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

    private static void HandleAutoSave() {
        if(BetterSMT.AutoSaveEnabled?.Value != true || !GameData.Instance.isServer) {
            return;
        }

        if(!stopwatch.IsRunning) {
            stopwatch.Start();
        }

        if(stopwatch.Elapsed.TotalSeconds <= BetterSMT.AutoSaveTimer?.Value) {
            return;
        }

        stopwatch.Restart();

        if(BetterSMT.AutoSaveDuringDay?.Value == true || !GameData.Instance.NetworkisSupermarketOpen) {
            _ = GameData.Instance.StartCoroutine(GameDataPatch.SaveGame());
        }
    }

    [HarmonyPatch("PriceSetFromNumpad")]
    [HarmonyPrefix]
    private static bool PriceSetFromNumpadPrefix(PlayerNetwork __instance,int productID) {
        if(!BetterSMT.NumberKeys.Value && GameData.Instance.isServer) {
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
    private static void UpdatePatch(PlayerNetwork __instance) {
        HandleAutoSave();
        #region Hotkeys

        var globals = FsmVariables.GlobalVariables;
        if(globals.GetFsmBool("InChat").Value
            || globals.GetFsmBool("inEvent").Value
            || globals.GetFsmBool("inOptions").Value
            || globals.GetFsmBool("isBeingPushed").Value
            || globals.GetFsmBool("inCameraEvent").Value
            || globals.GetFsmBool("inVehicle").Value) {
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

        #endregion
    }

    [HarmonyPatch("UpdateBoxContents"), HarmonyPostfix]
    private static void UpdateBoxContentsPatch() {
        int notificationHolder = 0;
        if(BetterSMT.StorageHighlighting.Value == true && notificationHolder == 0) {
            BetterSMT.CreateImportantNotification("Highlighting feature has been moved to SuperQoLity. Disable this message by disabling highlighting.");
            return;
        }
    }
}
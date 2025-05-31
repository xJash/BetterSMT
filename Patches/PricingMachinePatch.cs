using HarmonyLib;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(PricingMachine))]
public static class PricingMachinePatch {

    [HarmonyPatch("NumpadSetPricing")]
    [HarmonyPrefix]
    public static bool NumpadSetPricingPrefix(PricingMachine __instance) {
        if (!BetterSMT.NumberKeys.Value) {
            return true;
        }

        // Backspace / Delete
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete)) {
            __instance.NumberDelete();
            return false;
        }

        // Number keys (0-9)
        for (int i = 0; i <= 9; i++) {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i) || Input.GetKeyDown(KeyCode.Keypad0 + i)) {
                __instance.NumberPricing(i);
                return false;
            }
        }

        // Period / Comma
        if (Input.GetKeyDown(KeyCode.Period) || Input.GetKeyDown(KeyCode.Comma) || Input.GetKeyDown(KeyCode.KeypadPeriod)) {
            __instance.NumberPeriod();
            return false;
        }

        // Enter keys
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
            __instance.NumberAccept();
            return false;
        }

        return true;
    }
}

using HarmonyLib;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(TimeAccelerationWatcher), nameof(TimeAccelerationWatcher.Update))]
public static class TimeAccelerationWatcherPatch {
    [HarmonyPrefix]
    public static bool UpdatePatch(TimeAccelerationWatcher __instance) {
        if (BetterSMT.ClockMorning.Value) {
            Debug.Log("click morning value true");
            if (__instance.EmployeesDoingNothing()) {
                Debug.Log("employees doing nothing");
                __instance.RestoreTimeSettings();
            }
            return false;
        }
        Debug.Log("running original code1");
        return true;
    }
}

using HarmonyLib;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(TimeAccelerationWatcher), nameof(TimeAccelerationWatcher.Update))]
public static class TimeAccelerationWatcherPatch
{
    [HarmonyPrefix]
    public static bool UpdatePatch(TimeAccelerationWatcher __instance)
    {
        if (BetterSMT.ClockMorning.Value)
        {
            if (__instance.EmployeesDoingNothing())
            {
                __instance.RestoreTimeSettings();
            }
            return false;
        }
        return true;
    }
}

using HarmonyLib;

namespace BetterSMT.Patches;
[HarmonyPatch(typeof(TutorialManager))]
internal static class TutorialManagerPatch {

    [HarmonyPatch("Update")]
    [HarmonyPrefix]
    private static bool Prefix(TutorialManager __instance) {
        if (BetterSMT.Tutorial.Value) {
            __instance.enabled = false;
            return false;
        }
        return true;
    }
}
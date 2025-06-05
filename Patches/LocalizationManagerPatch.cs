using HarmonyLib;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(LocalizationManager))]
internal class LocalizationHandler {
    [HarmonyPatch(nameof(LocalizationManager.GetLocalizationString))]
    [HarmonyPrefix]
    public static bool NoLocalization_Prefix(ref string key, ref string __result) {
        if (key[0] == '`') {
            __result = key[1..];
            return false;
        }
        return true;
    }
}
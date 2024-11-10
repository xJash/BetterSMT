using HarmonyLib;

namespace DoublePrices.Patches
{

    [HarmonyPatch(typeof(LocalizationManager))]
    internal class LocalizationHandler
    {
        [HarmonyPatch(nameof(LocalizationManager.GetLocalizationString))]
        [HarmonyPrefix]
        public static bool noLocalization_Prefix(ref string key, ref string __result)
        {
            if (key[0] == '`')
            {
                __result = key.Substring(1);
                return false;
            }
            return true;
        }
    }
}
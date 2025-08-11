using HarmonyLib;
using TMPro;

namespace BetterSMT.Patches
{
    [HarmonyPatch(typeof(TMP_Text), "text", MethodType.Setter)]
    public static class TMPTextPatch
    {
        private static void Prefix(ref string value)
        {
            if (BetterSMT.CurrencyTypeToAny.Value != "$" && !string.IsNullOrEmpty(value))
            {
                value = value.Replace('$', BetterSMT.CurrencyTypeToAny.Value[0]);
            }
            if (BetterSMT.ReplaceCommasWithPeriods.Value && !string.IsNullOrEmpty(value))
            {
                value = value.Replace(',', '.');
            }
        }
    }
}
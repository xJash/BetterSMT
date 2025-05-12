using HarmonyLib;
using TMPro;

namespace BetterSMT.Patches {
    [HarmonyPatch(typeof(TMP_Text), "text", MethodType.Setter)]
    public static class TMPTextPatch {
        static void Prefix(ref string value) {
            if (BetterSMT.ReplaceCommasWithPeriods.Value && !string.IsNullOrEmpty(value)) {
                value = value.Replace(',', '.');
            }

            if (BetterSMT.CurrencyTypeToAny.Value != "$" && !string.IsNullOrEmpty(value)) {
                value = value.Replace('$', BetterSMT.CurrencyTypeToAny.Value[0]);
            }
        }
    }
}

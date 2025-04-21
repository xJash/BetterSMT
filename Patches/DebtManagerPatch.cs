using HarmonyLib;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(DebtManager))]
public static class DebtManagerPatch {
    [HarmonyPostfix]
    [HarmonyPatch("OnStartClient")]
    private static void EnableAutoPay(DebtManager __instance) {
        if (BetterSMT.AutoPayInvoices.Value == true) {
            __instance.autopayInvoices = true;
        }
    }
}

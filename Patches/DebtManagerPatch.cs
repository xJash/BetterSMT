using HarmonyLib;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(DebtManager), "OnStartClient")]
public static class DebtManagerPatch {
    private static void Postfix(DebtManager __instance) {
        __instance.autopayInvoices = BetterSMT.AutoPayAllInvoices?.Value ?? false;
    }
}

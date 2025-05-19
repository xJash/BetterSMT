using HarmonyLib;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(DebtManager), nameof(DebtManager.OnStartClient))]
public static class DebtManagerPatch {
    private static void Postfix(DebtManager __instance) {
        if (__instance == null) {
            return;
        }

        __instance.autopayInvoices = BetterSMT.AutoPayAllInvoices?.Value ?? false;
    }
}

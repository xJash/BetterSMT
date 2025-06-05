using HarmonyLib;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(GameCanvas))]
internal class NotificationHandler {
    [HarmonyPatch("Update")]
    [HarmonyPostfix]
    public static void NotificationHandler_Postfix(GameCanvas __instance, ref bool ___inCooldown) {
        if (!BetterSMT.ToggleDoublePrice.Value || !BetterSMT.notify) return;

        ___inCooldown = false;
        BetterSMT.notify = false;

        string notification = "`";
        switch (BetterSMT.notificationType) {
            case "priceToggle":
                notification += $"Double Price: {(BetterSMT.doublePrice ? "ON" : "OFF")}";
                break;
            case "roundDownSwitch":
                notification += $"Rounding to nearest {(BetterSMT.NearestTen.Value ? "ten" : "five")}";
                if (!BetterSMT.roundDown.Value) {
                    notification += "\r\n(Currently disabled)";
                }
                break;
            case "roundDownToggle":
                notification += $"Rounding has been {(BetterSMT.roundDown.Value ? "enabled" : "disabled")}";
                break;
            default:
                return;
        }

        __instance.CreateCanvasNotification(notification);
    }
}
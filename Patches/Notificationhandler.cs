using HarmonyLib;

namespace BetterSMT.Patches;


[HarmonyPatch(typeof(GameCanvas))]
internal class NotificationHandler
{
    [HarmonyPatch("Update")]
    [HarmonyPostfix]
    public static void NotificationHandler_Postfix(GameCanvas __instance, ref bool ___inCooldown)
    {
        if (BetterSMT.notify)
        {
            ___inCooldown = false;
            BetterSMT.notify = false;
            string Notification = "`";
            switch (BetterSMT.notificationType)
            {
                case "priceToggle":
                    Notification += "Double Price: " + (BetterSMT.doublePrice ? "ON" : "OFF");
                    break;
                case "roundDownSwitch":
                    Notification += "Rounding to nearest " + (BetterSMT.NearestTen.Value ? "ten" : "five") + (!BetterSMT.roundDown.Value ? "\r\n(Currently disabled)" : "");
                    break;
                case "roundDownToggle":
                    Notification += "Rounding has been " + (BetterSMT.roundDown.Value ? "enabled" : "disabled");
                    break;
                default:
                    break;
            }
            __instance.CreateCanvasNotification(Notification);
        }
    }
}
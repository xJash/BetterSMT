using HarmonyLib;
using StarterAssets;
using System;
using System.Globalization;
using TMPro;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(GameCanvas))]
internal class NotificationHandler {
    public static bool doublePrice = true;
    public static bool notify = false;
    public static string notificationType;

    [HarmonyPatch("Update"), HarmonyPostfix]
    public static void NotificationHandler_Postfix(ref bool ___inCooldown) {
        if(!BetterSMT.ToggleDoublePrice.Value) {
            return;
        }

        string notification = null;

        PlayerNetwork player = FirstPersonController.Instance?.GetComponent<PlayerNetwork>();
        if(player == null) {
            return;
        }

        float pPrice = player.pPrice;
        TextMeshProUGUI marketPriceTMP = player.marketPriceTMP;
        TextMeshProUGUI yourPriceTMP = player.yourPriceTMP;

        if(BetterSMT.DoublePrice.Value.IsDown()) {
            doublePrice = !doublePrice;
            notification = $"Double Price: {(doublePrice ? "ON" : "OFF")}";
        } else if(BetterSMT.RoundDownSwitch.Value.IsDown()) {
            BetterSMT.NearestTen.Value = !BetterSMT.NearestTen.Value;
            BetterSMT.NearestFive.Value = !BetterSMT.NearestFive.Value;

            notification = $"Rounding to nearest {(BetterSMT.NearestTen.Value ? "ten" : "five")}";
            if(!BetterSMT.RoundDown.Value) {
                notification += "\r\n(Currently disabled)";
            }
        } else if(BetterSMT.RoundDownToggle.Value.IsDown()) {
            BetterSMT.RoundDown.Value = !BetterSMT.RoundDown.Value;
            notification = $"Rounding has been {(BetterSMT.RoundDown.Value ? "enabled" : "disabled")}";
        }

        if(BetterSMT.NearestFive.Value && BetterSMT.NearestTen.Value) {
            BetterSMT.NearestTen.Value = false;
        }

        if(doublePrice && marketPriceTMP != null) {
            if(float.TryParse(
                marketPriceTMP.text[1..].Replace(',','.'),
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out float market
            )) {
                pPrice = market * 2f;

                if(BetterSMT.RoundDown.Value) {
                    pPrice = BetterSMT.NearestTen.Value
                        ? (float)(Math.Floor(pPrice * 10) / 10)
                        : (float)(Math.Floor(pPrice * 20) / 20);
                }

                yourPriceTMP.text = "$" + pPrice;
            }
        }

        player.pPrice = pPrice;
        player.yourPriceTMP = yourPriceTMP;
        player.marketPriceTMP = marketPriceTMP;

        if(!string.IsNullOrEmpty(notification)) {
            ___inCooldown = false;
            BetterSMT.CreateImportantNotification(notification);
        }
    }
}

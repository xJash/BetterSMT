using HarmonyLib;
using System;
using TMPro;

namespace BetterSMT.Patches
{

    [HarmonyPatch(typeof(PlayerNetwork))]
    internal class DoublePrice
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        public static void doublePrice_Postfix(ref float ___pPrice, TextMeshProUGUI ___marketPriceTMP, ref TextMeshProUGUI ___yourPriceTMP)
        {
            if (BetterSMT.doublePrice && ___marketPriceTMP != null)
            {
                float market;
                if (float.TryParse(___marketPriceTMP.text.Substring(1).Replace(',', '.'),
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out market))
                {
                    ___pPrice = market * 2;

                    if (BetterSMT.roundDown.Value)
                        if (BetterSMT.NearestTen.Value)
                            ___pPrice = (float)(Math.Floor(___pPrice * 10) / 10);
                        else
                            ___pPrice = (float)(Math.Floor(___pPrice * 20) / 20);

                    ___yourPriceTMP.text = "$" + ___pPrice;
                }
            }
        }
    }
}
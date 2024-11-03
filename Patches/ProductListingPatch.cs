using HarmonyLib;
using System.Linq;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(ProductListing))]
public class ProductListingPatch
{
    [HarmonyPatch("ConvertFloatToTextPrice"), HarmonyPostfix]
    static void ConvertFloatToTextPricePatch(ref string __result)
    {
        __result = BetterSMT.ReplaceCommas(__result);
    }
}
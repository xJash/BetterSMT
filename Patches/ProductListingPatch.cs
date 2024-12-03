using HarmonyLib;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(ProductListing))]
public class ProductListingPatch
{
    [HarmonyPatch("ConvertFloatToTextPrice"), HarmonyPostfix]
    private static void ConvertFloatToTextPricePatch(ref string __result)
    {
        __result = BetterSMT.ReplaceCommas(__result);
    }
}
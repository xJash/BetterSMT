using HarmonyLib;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch]
public class AutoProductPatch {

    private static bool _hasPatched = false;

    [HarmonyPostfix]
    [HarmonyPatch(typeof(ProductListing), "OnStartClient")]
    public static void Postfix(ProductListing __instance) {
        if (_hasPatched)
            return;

        _hasPatched = true;

        foreach (GameObject prefab in __instance.productPrefabs) {
            Data_Product data = prefab.GetComponent<Data_Product>();
            if (data != null) {
                data.maxItemsPerBox *= BetterSMT.MaxBoxSize.Value;
            }
        }
    }
}

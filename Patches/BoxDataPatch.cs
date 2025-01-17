using HarmonyLib;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(BoxData))]
public static class BoxDataPatch {
    public static int InitialLayer = -1;

    [HarmonyPostfix]
    [HarmonyPatch(nameof(BoxData.OnStartClient))]
    public static void OnStartClientPostfix(BoxData __instance) {
        if (BetterSMT.BoxCollision.Value == true) {
            if (__instance == null || __instance.gameObject == null) {
                return;
            }

            if (InitialLayer == -1) {
                InitialLayer = __instance.gameObject.layer;
            }

            __instance.gameObject.layer = 20;
            Physics.IgnoreLayerCollision(20, 20, true);
        }
    }
}

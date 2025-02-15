using HarmonyLib;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(BoxData))]
public static class BoxDataPatch {
    private static int _initialLayer = -1;

    [HarmonyPostfix]
    [HarmonyPatch(nameof(BoxData.OnStartClient))]
    public static void OnStartClientPostfix(BoxData __instance) {
        if (!BetterSMT.BoxCollision.Value || __instance?.gameObject == null) {
            return;
        }

        ApplyCollisionChanges(__instance.gameObject);
    }

    private static void ApplyCollisionChanges(GameObject boxObject) {
        if (_initialLayer == -1) {
            _initialLayer = boxObject.layer;
        }

        boxObject.layer = 20;
        Physics.IgnoreLayerCollision(20, 20, true);
    }
}
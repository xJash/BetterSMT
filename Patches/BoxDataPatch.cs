using HarmonyLib;
using UnityEngine;

namespace BetterSMT.Patches;

// Handles disabling box collisions when the client starts
[HarmonyPatch(typeof(BoxData))]
public static class BoxDataPatch {
    private static int _initialLayer = -1;

    // Runs after BoxData.OnStartClient
    [HarmonyPostfix]
    [HarmonyPatch(nameof(BoxData.OnStartClient))]
    public static void OnStartClientPostfix(BoxData __instance) {
        if (BetterSMT.DisableBoxCollisions?.Value != true || __instance?.gameObject == null) {
            return;
        }

        ApplyCollisionChanges(__instance.gameObject);
    }

    // Moves box to a special layer and disables collisions with other boxes
    private static void ApplyCollisionChanges(GameObject boxObject) {
        _initialLayer = (_initialLayer == -1) ? boxObject.layer : _initialLayer;

        boxObject.layer = 20;
        Physics.IgnoreLayerCollision(20, 20, true);
    }
}
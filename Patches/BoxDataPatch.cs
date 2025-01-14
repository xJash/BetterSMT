using HarmonyLib;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(BoxData))]
public static class BoxDataPatch
{   
    public static bool DisableBoxCollisions;
    public static int InitialLayer = -1;
    [HarmonyPatch(nameof(BoxData.SetBoxData))]
    [HarmonyPostfix]
    public static void SetBoxData(BoxData __instance)
    {
        if (BetterSMT.DisableBoxCollision.Value == true) {
            if (InitialLayer == -1) {
                InitialLayer = __instance.gameObject.layer;
            }
            __instance.gameObject.layer = 20;
            Physics.IgnoreLayerCollision(20, 20);
        }
    }
}
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(SurveillanceDesk))]
public static class SurveillanceDeskPatch {

    private static readonly Dictionary<GameObject, float> progressByCustomer = [];

    // Patch SurveillanceDesk.Update *Prefix* to fully control behavior
    [HarmonyPrefix]
    [HarmonyPatch("Update")]
    public static bool UpdatePrefix(SurveillanceDesk __instance) {
        if (BetterSMT.OneClickCheckMark.Value) {
            if (__instance.currentCustomerOBJ != null && __instance.MainPlayer.GetButton("Main Action")) {
                NPC_Info npc = __instance.currentCustomerOBJ.GetComponent<NPC_Info>();
                if (npc != null && !npc.surveillanceChecked) {
                    npc.surveillanceChecked = true;
                    npc.CmdSurveillanceSet();
                    __instance.surveillanceFinishAudioSource.Play();
                    __instance.Create3DTickObject(__instance.currentCustomerOBJ.transform);
                    __instance.currentCustomerOBJ = null;
                }
            }
            return false; // skip original Update entirely
        }

        // Otherwise run original Update method normally
        return true;
    }
}

using HarmonyLib;
using System.Collections;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(DemolishableManager))]
public class Patch_DemolishableManager {

    [HarmonyPrefix]
    [HarmonyPatch("UserCode_CmdDemolishItem__Int32__Int32")]
    static bool Prefix_CmdDemolishItem(DemolishableManager __instance, int parentIndex, int whichObjectToDemolish) {
        if (parentIndex >= __instance.demolishableParentRootOBJ.transform.childCount ||
            parentIndex >= __instance.demolishableValues.Length ||
            whichObjectToDemolish >= __instance.demolishableParentRootOBJ.transform.GetChild(parentIndex).childCount) {
            return false;
        }

        float defaultCost = __instance.demolishingCosts[parentIndex];
        float cost = BetterSMT.PillarPrice.Value != defaultCost ? BetterSMT.PillarPrice.Value : defaultCost;



        if (cost > GameData.Instance.gameFunds)
            return false;

        __instance.GetComponent<GameData>().AlterFundsFromEmployee(-cost);
        __instance.GetComponent<GameData>().otherCosts += cost;

        string value = __instance.demolishableValues[parentIndex];
        if (!string.IsNullOrEmpty(value) && value[whichObjectToDemolish] != '0')
            return false;

        __instance.demolishableValues[parentIndex] =
            Traverse.Create(__instance).Method("AssembleValue", parentIndex, whichObjectToDemolish).GetValue<string>();

        if (!BetterSMT.PillarRubble.Value) {
            __instance.StartCoroutine((IEnumerator)AccessTools.Method(__instance.GetType(), "DelayedDemolishEffectInstantiation")
                .Invoke(__instance, new object[] { parentIndex, whichObjectToDemolish }));
        }

        __instance.RpcDemolishItem(parentIndex, whichObjectToDemolish);
        return false; 
    }
}

using HarmonyLib;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace BetterSMT.Patches {
    [HarmonyPatch]
    public class Patch_DemolishableManager {
        private static MethodBase TargetMethod() {
            return AccessTools.Method(
                typeof(DemolishableManager),
                "UserCode_CmdDemolishItem__Int32__Int32",
                [typeof(int),typeof(int)]
            );
        }

        private static bool Prefix(DemolishableManager __instance,int parentIndex,int whichObjectToDemolish) {
            var root = __instance.demolishableParentRootOBJ.transform;

            if(parentIndex >= root.childCount || parentIndex >= __instance.demolishableValues.Length || parentIndex >= __instance.demolishingCosts.Length)
                return false;

            var parentObj = root.GetChild(parentIndex).gameObject;
            if(whichObjectToDemolish >= parentObj.transform.childCount)
                return false;

            float defaultCost = __instance.demolishingCosts[parentIndex];
            float cost = !Mathf.Approximately(BetterSMT.PillarPrice.Value,defaultCost)
                ? BetterSMT.PillarPrice.Value
                : defaultCost;

            if(cost > GameData.Instance.gameFunds)
                return false;

            var gameData = __instance.GetComponent<GameData>();
            gameData.AlterFundsFromEmployee(-cost);
            gameData.otherCosts += cost;

            string demolishValue = __instance.demolishableValues[parentIndex];
            if(!string.IsNullOrEmpty(demolishValue)) {
                char slot = demolishValue[whichObjectToDemolish];
                if(slot != __instance.nullValue[0])
                    return false;
            }

            __instance.demolishableValues[parentIndex] = __instance.AssembleValue(parentIndex,whichObjectToDemolish);

            if(!BetterSMT.PillarRubble.Value) {
                var delayedMethod = AccessTools.Method(__instance.GetType(),"DelayedDemolishEffectInstantiation");
                var enumerator = (IEnumerator)delayedMethod.Invoke(__instance,[parentIndex,whichObjectToDemolish]);
                _ = __instance.StartCoroutine(enumerator);
            }

            __instance.RpcDemolishItem(parentIndex,whichObjectToDemolish);

            return false; 
        }
    }
}

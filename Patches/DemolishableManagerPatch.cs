using HarmonyLib;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace BetterSMT.Patches
{
    [HarmonyPatch]
    public class Patch_DemolishableManager
    {
        static MethodBase TargetMethod()
        {
            return AccessTools.Method(typeof(DemolishableManager), "UserCode_CmdDemolishItem__Int32__Int32", new[] { typeof(int), typeof(int) });
        }

        static bool Prefix(DemolishableManager __instance, int parentIndex, int whichObjectToDemolish)
        {
            if (parentIndex >= __instance.demolishableParentRootOBJ.transform.childCount || parentIndex >= __instance.demolishableValues.Length)
                return false;

            GameObject gameObject = __instance.demolishableParentRootOBJ.transform.GetChild(parentIndex).gameObject;
            if (whichObjectToDemolish >= gameObject.transform.childCount || parentIndex >= __instance.demolishingCosts.Length)
                return false;

            float defaultCost = __instance.demolishingCosts[parentIndex];
            float num = BetterSMT.PillarPrice.Value != defaultCost ? BetterSMT.PillarPrice.Value : defaultCost;
            if (num > GameData.Instance.gameFunds) return false;

            __instance.GetComponent<GameData>().AlterFundsFromEmployee(0f - num);
            __instance.GetComponent<GameData>().otherCosts += num;

            string text = __instance.demolishableValues[parentIndex];
            if (text != "")
            {
                char num2 = text[whichObjectToDemolish];
                char c = __instance.nullValue[0];
                if (num2 != c)
                    return false;
            }

            __instance.demolishableValues[parentIndex] = __instance.AssembleValue(parentIndex, whichObjectToDemolish);
            Debug.Log("__instance.demolishableValues[parentIndex]" + __instance.demolishableValues[parentIndex]);
            if (!BetterSMT.PillarRubble.Value)
            {
                __instance.StartCoroutine((IEnumerator)AccessTools.Method(__instance.GetType(), "DelayedDemolishEffectInstantiation")
                    .Invoke(__instance, new object[] { parentIndex, whichObjectToDemolish }));
            }
            __instance.RpcDemolishItem(parentIndex, whichObjectToDemolish);

            return false;
        }
    }
}
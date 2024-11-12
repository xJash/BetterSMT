using HarmonyLib;
using Mirror;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(NPC_Info))]
public class NPC_InfoPatch
{
    [HarmonyPatch("PlaceProducts"), HarmonyPrefix]
    static void PlaceProductsPatch(NPC_Info __instance)
    {
        __instance.productItemPlaceWait = BetterSMT.FasterCheckout.Value ? 0f : 0.5f;
    }

    [HarmonyPatch("AuxiliarAnimationPlay"), HarmonyPrefix]
    static bool AuxiliarAnimationPlayPatch(NPC_Info __instance, ref int animationIndex)
    {
        if (!BetterSMT.OneHitThief.Value) return true;

        if (!__instance.beingPushed)
        {
            __instance.StartCoroutine(__instance.StopSpeed());
        }
        if (__instance.isAThief && __instance.productsIDCarrying.Count > 0)
        {
            int count = __instance.productsIDCarrying.Count;
            for (int i = 0; i < count; i++)
            {
                GameObject obj = Object.Instantiate(__instance.stolenProductPrefab, NPC_Manager.Instance.droppedProductsParentOBJ.transform);
                obj.transform.position = __instance.transform.position + new Vector3(Random.Range(-0.4f, 0.4f), 0f, Random.Range(-0.4f, 0.4f));
                obj.GetComponent<StolenProductSpawn>().NetworkproductID = __instance.productsIDCarrying[0];
                obj.GetComponent<StolenProductSpawn>().NetworkproductCarryingPrice = __instance.productsCarryingPrice[0] * 0.8f;
                NetworkServer.Spawn(obj);
                __instance.productsIDCarrying.RemoveAt(0);
                __instance.productsCarryingPrice.RemoveAt(0);
            }
        }
        if (__instance.isAThief && __instance.productsIDCarrying.Count == 0 && (bool)__instance.transform.Find("ThiefCanvas").gameObject && __instance.transform.Find("ThiefCanvas").gameObject.activeSelf)
        {
            __instance.RpcHideThief();
        }
        int num = Random.Range(0, 9);
        __instance.RpcAnimationPlay(animationIndex);
        __instance.RPCNotificationAboveHead("NPCmessagehit" + num, "");

        return false;
    }
}
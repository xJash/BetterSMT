using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BetterSMT.Patches;
[HarmonyPatch(typeof(NPC_Manager))]
public class NPC_ManagerPatch {


    [HarmonyPatch("ConvertBystanderToCustomer"), HarmonyPrefix]
    public static bool ConvertBystanderToCustomerPatch(GameObject npcOBJ,NPC_Manager __instance) {
        NPC_Info component = npcOBJ.GetComponent<NPC_Info>();
        if(Random.value > BetterSMT.FireExtinguisher.Value) {
            component.RPCNotificationAboveHead("bystndrcnvrt1","");
            component.surveillanceChecked = true;
            return false;
        }
        AchievementsManager.Instance.CmdAddAchievementPoint(23,1);
        _ = __instance.spawnPointsOBJ.transform.GetChild(Random.Range(0,__instance.spawnPointsOBJ.transform.childCount - 1)).transform.position;
        npcOBJ.transform.SetParent(__instance.customersnpcParentOBJ.transform);
        component.NetworkNPCID = Random.Range(0,__instance.NPCsArray.Length - 1);
        component.NetworkisCustomer = true;
        component.productItemPlaceWait = Mathf.Clamp(0.5f - (float)GameData.Instance.gameDay * 0.003f,0.1f,0.5f);
        component.productsIDToBuy = __instance.GenerateCompensatedList(component.NPCID);
        component.productsIDToBuy.Sort();
        if((double)Random.value < 0.5) {
            component.productsIDToBuy.Reverse();
        }
        NavMeshAgent component2 = npcOBJ.GetComponent<NavMeshAgent>();
        __instance.SetAgentData(component2);
        Vector3 position = __instance.shelvesOBJ.transform.GetChild(Random.Range(0,__instance.shelvesOBJ.transform.childCount)).Find("Standspot").transform.position;
        component2.destination = position;
        component.state = 0;
        __instance.SetAgentData(component2);
        component.RPCNotificationAboveHead("bystndrcnvrt","");
        return false;
    }

    [HarmonyPatch("GetAvailableSelfCheckout"), HarmonyPostfix]
    private static void GetAvailableSelfCheckoutPatch(NPC_Info npcInfo,NPC_Manager __instance) {
        _ = SelfCheckoutPatch(npcInfo,__instance);
    }

    public static int SelfCheckoutPatch(NPC_Info npcInfo,NPC_Manager __instance) {
        if(npcInfo.productsIDCarrying.Count > 18 + __instance.selfcheckoutExtraProductsFromPerk || npcInfo.productsIDCarrying.Count == 0) {
            return -1;
        }
        float time = Mathf.Clamp((18 + __instance.selfcheckoutExtraProductsFromPerk) / npcInfo.productsIDCarrying.Count,0f,1f);
        if(__instance.selfcheckoutChanceCurve.Evaluate(time) < Random.value) {
            for(int i = 0; i < __instance.selfCheckoutOBJ.transform.childCount; i++) {
                if(!__instance.selfCheckoutOBJ.transform.GetChild(i).GetComponent<Data_Container>().checkoutQueue[0]) {
                    if(BetterSMT.SelfCheckoutTheft.Value == false) {
                        if(npcInfo.productsIDCarrying.Count > 6 && Random.value < 0.02f + (GameData.Instance.difficulty * 0.005f)) {
                            int index = Random.Range(0,npcInfo.productsIDCarrying.Count);
                            npcInfo.productsIDCarrying.RemoveAt(index);
                            npcInfo.productsCarryingPrice.RemoveAt(index);
                        }
                    }
                    return i;
                }
            }
        }
        return -1;
    }
}

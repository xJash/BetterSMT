using HarmonyLib;
using UnityEngine;

namespace BetterSMT.Patches;
[HarmonyPatch(typeof(NPC_Manager))]
public class NPC_ManagerPatch {
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

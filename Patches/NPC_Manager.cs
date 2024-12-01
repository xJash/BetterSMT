using HarmonyLib;
using UnityEngine;
using UnityEngine.AI;

namespace BetterSMT.Patches
{
    [HarmonyPatch(typeof(NPC_Manager))]
    public class NPC_ManagerPatch
    {
        [HarmonyPatch("GetAvailableSelfCheckout"), HarmonyPostfix]
        static void GetAvailableSelfCheckoutPatch(NPC_Info npcInfo, NPC_Manager __instance)
        {
            SelfCheckoutPatch(npcInfo, __instance);
        }

        [HarmonyPatch("SpawnEmployee"), HarmonyPostfix]
        static void SetNPCRadiusPatch(NPC_Manager __instance)
        {
            DisableCollisions((__instance));
        }

        public static int SelfCheckoutPatch(NPC_Info npcInfo, NPC_Manager __instance)
        {
            if (npcInfo.productsIDCarrying.Count > BetterSMT.SelfCheckoutLimit.Value)
            {
                return -1;
            }
            if (npcInfo.productsIDCarrying.Count == 0)
            {
                return -1;
            }

            float time = Mathf.Clamp((float)(18 / npcInfo.productsIDCarrying.Count), 0f, 1f);

            for (int i = 0; i < __instance.selfCheckoutOBJ.transform.childCount; i++)
            {
                var station = __instance.selfCheckoutOBJ.transform.GetChild(i);

                var dataContainer = station.GetComponent<Data_Container>();
                if (dataContainer.checkoutQueue[0])
                {
                    continue;
                }

                if (BetterSMT.SelfCheckoutTheft.Value)
                {
                    if (npcInfo.productsIDCarrying.Count > 6 && UnityEngine.Random.value < 0.02f + (float)GameData.Instance.difficulty * 0.005f)
                    {
                        int index = UnityEngine.Random.Range(0, npcInfo.productsIDCarrying.Count);
                        npcInfo.productsIDCarrying.RemoveAt(index);
                        npcInfo.productsCarryingPrice.RemoveAt(index);
                    }
                }
                return i;
            }
            return -1;
        }

        internal static void DisableCollisions(NPC_Manager __instance)
        {
            if (BetterSMT.EmployeesPerPerk.Value >= 1)
            {
                foreach (NavMeshAgent agent in __instance.employeeParentOBJ.GetComponentsInChildren<NavMeshAgent>())
                {
                    agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
                }
            }
        }
    }
}

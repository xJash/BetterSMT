using HarmonyLib;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace BetterSMT.Patches {
    [HarmonyPatch(typeof(EmployeesDataGeneration))]
    public class EmployeesDataGenerationPatch {
        [HarmonyPatch("GenerateTodayEmployeesData"), HarmonyPrefix]
        private static bool GenerateTodayEmployeesDataPatch(EmployeesDataGeneration __instance) {
            if(BetterSMT.EmployeesLevel.Value!=0) {
                EmployeeLevelPatch(__instance);
                return false;
            } else {
                return true;
            }
        }

        public static void EmployeeLevelPatch(EmployeesDataGeneration __instance) {
            int num = Random.Range(0,5);
            int num2 = Random.Range(5,10);

            for(int i = 0; i < 10; i++) {
                int num3 = Random.Range(0,7);

                int[] stats = new int[7]; 

                if(i == num) {
                    for(int j = 0; j < stats.Length; j++)
                        stats[j] = Random.Range(j % 2 == 0 ? 6 : 7,11);
                } else if(i == num2) {
                    for(int j = 0; j < stats.Length; j++)
                        stats[j] = Random.Range(j % 2 == 0 ? 5 : 4,11);
                } else {
                    for(int j = 0; j < stats.Length; j++)
                        stats[j] = Random.Range(1,11);
                }

                if(BetterSMT.EmployeesLevel.Value != 0) {
                    for(int j = 0; j < stats.Length; j++)
                        stats[j] = BetterSMT.EmployeesLevel.Value;
                }

                int value = ((stats[0] + stats[1] + stats[2] + stats[3]) * Random.Range(3,6))
                            + (Random.Range(-2,3) * 10);

                value = Mathf.Clamp(value,30,1000);

                string text = num3 + "|" + value + "|" + string.Join("|",stats);

                __instance.managerComponent.todaysEmployeesData[i] = text;
                __instance.managerComponent.UpdateTodayEmployeesOnClients(i,text);
            }
        }

    }
}

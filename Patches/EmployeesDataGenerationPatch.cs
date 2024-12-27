using HarmonyLib;
using UnityEngine;

namespace BetterSMT.Patches {
    [HarmonyPatch(typeof(EmployeesDataGeneration))]
    public class EmployeesDataGenerationPatch {
        [HarmonyPatch("GenerateTodayEmployeesData"), HarmonyPostfix]
        private static void GenerateTodayEmployeesDataPatch(EmployeesDataGeneration __instance) {
            EmployeeLevelPatch(__instance);
        }

        public static void EmployeeLevelPatch(EmployeesDataGeneration __instance) {
            int num = Random.Range(0, 5);
            int num2 = Random.Range(5, 10);
            for (int i = 0; i < 10; i++) {
                int num3 = Random.Range(0, 7);
                int num4;
                int num5;
                int num6;
                int num7;
                if (i == num) {
                    num4 = Random.Range(6, 11);
                    num5 = Random.Range(7, 11);
                    num6 = Random.Range(6, 11);
                    num7 = Random.Range(7, 11);
                } else if (i == num2) {
                    num4 = Random.Range(5, 11);
                    num5 = Random.Range(4, 11);
                    num6 = Random.Range(5, 11);
                    num7 = Random.Range(4, 11);
                } else {
                    num4 = Random.Range(1, 11);
                    num5 = Random.Range(1, 11);
                    num6 = Random.Range(1, 11);
                    num7 = Random.Range(1, 11);
                }
                if (BetterSMT.EmployeesEnabled.Value == true) {
                    num4 = BetterSMT.EmployeesLevel.Value;
                    num5 = BetterSMT.EmployeesLevel.Value;
                    num6 = BetterSMT.EmployeesLevel.Value;
                    num7 = BetterSMT.EmployeesLevel.Value;
                }
                int value = ((num4 + num5 + num6 + num7) * Random.Range(3, 6)) + (Random.Range(-2, 3) * 10);
                value = Mathf.Clamp(value, 30, 1000);
                string text = num3 + "|" + value + "|" + num4 + "|" + num5 + "|" + num6 + "|" + num7;
                __instance.managerComponent.todaysEmployeesData[i] = text;
                __instance.managerComponent.UpdateTodayEmployeesOnClients(i, text);
            }
        }
    }
}

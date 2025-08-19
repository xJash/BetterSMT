using HarmonyLib;
using System.Collections;
using UnityEngine;

namespace BetterSMT.Patches
{
    [HarmonyPatch(typeof(AntiTheftBehaviour))]
    public static class AntiTheftBehaviourPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(AntiTheftBehaviour.AlarmBehaviour))]
        public static bool AlarmBehaviourPrefix(AntiTheftBehaviour __instance, ref IEnumerator __result)
        {
            __result = CustomAlarmBehaviour(__instance);
            return false;
        }

        private static IEnumerator CustomAlarmBehaviour(AntiTheftBehaviour __instance)
        {
            __instance.alarmIsPlaying = true;
            int iterations = 0;
            bool set = true;

            while (iterations < 20)
            {
                if (set)
                {
                    __instance.lightOBJ1.GetComponent<MeshRenderer>().material = __instance.lightOn;
                    __instance.lightOBJ2.GetComponent<MeshRenderer>().material = __instance.lightOn;
                }
                else
                {
                    __instance.lightOBJ1.GetComponent<MeshRenderer>().material = __instance.lightOff;
                    __instance.lightOBJ2.GetComponent<MeshRenderer>().material = __instance.lightOff;
                }

                yield return new WaitForSeconds(0.25f);
                iterations++;
                set = !set;
                if (BetterSMT.ShoplifterDetectionNotif.Value)
                {
                    BetterSMT.CreateImportantNotification("Shoplifted Detected!");
                }
            }

            yield return null;
            __instance.alarmIsPlaying = false;
        }
    }
}

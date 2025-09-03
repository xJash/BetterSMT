using HarmonyLib;
using System.Collections;
using UnityEngine;

namespace BetterSMT.Patches {
    [HarmonyPatch(typeof(AntiTheftBehaviour))]
    public static class AntiTheftBehaviourPatch {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(AntiTheftBehaviour.AlarmBehaviour))]
        public static bool AlarmBehaviourPrefix(AntiTheftBehaviour __instance,ref IEnumerator __result) {
            if(BetterSMT.ShoplifterDetectionNotif?.Value == true) {
                __result = CustomAlarmBehaviour(__instance);
                return false; 
            }
            return true; 
        }

        private static IEnumerator CustomAlarmBehaviour(AntiTheftBehaviour __instance) {
            __instance.alarmIsPlaying = true;

            var rend1 = __instance.lightOBJ1.GetComponent<MeshRenderer>();
            var rend2 = __instance.lightOBJ2.GetComponent<MeshRenderer>();

            bool set = true;

            BetterSMT.CreateImportantNotification("Shoplifter Detected!");

            for(int i = 0; i < 20; i++) {
                rend1.material = set ? __instance.lightOn : __instance.lightOff;
                rend2.material = set ? __instance.lightOn : __instance.lightOff;

                yield return new WaitForSeconds(0.25f);
                set = !set;
            }

            __instance.alarmIsPlaying = false;
        }
    }
}

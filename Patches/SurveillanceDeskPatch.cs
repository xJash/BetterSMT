using HarmonyLib;
using UnityEngine;

namespace BetterSMT.Patches
{
    [HarmonyPatch(typeof(SurveillanceDesk))]
    public static class SurveillanceDeskPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Update")]
        public static bool UpdatePrefix(SurveillanceDesk __instance)
        {
            if (BetterSMT.OneClickCheckMark.Value)
            {
                if (!__instance.nSpawner || !__instance.inASecurityCamera)
                {
                    return false;
                }

                if (__instance.MainPlayer.GetButtonDown("Build"))
                {
                    if (!__instance.inputBool)
                    {
                        __instance.inputBool = true;
                        __instance.GetNextCamera(nextCamera: true);
                    }
                }
                else if (__instance.MainPlayer.GetButtonDown("Drop Item"))
                {
                    if (!__instance.inputBool)
                    {
                        __instance.inputBool = true;
                        __instance.GetNextCamera(nextCamera: false);
                    }
                }
                else
                {
                    __instance.inputBool = false;
                }

                if (__instance.viewpointOBJ)
                {
                    __instance.x += __instance.MainPlayer.GetAxis("MoveH") * __instance.baseXSpeed * 6f * 0.02f;
                    __instance.y -= __instance.MainPlayer.GetAxis("MoveV") * __instance.baseYSpeed * 6f * 0.02f;
                    __instance.y = SurveillanceDesk.ClampAngle(__instance.y, __instance.yMinLimit, __instance.yMaxLimit);
                    __instance.x = SurveillanceDesk.ClampAngle(__instance.x, __instance.xMinLimit, __instance.xMaxLimit);
                    __instance.viewpointOBJ.transform.localRotation = Quaternion.Euler(__instance.y, __instance.x, 0f);
                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, 100f, __instance.lMask)
                    && hitInfo.transform.gameObject.CompareTag("Interactable")
                    && hitInfo.transform.parent
                    && hitInfo.transform.parent.GetComponent<NPC_Info>()
                    && __instance.MainPlayer.GetButtonDown("Main Action"))
                {
                    NPC_Info npc = hitInfo.transform.parent.GetComponent<NPC_Info>();

                    if (!hitInfo.transform.parent.Find("3DTick") && npc.isCustomer)
                    {
                        npc.surveillanceChecked = true;
                        npc.CmdSurveillanceSet();
                        __instance.surveillanceFinishAudioSource.Play();
                        __instance.Create3DTickObject(hitInfo.transform.parent);
                        GameCanvas.Instance.CreateCanvasNotification("surveillance1");
                    }
                }

                __instance.currentCustomerOBJ = null;
                __instance.spawnedCylinderOBJ.transform.position = new Vector3(0f, -10f, 0f);
                __instance.cylinderFillOBJ.transform.localScale = new Vector3(1f, 0f, 1f);

                return false;
            }

            return true;
        }
    }
}

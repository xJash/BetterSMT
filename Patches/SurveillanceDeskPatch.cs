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
                    Quaternion localRotation = Quaternion.Euler(__instance.y, __instance.x, 0f);
                    __instance.viewpointOBJ.transform.localRotation = localRotation;
                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 100f, __instance.lMask)
                    && hitInfo.transform.gameObject.CompareTag("Interactable")
                    && hitInfo.transform.parent
                    && hitInfo.transform.parent.GetComponent<NPC_Info>()
                    && __instance.MainPlayer.GetButton("Main Action"))
                {
                    NPC_Info component = hitInfo.transform.parent.GetComponent<NPC_Info>();
                    if (!hitInfo.transform.parent.Find("3DTick") && component.isCustomer)
                    {
                        if (component.surveillanceChecked)
                        {
                            GameCanvas.Instance.CreateCanvasNotification("surveillance1");
                            if (!hitInfo.transform.parent.Find("3DTick"))
                            {
                                __instance.Create3DTickObject(hitInfo.transform.parent);
                            }
                        }
                        else if (__instance.currentCustomerOBJ && hitInfo.transform.parent.gameObject == __instance.currentCustomerOBJ)
                        {
                            float num = Vector3.Distance(__instance.currentCustomerOBJ.transform.position, Camera.main.transform.position);
                            float num2;
                            if (true)
                            {
                                float t = 1f / (num - 4f);
                                num2 = Mathf.Lerp(__instance.fillMinAmountPerClick, __instance.fillMaxAmountPerClick, t);
                            }

                            __instance.currentFillScale += num2 * Time.deltaTime * 3f;
                            float pitch = 1f + num2 / 10f;
                            __instance.clickBeepAudioSource.pitch = pitch;
                            __instance.clickBeepAudioSource.Play();
                        }
                        else if (!__instance.MainPlayer.GetButtonPrev("Main Action") || !__instance.currentCustomerOBJ)
                        {
                            __instance.currentCustomerOBJ = hitInfo.transform.parent.gameObject;
                            __instance.currentFillScale = 0f;
                        }
                    }
                }

                if (__instance.currentCustomerOBJ)
                {
                    __instance.spawnedCylinderOBJ.transform.position = __instance.currentCustomerOBJ.transform.position;
                    if (__instance.currentFillScale > 0.99f)
                    {
                        __instance.cylinderFillOBJ.transform.localScale = new Vector3(1f, 1f, 1f);
                        __instance.currentCustomerOBJ.GetComponent<NPC_Info>().surveillanceChecked = true;
                        __instance.currentCustomerOBJ.GetComponent<NPC_Info>().CmdSurveillanceSet();
                        __instance.surveillanceFinishAudioSource.Play();
                        __instance.Create3DTickObject(__instance.currentCustomerOBJ.transform);
                        __instance.currentCustomerOBJ = null;
                    }
                    else
                    {
                        __instance.currentFillScale -= __instance.unfillAmount * Time.deltaTime;
                        __instance.currentFillScale = Mathf.Clamp(__instance.currentFillScale, 0f, 1f);
                        __instance.cylinderFillOBJ.transform.localScale = new Vector3(1f, __instance.currentFillScale, 1f);
                    }
                }
                else
                {
                    __instance.spawnedCylinderOBJ.transform.position = new Vector3(0f, -10f, 0f);
                    __instance.cylinderFillOBJ.transform.localScale = new Vector3(1f, 0f, 1f);
                }

                return false;
            }

            return true;
        }
    }
}

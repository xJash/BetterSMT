using HarmonyLib;
using HighlightPlus;
using Mirror;
using System.Reflection;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(Builder_Main))]
public class Builder_MainPatch {

    [HarmonyPatch("DeleteBehaviour"), HarmonyPrefix]
    private static bool DeleteBehaviourPatch(Builder_Main __instance) {
        return DeleteWheneverPatch(__instance);
    }

    public static bool DeleteWheneverPatch(Builder_Main __instance) {
        // Handle movable objects
        _ = HandleMovableObjects(__instance);

        // Handle decorations
        _ = HandleDecorations(__instance);

        return false;
    }

    private static bool HandleMovableObjects(Builder_Main __instance) {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 4f, __instance.lMask)) {
            if (hitInfo.transform.gameObject.CompareTag("Movable")) {
                if (__instance.oldHitOBJ2 != null && hitInfo.transform.gameObject != __instance.oldHitOBJ2 && __instance.hEffect2 != null) {
                    __instance.hEffect2.highlighted = false;
                }

                __instance.hEffect2 = hitInfo.transform.GetComponent<HighlightEffect>();
                if (__instance.hEffect2 != null) {
                    __instance.hEffect2.highlighted = true;
                } else {
                    Debug.LogWarning("HighlightEffect not found on Movable object!");
                }

                if (__instance.MainPlayer.GetButtonDown("Build") || __instance.MainPlayer.GetButtonDown("Main Action") || __instance.MainPlayer.GetButtonDown("Secondary Action")) {
                    if (!BetterSMT.AlwaysDeleteMode.Value) {
                        if (GameData.Instance.isSupermarketOpen) {
                            GameCanvas.Instance.CreateCanvasNotification("message15");
                            return false;
                        }

                        if (NPC_Manager.Instance.customersnpcParentOBJ.transform.childCount > 0) {
                            GameCanvas.Instance.CreateCanvasNotification("message16");
                            return false;
                        }
                    }

                    if (__instance.FurnitureContainsProduct(hitInfo.transform) && !__instance.MainPlayer.GetButton("Drop Item")) {
                        GameCanvas.Instance.CreateCanvasNotification("message17a");
                        return false;
                    }

                    if (hitInfo.transform.GetComponent<Data_Container>() != null) {
                        int containerID = hitInfo.transform.GetComponent<Data_Container>().containerID;
                        if (!BetterSMT.DeleteOnlyCheckout.Value) {
                            if ((containerID == 6 || containerID == 7) && GameData.Instance.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(2).transform.childCount == 1) {
                                GameCanvas.Instance.CreateCanvasNotification("checkoutwarning");
                                return false;
                            }
                        }
                    }

                    if (hitInfo.transform.GetComponent<NetworkIdentity>() != null) {
                        float num = hitInfo.transform.GetComponent<Data_Container>().cost * 0.9f;

                        if (__instance.MainPlayer.GetButton("Drop Item")) {
                            try {
                                MethodInfo calculateShelfProductCostMethod = typeof(Builder_Main).GetMethod(
                                    "CalculateShelfProductCost",
                                    BindingFlags.NonPublic | BindingFlags.Instance
                                );
                                if (calculateShelfProductCostMethod != null) {
                                    num += (float)calculateShelfProductCostMethod.Invoke(__instance, [hitInfo.transform]);
                                }
                            } catch (System.Exception ex) {
                                Debug.LogError($"Reflection error: {ex.Message}");
                            }
                        }

                        GameData.Instance.CmdAlterFundsWithoutExperience(num);
                        GameData.Instance.GetComponent<NetworkSpawner>().CmdDestroyBox(hitInfo.transform.gameObject);
                    }
                }

                __instance.oldHitOBJ2 = hitInfo.transform.gameObject;
                return true;
            } else if (__instance.hEffect2 != null) {
                __instance.hEffect2.highlighted = false;
            }
        } else if (__instance.hEffect2 != null) {
            __instance.hEffect2.highlighted = false;
        }

        return false;
    }

    private static bool HandleDecorations(Builder_Main __instance) {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo2, 4f, __instance.lMask)) {
            if (hitInfo2.transform.gameObject.CompareTag("Decoration")) {
                if (__instance.oldHitOBJ != null && hitInfo2.transform.gameObject != __instance.oldHitOBJ && __instance.hEffect != null) {
                    __instance.hEffect.enabled = false;
                }

                HighlightEffect highlightEffect = hitInfo2.transform.Find("Mesh")?.GetComponent<HighlightEffect>();
                if (highlightEffect != null) {
                    __instance.hEffect = highlightEffect;
                    __instance.hEffect.enabled = true;
                } else {
                    Debug.LogWarning("HighlightEffect not found on Decoration!");
                }

                if ((__instance.MainPlayer.GetButtonDown("Build") || __instance.MainPlayer.GetButtonDown("Main Action") || __instance.MainPlayer.GetButtonDown("Secondary Action")) && hitInfo2.transform.GetComponent<NetworkIdentity>() != null) {
                    float fundsToAdd = hitInfo2.transform.GetComponent<BuildableInfo>().cost * 0.9f;
                    GameData.Instance.CmdAlterFundsWithoutExperience(fundsToAdd);
                    GameData.Instance.GetComponent<NetworkSpawner>().CmdDestroyBox(hitInfo2.transform.gameObject);
                }

                __instance.oldHitOBJ = hitInfo2.transform.gameObject;
                return true;
            } else if (__instance.hEffect != null) {
                __instance.hEffect.enabled = false;
            }
        } else if (__instance.hEffect != null) {
            __instance.hEffect.enabled = false;
        }

        return false;
    }
}

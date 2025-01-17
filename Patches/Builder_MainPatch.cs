using HarmonyLib;
using HighlightPlus;
using Mirror;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(Builder_Main))]
public class Builder_MainPatch {

    [HarmonyPatch("DeleteBehaviour"), HarmonyPrefix]
    private static bool DeleteBehaviourPatch(Builder_Main __instance) {
        return DeleteWheneverPatch(__instance);
    }

    public static bool DeleteWheneverPatch(Builder_Main __instance) {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 4f, __instance.lMask)) {
            if (hitInfo.transform.gameObject.CompareTag("Movable")) {
                if ((bool)__instance.oldHitOBJ2 && hitInfo.transform.gameObject != __instance.oldHitOBJ2 && (bool)__instance.hEffect2) {
                    __instance.hEffect2.highlighted = false;
                }
                __instance.hEffect2 = hitInfo.transform.GetComponent<HighlightEffect>();
                __instance.hEffect2.highlighted = true;
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
                    if (BetterSMT.DeleteProduct.Value == false) {
                        if (__instance.FurnitureContainsProduct(hitInfo.transform)) {
                            GameCanvas.Instance.CreateCanvasNotification("message17");
                            return false;
                        }
                    }
                    if (BetterSMT.DeleteOnlyCheckout.Value == false) {
                        if ((bool)hitInfo.transform.GetComponent<Data_Container>()) {
                            int containerID = hitInfo.transform.GetComponent<Data_Container>().containerID;
                            if ((containerID == 6 || containerID == 7) && GameData.Instance.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(2).transform.childCount == 1) {
                                GameCanvas.Instance.CreateCanvasNotification("checkoutwarning");
                                return false;
                            }
                        }
                    }
                    if ((bool)hitInfo.transform.GetComponent<NetworkIdentity>()) {
                        float fundsToAdd = hitInfo.transform.GetComponent<Data_Container>().cost * 0.9f;
                        GameData.Instance.CmdAlterFundsWithoutExperience(fundsToAdd);
                        GameData.Instance.GetComponent<NetworkSpawner>().CmdDestroyBox(hitInfo.transform.gameObject);
                    }
                }
                __instance.oldHitOBJ2 = hitInfo.transform.gameObject;
            } else if ((bool)__instance.hEffect2) {
                __instance.hEffect2.highlighted = false;
            }

            return false;
        } else if ((bool)__instance.hEffect2) {
            __instance.hEffect2.highlighted = false;
            return false;
        }
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo2, 4f, __instance.lMask)) {
            if (hitInfo2.transform.gameObject.CompareTag("Decoration")) {
                if ((bool)__instance.oldHitOBJ && hitInfo2.transform.gameObject != __instance.oldHitOBJ && (bool)__instance.hEffect) {
                    __instance.hEffect.enabled = false;
                }
                __instance.hEffect = hitInfo2.transform.Find("Mesh").GetComponent<HighlightEffect>();
                __instance.hEffect.enabled = true;
                if ((__instance.MainPlayer.GetButtonDown("Build") || __instance.MainPlayer.GetButtonDown("Main Action") || __instance.MainPlayer.GetButtonDown("Secondary Action")) && (bool)hitInfo2.transform.GetComponent<NetworkIdentity>()) {
                    float fundsToAdd2 = hitInfo2.transform.GetComponent<BuildableInfo>().cost * 0.9f;
                    GameData.Instance.CmdAlterFundsWithoutExperience(fundsToAdd2);
                    GameData.Instance.GetComponent<NetworkSpawner>().CmdDestroyBox(hitInfo2.transform.gameObject);
                }
                __instance.oldHitOBJ = hitInfo2.transform.gameObject;
            } else if ((bool)__instance.hEffect) {
                __instance.hEffect.enabled = false;
            }
            return false;
        } else if ((bool)__instance.hEffect) {
            __instance.hEffect.enabled = false;
            return false;
        }
        return true;
    }
}

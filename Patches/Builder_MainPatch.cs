using HarmonyLib;
using HighlightPlus;
using HutongGames.PlayMaker.Actions;
using Mirror;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(Builder_Main), "WorkingDayControl")]
public class Builder_MainPatch { 

    [HarmonyPatch("DeleteBehaviour"), HarmonyPostfix]
    static void DeleteBehaviourPatch(Builder_Main __instance) {
        DeleteWheneverPatch((__instance));
    }

    public static void DeleteWheneverPatch(Builder_Main __instance)
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 4f, __instance.lMask))
        {
            if (raycastHit.transform.gameObject.CompareTag("Movable"))
            {
                if (__instance.oldHitOBJ2 && raycastHit.transform.gameObject != __instance.oldHitOBJ2 && __instance.hEffect2)
                {
                    __instance.hEffect2.highlighted = false;
                }
                __instance.hEffect2 = raycastHit.transform.GetComponent<HighlightEffect>();
                __instance.hEffect2.highlighted = true;
                if (__instance.MainPlayer.GetButtonDown("Build") || __instance.MainPlayer.GetButtonDown("Main Action") || __instance.MainPlayer.GetButtonDown("Secondary Action"))
                {
                    if (BetterSMT.AlwaysDeleteMode.Value == false)
                    {
                        if (GameData.Instance.isSupermarketOpen)
                        {
                            GameCanvas.Instance.CreateCanvasNotification("message15");
                            return;
                        }
                        if (NPC_Manager.Instance.customersnpcParentOBJ.transform.childCount > 0)
                        {
                            GameCanvas.Instance.CreateCanvasNotification("message16");
                            return;
                        }
                    }
                    if (BetterSMT.DeleteProduct.Value == false)
                    {
                        if (__instance.FurnitureContainsProduct(raycastHit.transform))
                        {
                            GameCanvas.Instance.CreateCanvasNotification("message17");
                            return;
                        }
                    }
                    if (raycastHit.transform.GetComponent<Data_Container>())
                    {
                        int containerID = raycastHit.transform.GetComponent<Data_Container>().containerID;
                        if ((containerID == 6 || containerID == 7) && GameData.Instance.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(2).transform.childCount == 1)
                        {
                            GameCanvas.Instance.CreateCanvasNotification("checkoutwarning");
                            return;
                        }
                    }
                    if (raycastHit.transform.GetComponent<NetworkIdentity>())
                    {
                        float fundsToAdd = (float)raycastHit.transform.GetComponent<Data_Container>().cost * 0.9f;
                        GameData.Instance.CmdAlterFundsWithoutExperience(fundsToAdd);
                        GameData.Instance.GetComponent<NetworkSpawner>().CmdDestroyBox(raycastHit.transform.gameObject);
                    }
                }
                __instance.oldHitOBJ2 = raycastHit.transform.gameObject;
            }
            else if (__instance.hEffect2)
            {
                __instance.hEffect2.highlighted = false;
            }
        }
        else if (__instance.hEffect2)
        {
            __instance.hEffect2.highlighted = false;
        }
    }
}
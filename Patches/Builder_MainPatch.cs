using HarmonyLib;
using HighlightPlus;
using Mirror;
using System.Reflection;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(Builder_Main))]
public class Builder_MainPatch
{
    [HarmonyPatch(typeof(Builder_Main), "RetrieveInitialBehaviours")]
    [HarmonyPriority(Priority.High)]
    [HarmonyPostfix]
    public static void ProductStackingWaitEndOfIEnumerable()
    {
        if (BetterSMT.ProductStacking.Value == true)
        {
            foreach (GameObject prodPrefab in ProductListing.Instance.productPrefabs)
            {
                if (prodPrefab == null || !prodPrefab.TryGetComponent(out Data_Product dataProduct))
                {
                    continue;
                }

                dataProduct.isStackable = true;
            }
        }
    }

    [HarmonyPatch("DeleteBehaviour"), HarmonyPrefix]
    public static bool DeleteWheneverPatch(Builder_Main __instance)
    {
        _ = HandleMovableObjects(__instance);
        _ = HandleDecorations(__instance);
        return false;
    }

    [HarmonyPatch(typeof(Builder_Main), "DecorationBehaviour")]
    [HarmonyPrefix]
    public static bool DecorationBehaviourPatch(Builder_Main __instance)
    {
        if (BetterSMT.CheatPlacement.Value)
        {
            // Full bypass mode
            __instance.inCorrectBounds = true;   // Ignore bounds restrictions
            __instance.overlapping = false;      // Ignore overlap restrictions
            __instance.raycastIsCorrect = true;  // Ignore raycast restrictions
            __instance.canPlace = true;          // Always allow placement

            if (__instance.dummyOBJ.TryGetComponent<HighlightEffect>(out HighlightEffect highlight))
            {
                highlight.glowHQColor = Color.green;
            }
        }
        else if (BetterSMT.AllowFreePlacement.Value)
        {
            // Ignore overlap but still require bounds + raycast checks
            __instance.inCorrectBounds = __instance.InCorrectBounds();
            __instance.overlapping = false;
            __instance.raycastIsCorrect = __instance.RaycastCheck();
            __instance.canPlace = __instance.inCorrectBounds && __instance.raycastIsCorrect;

            if (__instance.dummyOBJ.TryGetComponent<HighlightEffect>(out HighlightEffect highlight))
            {
                highlight.glowHQColor = __instance.canPlace ? Color.green : Color.red;
            }
        }
        else
        {
            // Normal placement rules
            __instance.inCorrectBounds = __instance.InCorrectBounds();
            __instance.overlapping = __instance.pmakerFSM.FsmVariables.GetFsmBool("Overlapping").Value;
            __instance.raycastIsCorrect = __instance.RaycastCheck();

            if (__instance.MainPlayer.GetButton("Drop Item") && __instance.currentTabIndex == 8)
            {
                __instance.overlapping = false;
            }

            if (__instance.inCorrectBounds && !__instance.overlapping && __instance.raycastIsCorrect && !__instance.canPlace)
            {
                __instance.canPlace = true;
                if (__instance.dummyOBJ.TryGetComponent<HighlightEffect>(out HighlightEffect highlight))
                {
                    highlight.glowHQColor = Color.green;
                }
            }

            if ((!__instance.inCorrectBounds || __instance.overlapping || !__instance.raycastIsCorrect) && __instance.canPlace)
            {
                __instance.canPlace = false;
                if (__instance.dummyOBJ.TryGetComponent<HighlightEffect>(out HighlightEffect highlight))
                {
                    highlight.glowHQColor = Color.red;
                }
            }
        }

        // Build button handling
        if (__instance.MainPlayer.GetButtonDown("Build") && __instance.canPlace)
        {
            if (__instance.currentElementIndex == 0)
            {
                if (!__instance.currentMovedOBJ.GetComponent<MiniTransportBehaviour>())
                {
                    GameData.Instance.GetComponent<NetworkSpawner>().GetMoveData(
                        __instance.currentMovedOBJ,
                        __instance.dummyOBJ.transform.position,
                        __instance.dummyOBJ.transform.rotation.eulerAngles
                    );
                }
                __instance.currentMovedOBJ = null;
                __instance.recentlyMoved = true;
                if (__instance.dummyOBJ)
                {
                    Object.Destroy(__instance.dummyOBJ);
                }
            }
            else
            {
                if (__instance.currentTabIndex == 4 && !GameData.Instance.removeLightsLimit && __instance.GetLightsCounter() >= 240)
                {
                    GameCanvas.Instance.CreateCanvasNotification("lghtlimit00");
                    return false;
                }

                if (!BetterSMT.CheatPlacement.Value && GameData.Instance.gameFunds < __instance.decorationCost)
                {
                    GameCanvas.Instance.CreateCanvasNotification("message6");
                }
                else
                {
                    if (!BetterSMT.CheatPlacement.Value)
                    {
                        GameData.Instance.CmdAlterFunds(0f - __instance.decorationCost);
                    }

                    GameData.Instance.GetComponent<NetworkSpawner>().CmdSpawnDecoration(
                        __instance.currentPropIndex,
                        __instance.dummyOBJ.transform.position,
                        __instance.dummyOBJ.transform.rotation.eulerAngles
                    );

                    if (__instance.currentTabIndex == 4 && !GameData.Instance.removeLightsLimit)
                    {
                        __instance.StartCoroutine(__instance.DelayedSetLightsInfo());
                    }
                }
            }
        }

        __instance.SharedBehaviour();
        return false;
    }

    [HarmonyPatch(typeof(Builder_Main), "BuildableBehaviour")]
    [HarmonyPrefix]
    public static bool BuildableBehaviourPatch(Builder_Main __instance)
    {
        if (BetterSMT.CheatPlacement.Value)
        {
            // Default correctSector check (only matters if not cheating)
            __instance.correctSector = __instance.CheckCorrectGround();
            // Full bypass mode
            __instance.correctSector = true;   // Ignore category ground restrictions
            __instance.overlapping = false;    // Ignore overlap restrictions
            __instance.canPlace = true;        // Always allow placement

            if (__instance.dummyOBJ.TryGetComponent<HighlightEffect>(out HighlightEffect highlight))
            {
                highlight.glowHQColor = Color.green;
            }
        }
        else if (BetterSMT.AllowFreePlacement.Value)
        {

            // Default correctSector check (only matters if not cheating)
            __instance.correctSector = __instance.CheckCorrectGround();

            // Ignore overlap but still require correct sector
            __instance.overlapping = false;
            __instance.canPlace = __instance.correctSector;

            if (__instance.dummyOBJ.TryGetComponent<HighlightEffect>(out HighlightEffect highlight))
            {
                highlight.glowHQColor = __instance.canPlace ? Color.green : Color.red;
            }
        }
        else
        {
            // Normal placement rules
            __instance.overlapping = __instance.pmakerFSM.FsmVariables.GetFsmBool("Overlapping").Value;

            if (__instance.correctSector && !__instance.overlapping && !__instance.canPlace)
            {
                __instance.canPlace = true;
                if (__instance.dummyOBJ.TryGetComponent<HighlightEffect>(out HighlightEffect highlight))
                {
                    highlight.glowHQColor = Color.green;
                }
            }

            if ((!__instance.correctSector || __instance.overlapping) && __instance.canPlace)
            {
                __instance.canPlace = false;
                if (__instance.dummyOBJ.TryGetComponent<HighlightEffect>(out HighlightEffect highlight))
                {
                    highlight.glowHQColor = Color.red;
                }
            }
        }

        // Build button handling
        if (__instance.MainPlayer.GetButtonDown("Build") && __instance.canPlace)
        {
            if (__instance.currentElementIndex == 0)
            {
                // Moving an object
                if ((bool)__instance.currentMovedOBJ?.GetComponent<NetworkIdentity>())
                {
                    GameData.Instance.GetComponent<NetworkSpawner>().GetMoveData(
                        __instance.currentMovedOBJ,
                        __instance.dummyOBJ.transform.position,
                        __instance.dummyOBJ.transform.rotation.eulerAngles
                    );
                    __instance.currentMovedOBJ.GetComponent<Data_Container>().RemoveMoveEffect();
                    __instance.currentMovedOBJ = null;
                    __instance.recentlyMoved = true;
                    if (__instance.dummyOBJ)
                    {
                        Object.Destroy(__instance.dummyOBJ);
                    }
                }
            }
            else if (!BetterSMT.CheatPlacement.Value && !BetterSMT.AllowFreePlacement.Value &&
                     GameData.Instance.gameFunds < __instance.buildableCost)
            {
                GameCanvas.Instance.CreateCanvasNotification("message6");
            }
            else
            {
                // Spawn new object
                GameData.Instance.GetComponent<NetworkSpawner>().CmdSpawn(
                    __instance.currentPropIndex,
                    __instance.dummyOBJ.transform.position,
                    __instance.dummyOBJ.transform.rotation.eulerAngles
                );
            }
        }

        __instance.SharedBehaviour();
        return false;
    }

    private static bool HandleMovableObjects(Builder_Main __instance)
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 4f, __instance.lMask))
        {
            if (hitInfo.transform.gameObject.CompareTag("Movable"))
            {
                if (__instance.oldHitOBJ2 != null && hitInfo.transform.gameObject != __instance.oldHitOBJ2 && __instance.hEffect2 != null)
                {
                    __instance.hEffect2.highlighted = false;
                }

                __instance.hEffect2 = hitInfo.transform.GetComponent<HighlightEffect>();
                if (__instance.hEffect2 != null)
                {
                    __instance.hEffect2.highlighted = true;
                }
                else
                {
                    Debug.LogWarning("HighlightEffect not found on Movable object!");
                }

                // Handles actual deletion logic
                if (__instance.MainPlayer.GetButtonDown("Build") || __instance.MainPlayer.GetButtonDown("Main Action") || __instance.MainPlayer.GetButtonDown("Secondary Action"))
                {
                    if (!BetterSMT.AlwaysAbleToDeleteMode.Value)
                    {
                        if (GameData.Instance.isSupermarketOpen)
                        {
                            GameCanvas.Instance.CreateCanvasNotification("message15");
                            return false;
                        }

                        if (NPC_Manager.Instance.customersnpcParentOBJ.transform.childCount > 0)
                        {
                            GameCanvas.Instance.CreateCanvasNotification("message16");
                            return false;
                        }
                    }

                    if (__instance.FurnitureContainsProduct(hitInfo.transform) && !__instance.MainPlayer.GetButton("Drop Item"))
                    {
                        GameCanvas.Instance.CreateCanvasNotification("message17a");
                        return false;
                    }

                    if (hitInfo.transform.GetComponent<Data_Container>() != null)
                    {
                        int containerID = hitInfo.transform.GetComponent<Data_Container>().containerID;
                        if (!BetterSMT.DeleteAllCheckouts.Value)
                        {
                            if ((containerID == 6 || containerID == 7) && GameData.Instance.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(2).transform.childCount == 1)
                            {
                                GameCanvas.Instance.CreateCanvasNotification("checkoutwarning");
                                return false;
                            }
                        }
                    }

                    if (hitInfo.transform.GetComponent<NetworkIdentity>() != null)
                    {
                        float num = hitInfo.transform.GetComponent<Data_Container>().cost * (BetterSMT.FullDeletionRefund.Value ? 1f : 0.9f);

                        if (__instance.MainPlayer.GetButton("Drop Item"))
                        {
                            try
                            {
                                MethodInfo calculateShelfProductCostMethod = typeof(Builder_Main).GetMethod(
                                    "CalculateShelfProductCost",
                                    BindingFlags.NonPublic | BindingFlags.Instance
                                );
                                if (calculateShelfProductCostMethod != null)
                                {
                                    num += (float)calculateShelfProductCostMethod.Invoke(__instance, [hitInfo.transform]);
                                }
                            }
                            catch (System.Exception ex)
                            {
                                Debug.LogError($"Reflection error: {ex.Message}");
                            }
                        }

                        GameData.Instance.CmdAlterFundsWithoutExperience(num);
                        GameData.Instance.GetComponent<NetworkSpawner>().CmdDestroyBox(hitInfo.transform.gameObject);
                    }
                }

                __instance.oldHitOBJ2 = hitInfo.transform.gameObject;
                return true;
            }
            else if (__instance.hEffect2 != null)
            {
                __instance.hEffect2.highlighted = false;
            }
        }
        else if (__instance.hEffect2 != null)
        {
            __instance.hEffect2.highlighted = false;
        }

        return false;
    }

    private static bool HandleDecorations(Builder_Main __instance)
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo2, 4f, __instance.lMask))
        {
            if (hitInfo2.transform.gameObject.CompareTag("Decoration"))
            {
                if (__instance.oldHitOBJ != null && hitInfo2.transform.gameObject != __instance.oldHitOBJ && __instance.hEffect != null)
                {
                    __instance.hEffect.enabled = false;
                }

                HighlightEffect highlightEffect = hitInfo2.transform.Find("Mesh")?.GetComponent<HighlightEffect>();
                if (highlightEffect != null)
                {
                    __instance.hEffect = highlightEffect;
                    __instance.hEffect.enabled = true;
                }
                else
                {
                    Debug.LogWarning("HighlightEffect not found on Decoration!");
                }

                if ((__instance.MainPlayer.GetButtonDown("Build") || __instance.MainPlayer.GetButtonDown("Main Action") || __instance.MainPlayer.GetButtonDown("Secondary Action")) && hitInfo2.transform.GetComponent<NetworkIdentity>() != null)
                {
                    float fundsToAdd = hitInfo2.transform.GetComponent<BuildableInfo>().cost * (BetterSMT.FullDeletionRefund.Value ? 1f : 0.9f);
                    GameData.Instance.CmdAlterFundsWithoutExperience(fundsToAdd);
                    GameData.Instance.GetComponent<NetworkSpawner>().CmdDestroyBox(hitInfo2.transform.gameObject);
                }

                __instance.oldHitOBJ = hitInfo2.transform.gameObject;
                return true;
            }
            else if (__instance.hEffect != null)
            {
                __instance.hEffect.enabled = false;
            }
        }
        else if (__instance.hEffect != null)
        {
            __instance.hEffect.enabled = false;
        }

        return false;
    }
}

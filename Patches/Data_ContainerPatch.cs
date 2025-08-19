using HarmonyLib;
using HutongGames.PlayMaker;
using StarterAssets;
using UnityEngine;

namespace BetterSMT.Patches;
[HarmonyPatch(typeof(Data_Container))]
public class Patch_Data_Container
{

    [HarmonyPatch("BreakingEvent"), HarmonyPostfix]
    public static void BreakingEvent(Data_Container __instance)
    {
        if (BetterSMT.SelfCheckoutBreak.Value)
        {
            __instance.isBroken = false;
        }
    }

    [HarmonyPatch("AddItemToRow"), HarmonyPrefix]
    private static bool AddItemToRowPatch(Data_Container __instance, int containerNumber, int productIDToAdd)
    {
        if (!BetterSMT.QuickStocking.Value)
        {
            return true;
        }

        if (!FirstPersonController.Instance.GetComponent<PlayerPermissions>().RequestRP())
        {
            return false;
        }

        bool flag = !__instance.isServer && FsmVariables.GlobalVariables.FindFsmBool("HighLatencyMode").Value;
        if (flag && __instance.highLatencyCooldown)
        {
            return false;
        }

        if (!__instance.productlistComponent)
        {
            __instance.productlistComponent = GameData.Instance.GetComponent<ProductListing>();
        }

        GameObject gameObject = __instance.productlistComponent.productPrefabs[productIDToAdd];
        Vector3 size = gameObject.GetComponent<BoxCollider>().size;

        if (!BetterSMT.PalletProduct.Value)
        {
            if (__instance.isVolumeRestricted && size.x * size.y * size.z < __instance.productVolumeLimit)
            {
                GameCanvas.Instance.CreateCanvasNotification("message20");
                return false;
            }
        }

        if (!BetterSMT.AllProduct.Value)
        {
            if (gameObject.GetComponent<Data_Product>().productContainerClass != __instance.containerClass)
            {
                GameCanvas.Instance.CreateCanvasNotification("message0");
                return false;
            }
        }


        bool isStackable = gameObject.GetComponent<Data_Product>().isStackable;
        int value = Mathf.FloorToInt(__instance.shelfLength / (size.x * 1.1f));
        value = Mathf.Clamp(value, 1, 100);
        int value2 = Mathf.FloorToInt(__instance.shelfWidth / (size.z * 1.1f));
        value2 = Mathf.Clamp(value2, 1, 100);
        int num = value * value2;

        if (isStackable)
        {
            int value3 = Mathf.FloorToInt(__instance.shelfHeight / (size.y * 1.1f));
            value3 = Mathf.Clamp(value3, 1, 100);
            num = value * value2 * value3;
        }

        int num2 = containerNumber * 2;
        int num3 = __instance.productInfoArray[num2];
        int num4 = __instance.productInfoArray[num2 + 1];

        if (num4 >= num)
        {
            GameCanvas.Instance.CreateCanvasNotification("message1");
            return false;
        }

        if (num3 != productIDToAdd && num3 != -1 && num4 != 0)
        {
            GameCanvas.Instance.CreateCanvasNotification("message2");
            return false;
        }

        PlayerNetwork component = FirstPersonController.Instance.GetComponent<PlayerNetwork>();

        if (flag)
        {
            _ = __instance.StartCoroutine(__instance.HighLatencyCoroutine());
            int shelfSpaceLeft = num - num4;
            int itemsAvailable = component.extraParameter2;
            int itemsToAdd = Mathf.Min(shelfSpaceLeft, itemsAvailable);

            if (itemsToAdd <= 0)
            {
                GameCanvas.Instance.CreateCanvasNotification("message1");
                return false;
            }

            component.extraParameter2 -= itemsToAdd;
            num4 += itemsToAdd;
            AchievementsManager.Instance.CmdAddAchievementPoint(1, itemsToAdd);
        }
        else
        {
            int itemsAvailable = component.extraParameter2;
            int shelfSpaceLeft = num - num4;
            int itemsToAdd = Mathf.Min(itemsAvailable, shelfSpaceLeft);

            if (itemsToAdd <= 0)
            {
                GameCanvas.Instance.CreateCanvasNotification("message1");
                return false;
            }

            AchievementsManager.Instance.CmdAddAchievementPoint(1, itemsToAdd);
            component.extraParameter2 -= itemsToAdd;
            num4 += itemsToAdd;
        }

        GameData.Instance.PlayPopSound();
        __instance.productInfoArray[num2 + 1] = num4;
        __instance.CmdUpdateArrayValues(num2, productIDToAdd, num4);

        return false;
    }
}

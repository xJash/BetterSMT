using HarmonyLib;
using HutongGames.PlayMaker;
using StarterAssets;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(Data_Container))]
public class Patch_Data_Container {

    [HarmonyPatch("BreakingEvent"), HarmonyPostfix]
    public static void BreakingEvent(Data_Container __instance) {
        if(BetterSMT.SelfCheckoutBreak?.Value == true)
            __instance.isBroken = false;
    }

    [HarmonyPatch("AddItemToRow"), HarmonyPrefix]
    private static bool AddItemToRowPatch(Data_Container __instance,int containerNumber,int productIDToAdd) {
        if(!BetterSMT.QuickStocking.Value || !BetterSMT.PalletProduct.Value || !BetterSMT.AllProduct.Value)
            return true;

        var player = FirstPersonController.Instance;
        var permissions = player.GetComponent<PlayerPermissions>();
        if(!permissions.RequestRP())
            return false;

        bool highLatency = !__instance.isServer && FsmVariables.GlobalVariables.FindFsmBool("HighLatencyMode").Value;
        if(highLatency && __instance.highLatencyCooldown)
            return false;

        __instance.productlistComponent ??= GameData.Instance.GetComponent<ProductListing>();

        GameObject prefab = __instance.productlistComponent.productPrefabs[productIDToAdd];
        var dataProduct = prefab.GetComponent<Data_Product>();
        var box = prefab.GetComponent<BoxCollider>();
        Vector3 size = box.size;

        if(!BetterSMT.PalletProduct.Value && __instance.isVolumeRestricted && size.x * size.y * size.z < __instance.productVolumeLimit) {
            GameCanvas.Instance.CreateCanvasNotification("message20");
            return false;
        }

        if(!BetterSMT.AllProduct.Value && dataProduct.productContainerClass != __instance.containerClass) {
            GameCanvas.Instance.CreateCanvasNotification("message0");
            return false;
        }

        int cols = Mathf.Clamp(Mathf.FloorToInt(__instance.shelfLength / (size.x * 1.1f)),1,100);
        int rows = Mathf.Clamp(Mathf.FloorToInt(__instance.shelfWidth / (size.z * 1.1f)),1,100);
        int capacity = cols * rows;

        if(dataProduct.isStackable) {
            int stacks = Mathf.Clamp(Mathf.FloorToInt(__instance.shelfHeight / (size.y * 1.1f)),1,100);
            capacity *= stacks;
        }

        int index = containerNumber * 2;
        int currentProduct = __instance.productInfoArray[index];
        int currentCount = __instance.productInfoArray[index + 1];

        if(currentCount >= capacity) {
            GameCanvas.Instance.CreateCanvasNotification("message1");
            return false;
        }

        if(currentProduct != productIDToAdd && currentProduct != -1 && currentCount != 0) {
            GameCanvas.Instance.CreateCanvasNotification("message2");
            return false;
        }

        var network = player.GetComponent<PlayerNetwork>();
        int itemsAvailable = network.extraParameter2;
        int shelfSpaceLeft = capacity - currentCount;
        int itemsToAdd = Mathf.Min(itemsAvailable,shelfSpaceLeft);

        if(itemsToAdd <= 0) {
            GameCanvas.Instance.CreateCanvasNotification("message1");
            return false;
        }

        if(highLatency)
            _ = __instance.StartCoroutine(__instance.HighLatencyCoroutine());

        network.extraParameter2 -= itemsToAdd;
        currentCount += itemsToAdd;
        AchievementsManager.Instance.CmdAddAchievementPoint(1,itemsToAdd);

        GameData.Instance.PlayPopSound();
        __instance.productInfoArray[index + 1] = currentCount;
        __instance.CmdUpdateArrayValues(index,productIDToAdd,currentCount);

        return false; 
    }
}

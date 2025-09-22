using BepInEx.Bootstrap;
using HarmonyLib;
using HutongGames.PlayMaker;
using StarterAssets;
using System.Linq;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(Data_Container))]
public class Patch_Data_Container {

    public static bool GetExternalConfigValue(string modGUID,string configKey,out object value) {
        value = null;

        if(Chainloader.PluginInfos.TryGetValue(modGUID,out BepInEx.PluginInfo modPluginInfo)) {
            BepInEx.Configuration.ConfigFile configEntries = modPluginInfo.Instance.Config;

            BepInEx.Configuration.ConfigEntryBase configEntry = configEntries
                    .Where(c => c.Key.Key == configKey)
                    .Select(c => c.Value)
                    .FirstOrDefault();

            if(configEntry != null) {
                value = configEntry.BoxedValue;
                return true;
            }
        }

        return false;
    }


    [HarmonyPatch("AddItemToRow"), HarmonyPrefix]
    private static bool AddItemToRowPatch(Data_Container __instance,int containerNumber,int productIDToAdd) {
        if(GetExternalConfigValue("es.damntry.SuperQoLity","*Enable ·Item Transfer Speed Module· (**)",out object value)) {
            if(value is bool otherValue && otherValue) {
                BetterSMT.QuickStocking.Value = true;
            }
        }

        if(!BetterSMT.QuickStocking.Value && !BetterSMT.PalletProduct.Value && !BetterSMT.AllProduct.Value) {
            return true;
        }

        FirstPersonController player = FirstPersonController.Instance;
        PlayerPermissions permissions = player.GetComponent<PlayerPermissions>();
        if(!permissions.RequestRP()) {
            return false;
        }

        bool highLatency = !__instance.isServer && FsmVariables.GlobalVariables.FindFsmBool("HighLatencyMode").Value;
        if(highLatency && __instance.highLatencyCooldown) {
            return false;
        }

        __instance.productlistComponent ??= GameData.Instance.GetComponent<ProductListing>();

        GameObject prefab = __instance.productlistComponent.productPrefabs[productIDToAdd];
        Data_Product dataProduct = prefab.GetComponent<Data_Product>();
        BoxCollider box = prefab.GetComponent<BoxCollider>();
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

        PlayerNetwork network = player.GetComponent<PlayerNetwork>();
        int itemsAvailable = network.extraParameter2;
        int shelfSpaceLeft = capacity - currentCount;

        int itemsToAdd;

        if(BetterSMT.QuickStocking.Value) {
            itemsToAdd = Mathf.Min(itemsAvailable,shelfSpaceLeft);
        } else {
            if(highLatency) {
                _ = __instance.StartCoroutine(__instance.HighLatencyCoroutine());

                int spaceClamp = Mathf.Clamp(shelfSpaceLeft,1,5);
                int availClamp = Mathf.Clamp(itemsAvailable,1,5);
                itemsToAdd = Mathf.Min(spaceClamp,availClamp);
            } else {
                itemsToAdd = (itemsAvailable > 0 && shelfSpaceLeft > 0) ? 1 : 0;
            }
        }

        if(itemsToAdd <= 0) {
            GameCanvas.Instance.CreateCanvasNotification("message1");
            return false;
        }

        network.extraParameter2 -= itemsToAdd;
        currentCount += itemsToAdd;

        AchievementsManager.Instance.CmdAddAchievementPoint(1,itemsToAdd);
        GameData.Instance.PlayPopSound();

        __instance.productInfoArray[index + 1] = currentCount;
        __instance.CmdUpdateArrayValues(index,productIDToAdd,currentCount);

        return false;
    }

    [HarmonyPatch("RemoveItemFromRow"), HarmonyPrefix]
    public static bool QuickRemovePrefix(Data_Container __instance,int containerNumber) {
        if(!BetterSMT.QuickRemoving.Value) {
            return true;
        }

        FirstPersonController player = FirstPersonController.Instance;
        PlayerPermissions permissions = player.GetComponent<PlayerPermissions>();
        PlayerNetwork component = player.GetComponent<PlayerNetwork>();

        if(!permissions.RequestRP()) {
            return false;
        }

        int index = containerNumber * 2;
        int productID = __instance.productInfoArray[index];
        int remainingInRow = __instance.productInfoArray[index + 1];

        if(productID == -1 || remainingInRow <= 0) {
            return false;
        }

        if(component.equippedItem != 1) {
            return false;
        }

        if(component.extraParameter1 != productID && component.extraParameter2 > 0) {
            GameCanvas.Instance.CreateCanvasNotification("message13");
            return false;
        }

        int maxItemsPerBox = ProductListing.Instance.productPrefabs[productID]
            .GetComponent<Data_Product>().maxItemsPerBox;

        if(component.extraParameter2 >= maxItemsPerBox) {
            GameCanvas.Instance.CreateCanvasNotification("message12");
            return false;
        }

        if(component.extraParameter2 == 0 && component.instantiatedOBJ) {
            component.extraParameter1 = productID;
            component.UpdateBoxContents(productID);
        }

        int spaceLeft = maxItemsPerBox - component.extraParameter2;
        int itemsToTake = Mathf.Min(spaceLeft,remainingInRow);

        component.extraParameter2 += itemsToTake;
        remainingInRow -= itemsToTake;

        GameData.Instance.PlayPop2Sound();
        __instance.productInfoArray[index + 1] = remainingInRow;
        __instance.CmdUpdateArrayValues(index,productID,remainingInRow);

        return false;
    }
}

using HarmonyLib;
using Mirror;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(ManagerBlackboard))]
public class ManagerBlackboardPatch {


    [HarmonyPatch(nameof(ServerCargoSpawner))]
    [HarmonyPrefix]
    private static bool ServerCargoSpawner(ManagerBlackboard __instance,ref IEnumerator __result) {
        if(BetterSMT.FastBoxSpawns.Value) {
            __result = CustomCargoSpawner(__instance);
            return false;
        } else {
            return true;
        }
    }

    private static IEnumerator CustomCargoSpawner(ManagerBlackboard __instance) {
        __instance.isSpawning = true;
        Vector3 halfExtents = new(0.3f,0.3f,0.45f);
        WaitForSeconds waitTime1;
        WaitForSeconds waitTime2;

        if(BetterSMT.FastBoxSpawns.Value) {
            waitTime1 = new WaitForSeconds(0.01f);
            waitTime2 = new WaitForSeconds(0.01f);
        } else {
            waitTime1 = new WaitForSeconds(0.5f);
            waitTime2 = new WaitForSeconds(0.2f);
        }

        while(__instance.idsToSpawn.Count > 0) {
            Vector3 spawnPosition = BetterSMT.CloserBoxSpawning.Value
                ? new Vector3(
                    20f + Random.Range(-2.5f,2.5f),
                    1f,
                    7f + Random.Range(-2.5f,2.5f)
                )
                : __instance.merchandiseSpawnpoint.transform.position + new Vector3(
                    Random.Range(-2f,2f),
                    0f,
                    Random.Range(-2f,2f)
                );
            if(Physics.BoxCast(spawnPosition + new Vector3(0f,5f,0f),halfExtents,-Vector3.up,Quaternion.identity,7.5f,__instance.boxSpawnLayerMask)) {
                yield return waitTime1;
            }
            yield return waitTime1;

            int num = __instance.idsToSpawn[0];
            GameObject gameObject = Object.Instantiate(__instance.boxPrefab,spawnPosition,Quaternion.identity);
            gameObject.GetComponent<BoxData>().NetworkproductID = num;

            int maxItemsPerBox = __instance.GetComponent<ProductListing>().productPrefabs[num].GetComponent<Data_Product>().maxItemsPerBox;
            gameObject.GetComponent<BoxData>().NetworknumberOfProducts = maxItemsPerBox;

            Sprite sprite = __instance.GetComponent<ProductListing>().productSprites[num];
            gameObject.transform.Find("Canvas/Image1").GetComponent<Image>().sprite = sprite;
            gameObject.transform.Find("Canvas/Image2").GetComponent<Image>().sprite = sprite;

            gameObject.transform.SetParent(__instance.boxParent);
            NetworkServer.Spawn(gameObject);
            __instance.RpcParentBoxOnClient(gameObject);
            __instance.idsToSpawn.RemoveAt(0);
        }


        yield return waitTime2;
        __instance.isSpawning = false;
    }

    public static IEnumerator CalculateShoppingListTotalOverride(ManagerBlackboard __instance) {
        if(BetterSMT.ReplaceCommasWithPeriods.Value) {
            yield return new WaitForEndOfFrame();
            __instance.shoppingTotalCharge = 0f;
            if(__instance.shoppingListParent.transform.childCount > 0) {
                foreach(Transform item in __instance.shoppingListParent.transform) {
                    string text = item.transform.Find("BoxPrice").GetComponent<TextMeshProUGUI>().text;

                    string cleanedText = text[2..].Trim();
                    if(float.TryParse(cleanedText,NumberStyles.Float,CultureInfo.InvariantCulture,out float price)) {
                        __instance.shoppingTotalCharge += price;
                    }
                }
            }
            __instance.totalChargeOBJ.text = ProductListing.Instance.ConvertFloatToTextPrice(__instance.shoppingTotalCharge);
        }
    }

    [HarmonyPatch(typeof(ManagerBlackboard),nameof(ManagerBlackboard.RemoveShoppingListProduct))]
    [HarmonyPrefix]
    public static bool RemoveShoppingListProductPatch(ManagerBlackboard __instance,int indexToRemove) {
        if(BetterSMT.ReplaceCommasWithPeriods.Value) {
            if(__instance.shoppingListParent.transform.childCount > 0) {
                Object.Destroy(__instance.shoppingListParent.transform.GetChild(indexToRemove).gameObject);
            }
            _ = __instance.StartCoroutine(CalculateShoppingListTotalOverride(__instance));
            return false;
        }

        return true;
    }

    [HarmonyPatch(nameof(ManagerBlackboard.RemoveAllShoppingList))]
    [HarmonyPrefix]
    public static bool RemoveAllShoppingListPatch(ManagerBlackboard __instance) {
        if(BetterSMT.ReplaceCommasWithPeriods.Value) {
            if(__instance.shoppingListParent.transform.childCount == 0) {
                return false;
            }

            foreach(Transform item in __instance.shoppingListParent.transform) {
                Object.Destroy(item.gameObject);
            }

            _ = __instance.StartCoroutine(CalculateShoppingListTotalOverride(__instance));
            return false;
        } else {
            return true;
        }
    }

    [HarmonyPatch("AddShoppingListProduct")]
    [HarmonyPrefix]
    public static bool AddShoppingListProductPatch(ManagerBlackboard __instance,int productID,float boxPrice) {
        if(!BetterSMT.ReplaceCommasWithPeriods.Value) {

            ProductListing component = __instance.GetComponent<ProductListing>();
            GameObject gameObject = Object.Instantiate(__instance.UIShoppingListPrefab,__instance.shoppingListParent.transform);

            string key = "product" + productID;
            string localizationString = LocalizationManager.instance.GetLocalizationString(key);
            gameObject.transform.Find("ProductName").GetComponent<TextMeshProUGUI>().text = localizationString;

            GameObject obj = component.productPrefabs[productID];
            string productBrand = obj.GetComponent<Data_Product>().productBrand;
            gameObject.transform.Find("BrandName").GetComponent<TextMeshProUGUI>().text = productBrand;

            int maxItemsPerBox = obj.GetComponent<Data_Product>().maxItemsPerBox;
            gameObject.transform.Find("BoxQuantity").GetComponent<TextMeshProUGUI>().text = "x" + maxItemsPerBox.ToString("F2",CultureInfo.InvariantCulture);
            gameObject.transform.Find("BoxPrice").GetComponent<TextMeshProUGUI>().text = $" ${boxPrice.ToString("F2",CultureInfo.InvariantCulture)}";

            gameObject.GetComponent<InteractableData>().thisSkillIndex = productID;

            _ = __instance.StartCoroutine(CalculateShoppingListTotalOverride(__instance));
            return false;
        } else {
            return true;
        }
    }
}
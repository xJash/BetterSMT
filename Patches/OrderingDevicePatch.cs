using HarmonyLib;
using System.Globalization;
using TMPro;
using UnityEngine;

I would be down to work with them, the big thing is #faq being reworked, removing the text channel from auto-voice chats (since they can just use voice text channel), add a category for rules through linked-communities, adding a command bot (like dyno or other) to add commands like ?logs and ?saves (aswell as others).

As far as mods- its obvious in logs if they are using mods since at the top of the unity log it has a log for BepInEx and which mods



using HarmonyLib;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(OrderingDevice))]
public static class OrderingDevicePatch {
    [HarmonyPostfix]
    [HarmonyPatch("OnEnable")]
    public static void OnOrderingDeviceEnabled(OrderingDevice __instance) {
        if (BetterSMT.AutoOrdering.Value == true) {
            ManagerBlackboard manager = GameData.Instance?.GetComponent<ManagerBlackboard>();
            ProductListing listing = ProductListing.Instance;
            GameObject shelves = NPC_Manager.Instance?.shelvesOBJ;

            if (manager == null || listing == null || shelves == null) {
                return;
            }

            int addedTotal = 0;

            for (int productId = 0; productId < listing.productPrefabs.Length; productId++) {
                GameObject prefab = listing.productPrefabs[productId];
                int maxItemsPerBox = prefab.GetComponent<Data_Product>().maxItemsPerBox;

                int missingItems = 0;

                for (int i = 0; i < shelves.transform.childCount; i++) {
                    Data_Container container = shelves.transform.GetChild(i).GetComponent<Data_Container>();
                    int[] array = container.productInfoArray;
                    for (int j = 0; j < array.Length / 2; j++) {
                        int id = array[j * 2];
                        int quantity = array[(j * 2) + 1];
                        if (id == productId && quantity >= 0) {
                            int maxPerRow = NPC_Manager.Instance.GetMaxProductsPerRow(i, productId);
                            missingItems += maxPerRow - quantity;
                        }
                    }
                }

                float rawBoxesNeeded = (float)missingItems / maxItemsPerBox;

                // ✅ Subtract boxes already in store, using reflection to access `boxesInStoreField`
                float boxesInStore = 0f;
                System.Reflection.FieldInfo fieldInfo = AccessTools.Field(typeof(OrderingDevice), "boxesInStoreField");
                if (fieldInfo != null) {
                    TMP_Text textField = fieldInfo.GetValue(__instance) as TMP_Text;
                    if (textField != null) {
                        string rawText = textField.text.Replace("x", "").Replace(",", ".");
                        if (float.TryParse(rawText, out float parsed)) {
                            boxesInStore = parsed;
                        }
                    }
                }

                float netBoxesNeeded = Mathf.Max(0, rawBoxesNeeded - boxesInStore);
                int finalBoxesToOrder = Mathf.CeilToInt(netBoxesNeeded);
                float pricePerBox = ProductPriceUtility.GetPricePerBox(productId);

                for (int b = 0; b < finalBoxesToOrder; b++) {
                    manager.AddShoppingListProduct(productId, pricePerBox);
                    addedTotal++;
                }
            }

            Debug.Log($"[BetterSMT] Auto-ordering complete. {addedTotal} boxes added to cart.");
        }
    }

    public static class ProductPriceUtility {
        public static float GetPricePerBox(int productID) {
            ProductListing listing = ProductListing.Instance;
            GameObject prefab = listing.productPrefabs[productID];
            Data_Product product = prefab.GetComponent<Data_Product>();

            float inflation = listing.tierInflation[product.productTier];
            float unitPrice = product.basePricePerUnit;
            int maxPerBox = product.maxItemsPerBox;

            float raw = unitPrice * inflation * maxPerBox;
            return Mathf.Round(raw * 100f) / 100f;
        }
    }

    [HarmonyPatch("ClearProduct")]
    [HarmonyPrefix]
    public static void ClearProductPatch(OrderingDevice __instance, int productID) {
        if (__instance.listParentOBJ.transform.childCount == 0) {
            return;
        }
        for (int i = 0; i < __instance.listParentOBJ.transform.childCount; i++) {
            Transform child = __instance.listParentOBJ.transform.GetChild(i);
            if (child.GetComponent<OrderingListReferences>().productID == productID) {
                Object.Destroy(child.gameObject);
                __instance.stylusAnimator.SetFloat("AnimationFactor", 1f);
                __instance.stylusAnimator.Play("StylusAnimation");
                __instance.StartCoroutine(__instance.AnimationHighlight(1));
                int childCount = GameData.Instance.GetComponent<ManagerBlackboard>().shoppingListParent.transform.childCount;
                if (i < childCount) {
                    int indexToRemove = childCount - 1 - i;
                    GameData.Instance.GetComponent<ManagerBlackboard>().RemoveShoppingListProduct(indexToRemove);
                }
                break;
            }
        }
        __instance.StartCoroutine(__instance.SetInListField(productID));
        _ = __instance.StartCoroutine(CalculateShoppingListTotalOverrideOrdering(__instance));
    }

    public static IEnumerator CalculateShoppingListTotalOverrideOrdering(OrderingDevice __instance) {
        GameObject managerListParentOBJ = GameData.Instance.GetComponent<ManagerBlackboard>().shoppingListParent;
        yield return new WaitForEndOfFrame();

        __instance.totalBoxesAmount.text = "x" + __instance.listParentOBJ.transform.childCount;
        float num = 0f;

        if (managerListParentOBJ.transform.childCount > 0) {
            foreach (Transform item in managerListParentOBJ.transform) {
                string text = item.transform.Find("BoxPrice").GetComponent<TextMeshProUGUI>().text;
                string cleanedText = text[2..].Trim();

                if (float.TryParse(cleanedText, NumberStyles.Float, CultureInfo.InvariantCulture, out float price)) {
                    num += price;
                } else {
                    Debug.LogWarning($"BetterSMT: Failed to parse float from price string '{cleanedText}'");
                }
            }
        }

        string text2 = ProductListing.Instance.ConvertFloatToTextPrice(num);
        __instance.totalPriceField.text = text2;
    }

    [HarmonyPatch("CopyManagerBlackboardList")]
    [HarmonyPrefix]
    public static void CopyManagerBlackboardListPatch(OrderingDevice __instance) {
        GameObject shoppingListParent = GameData.Instance.GetComponent<ManagerBlackboard>().shoppingListParent;
        for (int i = 0; i < shoppingListParent.transform.childCount; i++) {
            int thisSkillIndex = shoppingListParent.transform.GetChild(i).GetComponent<InteractableData>().thisSkillIndex;
            __instance.AddProductbase(thisSkillIndex);
        }
        _ = __instance.StartCoroutine(CalculateShoppingListTotalOverrideOrdering(__instance));
    }

    [HarmonyPatch("AddProduct")]
    [HarmonyPrefix]
    public static void AddProductPatch(OrderingDevice __instance, int productID) {
        __instance.AddProductbase(productID);
        float boxPrice = __instance.RetrievePricePerBox(productID);
        GameData.Instance.GetComponent<ManagerBlackboard>().AddShoppingListProduct(productID, boxPrice);
        __instance.StartCoroutine(__instance.SetInListField(productID));
        _ = __instance.StartCoroutine(CalculateShoppingListTotalOverrideOrdering(__instance));
    }

}

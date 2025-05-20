using HarmonyLib;
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
                        int quantity = array[j * 2 + 1];
                        if (id == productId && quantity >= 0) {
                            int maxPerRow = NPC_Manager.Instance.GetMaxProductsPerRow(i, productId);
                            missingItems += maxPerRow - quantity;
                        }
                    }
                }

                int boxesNeeded = Mathf.CeilToInt((float)missingItems / maxItemsPerBox);
                float pricePerBox = ProductPriceUtility.GetPricePerBox(productId);

                for (int b = 0; b < boxesNeeded; b++) {
                    manager.AddShoppingListProduct(productId, pricePerBox);
                    addedTotal++;
                }
            }
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
}

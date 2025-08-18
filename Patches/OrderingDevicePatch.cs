using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(OrderingDevice))]
public static class OrderingDevicePatch
{
    [HarmonyPatch("Update"), HarmonyPostfix]
    private static void UpdatePatch()
    {
        HandleProductFeatures();
    }
    private static readonly Stopwatch productCheckStopwatch = new Stopwatch();

    private static void HandleProductFeatures()
    {
        if (!GameData.Instance.isServer)
            return;

        if (BetterSMT.AutoOrderEnabled?.Value != true && BetterSMT.LowStockAlertEnabled?.Value != true)
            return;

        if (!productCheckStopwatch.IsRunning)
        {
            productCheckStopwatch.Start();
            return;
        }

        if (productCheckStopwatch.Elapsed.TotalSeconds < BetterSMT.AutoOrderCheckInterval?.Value)
            return;

        productCheckStopwatch.Restart();

        CheckProductsAndHandle();
    }

    private static void CheckProductsAndHandle()
    {
        var manager = GameData.Instance?.GetComponent<ManagerBlackboard>();
        var listing = ProductListing.Instance;
        var shelves = NPC_Manager.Instance?.shelvesOBJ;
        var storage = NPC_Manager.Instance?.storageOBJ;

        if (manager == null || listing == null || shelves == null || storage == null)
            return;

        List<string> lowStockMessages = new List<string>();
        List<string> autoOrderMessages = new List<string>();

        var availableProducts = listing.availableProducts;

        for (int productId = 0; productId < listing.productPrefabs.Length; productId++)
        {
            if (!availableProducts.Contains(productId))
                continue;

            var prefab = listing.productPrefabs[productId];
            var dataProduct = prefab.GetComponent<Data_Product>();
            int maxItemsPerBox = dataProduct.maxItemsPerBox;

            int totalStock = 0;
            int missingItems = 0;

            for (int i = 0; i < shelves.transform.childCount; i++)
            {
                var container = shelves.transform.GetChild(i).GetComponent<Data_Container>();
                var array = container.productInfoArray;

                for (int j = 0; j < array.Length / 2; j++)
                {
                    int id = array[j * 2];
                    int quantity = array[(j * 2) + 1];

                    if (id == productId && quantity >= 0)
                    {
                        totalStock += quantity;
                        int maxPerRow = NPC_Manager.Instance.GetMaxProductsPerRow(i, productId);
                        missingItems += maxPerRow - quantity;
                    }
                }
            }

            for (int i = 0; i < storage.transform.childCount; i++)
            {
                var container = storage.transform.GetChild(i).GetComponent<Data_Container>();
                var array = container.productInfoArray;

                for (int j = 0; j < array.Length / 2; j++)
                {
                    int id = array[j * 2];
                    int quantity = array[(j * 2) + 1];

                    if (id == productId && quantity >= 0)
                    {
                        totalStock += quantity;
                    }
                }
            }

            string productName = GameDataPatch.productNames.TryGetValue(productId, out string name)
                ? name
                : $"Product {productId}";

            if (BetterSMT.LowStockAlertEnabled?.Value == true && totalStock <= BetterSMT.LowStockThreshold?.Value)
            {
                lowStockMessages.Add($"{productName} ({totalStock} left)");
            }

            if (BetterSMT.AutoOrderEnabled?.Value == true)
            {
                int finalMissingItems = Mathf.Max(missingItems - totalStock, 0);
                int boxesToOrder = Mathf.CeilToInt((float)finalMissingItems / maxItemsPerBox);

                if (boxesToOrder > 0)
                {
                    float pricePerBox = GetPricePerBox(productId);
                    for (int b = 0; b < boxesToOrder; b++)
                    {
                        manager.AddShoppingListProduct(productId, pricePerBox);
                    }
                    autoOrderMessages.Add($"{boxesToOrder} boxes of {productName}");
                }
            }
        }

        if (lowStockMessages.Count > 0)
        {
            BetterSMT.CreateImportantNotification("Low stock: " + string.Join(", ", lowStockMessages));
        }

        if (autoOrderMessages.Count > 0)
        {
            BetterSMT.CreateImportantNotification("Auto-ordered: " + string.Join(", ", autoOrderMessages));
        }
    }


    [HarmonyPostfix]
    [HarmonyPatch("OnEnable")]
    public static void OnOrderingDeviceEnabled(OrderingDevice __instance)
    {
        if (!BetterSMT.AutoOrdering.Value || processedDevices.Contains(__instance))
            return;

        _ = processedDevices.Add(__instance);

        __instance.StartCoroutine(WaitThenInit(__instance));
    }
    private static IEnumerator WaitThenInit(OrderingDevice instance)
    {
        yield return new WaitUntil(() =>
            GameData.Instance != null &&
            GameData.Instance.GetComponent<ManagerBlackboard>()?.shoppingListParent != null &&
            ProductListing.Instance != null &&
            NPC_Manager.Instance?.shelvesOBJ != null &&
            NPC_Manager.Instance?.storageOBJ != null
        );

        yield return null;

        TryAddProductsToShoppingList(instance);
        instance.CopyManagerBlackboardList();
    }
    private static void TryAddProductsToShoppingList(OrderingDevice __instance)
    {
        var manager = GameData.Instance?.GetComponent<ManagerBlackboard>();
        var listing = ProductListing.Instance;
        var shelves = NPC_Manager.Instance?.shelvesOBJ;
        var storage = NPC_Manager.Instance?.storageOBJ;

        if (manager == null || listing == null || shelves == null || storage == null)
            return;

        for (int productId = 0; productId < listing.productPrefabs.Length; productId++)
        {
            var prefab = listing.productPrefabs[productId];
            var dataProduct = prefab.GetComponent<Data_Product>();
            int maxItemsPerBox = dataProduct.maxItemsPerBox;

            int missingItems = 0;
            for (int i = 0; i < shelves.transform.childCount; i++)
            {
                var container = shelves.transform.GetChild(i).GetComponent<Data_Container>();
                var array = container.productInfoArray;

                for (int j = 0; j < array.Length / 2; j++)
                {
                    int id = array[j * 2];
                    int quantity = array[(j * 2) + 1];

                    if (id == productId && quantity >= 0)
                    {
                        int maxPerRow = NPC_Manager.Instance.GetMaxProductsPerRow(i, productId);
                        missingItems += maxPerRow - quantity;
                    }
                }
            }

            int storedCount = 0;
            for (int i = 0; i < storage.transform.childCount; i++)
            {
                var container = storage.transform.GetChild(i).GetComponent<Data_Container>();
                var array = container.productInfoArray;

                for (int j = 0; j < array.Length / 2; j++)
                {
                    int id = array[j * 2];
                    int quantity = array[(j * 2) + 1];

                    if (id == productId && quantity >= 0)
                    {
                        storedCount += quantity;
                    }
                }
            }

            int finalMissingItems = Mathf.Max(missingItems - storedCount, 0);
            int boxesToOrder = Mathf.CeilToInt((float)finalMissingItems / maxItemsPerBox);
            float pricePerBox = GetPricePerBox(productId);

            for (int b = 0; b < boxesToOrder; b++)
            {
                manager.AddShoppingListProduct(productId, pricePerBox);
            }
        }
    }
    private static readonly HashSet<OrderingDevice> processedDevices = [];
    public static float GetPricePerBox(int productID)
    {
        ProductListing listing = ProductListing.Instance;
        GameObject prefab = listing.productPrefabs[productID];
        Data_Product product = prefab.GetComponent<Data_Product>();

        float inflation = listing.tierInflation[product.productTier];
        float unitPrice = product.basePricePerUnit;
        int maxPerBox = product.maxItemsPerBox;

        float raw = unitPrice * inflation * maxPerBox;
        return Mathf.Round(raw * 100f) / 100f;
    }
    [HarmonyPatch(typeof(OrderingDevice), "ClearProduct")]
    [HarmonyPrefix]
    public static bool ClearProductPatch(OrderingDevice __instance, int productID)
    {

        if (!BetterSMT.ReplaceCommasWithPeriods.Value)
        {
            return true;
        }

        if (__instance.listParentOBJ.transform.childCount == 0)
        {
            return false;
        }

        for (int i = 0; i < __instance.listParentOBJ.transform.childCount; i++)
        {
            Transform child = __instance.listParentOBJ.transform.GetChild(i);
            int childProductID = child.GetComponent<OrderingListReferences>().productID;
            if (childProductID == productID)
            {
                UnityEngine.Object.Destroy(child.gameObject);
                __instance.stylusAnimator.SetFloat("AnimationFactor", 1f);
                __instance.stylusAnimator.Play("StylusAnimation");
                _ = __instance.StartCoroutine(__instance.AnimationHighlight(1));

                int childCount = GameData.Instance.GetComponent<ManagerBlackboard>().shoppingListParent.transform.childCount;
                if (i < childCount)
                {
                    int indexToRemove = childCount - 1 - i;
                    GameData.Instance.GetComponent<ManagerBlackboard>().RemoveShoppingListProduct(indexToRemove);
                }
                break;
            }
        }

        _ = __instance.StartCoroutine(__instance.SetInListField(productID));
        _ = __instance.StartCoroutine(CalculateShoppingListTotalOverrideOrdering(__instance));

        return false;
    }

    private static bool _suppressAddProduct = false;
    [HarmonyPatch(typeof(OrderingDevice), "CopyManagerBlackboardList")]
    [HarmonyPrefix]
    public static bool CopyManagerBlackboardListPatch(OrderingDevice __instance)
    {

        if (!BetterSMT.ReplaceCommasWithPeriods.Value)
        {
            return true;
        }

        _suppressAddProduct = true;

        GameObject shoppingListParent = GameData.Instance.GetComponent<ManagerBlackboard>().shoppingListParent;
        for (int i = 0; i < shoppingListParent.transform.childCount; i++)
        {
            int thisSkillIndex = shoppingListParent.transform.GetChild(i).GetComponent<InteractableData>().thisSkillIndex;
            __instance.AddProductbase(thisSkillIndex);
        }

        _suppressAddProduct = false;
        _ = __instance.StartCoroutine(CalculateShoppingListTotalOverrideOrdering(__instance));

        return false;
    }
    private static readonly Dictionary<(OrderingDevice, int), float> lastAddTime = [];
    [HarmonyPatch(typeof(OrderingDevice), "AddProduct")]
    [HarmonyPrefix]
    public static bool AddProductPatch(OrderingDevice __instance, int productID)
    {
        if (!BetterSMT.ReplaceCommasWithPeriods.Value || _suppressAddProduct)
        {
            return true;
        }

        float now = Time.time;
        (OrderingDevice __instance, int productID) key = (__instance, productID);

        if (lastAddTime.TryGetValue(key, out float lastTime))
        {
            if (now - lastTime < 0.05f)
            {
                return false;
            }
        }

        lastAddTime[key] = now;


        __instance.AddProductbase(productID);
        float boxPrice = __instance.RetrievePricePerBox(productID);
        GameData.Instance.GetComponent<ManagerBlackboard>().AddShoppingListProduct(productID, boxPrice);
        _ = __instance.StartCoroutine(__instance.SetInListField(productID));
        _ = __instance.StartCoroutine(CalculateShoppingListTotalOverrideOrdering(__instance));

        return false;
    }
    public static IEnumerator CalculateShoppingListTotalOverrideOrdering(OrderingDevice __instance)
    {
        GameObject managerListParentOBJ = GameData.Instance.GetComponent<ManagerBlackboard>().shoppingListParent;
        yield return new WaitForEndOfFrame();

        __instance.totalBoxesAmount.text = "x" + __instance.listParentOBJ.transform.childCount;
        float totalPrice = 0f;

        if (managerListParentOBJ.transform.childCount > 0)
        {
            foreach (Transform item in managerListParentOBJ.transform)
            {
                string text = item.transform.Find("BoxPrice").GetComponent<TextMeshProUGUI>().text;
                string cleanedText = text[2..].Trim().Replace(",", ".");
                if (float.TryParse(cleanedText, NumberStyles.Float, CultureInfo.InvariantCulture, out float price))
                {
                    totalPrice += price;
                }
                else
                {
                }
            }
        }

        string formattedPrice = ProductListing.Instance.ConvertFloatToTextPrice(totalPrice);
        __instance.totalPriceField.text = formattedPrice;
    }
}
using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(ManagerBlackboard))]
public class ManagerBlackboardPatch {

    [HarmonyPatch("ServerCargoSpawner", MethodType.Enumerator), HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> InstantCargoSpawner(IEnumerable<CodeInstruction> instructions) {
        return BetterSMT.FastBoxSpawns.Value ?
            new CodeMatcher(instructions)
                .Start()
                .MatchForward(false, new CodeMatch(OpCodes.Newobj, AccessTools.Constructor(typeof(WaitForSeconds), [typeof(float)])))
                .Repeat(matcher => {
                    _ = matcher.Advance(-1);
                    _ = matcher.SetOperandAndAdvance(0.01f);
                    _ = matcher.Advance(1);
                })
                .InstructionEnumeration() :

            instructions;
    }

    public static IEnumerator CalculateShoppingListTotalOverride(ManagerBlackboard __instance) {
        if (BetterSMT.ReplaceCommasWithPeriods.Value) {
            yield return new WaitForEndOfFrame();
            __instance.shoppingTotalCharge = 0f;
            if (__instance.shoppingListParent.transform.childCount > 0) {
                foreach (Transform item in __instance.shoppingListParent.transform) {
                    string text = item.transform.Find("BoxPrice").GetComponent<TextMeshProUGUI>().text;

                    string cleanedText = text[2..].Trim();
                    if (float.TryParse(cleanedText, NumberStyles.Float, CultureInfo.InvariantCulture, out float price)) {
                        __instance.shoppingTotalCharge += price;
                    }
                }
            }
            __instance.totalChargeOBJ.text = ProductListing.Instance.ConvertFloatToTextPrice(__instance.shoppingTotalCharge);
        }
    }

    [HarmonyPatch("RemoveShoppingListProduct")]
    [HarmonyPrefix]
    public static void RemoveShoppingListProductPatch(ManagerBlackboard __instance, int indexToRemove) {
        if (BetterSMT.ReplaceCommasWithPeriods.Value) {
            if (__instance.shoppingListParent.transform.childCount > 0) {
                Object.Destroy(__instance.shoppingListParent.transform.GetChild(indexToRemove).gameObject);
            }
            _ = __instance.StartCoroutine(CalculateShoppingListTotalOverride(__instance));
        }
    }

    [HarmonyPatch("RemoveAllShoppingList")]
    [HarmonyPrefix]
    public static void RemoveAllShoppingListPatch(ManagerBlackboard __instance) {
        if (BetterSMT.ReplaceCommasWithPeriods.Value) {
            if (__instance.shoppingListParent.transform.childCount == 0) {
                return;
            }
            foreach (Transform item in __instance.shoppingListParent.transform) {
                Object.Destroy(item.gameObject);
            }
            _ = __instance.StartCoroutine(CalculateShoppingListTotalOverride(__instance));
        }
    }

    [HarmonyPatch("AddShoppingListProduct")]
    [HarmonyPrefix]
    public static bool AddShoppingListProductPatch(ManagerBlackboard __instance, int productID, float boxPrice) {
        if (BetterSMT.ReplaceCommasWithPeriods.Value) {
            ProductListing component = __instance.GetComponent<ProductListing>();
            GameObject gameObject = Object.Instantiate(__instance.UIShoppingListPrefab, __instance.shoppingListParent.transform);
            string key = "product" + productID;
            string localizationString = LocalizationManager.instance.GetLocalizationString(key);
            gameObject.transform.Find("ProductName").GetComponent<TextMeshProUGUI>().text = localizationString;
            GameObject obj = component.productPrefabs[productID];
            string productBrand = obj.GetComponent<Data_Product>().productBrand;
            gameObject.transform.Find("BrandName").GetComponent<TextMeshProUGUI>().text = productBrand;
            int maxItemsPerBox = obj.GetComponent<Data_Product>().maxItemsPerBox;
            gameObject.transform.Find("BoxQuantity").GetComponent<TextMeshProUGUI>().text = "x" + maxItemsPerBox.ToString("F2", CultureInfo.InvariantCulture);
            gameObject.transform.Find("BoxPrice").GetComponent<TextMeshProUGUI>().text = " $" + boxPrice.ToString("F2", CultureInfo.InvariantCulture);
            gameObject.GetComponent<InteractableData>().thisSkillIndex = productID;
            _ = __instance.StartCoroutine(CalculateShoppingListTotalOverride(__instance));

            return false;
        }
        return true;
    }
}
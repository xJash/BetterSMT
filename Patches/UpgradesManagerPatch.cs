using HarmonyLib;
using System.Reflection;
using UnityEngine;
using System.Collections;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(UpgradesManager))]
public class UpgradesManagerPatch {
    [HarmonyPatch(typeof(UpgradesManager))]
    [HarmonyPatch("OnStartClient")]
    public class ClockSpeedPatch {
        [HarmonyPostfix]
        public static void Postfix(UpgradesManager __instance) {
            FieldInfo field = typeof(UpgradesManager).GetField("acceleratedTimeFactor", BindingFlags.NonPublic | BindingFlags.Instance);
            field?.SetValue(__instance, BetterSMT.ClockSpeed.Value);

            if (BetterSMT.AllRecyclers.Value == true) {
                __instance.normalTrashContainerOBJ.SetActive(false);
                __instance.recycleContainerOBJ.SetActive(true);
                NPC_Manager.Instance.closestRecyclePerk = true;
            }

            if (BetterSMT.EnablePalletDisplays.Value == true) {
                __instance.StartCoroutine(ForceEnablePalletDisplays(__instance));
            }
        }

        private static IEnumerator ForceEnablePalletDisplays(UpgradesManager __instance) {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < __instance.UIpalletsOBJsArray.Length; i++) {
                GameObject obj = __instance.UIpalletsOBJsArray[i];
                obj.transform.SetParent(__instance.UIBuildablesParentOBJ.transform);
                obj.transform.SetSiblingIndex(__instance.UIBuildablesParentOBJ.transform.childCount - 2);
                obj.SetActive(value: true);
                yield return null;
            }
            while (!GameCanvas.Instance) {
                yield return null;
            }
            GameCanvas.Instance.GetComponent<Builder_Main>().ReassignBuildablesData();
        }

    }

    [HarmonyPatch("ManageExtraPerks"), HarmonyPrefix]
    private static bool ManageExtraPerksPatch(UpgradesManager __instance, int perkIndex) {
        switch (perkIndex) {
            case 5:
                NPC_Manager.Instance.extraEmployeeSpeedFactor += BetterSMT.EmployeeSpeedPerPerk.Value;
                NPC_Manager.Instance.UpdateEmployeeStats();
                break;
            case 6:
                NPC_Manager.Instance.extraCheckoutMoney += BetterSMT.EmployeExtraCheckoutMoney.Value;
                NPC_Manager.Instance.UpdateEmployeeStats();
                break;
            case 7:
                NPC_Manager.Instance.extraEmployeeSpeedFactor += BetterSMT.EmployeeSpeedPerPerk.Value;
                NPC_Manager.Instance.UpdateEmployeeStats();
                break;
            case 9:
                __instance.GetComponent<GameData>().extraCustomersPerk += BetterSMT.CustomersPerPerk.Value;
                break;
            case 10:
                __instance.GetComponent<GameData>().extraCustomersPerk += BetterSMT.CustomersPerPerk.Value;
                break;
            case 16:
                NPC_Manager.Instance.productCheckoutWait -= BetterSMT.EmployeeCheckoutPerPerk1.Value;
                break;
            case 17:
                NPC_Manager.Instance.productCheckoutWait -= BetterSMT.EmployeeCheckoutPerPerk2.Value;
                break;
            case 18:
                NPC_Manager.Instance.productCheckoutWait -= BetterSMT.EmployeeCheckoutPerPerk3.Value;
                break;
            case 19:
                NPC_Manager.Instance.employeeItemPlaceWait -= BetterSMT.EmployeeRestockPerPerk.Value;
                NPC_Manager.Instance.UpdateEmployeeStats();
                break;
            case 20:
                NPC_Manager.Instance.employeeItemPlaceWait -= BetterSMT.EmployeeRestockPerPerk.Value;
                NPC_Manager.Instance.UpdateEmployeeStats();
                break;
            case 21:
                NPC_Manager.Instance.extraEmployeeSpeedFactor += BetterSMT.EmployeeSpeedPerPerk.Value;
                NPC_Manager.Instance.UpdateEmployeeStats();
                break;
            case 22:
                NPC_Manager.Instance.extraEmployeeSpeedFactor += BetterSMT.EmployeeSpeedPerPerk.Value;
                NPC_Manager.Instance.UpdateEmployeeStats();
                break;
            case 23:
                NPC_Manager.Instance.extraEmployeeSpeedFactor += BetterSMT.EmployeeSpeedPerPerk.Value;
                NPC_Manager.Instance.UpdateEmployeeStats();
                break;
            case 25:
                NPC_Manager.Instance.selfcheckoutExtraProductsFromPerk += BetterSMT.SelfCheckoutLimit.Value;
                break;
            case 35:
                __instance.GetComponent<ProductListing>().allowedSimultaneousSales += BetterSMT.SalesAmount.Value;
                break;
            case 36:
                __instance.GetComponent<ProductListing>().allowedSimultaneousSales += BetterSMT.SalesAmount.Value;
                break;
            case 37:
                __instance.GetComponent<ProductListing>().allowedSimultaneousSales += BetterSMT.SalesAmount.Value;
                break;
            default:
                return true;
        }

        GameObject obj = __instance.UIPerksParent.transform.GetChild(perkIndex).gameObject;
        obj.GetComponent<CanvasGroup>().alpha = 1f;
        obj.tag = "Untagged";
        obj.transform.Find("Highlight2").gameObject.SetActive(value: true);

        return false;
    }
}
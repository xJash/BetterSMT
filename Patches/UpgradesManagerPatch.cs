using HarmonyLib;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(UpgradesManager))]
public class UpgradesManagerPatch {
    [HarmonyPatch(typeof(UpgradesManager))]
    [HarmonyPatch("OnStartClient")]
    public class ClockSpeedPatch {
        [HarmonyPostfix]
        public static void Postfix(UpgradesManager __instance) {
            typeof(UpgradesManager).GetField("acceleratedTimeFactor", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(__instance, BetterSMT.ClockSpeed?.Value ?? 1f);

            if (BetterSMT.AllTrashToRecyclers?.Value == true) {
                __instance.normalTrashContainerOBJ?.SetActive(false);
                __instance.recycleContainerOBJ?.SetActive(true);
                if (NPC_Manager.Instance != null) {
                    NPC_Manager.Instance.closestRecyclePerk = true;
                }
            }

        }
    }

    [HarmonyPatch("GameStartSetPerks"), HarmonyPrefix]
    private static void GameStartSetPerksPatch(UpgradesManager __instance) {
        if (BetterSMT.EnablePalletDisplaysPerk?.Value == true) {
            BetterSMT.Instance.StartCoroutine(__instance.AuxiliarSetUIPallets());
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
                __instance.GetComponent<ProductListing>().allowedSimultaneousSales += BetterSMT.SalesActiveAmount.Value;
                break;
            case 36:
                __instance.GetComponent<ProductListing>().allowedSimultaneousSales += BetterSMT.SalesActiveAmount.Value;
                break;
            case 37:
                __instance.GetComponent<ProductListing>().allowedSimultaneousSales += BetterSMT.SalesActiveAmount.Value;
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
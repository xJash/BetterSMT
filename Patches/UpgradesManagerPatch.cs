using HarmonyLib;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(UpgradesManager))]
public class UpgradesManagerPatch {

    [HarmonyPatch("ManageExtraPerks"), HarmonyPrefix]
    private static bool ManageExtraPerksPatch(UpgradesManager __instance, int perkIndex) {
        if (__instance == null) {
            Debug.LogError("UpgradesManager instance is null in ManageExtraPerksPatch.");
        }
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
using HarmonyLib;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(UpgradesManager))]
public class UpgradesManagerPatch
{
    [HarmonyPatch(typeof(UpgradesManager))]
    [HarmonyPatch("OnStartClient")]
    public class ClockSpeedPatch
    {
        [HarmonyPostfix]
        public static void Postfix(UpgradesManager __instance)
        {
            typeof(UpgradesManager)
                .GetField("acceleratedTimeFactor", BindingFlags.NonPublic | BindingFlags.Instance)?
                .SetValue(__instance, BetterSMT.ClockSpeed?.Value ?? 1f);

            if (BetterSMT.AllTrashToRecyclers?.Value == true)
            {
                __instance.normalTrashContainerOBJ?.SetActive(false);
                __instance.recycleContainerOBJ?.SetActive(true);
                if (NPC_Manager.Instance != null)
                {
                    NPC_Manager.Instance.closestRecyclePerk = true;
                }
            }

        }
    }

    [HarmonyPatch(typeof(UpgradesManager), nameof(UpgradesManager.UserCode_CmdTimeAcceleration))]
    [HarmonyPrefix]
    public static bool UserCode_CmdTimeAccelerationPatch(UpgradesManager __instance)
    {
        if (BetterSMT.ClockMorning.Value)
        {
            if (__instance.acceleratedTime || ((__instance.GetComponent<GameData>().timeOfDay > 8.01f || __instance.GetComponent<GameData>().timeOfDay < 22.4f) && !__instance.GetComponent<GameData>().isSupermarketOpen && NPC_Manager.Instance.numberOfHiredEmployees != 0 && NPC_Manager.Instance.customersnpcParentOBJ.transform.childCount <= 0))
            {


                __instance.NetworkacceleratedTime = !__instance.acceleratedTime;
                __instance.GetComponent<TimeAccelerationWatcher>().enabled = __instance.acceleratedTime;
                __instance.RpcTimeAcceleration(__instance.acceleratedTime);
                return false;
            }
        }
        return true;
    }

    [HarmonyPatch("GameStartSetPerks"), HarmonyPostfix]
    private static void GameStartSetPerksPatch(UpgradesManager __instance)
    {
        if (BetterSMT.EnablePalletDisplaysPerk?.Value == true)
        {
            _ = BetterSMT.Instance.StartCoroutine(DelayedUIPalletSetup(__instance));
        }
    }

    private static IEnumerator DelayedUIPalletSetup(UpgradesManager instance)
    {
        yield return null;
        yield return instance.AuxiliarSetUIPallets();
    }


    [HarmonyPatch("ManageExtraPerks"), HarmonyPrefix]
    private static bool ManageExtraPerksPatch(UpgradesManager __instance, int perkIndex)
    {
        #region Switch- Perks
        switch (perkIndex)
        {
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
                NPC_Manager.Instance.productCheckoutWait -= BetterSMT.EmployeeCheckoutPerPerk.Value;
                break;
            case 17:
                NPC_Manager.Instance.productCheckoutWait -= BetterSMT.EmployeeCheckoutPerPerk.Value;
                break;
            case 18:
                NPC_Manager.Instance.productCheckoutWait -= BetterSMT.EmployeeCheckoutPerPerk.Value;
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
                #endregion
        }

        GameObject obj = __instance.UIPerksParent.transform.GetChild(perkIndex).gameObject;
        obj.GetComponent<CanvasGroup>().alpha = 1f;
        obj.tag = "Untagged";
        obj.transform.Find("Highlight2").gameObject.SetActive(value: true);

        return false;
    }
}
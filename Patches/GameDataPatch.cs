using HarmonyLib;
using HighlightPlus;
using HutongGames.PlayMaker.Actions;
using Mirror;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(GameData), "WorkingDayControl")]
public class GameDataPatch
{

    [HarmonyPatch("OnStartClient"), HarmonyPostfix]
    static void OnStartClientPatch(GameData __instance)
    {
        ShowCounters();
        UpdateEscapeMenu();
    }

    [HarmonyPatch("WorkingDayControl"), HarmonyPostfix]
    static void WorkingDayControlPatch(GameData __instance)
    {
        WorkingDayLightControlPatch((__instance));
        WorkingDayEmployeeControlPatch((__instance));
        WorkingDayRentControlPatch((__instance));
    }

    [HarmonyPatch("TrashManager"), HarmonyPostfix]
    static void TrashManagerPatch(GameData __instance)
    {
        nextTimeToSpawnTrashPatch((__instance));
    }
    
    [HarmonyPatch("UserCode_CmdOpenSupermarket"), HarmonyPostfix]
    static void UserCode_CmdOpenSupermarketPatch(GameData __instance)
    {
        maxCustomersNPCsPatch((__instance));
    }

    private static void UpdateEscapeMenu()
    {
        GameObject EscapeMenu = GameObject.Find("MasterOBJ/MasterCanvas/Menus/EscapeMenu/");

        GameObject OptionsButton = EscapeMenu.transform.Find("OptionsButton").gameObject;

        GameObject QuitButton = EscapeMenu.transform.Find("QuitButton").gameObject;
        QuitButton.transform.localPosition = new Vector3(0f, 0f, 0f);
        GameObject MainMenuButton = EscapeMenu.transform.Find("MainMenuButton").gameObject;
        MainMenuButton.transform.localPosition = new Vector3(0f, 85f, 0f);

        GameObject SaveButton = Object.Instantiate(QuitButton, EscapeMenu.transform);
        SaveButton.name = "SaveButton";
        PlayMakerFSM[] PlayMakerComps = SaveButton.GetComponents<PlayMakerFSM>();
        PlayMakerComps.ToList().ForEach(Object.Destroy);
        Object.Destroy(SaveButton.GetComponent<EventTrigger>());
        SaveButton.transform.position = QuitButton.transform.position;
        SaveButton.transform.localScale = QuitButton.transform.localScale;
        SaveButton.transform.localPosition = new Vector3(0f, -85f, 0f);

        SaveButton.GetComponentInChildren<TextMeshProUGUI>().text = "Save Game";

        Button ButtonComp = SaveButton.GetComponent<Button>();
        ButtonComp.onClick.AddListener(() =>
        {
            GameData.Instance.StartCoroutine(SaveGame());
        });

        if (!GameData.Instance.isServer) SaveButton.SetActive(false);
    }

    public static IEnumerator SaveGame()
    {
        NetworkSpawner nSpawnerComponent = GameData.Instance.GetComponent<NetworkSpawner>();
        if (!nSpawnerComponent.isSaving)
        {
            BetterSMT.CreateImportantNotification("Saving Game");
            GameData.Instance.DoDaySaveBackup();
            GameData.Instance.DoDaySaveBackup();
            PlayMakerFSM fsm = GameData.Instance.SaveOBJ.GetComponent<PlayMakerFSM>();
            fsm.FsmVariables.GetFsmBool("IsSaving").Value = true;
            fsm.SendEvent("Send_Data");
            while (fsm.FsmVariables.GetFsmBool("IsSaving").Value)
            {
                yield return null;
            }
            yield return nSpawnerComponent.SavePropsCoroutine();
            BetterSMT.CreateImportantNotification("Saving Finished");
        }
        else
        {
            BetterSMT.CreateImportantNotification("Saving already in progress");
        }
    }

    public static void ShowCounters()
    {
        if (BetterSMT.ShowPing.Value)
        {
            GameObject Ping = GameObject.Find("MasterOBJ/MasterCanvas/Ping");
            if (Ping == null)
            {
                BetterSMT.Logger.LogWarning("Couldnt find Ping object");
                return;
            }
            Ping.SetActive(true);
        }
        if (BetterSMT.ShowFPS.Value)
        {
            GameObject FPSDisplay = GameObject.Find("MasterOBJ/MasterCanvas/FPSDisplay");
            if (FPSDisplay == null)
            {
                BetterSMT.Logger.LogWarning("Couldnt find FPSDisplay object");
                return;
            }
            FPSDisplay.SetActive(true);
        }
    }

    public static void WorkingDayLightControlPatch(GameData __instance)
    {
        UpgradesManager component = __instance.GetComponent<UpgradesManager>();
        if (component != null)
        {
            float actualLightCost = BetterSMT.LightCostMod.Value + (float)component.spaceBought + (float)component.storageBought;
            __instance.lightCost = actualLightCost;
        }
        else
        {
            __instance.lightCost = 10f + (float)component.spaceBought + (float)component.storageBought;
        }
    }

    public static void maxCustomersNPCsPatch(GameData __instance)
    {
        if (__instance.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(2).childCount == 0)
        {
            __instance.RpcNoCheckoutsMessage();
            return;
        }
        if (!__instance.isSupermarketOpen || __instance.timeOfDay > 23f || __instance.timeOfDay < 8f)
        {
            __instance.NetworkisSupermarketOpen = true;
            __instance.timeFactor = 1f;
            __instance.maxProductsCustomersToBuy = 5 + __instance.gameDay / 2 + NetworkServer.connections.Count + __instance.difficulty;
            __instance.maxProductsCustomersToBuy = Mathf.Clamp(__instance.maxProductsCustomersToBuy, 5, 25 + NetworkServer.connections.Count + __instance.difficulty);
            __instance.maxCustomersNPCs = 3 + __instance.gameDay + (NetworkServer.connections.Count - 1) * 4 + __instance.extraCustomersPerk + __instance.difficulty * 2;
            __instance.maxCustomersNPCs = Mathf.Clamp(__instance.maxCustomersNPCs, 160, 700 + NetworkServer.connections.Count);
            __instance.RpcOpenSupermarket();
        }
    }
    
    public static void nextTimeToSpawnTrashPatch(GameData __instance)
    {
        if (BetterSMT.DisableTrash.Value == true)
        {
            __instance.nextTimeToSpawnTrash = 99999f;
            return;
        }
    }

    public static void WorkingDayRentControlPatch(GameData __instance)
    {
        UpgradesManager component = __instance.GetComponent<UpgradesManager>();
        if (component != null)
        {
            float actualRentCost = BetterSMT.RentCostMod.Value + (float)(component.spaceBought * 5) + (float)(component.storageBought * 10);
            __instance.rentCost = actualRentCost;
        }
        else
        {
            __instance.rentCost = 10f + (float)(component.spaceBought * 5) + (float)(component.storageBought * 10);
        }
    }

    public static void WorkingDayEmployeeControlPatch(GameData __instance)
    {
        UpgradesManager component = __instance.GetComponent<UpgradesManager>();
        if (component != null)
        {
            float actualEmployeeCost = BetterSMT.EmployeeCostMod.Value + (float)(NPC_Manager.Instance.maxEmployees * 60);
            __instance.employeesCost = actualEmployeeCost;
        }
        else
        {
            __instance.employeesCost = (float)(NPC_Manager.Instance.maxEmployees * 60);
        }
    }
}
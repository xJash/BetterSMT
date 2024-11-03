using HarmonyLib;
using HighlightPlus;
using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(GameData))]
public class GameDataPatch
{
    //[HarmonyPatch("OnStartClient"), HarmonyPrefix]
    //static void OnStartClientPrePatch(GameData __instance)
    //{
    //    __instance.gameFranchisePoints += 150;
    //}

    [HarmonyPatch("OnStartClient"), HarmonyPostfix]
    static void OnStartClientPatch(GameData __instance)
    {
        ShowCounters();
        UpdateEscapeMenu();
        //__instance.StartCoroutine(OpenDoorsCoroutine());
    }

    //[HarmonyPatch("LightsOffControl"), HarmonyPostfix]
    //static void LightsOffControlPatch(GameData __instance)
    //{
    //    __instance.StartCoroutine(OpenDoorsCoroutine());
    //}

    //private static IEnumerator OpenDoorsCoroutine()
    //{
    //    yield return new WaitForSeconds(5f);
    //    OpenDoors();
    //}

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
    //public static void OpenDoors()
    //{
    //    GameObject doors = GameObject.Find("Level_Supermarket/Doors");
    //    if (doors == null)
    //    {
    //        BetterSMT.Logger.LogWarning("OpenDoors No Doors object");
    //        return;
    //    }

    //    // FIRST
    //    Transform firstSet = doors.transform.GetChild(0);
    //    if (firstSet != null)
    //    {
    //        firstSet.GetChild(0).localRotation = Quaternion.Euler(0, 270, 0);
    //        firstSet.GetChild(1).localRotation = Quaternion.Euler(0, 90, 0);
    //    }


    //    // SECOND
    //    Transform secondSet = doors.transform.GetChild(1);
    //    if (secondSet != null)
    //    {
    //        secondSet.GetChild(0).localRotation = Quaternion.Euler(0, 270, 0);
    //        secondSet.GetChild(1).localRotation = Quaternion.Euler(0, 90, 0);
    //    }


    //    // THIRD
    //    Transform thirdSet = doors.transform.GetChild(2);
    //    if (thirdSet != null)
    //    {
    //        thirdSet.GetChild(0).localRotation = Quaternion.Euler(0, 270, 0);
    //        thirdSet.GetChild(1).localRotation = Quaternion.Euler(0, 90, 0);
    //    }
    //}
}
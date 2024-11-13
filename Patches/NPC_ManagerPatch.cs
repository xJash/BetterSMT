//using HarmonyLib;
//using HighlightPlus;
//using HutongGames.PlayMaker.Actions;
//using Mirror;
//using System.Collections;
//using System.ComponentModel;
//using System.Linq;
//using TMPro;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//
//namespace BetterSMT.Patches;
//
//[HarmonyPatch(typeof(NPC_Manager))]
//public class NPC_ManagerPatch
//{
//
//    [HarmonyPatch("SpawnCustomerNCP"), HarmonyPostfix]
//    static void SpawnCustomerNCPPatch()
//    {
//        ThievesSpawningPatch();
//    }
//
//    public static void ThievesSpawningPatch()
//    {
//
//        float num4 = Random.Range(0.1f, 100f);
//        float num3;
//        //singleplayer thieves
//        if (NetworkServer.connections.Count <= 1)
//        {
//            num3 = ((float)GameData.Instance.gameDay - 7f) * 0.05f + (float)GameData.Instance.difficulty * 0.1f;
//            num3 = Mathf.Clamp(num3, 0f, 1.25f + (float)GameData.Instance.difficulty);
//        }
//        //multiplayer thieves
//        else
//        {
//            num3 = ((float)GameData.Instance.gameDay - 7f) * 0.15f + (float)GameData.Instance.difficulty * 0.15f;
//            num3 = Mathf.Clamp(num3, 0f, 2f + (float)GameData.Instance.difficulty + (float)NetworkServer.connections.Count);
//        }
//    }
//}
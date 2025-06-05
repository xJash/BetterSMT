using HarmonyLib;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using System.Reflection;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(CardboardBaler))]
public static class CardboardBalerPatch {
    private static readonly FieldInfo BoxesLimitField = typeof(CardboardBaler).GetField("boxesLimitToCreateACardboardBale", BindingFlags.NonPublic | BindingFlags.Instance);
    public static bool Prepare() => BetterSMT.CardboardBalerValue.Value != 10;

    [HarmonyPostfix]
    [HarmonyPatch(MethodType.Constructor)]
    public static void SetBoxLimitPostfix(CardboardBaler __instance) {
        BoxesLimitField?.SetValue(__instance, BetterSMT.CardboardBalerValue.Value);
    }

    [HarmonyPatch("OnStartServer")]
    [HarmonyPostfix]
    private static void OnStartServerPatch() {
        float newValue = BetterSMT.CardboardBalerValue.Value;

        if (Mathf.Approximately(newValue, 10f)) return;

        foreach (var fsm in Object.FindObjectsOfType<PlayMakerFSM>()) {
            if (fsm.FsmName != "Behaviour" || !fsm.gameObject.name.StartsWith("Trash_Recycle")) continue;

            foreach (var state in fsm.FsmStates) {
                foreach (var action in state.Actions) {
                    if (action is FloatOperator floatOp && Mathf.Approximately(floatOp.float1.Value, 18f)) floatOp.float1.Value = newValue;
                }
            }
        }
    }
}
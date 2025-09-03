using HarmonyLib;
using HutongGames.PlayMaker;
using Cinemachine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(CustomCameraController),"LateUpdate")]
public class LateUpdateRaycastPatch {
    private static bool isThirdPersonEnabled;

    private static void Postfix(CustomCameraController __instance) {
        if(__instance == null)
            return;

        var globals = FsmVariables.GlobalVariables;
        if(globals.GetFsmBool("InChat").Value
            || globals.GetFsmBool("inEvent").Value
            || globals.GetFsmBool("inOptions").Value
            || globals.GetFsmBool("isBeingPushed").Value
            || globals.GetFsmBool("inCameraEvent").Value
            || globals.GetFsmBool("inVehicle").Value
            || !BetterSMT.ThirdPersonToggle.Value) {
            return;
        }

        if(BetterSMT.ThirdPersonHotkey.Value.IsDown())
            isThirdPersonEnabled = !isThirdPersonEnabled;

        __instance.inEmoteEvent = isThirdPersonEnabled;

        if(__instance.thirdPersonFollow is Cinemachine3rdPersonFollow follow) {
            follow.CameraDistance = isThirdPersonEnabled ? 2f : 0f;
            follow.CameraCollisionFilter = isThirdPersonEnabled
                ? __instance.thirdPersonDefaultLayerMask
                : 0;
        }

        __instance.ShowCharacter(isThirdPersonEnabled);
    }
}

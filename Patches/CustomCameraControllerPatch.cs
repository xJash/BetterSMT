using HarmonyLib;
using HutongGames.PlayMaker;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(CustomCameraController), "LateUpdate")]
public class LateUpdateRaycastPatch {
    private static bool isThirdPersonEnabled = false;

    private static void Postfix(CustomCameraController __instance) {
        if (__instance == null) {
            return;
        }

        bool inChat = FsmVariables.GlobalVariables.GetFsmBool("InChat").Value;
        if (inChat || __instance.inVehicle || __instance.isInCameraEvent || !BetterSMT.ThirdPersonToggle.Value) {
            return;
        }

        if (BetterSMT.ThirdPersonHotkey.Value.IsDown()) {
            isThirdPersonEnabled = !isThirdPersonEnabled;
        }

        __instance.inEmoteEvent = isThirdPersonEnabled;

        Cinemachine.Cinemachine3rdPersonFollow follow = __instance.thirdPersonFollow;
        if (follow != null) {
            follow.CameraDistance = isThirdPersonEnabled ? 2f : 0f;
            follow.CameraCollisionFilter = isThirdPersonEnabled ? __instance.thirdPersonDefaultLayerMask : 0;
        }

        __instance.ShowCharacter(isThirdPersonEnabled);
    }
}

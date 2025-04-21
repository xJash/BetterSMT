using HarmonyLib;
using HutongGames.PlayMaker;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(CustomCameraController), "LateUpdate")]
public class LateUpdateRaycastPatch {
    private static bool isThirdPersonEnabled = false;

    private static void Postfix(CustomCameraController __instance) {
        if (FsmVariables.GlobalVariables.GetFsmBool("InChat").Value) {
            return;
        }

        if (!BetterSMT.ThirdPersonToggle.Value || __instance == null || __instance.inVehicle || __instance.isInCameraEvent) {
            return;
        }

        if (BetterSMT.ThirdPersonHotkey.Value.IsDown()) {
            isThirdPersonEnabled = !isThirdPersonEnabled;
        }

        __instance.inEmoteEvent = isThirdPersonEnabled;
        if (__instance.thirdPersonFollow != null) {
            __instance.thirdPersonFollow.CameraDistance = isThirdPersonEnabled ? 2f : 0f;
            __instance.thirdPersonFollow.CameraCollisionFilter = isThirdPersonEnabled ? __instance.thirdPersonDefaultLayerMask : 0;
        }

        __instance.ShowCharacter(isThirdPersonEnabled);
    }
}

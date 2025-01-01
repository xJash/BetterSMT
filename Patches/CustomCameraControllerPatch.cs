using HarmonyLib;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(CustomCameraController), "LateUpdate")]
public class LateUpdateRaycastPatch {


    private static bool isThirdPersonEnabled = false;

    private static void Postfix(CustomCameraController __instance) {
        if (BetterSMT.ThirdPersonToggle.Value == true) {
            if (__instance == null || __instance.inVehicle || __instance.isInCameraEvent) {
                return;
            }

            if (BetterSMT.ThirdPersonHotkey.Value.IsDown()) {
                isThirdPersonEnabled = !isThirdPersonEnabled;
            }

            if (isThirdPersonEnabled) {
                __instance.inEmoteEvent = true;
                if (__instance.thirdPersonFollow != null) {
                    __instance.thirdPersonFollow.CameraDistance = 2f;
                    __instance.thirdPersonFollow.CameraCollisionFilter = __instance.thirdPersonDefaultLayerMask;
                }
                __instance.ShowCharacter(true);
            } else {
                __instance.inEmoteEvent = false;
                if (__instance.thirdPersonFollow != null) {
                    __instance.thirdPersonFollow.CameraDistance = 0f;
                    __instance.thirdPersonFollow.CameraCollisionFilter = 0;
                }
                __instance.ShowCharacter(false);
            }
        }
    }
}

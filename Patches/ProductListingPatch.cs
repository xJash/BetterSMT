using HarmonyLib;
using HutongGames.PlayMaker;
using Mirror;
using UnityEngine;

namespace BetterSMT.Patches {
    [HarmonyPatch(typeof(ProductListing))]
    public class ProductListingPatch {
        public static KeyCode ManualSaleClearKey = KeyCode.U;
        private static bool _hasPatched = false;

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ProductListing), "OnStartClient")]
        public static void Postfix(ProductListing __instance) {
            if (_hasPatched) {
                return;
            }

            _hasPatched = true;

            foreach (GameObject prefab in __instance.productPrefabs) {
                Data_Product data = prefab.GetComponent<Data_Product>();
                if (data != null) {
                    data.maxItemsPerBox *= BetterSMT.MaxBoxSize.Value;
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        public static void CaptureInstance(ProductListing __instance) {
            if (__instance.isLocalPlayer) {
                ProductListing.Instance = __instance;
            }
        }
    }

    public class ManualSaleClearHotkeyListener : MonoBehaviour {
        private void Update() {
            if (!BetterSMT.ToggleClearSalesHotkey.Value) return;

            if (FsmVariables.GlobalVariables.GetFsmBool("InChat").Value) return;

            if (Input.GetKeyDown(BetterSMT.ClearSales.Value.MainKey)) {
                SaleResetCommandPatch.TriggerManualSaleClear();
            }
        }
    }

    public static class SaleResetCommandPatch {
        public static void TriggerManualSaleClear() {
            if (!NetworkClient.active) {
                return;
            }

            if (ProductListing.Instance == null) {
                return;
            }

            ProductListing.Instance.CmdClearSalesManually();
        }
    }

    public static class ProductListingExtension {
        [Command(requiresAuthority = false)]
        public static void CmdClearSalesManually(this ProductListing self) {
            BetterSMT.CreateImportantNotification("Sales have been cleared.");
            self.productsIDOnSale.Clear();
            self.productsSaleDiscount.Clear();
            self.ServerClearSalesSyncvar();
            self.UpdateShelvesSaleSigns();
        }
    }
}
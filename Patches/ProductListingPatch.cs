using HarmonyLib;
using HutongGames.PlayMaker;
using Mirror;
using UnityEngine;

namespace BetterSMT.Patches {
    [HarmonyPatch(typeof(ProductListing))]
    public class ProductListingPatch {
        public static KeyCode ManualSaleClearKey = KeyCode.U;

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ProductListing),"OnStartClient")]
        public static void Postfix(ProductListing __instance) {
            if(BetterSMT.MaxBoxSize.Value == (int)BetterSMT.MaxBoxSize.DefaultValue) {
                return;
            }

            foreach(GameObject prefab in __instance.productPrefabs) {
                if(prefab == null) {
                    continue;
                }
                Data_Product data = prefab.GetComponent<Data_Product>();
                data.maxItemsPerBox *= BetterSMT.MaxBoxSize.Value;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        public static void CaptureInstance(ProductListing __instance) {

            ProductListing.Instance = __instance;
        }
    }

    public class ManualSaleClearHotkeyListener : MonoBehaviour {
        private void Update() {
            FsmVariables globals = FsmVariables.GlobalVariables;
            if(globals.GetFsmBool("InChat").Value
                || globals.GetFsmBool("inEvent").Value
                || globals.GetFsmBool("inOptions").Value
                || globals.GetFsmBool("isBeingPushed").Value
                || globals.GetFsmBool("inCameraEvent").Value
                || globals.GetFsmBool("inVehicle").Value
                || !BetterSMT.ToggleClearSalesHotkey.Value) {
                return;
            }

            if(Input.GetKeyDown(BetterSMT.ClearSales.Value.MainKey)) {
                SaleResetCommandPatch.TriggerManualSaleClear();
            }

        }
    }

    public static class SaleResetCommandPatch {
        public static void TriggerManualSaleClear() {

            if(!NetworkClient.active) {
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
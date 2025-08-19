using HarmonyLib;
using HutongGames.PlayMaker;
using Mirror;
using UnityEngine;

namespace BetterSMT.Patches
{
    [HarmonyPatch(typeof(ProductListing))]
    public class ProductListingPatch
    {
        public static KeyCode ManualSaleClearKey = KeyCode.U;
        private static bool _hasPatched = false;

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ProductListing), "OnStartClient")]
        public static void Postfix(ProductListing __instance)
        {
            try
            {
                if (_hasPatched || __instance == null || __instance.productPrefabs == null)
                {
                    if (__instance == null)
                    {
                        BetterSMT.Logger?.LogWarning("[ProductListingPatch] __instance is null in OnStartClient.");
                    }
                    if (__instance?.productPrefabs == null)
                    {
                        BetterSMT.Logger?.LogWarning("[ProductListingPatch] productPrefabs is null in OnStartClient.");
                    }
                    return;
                }

                _hasPatched = true;

                foreach (GameObject prefab in __instance.productPrefabs)
                {
                    if (prefab == null)
                    {
                        BetterSMT.Logger?.LogWarning("[ProductListingPatch] Found null prefab in productPrefabs.");
                        continue;
                    }

                    Data_Product data = prefab.GetComponent<Data_Product>();
                    if (data != null)
                    {
                        data.maxItemsPerBox *= BetterSMT.MaxBoxSize.Value;
                    }
                    else
                    {
                        BetterSMT.Logger?.LogWarning($"[ProductListingPatch] Missing Data_Product on prefab '{prefab.name}'");
                    }
                }
            }
            catch (System.Exception ex)
            {
                BetterSMT.Logger?.LogError($"[ProductListingPatch.OnStartClient Postfix] Exception: {ex}");
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        public static void CaptureInstance(ProductListing __instance)
        {
            try
            {
                if (__instance != null && __instance.isLocalPlayer)
                {
                    ProductListing.Instance = __instance;
                }
            }
            catch (System.Exception ex)
            {
                BetterSMT.Logger?.LogError($"[ProductListingPatch.CaptureInstance] Exception: {ex}");
            }
        }
    }

    public class ManualSaleClearHotkeyListener : MonoBehaviour
    {
        private void Update()
        {
            try
            {
                if (!BetterSMT.ToggleClearSalesHotkey.Value)
                {
                    return;
                }

                if (FsmVariables.GlobalVariables.GetFsmBool("InChat").Value)
                {
                    return;
                }

                if (Input.GetKeyDown(BetterSMT.ClearSales.Value.MainKey))
                {
                    SaleResetCommandPatch.TriggerManualSaleClear();
                }
            }
            catch (System.Exception ex)
            {
                BetterSMT.Logger?.LogError($"[ManualSaleClearHotkeyListener.Update] Exception: {ex}");
            }
        }
    }

    public static class SaleResetCommandPatch
    {
        public static void TriggerManualSaleClear()
        {
            try
            {
                if (!NetworkClient.active)
                {
                    return;
                }

                if (ProductListing.Instance == null)
                {
                    BetterSMT.Logger?.LogWarning("[SaleResetCommandPatch] ProductListing.Instance is null.");
                    return;
                }

                ProductListing.Instance.CmdClearSalesManually();
            }
            catch (System.Exception ex)
            {
                BetterSMT.Logger?.LogError($"[SaleResetCommandPatch.TriggerManualSaleClear] Exception: {ex}");
            }
        }
    }

    public static class ProductListingExtension
    {
        [Command(requiresAuthority = false)]
        public static void CmdClearSalesManually(this ProductListing self)
        {
            try
            {
                BetterSMT.CreateImportantNotification("Sales have been cleared.");
                self.productsIDOnSale.Clear();
                self.productsSaleDiscount.Clear();
                self.ServerClearSalesSyncvar();
                self.UpdateShelvesSaleSigns();
            }
            catch (System.Exception ex)
            {
                BetterSMT.Logger?.LogError($"[ProductListingExtension.CmdClearSalesManually] Exception: {ex}");
            }
        }
    }
}

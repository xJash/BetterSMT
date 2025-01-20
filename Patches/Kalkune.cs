//using BepInEx;
//using BepInEx.Configuration;
//using HarmonyLib;
//using System;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//
//namespace BetterSMT.Patches {
//    [HarmonyPatch(typeof(GameCanvas))]
//    internal class NotificationHandler2 {
//        [HarmonyPatch("Update")]
//        [HarmonyPostfix]
//        public static void NotificationHandler_Postfix(GameCanvas __instance, ref bool ___inCooldown) {
//            if (BulkPurchasePlus.BulkPurchasePlus.notificationSent) {
//                ___inCooldown = false;
//                BulkPurchasePlus.BulkPurchasePlus.notificationSent = false;
//                string text = "`";
//                switch (BulkPurchasePlus.BulkPurchasePlus.currentMode) {
//                    case 1:
//                        text += "Threshold: Shelves Filled";
//                        break;
//                    case 2:
//                        text += "Threshold: " + BulkPurchasePlus.BulkPurchasePlus.HardThreshold.Value + " On Shelf";
//                        break;
//                    case 3:
//                        text += "Threshold: Shelf Mixed";
//                        break;
//                    case 4:
//                        text += "Threshold: " + BulkPurchasePlus.BulkPurchasePlus.StorageThreshold.Value + " Product In Storage";
//                        break;
//                    case 5:
//                        text += "Threshold: " + BulkPurchasePlus.BulkPurchasePlus.StorageBoxThreshold.Value + " Boxes In Storage";
//                        break;
//                    case 6:
//                        text += "Threshold: Storage Mixed";
//                        break;
//                }
//                __instance.CreateCanvasNotification(text);
//            }
//        }
//        [HarmonyPatch(typeof(LocalizationManager))]
//        internal class LocalizationHandler {
//            [HarmonyPatch("GetLocalizationString")]
//            [HarmonyPrefix]
//            public static bool NoLocalization_Prefix(ref string key, ref string __result) {
//                if (key[0] == '`') {
//                    __result = key[1..];
//                    return false;
//                }
//                return true;
//            }
//        }
//    }
//    [HarmonyPatch(typeof(PlayerNetwork), nameof(PlayerNetwork.OnStartClient))]
//    public class AddButton {
//        public static bool Prefix() {
//            // Find the Buttons_Bar GameObject
//            GameObject buttonsBar = GameObject.Find("Buttons_Bar");
//
//            if (buttonsBar == null) {
//                return true;
//            }
//
//            // Create the "Add All to Cart" button if it doesn't exist
//            if (buttonsBar.transform.Find("AddAllToCartButton") == null) {
//                GameObject addAllButton = CreateButton(buttonsBar, "AddAllToCartButton", -450, 110); // Full width
//                AddButtonEvents(addAllButton.GetComponent<Button>(), addAllButton.GetComponent<Image>(), OnAddAllToCartButtonClick);
//            }
//
//            // Create the "Remove All from Cart" button if it doesn't exist
//            if (buttonsBar.transform.Find("RemoveAllFromCartButton") == null) {
//                GameObject removeAllButton = CreateButton(buttonsBar, "RemoveAllFromCartButton", 425, 110); // Shifted 800 units to the right
//                AddButtonEvents(removeAllButton.GetComponent<Button>(), removeAllButton.GetComponent<Image>(), OnRemoveAllFromCartButtonClick);
//            }
//
//            // Create the new button if it doesn't exist
//            if (buttonsBar.transform.Find("NeedsOnlyButton") == null) {
//                // Position this button 50px to the right of the "AddAllToCartButton"
//                GameObject newButton = CreateButton(buttonsBar, "NeedsOnlyButton", -325, 55); // Half width, 50px right
//                AddButtonEvents(newButton.GetComponent<Button>(), newButton.GetComponent<Image>(), OnNeedsOnlyButtonClick);
//            }
//
//            return true;
//        }
//
//        private static GameObject CreateButton(GameObject parent, string name, float xOffset, float width) {
//            // Create the button GameObject
//            GameObject buttonObject = new(name);
//            RectTransform rectTransform = buttonObject.AddComponent<RectTransform>();
//            _ = buttonObject.AddComponent<Button>();
//            _ = buttonObject.AddComponent<Image>();
//
//            // Set the button's parent to Buttons_Bar
//            buttonObject.transform.SetParent(parent.transform, false);
//
//            // Set up RectTransform properties
//            rectTransform.sizeDelta = new Vector2(width, 35); // Adjust width here
//            rectTransform.anchoredPosition = new Vector2(xOffset, 612);
//            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
//            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
//            rectTransform.pivot = new Vector2(0.5f, 0.5f);
//
//            // Create and configure the text component
//            GameObject textObject = new("ButtonText");
//            textObject.transform.SetParent(buttonObject.transform, false);
//
//            RectTransform textRectTransform = textObject.AddComponent<RectTransform>();
//            Text textComponent = textObject.AddComponent<Text>();
//
//            textRectTransform.sizeDelta = rectTransform.sizeDelta;
//            textRectTransform.anchoredPosition = Vector2.zero;
//
//            textComponent.text = name == "AddAllToCartButton" ? "Add All to Cart" :
//                                  name == "RemoveAllFromCartButton" ? "Remove All from Cart" : "Needs Only Button";
//            textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
//            textComponent.alignment = TextAnchor.MiddleCenter;
//            textComponent.color = Color.black;
//            textComponent.fontStyle = FontStyle.Bold;
//
//            return buttonObject;
//        }
//
//        private static void AddButtonEvents(Button button, Image buttonImage, UnityEngine.Events.UnityAction onClickAction) {
//            EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
//
//            // Hover enter event
//            EventTrigger.Entry pointerEnter = new() {
//                eventID = EventTriggerType.PointerEnter
//            };
//            pointerEnter.callback.AddListener((data) => OnHoverEnter(buttonImage));
//            trigger.triggers.Add(pointerEnter);
//
//            // Hover exit event
//            EventTrigger.Entry pointerExit = new() {
//                eventID = EventTriggerType.PointerExit
//            };
//            pointerExit.callback.AddListener((data) => OnHoverExit(buttonImage));
//            trigger.triggers.Add(pointerExit);
//
//            // Click event (only triggers if hovered)
//            button.onClick.AddListener(() => {
//                if (buttonImage.color != Color.white) {
//                    onClickAction.Invoke();
//                }
//            });
//        }
//
//        private static void OnHoverEnter(Image buttonImage) {
//            buttonImage.color = new Color(5f / 255f, 133f / 255f, 208f / 255f); // Light blue hover color
//        }
//
//        private static void OnHoverExit(Image buttonImage) {
//            buttonImage.color = Color.white; // Revert color when not hovering
//        }
//
//        private static void OnAddAllToCartButtonClick() {
//            ProductListing productListing = UnityEngine.Object.FindFirstObjectByType<ProductListing>();
//            ManagerBlackboard managerBlackboard = UnityEngine.Object.FindFirstObjectByType<ManagerBlackboard>();
//
//            if (productListing == null || managerBlackboard == null) {
//                return;
//            }
//
//            foreach (GameObject productPrefab in productListing.productPrefabs) {
//                Data_Product productComponent = productPrefab.GetComponent<Data_Product>();
//                if (productComponent != null && productListing.unlockedProductTiers[productComponent.productTier]) {
//                    float boxPrice = productComponent.basePricePerUnit * productComponent.maxItemsPerBox;
//                    boxPrice *= productListing.tierInflation[productComponent.productTier];
//                    float roundedBoxPrice = Mathf.Round(boxPrice * 100f) / 100f;
//                    managerBlackboard.AddShoppingListProduct(productComponent.productID, roundedBoxPrice);
//                }
//            }
//        }
//
//        private static void OnRemoveAllFromCartButtonClick() {
//            ManagerBlackboard managerBlackboard = UnityEngine.Object.FindFirstObjectByType<ManagerBlackboard>();
//
//            if (managerBlackboard == null) {
//                return;
//            }
//
//            int itemCount = managerBlackboard.shoppingListParent.transform.childCount;
//            for (int i = itemCount - 1; i >= 0; i--) {
//                managerBlackboard.RemoveShoppingListProduct(i);
//            }
//        }
//
//        private static void OnNeedsOnlyButtonClick() {
//            ProductListing productListing = UnityEngine.Object.FindFirstObjectByType<ProductListing>();
//            ManagerBlackboard managerBlackboard = UnityEngine.Object.FindFirstObjectByType<ManagerBlackboard>();
//
//            if (productListing == null || managerBlackboard == null) {
//                return;
//            }
//
//            // Define your threshold for product existence
//
//            foreach (GameObject productPrefab in productListing.productPrefabs) {
//                Data_Product productComponent = productPrefab.GetComponent<Data_Product>();
//                if (productComponent != null && productListing.unlockedProductTiers[productComponent.productTier]) {
//                    int productID = productComponent.productID;
//                    // Get the count of existing products
//                    int[] productExistences = managerBlackboard.GetProductsExistences(productID);
//                    int totalExistence = 0;
//                    foreach (int count in productExistences) {
//                        totalExistence += count;
//                    }
//
//                    bool order = CheckOrderAviablility(totalExistence, productID, BulkPurchasePlus.BulkPurchasePlus.currentMode, productComponent);
//
//                    if (order) {
//                        float boxPrice = productComponent.basePricePerUnit * productComponent.maxItemsPerBox;
//                        boxPrice *= productListing.tierInflation[productComponent.productTier];
//                        float roundedBoxPrice = Mathf.Round(boxPrice * 100f) / 100f;
//                        managerBlackboard.AddShoppingListProduct(productID, roundedBoxPrice);
//                    }
//
//                }
//            }
//        }
//
//
//        public static bool CheckOrderAviablility(int totalExistence, int productID, int orderNumber, Data_Product productComponent) {
//            bool order = false;
//            switch (orderNumber) {
//                case 1:
//                    if (totalExistence < BulkPurchasePlus.BulkPurchasePlus.somethingsomething(NPC_Manager.Instance, productID)) {
//                        order = true;
//                    }
//
//                    break;
//                case 2:
//                    if (totalExistence < BulkPurchasePlus.BulkPurchasePlus.threshold) {
//                        order = true;
//                    }
//
//                    break;
//                case 3:
//                    if (CheckOrderAviablility(totalExistence, productID, 1, productComponent) && CheckOrderAviablility(totalExistence, productID, 2, productComponent)/*totalExistence < BulkPurchasePlus.BulkPurchasePlus.threshold && //totalExistence <= BulkPurchasePlus.BulkPurchasePlus.somethingsomething(NPC_Manager.Instance, productID)*/) {
//                        order = true;
//                    }
//
//                    break;
//                case 4:
//                    if (totalExistence < BulkPurchasePlus.BulkPurchasePlus.somethingsomething(NPC_Manager.Instance, productID) + BulkPurchasePlus.BulkPurchasePlus.StorageThreshold.Value) {
//                        order = true;
//                    }
//
//                    break;
//                case 5:
//                    if (totalExistence < BulkPurchasePlus.BulkPurchasePlus.somethingsomething(NPC_Manager.Instance, productID) + (BulkPurchasePlus.BulkPurchasePlus.StorageBoxThreshold.Value * productComponent.maxItemsPerBox)) {
//                        order = true;
//                    }
//
//                    break;
//                case 6:
//                    if (CheckOrderAviablility(totalExistence, productID, 4, productComponent) && CheckOrderAviablility(totalExistence, productID, 5, productComponent)) {
//                        order = true;
//                    }
//
//                    break;
//            }
//            return order;
//        }
//    }
//}
//
//namespace BulkPurchasePlus {
//    [BepInPlugin("com.Kalkune.BulkPurchasePlus", "BulkPurchasePlus", "1.0.1")]
//    public class BulkPurchasePlus : BaseUnityPlugin {
//
//        internal static Harmony Harmony;
//        public static ConfigEntry<int> HardThreshold { get; set; }
//        public static ConfigEntry<int> StorageThreshold { get; set; }
//        public static ConfigEntry<int> StorageBoxThreshold { get; set; }
//        public static ConfigEntry<KeyboardShortcut> KeyboardShortcutDoublePrice { get; set; }
//        public static int threshold;
//        public static int currentMode = 1;
//        public static bool notificationSent = false;
//        public static string notificationMessage;
//        public void Awake() {
//            HardThreshold = Config.Bind("Threshold", "Hard Threshold Cap", 50, "Products with quantity above this number won't be ordered with Needs Only if on alternate modes.");
//            StorageThreshold = Config.Bind("Threshold", "Storage Threshold Cap", 30, "Products with quantity above this number won't be ordered with Product Storage Mode.");
//            StorageBoxThreshold = Config.Bind("Threshold", "Storage Box Threshold Cap", 4, "Products with box quantity above this number won't be ordered with Box Storage Mode.");
//            KeyboardShortcutDoublePrice = Config.Bind("Threshold", "Toggle Threshold Keybind", new KeyboardShortcut((KeyCode)114, Array.Empty<KeyCode>()), "");
//            threshold = HardThreshold.Value;
//            Harmony = new("com.Kalkune.BulkPurchasePlus");
//            Harmony.PatchAll();
//        }
//        public void Update() {
//            KeyboardShortcut value = KeyboardShortcutDoublePrice.Value;
//            if (value.IsDown()) {
//                if (currentMode >= 6) {
//                    currentMode = 1;
//                } else {
//                    currentMode++;
//                }
//
//                notificationMessage = "ThresholdToggle";
//                notificationSent = true;
//                return;
//            }
//        }
//
//        public static int somethingsomething(NPC_Manager __instance, int productId) {
//            if (__instance.shelvesOBJ.transform.childCount == 0) {
//                return 0;
//            }
//
//            int productCount = 0;
//            int productQuantity = 0;
//
//            for (int i = 0; i < __instance.shelvesOBJ.transform.childCount; i++) {
//                int[] productInfoArray = __instance.shelvesOBJ.transform.GetChild(i).GetComponent<Data_Container>().productInfoArray;
//                int num = productInfoArray.Length / 2;
//                for (int j = 0; j < num; j++) {
//
//                    int storageProductId = productInfoArray[j * 2];
//                    //int productQuantity = productInfoArray[j * 2 + 1];
//
//                    if (storageProductId == productId) {
//                        productCount++;
//                    }
//                    Data_Container shelfinfo = __instance.shelvesOBJ.transform.GetChild(i).GetComponent<Data_Container>();
//                    GameObject gameObject = shelfinfo.productlistComponent.productPrefabs[productId];
//                    Vector3 size = gameObject.GetComponent<BoxCollider>().size;
//
//                    bool isStackable = gameObject.GetComponent<Data_Product>().isStackable;
//                    int num1 = Mathf.FloorToInt(shelfinfo.shelfLength / (size.x * 1.1f));
//                    num1 = Mathf.Clamp(num1, 1, 100);
//                    int num2 = Mathf.FloorToInt(shelfinfo.shelfWidth / (size.z * 1.1f));
//                    num2 = Mathf.Clamp(num2, 1, 100);
//                    int num3 = num1 * num2;
//                    if (isStackable) {
//                        int num4 = Mathf.FloorToInt(shelfinfo.shelfHeight / (size.y * 1.1f));
//                        num4 = Mathf.Clamp(num4, 1, 100);
//                        num3 = num1 * num2 * num4;
//                    }
//                    productQuantity += num3 * productCount;
//                    productCount = 0;
//
//                }
//            }
//            return productQuantity;
//        }
//    }
//}
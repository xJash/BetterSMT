using HarmonyLib;
using HighlightPlus;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(PlayerNetwork))]
public class PlayerNetworkPatch {
    public static readonly Dictionary<int, string> productNames = new() { { 0, "Pasta Penne" }, { 1, "Water Bottle" }, { 2, "Honey Cereals" }, { 3, "Rice" }, { 4, "Salt" }, { 5, "Sugar" }, { 6, "Margarine" }, { 7, "Flour" }, { 8, "Apple Juice" }, { 9, "Olive Oil" }, { 10, "Ketchup" }, { 11, "Sliced Bread" }, { 12, "Pepper" }, { 13, "Orange Juice" }, { 14, "Barbaque Sauce" }, { 15, "Mustard Sauce" }, { 16, "Spaghetti Box" }, { 17, "Tuna Pate" }, { 18, "Fiber Cereals" }, { 19, "Supreme Flour" }, { 20, "Black Coffee" }, { 21, "Egg Box" }, { 22, "Houmous" }, { 23, "White Flour" }, { 24, "Cane Sugar Box" }, { 25, "Sugar" }, { 26, "Macarroni" }, { 27, "Ecologic Sugar" }, { 28, "Brown Sugar" }, { 29, "Sunflower Oil" }, { 30, "Mash Potatoes" }, { 31, "Potato Bag" }, { 32, "Espresso Coffee" }, { 33, "Basmati Rice" }, { 34, "Long Grain Rice" }, { 35, "Coffee" }, { 36, "Supreme Pasta" }, { 37, "Chocolate Cereals" }, { 38, "Premium Water" }, { 39, "Spring Water" }, { 40, "Powdered Sugar" }, { 41, "Sugar - Big Box" }, { 42, "Brown Sugar - Big Box" }, { 43, "Emmental Cheese" }, { 44, "Gruyere Cheese" }, { 45, "Skimmed Cheese" }, { 46, "Fruit Yoghurt" }, { 47, "Vanilla Yoghurt" }, { 48, "Milk Brick" }, { 49, "Butter" }, { 50, "Parmigiano Cheese" }, { 51, "Reggiano Cheese" }, { 52, "Mozzarella Cheese" }, { 53, "Skimmed Yoghurt" }, { 54, "Cola Pack" }, { 55, "Soda Pack" }, { 56, "Decaf Soda Pack" }, { 57, "Soda Bottle" }, { 58, "Cola Bottle" }, { 59, "Sugar Free Soda Bottle" }, { 60, "Premium Soda" }, { 61, "Pizza Barbaque" }, { 62, "Fondue" }, { 63, "Crocanti Ham" }, { 64, "Ham Cheese Crepe" }, { 65, "French Fries" }, { 66, "Crispy Potato Pops" }, { 67, "Green Beans" }, { 68, "Four Cheese Pizza" }, { 69, "Four Seasons Pizza" }, { 70, "Vegetable Mix" }, { 71, "Chicken Mix" }, { 72, "Bolognaise Lasagna" }, { 73, "Vegetable Lasagna" }, { 74, "Toothpaste" }, { 75, "Toilet Paper" }, { 76, "Hand Soap" }, { 77, "Avocado Shampoo" }, { 78, "Egg Shampoo" }, { 79, "Bath Gel" }, { 80, "Toilet Paper" }, { 81, "Mango Soap" }, { 82, "Extra Soft Shampoo" }, { 83, "Jojoba Honey Shampoo" }, { 84, "Argan Oil Shampoo" }, { 85, "Paper Towel" }, { 86, "Double Side Toilet Paper" }, { 87, "Lemon Soap" }, { 88, "Premium Bath Gel" }, { 89, "Shampoo For Babies" }, { 90, "Detergent" }, { 91, "Stain Remover" }, { 92, "Glass Cleaner" }, { 93, "Detergent Tables" }, { 94, "Dishwasher" }, { 95, "Bleach" }, { 96, "Bleach - Big Bottle" }, { 97, "Softener" }, { 98, "Premium Detergent" }, { 99, "Insecticide" }, { 100, "Cleaning Cloths" }, { 101, "Premium Capsules" }, { 102, "Premium Bleach" }, { 103, "Ammonia" }, { 104, "Cookie Jar" }, { 105, "Maxi Cone" }, { 106, "Chocolate Spread" }, { 107, "Chocolate Powder" }, { 108, "Chips" }, { 109, "Sweet Bonbek" }, { 110, "Peach Jam" }, { 111, "Ice Cream Box" }, { 112, "Chocolate Box" }, { 113, "Chocolate Biscuit" }, { 114, "Vanilate Biscuit" }, { 115, "Madeleine" }, { 116, "Strawberry Jam" }, { 117, "Peanut Butter" }, { 118, "Chipos" }, { 119, "Marshmallow" }, { 120, "Lemon Biscuit" }, { 121, "Hazelnut Biscuit" }, { 122, "Premium Ice Cream" }, { 123, "Honey" }, { 124, "Premium Chocolate Box" }, { 125, "Foditos" }, { 126, "Premium Cake" }, { 127, "Chopped Beef" }, { 128, "Pure Beef" }, { 129, "Veal" }, { 130, "Chicken Wings" }, { 131, "Chicken" }, { 132, "Parma Ham" }, { 133, "Sliced Ham" }, { 134, "Peas - Big" }, { 135, "Tuna - Big" }, { 136, "Red Beans" }, { 137, "Cat Food" }, { 138, "Cat Food" }, { 139, "Dog Food" }, { 140, "Green Tea" }, { 141, "Lemon Tea" }, { 142, "Black Tea" }, { 143, "Peppermint" }, { 144, "Mint" }, { 145, "Valerian" }, { 146, "Big Sushi" }, { 147, "Small Sushi" }, { 148, "Smoked Salmon" }, { 149, "Crab Sticks" }, { 150, "Book - Electromagnetic" }, { 151, "Book - Surprise" }, { 152, "Book - ABC" }, { 153, "Book - Mother And Child" }, { 154, "Book - Colors" }, { 155, "Book - Piticha" }, { 156, "Book - OnceUpon" }, { 157, "Book - Krok" }, { 158, "Book - Adventures" }, { 159, "Book - Donnine" }, { 160, "Book - Vintage" }, { 161, "Book - I Wont Share" }, { 162, "Beer Pack" }, { 163, "Beer Pack" }, { 164, "Beer Pack" }, { 165, "Beer Barrel" }, { 166, "Beer Barrel" }, { 167, "Vodka" }, { 168, "Red Wine" }, { 169, "Rose Wine" }, { 170, "White Wine" }, { 171, "Beer Barrel" }, { 172, "Premium Vodka" }, { 173, "Japanese Whisky" }, { 174, "Premium Whisky" }, { 175, "Premium Whisky" }, { 176, "Hydrogen Peroxide" }, { 177, "Disinfectant" }, { 178, "Ibuprofen" }, { 179, "Paracetamol" }, { 180, "Adhesive Bandages" }, { 181, "Laxative" }, { 182, "Antihistamine" }, { 183, "Zinc Supplement" }, { 184, "Antioxidant" }, { 185, "Fish Oil" }, { 186, "Algae Pills" }, { 187, "Vitamins" }, { 188, "Melatonin" }, { 189, "Sunscreen" }, { 190, "Stretch Cream" }, { 191, "Red Apple Tray" }, { 192, "Green Apple Tray" }, { 193, "Clementine Tray" }, { 194, "Orange Tray" }, { 195, "Pear Tray" }, { 196, "Lemon Tray" }, { 197, "Mango Tray" }, { 198, "Avocado Tray" }, { 199, "Kiwi Tray" }, { 200, "Papaya Tray" }, { 201, "Strawberry Tray" }, { 202, "Cherry Tray" }, { 203, "Artichoke Tray" }, { 204, "Zucchini Tray" }, { 205, "Carrot Tray" }, { 206, "Tomato Tray" }, { 207, "Potato Tray" }, { 208, "Onion Tray" }, { 209, "Banana Pack" }, { 210, "Melon" }, { 211, "Pineapple" }, { 212, "Pumpkin" }, { 213, "Watermelon" }, { 214, "Baby Food: Vegetables" }, { 215, "Baby Food: Fish" }, { 216, "Baby Food: Fruits" }, { 217, "Baby Food: Meat" }, { 218, "Nutritive Milk Mix" }, { 219, "Nutritive Milk Powder" }, { 220, "Ecologic Diapers" }, { 221, "Basic Diapers" }, { 222, "Toddler Diapers" }, { 223, "Premium Diapers" }, { 224, "Aloe Baby Wipes " }, { 225, "Basic Baby Wipes" }, { 226, "Baby Powder" }, { 227, "Orange Soda" }, { 228, "Pineapple Soda" }, { 229, "Tropical Soda" }, { 230, "Green Tea Drink" }, { 231, "Red Tea Drink" }, { 232, "Lemon Tea Drink" }, { 233, "Cold Brew Coffee" }, { 234, "Blueberry Energy Drink" }, { 235, "Guava Energy Drink" }, { 236, "Lima Energy Drink" }, { 237, "Fruit Punch Energy Drink" }, { 238, "Mango Energy Drink" }, { 239, "Cola Energy Drink" }, { 240, "Sugar Free Energy Drink" }, { 241, "Basic Strawberry Ice Cream" }, { 242, "Lemon Ice Cream" }, { 243, "Coffee Ice Cream" }, { 244, "Stracciatella Ice Cream" }, { 245, "Strawberry Meringue Ice Cream" }, { 246, "Caramel Ice Cream" }, { 247, "Premium Strawberry Ice Cream" }, { 248, "Strawberry Cheesecake Ice Cream" }, { 249, "Premium Caramel Ice Cream" }, { 250, "Pink Strawberry Ice Cream" }, { 251, "Alcoholic Ice Cream" }, { 252, "Chickpeas" }, { 253, "Meatballs" }, { 254, "Lentils" }, { 255, "Tomato Soup" }, { 256, "Canned Corn" }, { 257, "Canned Peas" }, { 258, "Strawberry Seeds" }, { 259, "Raspberry Seeds" }, { 260, "Blueberry Seeds" }, { 261, "Pineapple Seeds" }, { 262, "Meyer Lemon Seeds" }, { 263, "Tomato Seeds" }, { 264, "Pepper Seeds" }, { 265, "Cucumber Seeds" }, { 266, "Radish Seeds" }, { 267, "Carrots Seeds" }, { 268, "Lawn Seeds" }, { 269, "Poppy Seeds" }, { 270, "Tulip Seeds" }, { 271, "Sunflower Seeds" }, { 272, "Petunia Seeds" }, { 273, "Hand Rake (A)" }, { 274, "Hand Rake (B)" }, { 275, "Hand Shovel" }, { 276, "Hand Cultivator" }, { 277, "Potting Soil" }, { 278, "Fertilizer" }, { 279, "Plant Pot Dish" }, { 280, "Plant Pot" }, { 281, "AA Batteries" }, { 282, "AAA Batteries" }, { 283, "C Batteries" }, { 284, "9V Batteries" }, { 285, "Universal TV Remote" }, { 286, "Universal Phone Charger" }, { 287, "Basic Prepaid Phone" }, { 288, "Basic Mouse" }, { 289, "Wifi Dongle" }, { 290, "Basic Earbuds" }, { 291, "Basic Keyboard" }, { 292, "Basic Gamepad" }, { 293, "USB Flash Drive (128GB)" }, { 294, "USB Flash Drive (256GB)" }, { 295, "USB Flash Drive (512GB)" }, { 296, "USB Flash Drive (1TB)" }, { 297, "Basic Speaker" }, { 298, "Basic Headphones" }, { 299, "Basic Gaming Console" } };

    private static readonly Stopwatch stopwatch = new();
    private static PlayerNetwork pNetwork = null;
    private static UpgradesManager upgradesManager;
    public enum ShelfType {
        ProductDisplay,
        Storage
    }

    private struct ShelfData {
        public string highlightsName;
        public string highlightsOriginalName;
        public ShelfType shelfType;

        public ShelfData(ShelfType shelfType) {
            if (shelfType == ShelfType.ProductDisplay) {
                highlightsName = "Labels";
                highlightsOriginalName = "";
                this.shelfType = ShelfType.ProductDisplay;
            } else {
                highlightsName = "HighlightsMarker";
                highlightsOriginalName = "Highlights";
                this.shelfType = ShelfType.Storage;
            }
        }
    }

    [HarmonyPatch(typeof(PlayerNetwork), "UserCode_CmdChangeEquippedItem__Int32")]
    public static class PatchEquippedItemChange {
        [HarmonyPrefix]
        public static void Prefix(int selectedItem) {
            UnityEngine.Debug.Log(selectedItem);
        }
    }

    private static void HandleAutoSave() {
        if (BetterSMT.AutoSaveEnabled?.Value != true || !GameData.Instance.isServer) {
            return;
        }

        if (!stopwatch.IsRunning) {
            stopwatch.Start();
        }

        if (stopwatch.Elapsed.TotalSeconds <= BetterSMT.AutoSaveTimer?.Value) {
            return;
        }

        stopwatch.Restart();

        if (BetterSMT.AutoSaveDuringDay?.Value == true || !GameData.Instance.NetworkisSupermarketOpen) {
            _ = GameData.Instance.StartCoroutine(GameDataPatch.SaveGame());
        }
    }

    [HarmonyPatch("Update"), HarmonyPostfix]
    private static void UpdatePatch(PlayerNetwork __instance, ref float ___pPrice, TextMeshProUGUI ___marketPriceTMP, ref TextMeshProUGUI ___yourPriceTMP) {
        HandleAutoSave();

        if (!FsmVariables.GlobalVariables.GetFsmBool("InChat").Value == false) {
            return;
        } else {
            bool usedTool = false;
            (bool?, BepInEx.Configuration.KeyboardShortcut?, int)[] toolHotkeys = new[] {
                (BetterSMT.SledgeToggle?.Value,      BetterSMT.SledgeHotkey?.Value,      7),
                (BetterSMT.OsMartToggle?.Value,      BetterSMT.OsMartHotkey?.Value,      6),
                (BetterSMT.TrayToggle?.Value,        BetterSMT.TrayHotkey?.Value,        9),
                (BetterSMT.SalesToggle?.Value,       BetterSMT.SalesHotkey?.Value,       10),
                (BetterSMT.PricingGunToggle?.Value,  BetterSMT.PricingGunHotkey?.Value,  2),
                (BetterSMT.BroomToggle?.Value,       BetterSMT.BroomHotkey?.Value,       3),
                (BetterSMT.LadderToggle?.Value,      BetterSMT.LadderHotkey?.Value,      8),
                (BetterSMT.DLCTabletToggle?.Value,   BetterSMT.DLCTabletHotkey?.Value,   5),
            };

            foreach ((bool? toggle, BepInEx.Configuration.KeyboardShortcut? hotkey, int itemId) in toolHotkeys) {
                if (toggle == true && hotkey?.IsDown() == true) {
                    __instance.CmdChangeEquippedItem(itemId);
                    usedTool = true;
                    break;
                }
            }

            if (!usedTool && BetterSMT.EmptyHandsHotkey.Value.IsDown()) {
                __instance.CmdChangeEquippedItem(0);
            }

            if (BetterSMT.ClockToggle?.Value == true && BetterSMT.ClockHotkey?.Value.IsDown() == true) {
                upgradesManager ??= UnityEngine.Object.FindObjectOfType<TimeAccelerationWatcher>()?.GetComponent<UpgradesManager>();

                if (upgradesManager != null) {
                    bool newState = !upgradesManager.NetworkacceleratedTime;
                    upgradesManager.NetworkacceleratedTime = newState;
                    upgradesManager.RpcTimeAcceleration(newState);
                }
            }

        }

        if (BetterSMT.ToggleDoublePrice.Value == true) {
            if (BetterSMT.doublePrice && ___marketPriceTMP != null) {
                if (float.TryParse(___marketPriceTMP.text[1..].Replace(',', '.'),
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out float market)) {
                    ___pPrice = market * 2;

                    if (BetterSMT.roundDown.Value) {
                        ___pPrice = BetterSMT.NearestTen.Value ? (float)(Math.Floor(___pPrice * 10) / 10) : (float)(Math.Floor(___pPrice * 20) / 20);
                    }

                    ___yourPriceTMP.text = "$" + ___pPrice;
                }
            }
        }
    }

    [HarmonyPatch("ChangeEquipment"), HarmonyPostfix]
    private static void ChangeEquipmentPatch(int newEquippedItem) {
        if (newEquippedItem == 0) {
            ClearHighlightedShelves();
        }
    }

    private static readonly Dictionary<int, Transform> highlightObjectCache = [];

    public static bool IsHighlightCacheUsed { get; set; } = true;

    [HarmonyPatch("Start"), HarmonyPrefix]
    private static void StartPatch(PlayerNetwork __instance) {
        if (__instance.isLocalPlayer) {
            pNetwork = __instance;
        }
    }

    [HarmonyPatch("UpdateBoxContents"), HarmonyPostfix]
    private static void UpdateBoxContentsPatch(int productIndex) {
        HighlightShelvesByProduct(productIndex);
    }

    [HarmonyPatch(typeof(Data_Container), "BoxSpawner")]
    [HarmonyPostfix]
    private static void BoxSpawnerPatch(Data_Container __instance) {
        AddHighlightMarkersToStorage(__instance.transform);
    }

    [HarmonyPatch(typeof(NetworkSpawner), "UserCode_CmdSpawn__Int32__Vector3__Vector3")]
    [HarmonyPostfix]
    private static void NewBuildableConstructed(NetworkSpawner __instance, int prefabID) {
        if (BetterSMT.StorageHighlighting.Value == false) {
            return;
        }

        GameObject buildable = __instance.buildables[prefabID];

        if (buildable.name.Contains("StorageShelf")) {
            int index = buildable.GetComponent<Data_Container>().parentIndex;
            Transform buildableParent = __instance.levelPropsOBJ.transform.GetChild(index);
            GameObject lastStorageObject = buildableParent.GetChild(buildableParent.childCount - 1).gameObject;

            AddHighlightMarkersToStorage(lastStorageObject.transform);
        }
    }

    public static int GetProductFromRaycast() {
        if (BetterSMT.StorageHighlighting.Value == false) {
            return -1;
        }

        int productID = -1;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo3, 4f, pNetwork.interactableMask)) {
            if (hitInfo3.transform.gameObject.name == "SubContainer") {
                int siblingIndex = hitInfo3.transform.GetSiblingIndex();
                if (!hitInfo3.transform?.parent?.transform?.parent) {
                    return productID;
                }

                Data_Container component = hitInfo3.transform.parent.transform.parent.GetComponent<Data_Container>();
                if (component != null && component.containerClass < 20) {
                    productID = component.productInfoArray[siblingIndex * 2];
                }
            }
        } else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 4f, pNetwork.lMask)) {
            if (hitInfo.transform.gameObject.tag == "Interactable" && hitInfo.transform.GetComponent<BoxData>()) {
                BoxData boxData = hitInfo.transform.GetComponent<BoxData>();
                if (boxData != null) {
                    productID = boxData.productID;
                }
            } else {
                int siblingIndex = hitInfo.transform.GetSiblingIndex();
                if (!hitInfo.transform?.parent?.transform?.parent) {
                    return productID;
                }

                Data_Container component = hitInfo.transform.parent.transform.parent.GetComponent<Data_Container>();
                if (component != null && component.containerClass == 69) {
                    int num = component.productInfoArray[siblingIndex * 2];
                    productID = num;
                }
            }
        }

        return productID;
    }

    public static void HighlightShelvesByProduct(int productID) {
        if (BetterSMT.StorageHighlighting.Value == false) {
            return;
        }

        HighlightShelfTypeByProduct(productID, Color.yellow, ShelfType.ProductDisplay);
        HighlightShelfTypeByProduct(productID, Color.red, ShelfType.Storage);
    }

    public static void ClearHighlightedShelves() {
        if (BetterSMT.StorageHighlighting.Value == false) {
            return;
        }

        if (IsHighlightCacheUsed) {
            foreach (KeyValuePair<int, Transform> item in highlightObjectCache) {
                HighlightShelf(item.Value, false);
            }
            highlightObjectCache.Clear();
        } else {
            ClearHighlightShelvesByProduct(ShelfType.ProductDisplay);
            ClearHighlightShelvesByProduct(ShelfType.Storage);
        }
    }

    private static void ClearHighlightShelvesByProduct(ShelfType shelfType) {
        HighlightShelfTypeByProduct(-1, Color.white, shelfType);
    }

    private static void HighlightShelfTypeByProduct(int productID, Color shelfHighlightColor, ShelfType shelfType) {
        if (BetterSMT.StorageHighlighting.Value == false) {
            return;
        }

        GameObject shelvesObject = GameObject.Find(GetGameObjectStringPath(shelfType));

        for (int i = 0; i < shelvesObject.transform.childCount; i++) {
            Transform shelf = shelvesObject.transform.GetChild(i);
            int[] productInfoArray = shelf.gameObject.GetComponent<Data_Container>().productInfoArray;
            int num = productInfoArray.Length / 2;
            bool enableShelfHighlight = false;

            for (int j = 0; j < num; j++) {
                bool enableSlotHighlight = productID >= 0 && productInfoArray[j * 2] == productID;
                if (enableSlotHighlight) {
                    enableShelfHighlight = true;

                    ShelfData shelfData = new(shelfType);
                    Transform highlightsMarker = shelf.Find(shelfData.highlightsName);

                    if (highlightsMarker != null) {
                        Transform specificHighlight = shelfType == ShelfType.Storage ? highlightsMarker.GetChild(j).GetChild(0) : highlightsMarker.GetChild(j);
                        HighlightShelf(specificHighlight, true, Color.yellow);
                    }
                }
            }

            HighlightShelf(shelf, enableShelfHighlight, shelfHighlightColor);
        }
    }

    public static string GetGameObjectStringPath(ShelfType shelfType) {
        return shelfType switch {
            ShelfType.ProductDisplay => "Level_SupermarketProps/Shelves",
            ShelfType.Storage => "Level_SupermarketProps/StorageShelves",
            _ => throw new NotImplementedException(),
        };
    }

    public static void HighlightShelf(Transform t, bool isEnableHighlight, Color? color = null) {
        if (BetterSMT.StorageHighlighting.Value == false) {
            return;
        }

        HighlightEffect highlightEffect = t.GetComponent<HighlightEffect>() ?? t.gameObject.AddComponent<HighlightEffect>();

        if (IsHighlightCacheUsed) {
            if (isEnableHighlight == highlightEffect.highlighted) {
                return;
            }

            if (isEnableHighlight) {
                if (!highlightObjectCache.ContainsKey(t.GetInstanceID())) {
                    highlightObjectCache.Add(t.GetInstanceID(), t);
                }
            }

            MeshRenderer meshRender = t.GetComponent<MeshRenderer>();
            if (meshRender != null) {
                meshRender.allowOcclusionWhenDynamic = !isEnableHighlight;
            }
        }

        if (color != null) {
            highlightEffect.outlineColor = (Color)color;
        }
        highlightEffect.outlineQuality = HighlightPlus.QualityLevel.High;
        highlightEffect.outlineVisibility = Visibility.AlwaysOnTop;
        highlightEffect.outlineContourStyle = ContourStyle.AroundObjectShape;

        highlightEffect.outlineIndependent = true;
        highlightEffect.outline = isEnableHighlight ? 1f : 0f;
        highlightEffect.glow = isEnableHighlight ? 0f : 1f;

        highlightEffect.Refresh();
        highlightEffect.highlighted = isEnableHighlight;

        foreach (Transform child in t) {
            if (child.name.Contains("PriceLabel")) {
                HighlightEffect childHighlightEffect = child.GetComponent<HighlightEffect>() ?? child.gameObject.AddComponent<HighlightEffect>();

                if (color != null) {
                    childHighlightEffect.outlineColor = (Color)color;
                }
                childHighlightEffect.outlineQuality = HighlightPlus.QualityLevel.High;
                childHighlightEffect.outlineVisibility = Visibility.AlwaysOnTop;
                childHighlightEffect.outlineContourStyle = ContourStyle.AroundObjectShape;

                childHighlightEffect.outlineIndependent = true;
                childHighlightEffect.outline = isEnableHighlight ? 1f : 0f;
                childHighlightEffect.glow = isEnableHighlight ? 0f : 1f;

                childHighlightEffect.Refresh();
                childHighlightEffect.highlighted = isEnableHighlight;
            }
        }
    }


    public static void AddHighlightMarkersToStorage(Transform storage) {
        if (BetterSMT.StorageHighlighting.Value == false) {
            return;
        }

        ShelfData shelfData = new(ShelfType.Storage);

        Transform highlightsMarker = storage.transform.Find(shelfData.highlightsName);

        if (highlightsMarker != null) {
            return;
        }

        highlightsMarker = UnityEngine.Object.Instantiate(storage.Find(shelfData.highlightsOriginalName).gameObject, storage).transform;
        highlightsMarker.name = shelfData.highlightsName;

        for (int i = 0; i < highlightsMarker.childCount; i++) {
            highlightsMarker.GetChild(i).gameObject.SetActive(true);

            Transform highlight = highlightsMarker.GetChild(i).GetChild(0);
            highlight.gameObject.SetActive(true);

            HighlightShelf(highlight, false, null);
        }
    }
}

using HarmonyLib;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(GameData), "WorkingDayControl")]
public class GameDataPatch {
    public static readonly Dictionary<int, string> productNames = new() { { 0, "Pasta Penne" }, { 1, "Water Bottle" }, { 2, "Honey Cereals" }, { 3, "Rice" }, { 4, "Salt" }, { 5, "Sugar" }, { 6, "Margarine" }, { 7, "Flour" }, { 8, "Apple Juice" }, { 9, "Olive Oil" }, { 10, "Ketchup" }, { 11, "Sliced Bread" }, { 12, "Pepper" }, { 13, "Orange Juice" }, { 14, "Barbaque Sauce" }, { 15, "Mustard Sauce" }, { 16, "Spaghetti Box" }, { 17, "Tuna Pate" }, { 18, "Fiber Cereals" }, { 19, "Supreme Flour" }, { 20, "Black Coffee" }, { 21, "Egg Box" }, { 22, "Houmous" }, { 23, "White Flour" }, { 24, "Cane Sugar Box" }, { 25, "Sugar" }, { 26, "Macarroni" }, { 27, "Ecologic Sugar" }, { 28, "Brown Sugar" }, { 29, "Sunflower Oil" }, { 30, "Mash Potatoes" }, { 31, "Potato Bag" }, { 32, "Espresso Coffee" }, { 33, "Basmati Rice" }, { 34, "Long Grain Rice" }, { 35, "Coffee" }, { 36, "Supreme Pasta" }, { 37, "Chocolate Cereals" }, { 38, "Premium Water" }, { 39, "Spring Water" }, { 40, "Powdered Sugar" }, { 41, "Sugar - Big Box" }, { 42, "Brown Sugar - Big Box" }, { 43, "Emmental Cheese" }, { 44, "Gruyere Cheese" }, { 45, "Skimmed Cheese" }, { 46, "Fruit Yoghurt" }, { 47, "Vanilla Yoghurt" }, { 48, "Milk Brick" }, { 49, "Butter" }, { 50, "Parmigiano Cheese" }, { 51, "Reggiano Cheese" }, { 52, "Mozzarella Cheese" }, { 53, "Skimmed Yoghurt" }, { 54, "Cola Pack" }, { 55, "Soda Pack" }, { 56, "Decaf Soda Pack" }, { 57, "Soda Bottle" }, { 58, "Cola Bottle" }, { 59, "Sugar Free Soda Bottle" }, { 60, "Premium Soda" }, { 61, "Pizza Barbaque" }, { 62, "Fondue" }, { 63, "Crocanti Ham" }, { 64, "Ham Cheese Crepe" }, { 65, "French Fries" }, { 66, "Crispy Potato Pops" }, { 67, "Green Beans" }, { 68, "Four Cheese Pizza" }, { 69, "Four Seasons Pizza" }, { 70, "Vegetable Mix" }, { 71, "Chicken Mix" }, { 72, "Bolognaise Lasagna" }, { 73, "Vegetable Lasagna" }, { 74, "Toothpaste" }, { 75, "Toilet Paper" }, { 76, "Hand Soap" }, { 77, "Avocado Shampoo" }, { 78, "Egg Shampoo" }, { 79, "Bath Gel" }, { 80, "Toilet Paper" }, { 81, "Mango Soap" }, { 82, "Extra Soft Shampoo" }, { 83, "Jojoba Honey Shampoo" }, { 84, "Argan Oil Shampoo" }, { 85, "Paper Towel" }, { 86, "Double Side Toilet Paper" }, { 87, "Lemon Soap" }, { 88, "Premium Bath Gel" }, { 89, "Shampoo For Babies" }, { 90, "Detergent" }, { 91, "Stain Remover" }, { 92, "Glass Cleaner" }, { 93, "Detergent Tables" }, { 94, "Dishwasher" }, { 95, "Bleach" }, { 96, "Bleach - Big Bottle" }, { 97, "Softener" }, { 98, "Premium Detergent" }, { 99, "Insecticide" }, { 100, "Cleaning Cloths" }, { 101, "Premium Capsules" }, { 102, "Premium Bleach" }, { 103, "Ammonia" }, { 104, "Cookie Jar" }, { 105, "Maxi Cone" }, { 106, "Chocolate Spread" }, { 107, "Chocolate Powder" }, { 108, "Chips" }, { 109, "Sweet Bonbek" }, { 110, "Peach Jam" }, { 111, "Ice Cream Box" }, { 112, "Chocolate Box" }, { 113, "Chocolate Biscuit" }, { 114, "Vanilate Biscuit" }, { 115, "Madeleine" }, { 116, "Strawberry Jam" }, { 117, "Peanut Butter" }, { 118, "Chipos" }, { 119, "Marshmallow" }, { 120, "Lemon Biscuit" }, { 121, "Hazelnut Biscuit" }, { 122, "Premium Ice Cream" }, { 123, "Honey" }, { 124, "Premium Chocolate Box" }, { 125, "Foditos" }, { 126, "Premium Cake" }, { 127, "Chopped Beef" }, { 128, "Pure Beef" }, { 129, "Veal" }, { 130, "Chicken Wings" }, { 131, "Chicken" }, { 132, "Parma Ham" }, { 133, "Sliced Ham" }, { 134, "Peas - Big" }, { 135, "Tuna - Big" }, { 136, "Red Beans" }, { 137, "Cat Food" }, { 138, "Cat Food" }, { 139, "Dog Food" }, { 140, "Green Tea" }, { 141, "Lemon Tea" }, { 142, "Black Tea" }, { 143, "Peppermint" }, { 144, "Mint" }, { 145, "Valerian" }, { 146, "Big Sushi" }, { 147, "Small Sushi" }, { 148, "Smoked Salmon" }, { 149, "Crab Sticks" }, { 150, "Book - Electromagnetic" }, { 151, "Book - Surprise" }, { 152, "Book - ABC" }, { 153, "Book - Mother And Child" }, { 154, "Book - Colors" }, { 155, "Book - Piticha" }, { 156, "Book - OnceUpon" }, { 157, "Book - Krok" }, { 158, "Book - Adventures" }, { 159, "Book - Donnine" }, { 160, "Book - Vintage" }, { 161, "Book - I Wont Share" }, { 162, "Beer Pack" }, { 163, "Beer Pack" }, { 164, "Beer Pack" }, { 165, "Beer Barrel" }, { 166, "Beer Barrel" }, { 167, "Vodka" }, { 168, "Red Wine" }, { 169, "Rose Wine" }, { 170, "White Wine" }, { 171, "Beer Barrel" }, { 172, "Premium Vodka" }, { 173, "Japanese Whisky" }, { 174, "Premium Whisky" }, { 175, "Premium Whisky" }, { 176, "Hydrogen Peroxide" }, { 177, "Disinfectant" }, { 178, "Ibuprofen" }, { 179, "Paracetamol" }, { 180, "Adhesive Bandages" }, { 181, "Laxative" }, { 182, "Antihistamine" }, { 183, "Zinc Supplement" }, { 184, "Antioxidant" }, { 185, "Fish Oil" }, { 186, "Algae Pills" }, { 187, "Vitamins" }, { 188, "Melatonin" }, { 189, "Sunscreen" }, { 190, "Stretch Cream" }, { 191, "Red Apple Tray" }, { 192, "Green Apple Tray" }, { 193, "Clementine Tray" }, { 194, "Orange Tray" }, { 195, "Pear Tray" }, { 196, "Lemon Tray" }, { 197, "Mango Tray" }, { 198, "Avocado Tray" }, { 199, "Kiwi Tray" }, { 200, "Papaya Tray" }, { 201, "Strawberry Tray" }, { 202, "Cherry Tray" }, { 203, "Artichoke Tray" }, { 204, "Zucchini Tray" }, { 205, "Carrot Tray" }, { 206, "Tomato Tray" }, { 207, "Potato Tray" }, { 208, "Onion Tray" }, { 209, "Banana Pack" }, { 210, "Melon" }, { 211, "Pineapple" }, { 212, "Pumpkin" }, { 213, "Watermelon" }, { 214, "Baby Food: Vegetables" }, { 215, "Baby Food: Fish" }, { 216, "Baby Food: Fruits" }, { 217, "Baby Food: Meat" }, { 218, "Nutritive Milk Mix" }, { 219, "Nutritive Milk Powder" }, { 220, "Ecologic Diapers" }, { 221, "Basic Diapers" }, { 222, "Toddler Diapers" }, { 223, "Premium Diapers" }, { 224, "Aloe Baby Wipes " }, { 225, "Basic Baby Wipes" }, { 226, "Baby Powder" }, { 227, "Orange Soda" }, { 228, "Pineapple Soda" }, { 229, "Tropical Soda" }, { 230, "Green Tea Drink" }, { 231, "Red Tea Drink" }, { 232, "Lemon Tea Drink" }, { 233, "Cold Brew Coffee" }, { 234, "Blueberry Energy Drink" }, { 235, "Guava Energy Drink" }, { 236, "Lima Energy Drink" }, { 237, "Fruit Punch Energy Drink" }, { 238, "Mango Energy Drink" }, { 239, "Cola Energy Drink" }, { 240, "Sugar Free Energy Drink" }, { 241, "Basic Strawberry Ice Cream" }, { 242, "Lemon Ice Cream" }, { 243, "Coffee Ice Cream" }, { 244, "Stracciatella Ice Cream" }, { 245, "Strawberry Meringue Ice Cream" }, { 246, "Caramel Ice Cream" }, { 247, "Premium Strawberry Ice Cream" }, { 248, "Strawberry Cheesecake Ice Cream" }, { 249, "Premium Caramel Ice Cream" }, { 250, "Pink Strawberry Ice Cream" }, { 251, "Alcoholic Ice Cream" }, { 252, "Chickpeas" }, { 253, "Meatballs" }, { 254, "Lentils" }, { 255, "Tomato Soup" }, { 256, "Canned Corn" }, { 257, "Canned Peas" }, { 258, "Strawberry Seeds" }, { 259, "Raspberry Seeds" }, { 260, "Blueberry Seeds" }, { 261, "Pineapple Seeds" }, { 262, "Meyer Lemon Seeds" }, { 263, "Tomato Seeds" }, { 264, "Pepper Seeds" }, { 265, "Cucumber Seeds" }, { 266, "Radish Seeds" }, { 267, "Carrots Seeds" }, { 268, "Lawn Seeds" }, { 269, "Poppy Seeds" }, { 270, "Tulip Seeds" }, { 271, "Sunflower Seeds" }, { 272, "Petunia Seeds" }, { 273, "Hand Rake (A)" }, { 274, "Hand Rake (B)" }, { 275, "Hand Shovel" }, { 276, "Hand Cultivator" }, { 277, "Potting Soil" }, { 278, "Fertilizer" }, { 279, "Plant Pot Dish" }, { 280, "Plant Pot" }, { 281, "AA Batteries" }, { 282, "AAA Batteries" }, { 283, "C Batteries" }, { 284, "9V Batteries" }, { 285, "Universal TV Remote" }, { 286, "Universal Phone Charger" }, { 287, "Basic Prepaid Phone" }, { 288, "Basic Mouse" }, { 289, "Wifi Dongle" }, { 290, "Basic Earbuds" }, { 291, "Basic Keyboard" }, { 292, "Basic Gamepad" }, { 293, "USB Flash Drive (128GB)" }, { 294, "USB Flash Drive (256GB)" }, { 295, "USB Flash Drive (512GB)" }, { 296, "USB Flash Drive (1TB)" }, { 297, "Basic Speaker" }, { 298, "Basic Headphones" }, { 299, "Basic Gaming Console" } };

    [HarmonyPatch("OnStartClient"), HarmonyPostfix]
    private static void OnStartClientPatch() {
        ShowCounters();
        UpdateEscapeMenu();
    }

    [HarmonyPatch(typeof(GameData), nameof(GameData.ServerCalculateNewInflation))]
    [HarmonyPostfix]
    private static void OptimizePricesDaily() {
        OptimizeProductPrices();
    }

    [HarmonyPatch("WorkingDayControl"), HarmonyPostfix]
    private static void WorkingDayControlPatch(GameData __instance) {
        WorkingDayLightControlPatch(__instance);
        WorkingDayEmployeeControlPatch(__instance);
        WorkingDayRentControlPatch(__instance);
    }

    [HarmonyPatch("TrashManager"), HarmonyPostfix]
    private static void TrashManagerPatch(GameData __instance) {
        NextTimeToSpawnTrashPatch(__instance);
    }

    [HarmonyPatch(typeof(GameData), "UserCode_CmdOpenSupermarket")]
    [HarmonyPostfix]
    private static void UserCode_CmdOpenSupermarketPatch(GameData __instance) {
        MaxCustomersNPCsPatch(__instance);
    }

    public static void OptimizeProductPrices() {
        if (BetterSMT.AutoAdjustPriceDaily.Value == true) {
            GameObject[] products = ProductListing.Instance.productPrefabs;
            ProductListing productListing = ProductListing.Instance;
            System.Collections.Generic.List<float> basePriceList = [];
            for (int i = 0; i < products.Length; i++) {
                if (i < products.Length) {
                    Data_Product product = products[i].GetComponent<Data_Product>();
                    basePriceList.Add(product.basePricePerUnit);
                }
            }
            float[] basePrices = [.. basePriceList];
            float[] inflationMultiplier = productListing.tierInflation;
            float priceMultiplier = BetterSMT.AutoAdjustPriceDailyValue.Value;

            for (int i = 0; i < basePrices.Length; i++) {
                Data_Product productToUpdate = products[i].GetComponent<Data_Product>();
                float calculatedPrice = basePrices[i] * inflationMultiplier[productToUpdate.productTier] * priceMultiplier;
                float newPrice = Mathf.Floor(calculatedPrice * 100) / 100;
                productListing.CmdUpdateProductPrice(i, newPrice);
            }
        }
    }

    private static void UpdateEscapeMenu() {
        GameObject EscapeMenu = GameObject.Find("MasterOBJ/MasterCanvas/Menus/EscapeMenu/");

        GameObject OptionsButton = EscapeMenu.transform.Find("OptionsButton").gameObject;

        GameObject QuitButton = EscapeMenu.transform.Find("QuitButton").gameObject;
        QuitButton.transform.localPosition = new Vector3(0f, 0f, 0f);
        GameObject MainMenuButton = EscapeMenu.transform.Find("MainMenuButton").gameObject;
        MainMenuButton.transform.localPosition = new Vector3(0f, 85f, 0f);

        GameObject SaveButton = Object.Instantiate(QuitButton, EscapeMenu.transform);
        SaveButton.name = "SaveButton";
        PlayMakerFSM[] PlayMakerComps = SaveButton.GetComponents<PlayMakerFSM>();
        PlayMakerComps.ToList().ForEach(Object.Destroy);
        Object.Destroy(SaveButton.GetComponent<EventTrigger>());
        SaveButton.transform.position = QuitButton.transform.position;
        SaveButton.transform.localScale = QuitButton.transform.localScale;
        SaveButton.transform.localPosition = new Vector3(0f, -85f, 0f);

        SaveButton.GetComponentInChildren<TextMeshProUGUI>().text = "Save Game";

        Button ButtonComp = SaveButton.GetComponent<Button>();
        ButtonComp.onClick.AddListener(() => {
            _ = GameData.Instance.StartCoroutine(SaveGame());
        });

        if (!GameData.Instance.isServer) {
            SaveButton.SetActive(false);
        }
    }

    public static IEnumerator SaveGame() {
        NetworkSpawner nSpawnerComponent = GameData.Instance.GetComponent<NetworkSpawner>();
        if (!nSpawnerComponent.isSaving) {
            BetterSMT.CreateImportantNotification("Saving Game");
            GameData.Instance.DoDaySaveBackup();
            GameData.Instance.DoDaySaveBackup();
            PlayMakerFSM fsm = GameData.Instance.SaveOBJ.GetComponent<PlayMakerFSM>();
            fsm.FsmVariables.GetFsmBool("IsSaving").Value = true;
            fsm.SendEvent("Send_Data");
            while (fsm.FsmVariables.GetFsmBool("IsSaving").Value) {
                yield return null;
            }
            yield return nSpawnerComponent.SavePropsCoroutine();
            BetterSMT.CreateImportantNotification("Saving Finished");
        } else {
            BetterSMT.CreateImportantNotification("Saving already in progress");
        }
    }

    public static void ShowCounters() {
        if (BetterSMT.ShowPing.Value) {
            GameObject Ping = GameObject.Find("MasterOBJ/MasterCanvas/Ping");
            if (Ping == null) {
                BetterSMT.Logger.LogWarning("Couldnt find Ping object");
                return;
            }
            Ping.SetActive(true);
        }
        if (BetterSMT.ShowFPS.Value) {
            GameObject FPSDisplay = GameObject.Find("MasterOBJ/MasterCanvas/FPSDisplay");
            if (FPSDisplay == null) {
                BetterSMT.Logger.LogWarning("Couldnt find FPSDisplay object");
                return;
            }
            FPSDisplay.SetActive(true);
        }
    }

    public static void WorkingDayLightControlPatch(GameData __instance) {
        UpgradesManager component = __instance.GetComponent<UpgradesManager>();
        if (component != null) {
            float actualLightCost = BetterSMT.LightCostMod.Value + component.spaceBought + component.storageBought;
            __instance.lightCost = actualLightCost;
        } else {
            __instance.lightCost = 10f + component.spaceBought + component.storageBought;
        }
    }

    [HarmonyPatch("AddExpensiveList"), HarmonyPostfix]
    public static void CustomerNPCControlPatch(GameData __instance, int productID) {
        AddExpensiveListPatch(__instance, productID);
    }

    [HarmonyPatch("AddNotFoundList"), HarmonyPostfix]
    public static void AddNotFoundList(GameData __instance, int productID) {
        AddNotFoundListPatch(__instance, productID);
    }


    public static void AddExpensiveListPatch(GameData __instance, int productID) {
        if (__instance.productsTooExpensiveList.Count == 0) {
            __instance.productsTooExpensiveList.Add(productID);
        }
        foreach (int productsTooExpensive in __instance.productsTooExpensiveList) {
            if (productsTooExpensive == productID) {
                if (BetterSMT.MissingProduct.Value == true) {
                    string productName = productNames.ContainsKey(productID) ? productNames[productID] : $"Product {productID}";
                    PlayerObjectController playerController = GameObject.FindObjectOfType<PlayerObjectController>();
                    string message = $"{productName} is not found on the shelf.";
                    playerController.CmdSendMessage(message);
                    Debug.Log(message);
                }
                return;
            }
        }
        __instance.productsTooExpensiveList.Add(productID);
    }

    public static void AddNotFoundListPatch(GameData __instance, int productID) {
        if (__instance.productsNotFoundList.Count == 0) {
            __instance.productsNotFoundList.Add(productID);
        }
        foreach (int productsNotFound in __instance.productsNotFoundList) {
            if (productsNotFound == productID) {
                if (BetterSMT.MissingProduct.Value == true) {
                    string productName = productNames.ContainsKey(productID) ? productNames[productID] : $"Product {productID}";
                    PlayerObjectController playerController = GameObject.FindObjectOfType<PlayerObjectController>();
                    string message = $"{productName} is not found on the shelf.";
                    playerController.CmdSendMessage(message);
                    Debug.Log(message);
                }
                return;
            }
        }
        __instance.productsNotFoundList.Add(productID);
    }

    public static void MaxCustomersNPCsPatch(GameData __instance) {
        if (__instance.isSupermarketOpen || (__instance.timeOfDay < 23f && __instance.timeOfDay > 8f)) {
            __instance.maxProductsCustomersToBuy = BetterSMT.BaseCustomerCart.Value + (__instance.gameDay / 2) + NetworkServer.connections.Count + __instance.difficulty;
            __instance.maxProductsCustomersToBuy = Mathf.Clamp(__instance.maxProductsCustomersToBuy, BetterSMT.BaseCustomerCart.Value, BetterSMT.MaxCustomerCart.Value + NetworkServer.connections.Count + __instance.difficulty);
            __instance.maxCustomersNPCs = BetterSMT.BaseCustomerSpawns.Value + __instance.gameDay + ((NetworkServer.connections.Count - 1) * 4) + __instance.extraCustomersPerk + (__instance.difficulty * 2);
            __instance.maxCustomersNPCs = Mathf.Clamp(__instance.maxCustomersNPCs, BetterSMT.BaseCustomerSpawns.Value, BetterSMT.MaxCustomerInStore.Value + NetworkServer.connections.Count);
        }
    }

    public static void NextTimeToSpawnTrashPatch(GameData __instance) {
        if (BetterSMT.DisableTrash.Value == true) {
            __instance.nextTimeToSpawnTrash = 99999f;
            return;
        }
    }

    public static void WorkingDayRentControlPatch(GameData __instance) {
        UpgradesManager component = __instance.GetComponent<UpgradesManager>();
        if (component != null) {
            float actualRentCost = BetterSMT.RentCostMod.Value + (component.spaceBought * 5) + (component.storageBought * 10);
            __instance.rentCost = actualRentCost;
        } else {
            __instance.rentCost = 10f + (component.spaceBought * 5) + (component.storageBought * 10);
        }
    }

    public static void WorkingDayEmployeeControlPatch(GameData __instance) {
        UpgradesManager component = __instance.GetComponent<UpgradesManager>();
        if (component != null) {
            float actualEmployeeCost = BetterSMT.EmployeeCostMod.Value + (NPC_Manager.Instance.maxEmployees * 60);
            __instance.employeesCost = actualEmployeeCost;
        } else {
            __instance.employeesCost = NPC_Manager.Instance.maxEmployees * 60;
        }
    }
}
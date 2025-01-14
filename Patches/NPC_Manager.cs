using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BetterSMT.Patches {
    [HarmonyPatch(typeof(NPC_Manager))]
    public class NPC_ManagerPatch {
        [HarmonyPatch("GetAvailableSelfCheckout"), HarmonyPostfix]
        private static void GetAvailableSelfCheckoutPatch(NPC_Info npcInfo, NPC_Manager __instance) {
            _ = SelfCheckoutPatch(npcInfo, __instance);
        }

        [HarmonyPatch("CustomerNPCControl"), HarmonyPrefix]
        private static void CustomerNPCControlPatch(NPC_Manager __instance, int NPCIndex) {
            TooExpensiveChatPatch(__instance, NPCIndex);
        }

        public static void TooExpensiveChatPatch(NPC_Manager __instance, int NPCIndex) {
            Dictionary<int, string> productNames = new() {
                {0, "Pasta Penne"},  {1, "Water Bottle"}, {2, "Honey Cereals"}, {3, "Rice"}, {4, "Salt"}, {5, "Sugar"}, {6, "Margarine"}, {7, "Flour"}, {8, "Apple Juice"}, {9, "Olive Oil"}, {10, "Ketchup"}, {11, "Sliced Bread"}, {12, "Pepper"},
                {13, "Orange Juice"}, {14, "Barbaque Sauce"}, {15, "Mustard Sauce"}, {16, "Spaghetti Box"}, {17, "Tuna Pate"}, {18, "Fiber Cereals"}, {19, "Supreme Flour"}, {20, "Black Coffee"}, {21, "Egg Box"}, {22, "Houmous"},
                {23, "White Flour"}, {24, "Cane Sugar Box"}, {25, "Sugar"}, {26, "Macarroni"}, {27, "Ecologic Sugar"}, {28, "Brown Sugar"}, {29, "Sunflower Oil"}, {30, "Mash Potatoes"}, {31, "Potatoe Bag"}, {32, "Espresso Coffee"},
                {33, "Basmati Rice"}, {34, "Long Grain Rice"}, {35, "Coffee"}, {36, "Supreme Pasta"}, {37, "Chocolate Cereals"}, {38, "Premium Water"}, {39, "Spring Water"}, {40, "Powdered Sugar"}, {41, "Sugar - Big Box"},
                {42, "Brown Sugar - Big Box"}, {43, "Emmental Cheese"}, {44, "Gruyere Cheese"}, {45, "Skimmed Cheese"}, {46, "Fruit Yoghurt"}, {47, "Vanilla Yoghurt"}, {48, "Milk Brick"}, {49, "Butter"}, {50, "Parmigiano Cheese"},
                {51, "Reggiano Cheese"}, {52, "Mozzarella Cheese"}, {53, "Skimmed Yoghurt"}, {54, "Cola Pack"}, {55, "Soda Pack"}, {56, "Decaf Soda Pack"}, {57, "Soda Bottle"}, {58, "Cola Bottle"}, {59, "Sugar Free Soda Bottle"},
                {60, "Premium Soda"}, {61, "Pizza Barbaque"}, {62, "Fondue"}, {63, "Crocanti Ham"}, {64, "Ham Cheese Crepe"}, {65, "French Fries"}, {66, "Crispy Potatoe Pos"}, {67, "Green Beans"}, {68, "Four Cheese Pizza"},
                {69, "Four Seasons Pizza"}, {70, "Vegetable Mix"}, {71, "Chicken Mix"}, {72, "Bolognaise Lasagna"}, {73, "Vegetable Lasagna"}, {74, "Toothpaste"}, {75, "Toilet Paper"}, {76, "Hand Soap"}, {77, "Avocado Shampoo"},
                {78, "Egg Shampoo"}, {79, "Bath Gel"}, {80, "Toilet Paper"}, {81, "Mango Soap"}, {82, "Extra Soft Shampoo"}, {83, "Jojoba Honey Shampoo"}, {84, "Argan Oil Shampoo"}, {85, "Paper Towel"}, {86, "Double Side Toilet Paper"},
                {87, "Lemon Soap"}, {88, "Premium Bath Gel"}, {89, "Shampoo For Babies"}, {90, "Detergent"}, {91, "Stain Remover"}, {92, "Glass Cleaner"}, {93, "Detergent Tables"}, {94, "Dishwasher"}, {95, "Bleach"}, {96, "Bleach - Big Bottle"},
                {97, "Softener"}, {98, "Premium Detergent"}, {99, "Insecticide"}, {100, "Cleaning Cloths"}, {101, "Premium Capsules"}, {102, "Premium Bleach"}, {103, "Ammonia"}, {104, "Cookie Jar"}, {105, "Maxi Cone"}, {106, "Chocolate Spread"},
                {107, "Chocolate Powder"}, {108, "Chips"}, {109, "Sweet Bonbek"}, {110, "Peach Jam"}, {111, "Ice Cream Box"}, {112, "Chocolate Box"}, {113, "Chocolate Biscuit"}, {114, "Vanilate Biscuit"}, {115, "Madeleine"},
                {116, "Strawberry Jam"}, {117, "Peanut Butter"}, {118, "Chipos"}, {119, "Marshmallow"}, {120, "Lemon Biscuit"}, {121, "Hazelnut Biscuit"}, {122, "Premium Ice Cream"}, {123, "Honey"}, {124, "Premium Chocolate Box"},
                {125, "Foditos"}, {126, "Premium Cake"}, {127, "Chopped Beef"}, {128, "Pure Beef"}, {129, "Veal"}, {130, "Chicken Wings"}, {131, "Chicken"}, {132, "Parma Ham"}, {133, "Sliced Ham"}, {134, "Peas - Big"}, {135, "Tuna - Big"},
                {136, "Red Beans"}, {137, "Cat Food"}, {138, "Cat Food"}, {139, "Dog Food"}, {140, "Green Tea"}, {141, "Lemon Tea"}, {142, "Black Tea"}, {143, "Peppermint"}, {144, "Mint"}, {145, "Valerian"}, {146, "Big Sushi"},
                {147, "Small Sushi"}, {148, "Smoked Salmon"}, {149, "Crab Sticks"}, {150, "Book - Electromagnetic"}, {151, "Book - Surprise"}, {152, "Book - ABC"}, {153, "Book - Mother And Child"}, {154, "Book - Colors"}, {155, "Book - Piticha"},
                {156, "Book - OnceUpon"}, {157, "Book - Krok"}, {158, "Book - Adventures"}, {159, "Book - Donnine"}, {160, "Book - Vintage"}, {161, "Book - I Wont Share"}, {162, "Beer Pack"}, {163, "Beer Pack"}, {164, "Beer Pack"},
                {165, "Beer Barrel"}, {166, "Beer Barrel"}, {167, "Vodka"}, {168, "Red Wine"}, {169, "Rose Wine"}, {170, "White Wine"}, {171, "Beer Barrel"}, {172, "Premium Vodka"}, {173, "Japanese Whisky"}, {174, "Premium Whisky"},
                {175, "Premium Whisky"}, {176, "Hydrogen Peroxide"}, {177, "Disinfectant"}, {178, "Ibuprofen"}, {179, "Paracetamol"}, {180, "Adhesive Bandages"}, {181, "Laxative"}, {182, "Antihistamine"}, {183, "Zinc Supplement"},
                {184, "Antioxidant"}, {185, "Fish Oil"}, {186, "Algae Pills"}, {187, "Vitamins"}, {188, "Melatonin"}, {189, "Sunscreen"}, {190, "Stretch Cream"}, {191, "Red Apple Tray"}, {192, "Green Apple Tray"}, {193, "Clementine Tray"},
                {194, "Orange Tray"}, {195, "Pear Tray"}, {196, "Lemon Tray"}, {197, "Mango Tray"}, {198, "Avocado Tray"}, {199, "Kiwi Tray"}, {200, "Papaya Tray"}, {201, "Strawberry Tray"}, {202, "Cherry Tray"}, {203, "Artichoke Tray"},
                {204, "Zucchini Tray"}, {205, "Carrot Tray"}, {206, "Tomato Tray"}, {207, "Potato Tray"}, {208, "Onion Tray"}, {209, "Banana Pack"}, {210, "Melon"}, {211, "Pineapple"}, {212, "Pumpkin"}, {213, "Watermelon"},
                {214, "Baby Food: Vegetables"}, {215, "Baby Food: Fish"}, {216, "Baby Food: Fruits"}, {217, "Baby Food: Meat"}, {218, "Nutritive Milk Mix"}, {219, "Nutritive Milk Powder"}, {220, "Ecologic Diapers"}, {221, "Basic Diapers"},
                {222, "Toddler Diapers"}, {223, "Premium Diapers"}, {224, "Aloe Baby Wipes "}, {225, "Basic Baby Wipes"}, {226, "Baby Powder"}, {227, "Orange Soda"}, {228, "Pineapple Soda"}, {229, "Tropical Soda"}, {230, "Green Tea"},
                {231, "Red Tea"}, {232, "Lemon Tea"}, {233, "Cold Brew Coffee"}, {234, "Blueberry Energy Drink"}, {235, "Guava Energy Drink"}, {236, "Lima Energy Drink"}, {237, "Fruit Punch Energy Drink"}, {238, "Mango Energy Drink"},
                {239, "Cola Energy Drink"}, {240, "Sugar Free Energy Drink"}, {241, "Basic Strawberry Ice Cream"}, {242, "Lemon Ice Cream"}, {243, "Coffee Ice Cream"}, {244, "Stracciatella Ice Cream"}, {245, "Strawberry Meringue Ice Cream"},
                {246, "Caramel Ice Cream"}, {247, "Premium Strawberry Ice Cream"}, {248, "Strawberry Cheesecake Ice Cream"}, {249, "Premium Caramel Ice Cream"}, {250, "Pink Strawberry Ice Cream"}, {251, "Alcoholic Ice Cream"},
                {252, "Chickpeas"}, {253, "Meatballs"}, {254, "Lentils"}, {255, "Tomato Soup"}, {256, "Canned Corn"}, {257, "Canned Peas"}
            };

            GameObject gameObject = __instance.customersnpcParentOBJ.transform.GetChild(NPCIndex).gameObject;
            NPC_Info component = gameObject.GetComponent<NPC_Info>();
            int state = component.state;
            NavMeshAgent component2 = gameObject.GetComponent<NavMeshAgent>();
            if (state == -1 || component2.pathPending || !(component2.remainingDistance <= component2.stoppingDistance) || (component2.hasPath && component2.velocity.sqrMagnitude != 0f)) {
                return;
            }
            if (component.productsIDToBuy.Count > 0) {
                switch (state) {
                    case 0: {
                            int productID = component.productsIDToBuy[0];
                            int num4 = __instance.WhichShelfHasItem(productID);
                            if (num4 == -1) {
                                if (BetterSMT.MissingProduct.Value == true) {
                                    string productName = productNames.ContainsKey(productID) ? productNames[productID] : $"Product {productID}";
                                    PlayerObjectController playerController = GameObject.FindObjectOfType<PlayerObjectController>();
                                    string message = $"{productName} is not found on the shelf.";
                                    playerController.CmdSendMessage(message);
                                    Debug.Log(message);
                                }
                            }
                            break;
                        }
                    case 1: {
                            int num = component.productsIDToBuy[0];
                            if (__instance.IsItemInShelf(component.shelfThatHasTheItem, num)) {
                                float num2 = ProductListing.Instance.productPlayerPricing[num];
                                Data_Product component3 = ProductListing.Instance.productPrefabs[num].GetComponent<Data_Product>();
                                int productTier = component3.productTier;
                                float num3 = component3.basePricePerUnit * ProductListing.Instance.tierInflation[productTier] * Random.Range(2f, 2.5f);
                                if (num2 > num3) {
                                    if (BetterSMT.TooExpensive.Value == true) {
                                        string productName = productNames.ContainsKey(num) ? productNames[num] : $"Product {num}";
                                        PlayerObjectController playerController = GameObject.FindObjectOfType<PlayerObjectController>();
                                        string message = $"{productName} is too expensive.";
                                        playerController.CmdSendMessage(message);
                                        Debug.Log(message);
                                    }
                                }
                            }
                            break;
                        }
                }
            }
        }

        public static int SelfCheckoutPatch(NPC_Info npcInfo, NPC_Manager __instance) {
            if (npcInfo.productsIDCarrying.Count == 0) {
                return -1;
            }

            _ = Mathf.Clamp(18 / npcInfo.productsIDCarrying.Count, 0f, 1f);
            for (int i = 0; i < __instance.selfCheckoutOBJ.transform.childCount; i++) {
                Transform station = __instance.selfCheckoutOBJ.transform.GetChild(i);

                Data_Container dataContainer = station.GetComponent<Data_Container>();
                if (dataContainer.checkoutQueue[0]) {
                    continue;
                }

                if (BetterSMT.SelfCheckoutTheft.Value) {
                    if (npcInfo.productsIDCarrying.Count > 6 && UnityEngine.Random.value < 0.02f + (GameData.Instance.difficulty * 0.005f)) {
                        int index = UnityEngine.Random.Range(0, npcInfo.productsIDCarrying.Count);
                        npcInfo.productsIDCarrying.RemoveAt(index);
                        npcInfo.productsCarryingPrice.RemoveAt(index);
                    }
                }
                return i;
            }
            return -1;
        }
    }
}

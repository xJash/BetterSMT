using HarmonyLib;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(GameData))]
public class GameDataPatch {
    #region productNamesList Dict
    public static readonly Dictionary<int,string> productNames = new() { { 0,"Pasta Penne" },{ 1,"Water Bottle" },{ 2,"Honey Cereals" },{ 3,"Rice" },{ 4,"Salt" },{ 5,"Sugar" },{ 6,"Margarine" },{ 7,"Flour" },{ 8,"Apple Juice" },{ 9,"Olive Oil" },{ 10,"Ketchup" },{ 11,"Sliced Bread" },{ 12,"Pepper" },{ 13,"Orange Juice" },{ 14,"Barbaque Sauce" },{ 15,"Mustard Sauce" },{ 16,"Spaghetti Box" },{ 17,"Tuna Pate" },{ 18,"Fiber Cereals" },{ 19,"Supreme Flour" },{ 20,"Black Coffee" },{ 21,"Egg Box" },{ 22,"Houmous" },{ 23,"White Flour" },{ 24,"Cane Sugar Box" },{ 25,"Sugar" },{ 26,"Macarroni" },{ 27,"Ecologic Sugar" },{ 28,"Brown Sugar" },{ 29,"Sunflower Oil" },{ 30,"Mash Potatoes" },{ 31,"Potato Bag" },{ 32,"Espresso Coffee" },{ 33,"Basmati Rice" },{ 34,"Long Grain Rice" },{ 35,"Coffee" },{ 36,"Supreme Pasta" },{ 37,"Chocolate Cereals" },{ 38,"Premium Water" },{ 39,"Spring Water" },{ 40,"Powdered Sugar" },{ 41,"Sugar - Big Box" },{ 42,"Brown Sugar - Big Box" },{ 43,"Emmental Cheese" },{ 44,"Gruyere Cheese" },{ 45,"Skimmed Cheese" },{ 46,"Fruit Yoghurt" },{ 47,"Vanilla Yoghurt" },{ 48,"Milk Brick" },{ 49,"Butter" },{ 50,"Parmigiano Cheese" },{ 51,"Reggiano Cheese" },{ 52,"Mozzarella Cheese" },{ 53,"Skimmed Yoghurt" },{ 54,"Cola Pack" },{ 55,"Soda Pack" },{ 56,"Decaf Soda Pack" },{ 57,"Soda Bottle" },{ 58,"Cola Bottle" },{ 59,"Sugar Free Soda Bottle" },{ 60,"Premium Soda" },{ 61,"Pizza Barbaque" },{ 62,"Fondue" },{ 63,"Crocanti Ham" },{ 64,"Ham Cheese Crepe" },{ 65,"French Fries" },{ 66,"Crispy Potato Pops" },{ 67,"Green Beans" },{ 68,"Four Cheese Pizza" },{ 69,"Four Seasons Pizza" },{ 70,"Vegetable Mix" },{ 71,"Chicken Mix" },{ 72,"Bolognaise Lasagna" },{ 73,"Vegetable Lasagna" },{ 74,"Toothpaste" },{ 75,"Toilet Paper" },{ 76,"Hand Soap" },{ 77,"Avocado Shampoo" },{ 78,"Egg Shampoo" },{ 79,"Bath Gel" },{ 80,"Toilet Paper" },{ 81,"Mango Soap" },{ 82,"Extra Soft Shampoo" },{ 83,"Jojoba Honey Shampoo" },{ 84,"Argan Oil Shampoo" },{ 85,"Paper Towel" },{ 86,"Double Side Toilet Paper" },{ 87,"Lemon Soap" },{ 88,"Premium Bath Gel" },{ 89,"Shampoo For Babies" },{ 90,"Detergent" },{ 91,"Stain Remover" },{ 92,"Glass Cleaner" },{ 93,"Detergent Tables" },{ 94,"Dishwasher" },{ 95,"Bleach" },{ 96,"Bleach - Big Bottle" },{ 97,"Softener" },{ 98,"Premium Detergent" },{ 99,"Insecticide" },{ 100,"Cleaning Cloths" },{ 101,"Premium Capsules" },{ 102,"Premium Bleach" },{ 103,"Ammonia" },{ 104,"Cookie Jar" },{ 105,"Maxi Cone" },{ 106,"Chocolate Spread" },{ 107,"Chocolate Powder" },{ 108,"Chips" },{ 109,"Sweet Bonbek" },{ 110,"Peach Jam" },{ 111,"Ice Cream Box" },{ 112,"Chocolate Box" },{ 113,"Chocolate Biscuit" },{ 114,"Vanilate Biscuit" },{ 115,"Madeleine" },{ 116,"Strawberry Jam" },{ 117,"Peanut Butter" },{ 118,"Chipos" },{ 119,"Marshmallow" },{ 120,"Lemon Biscuit" },{ 121,"Hazelnut Biscuit" },{ 122,"Premium Ice Cream" },{ 123,"Honey" },{ 124,"Premium Chocolate Box" },{ 125,"Foditos" },{ 126,"Premium Cake" },{ 127,"Chopped Beef" },{ 128,"Pure Beef" },{ 129,"Veal" },{ 130,"Chicken Wings" },{ 131,"Chicken" },{ 132,"Parma Ham" },{ 133,"Sliced Ham" },{ 134,"Peas - Big" },{ 135,"Tuna - Big" },{ 136,"Red Beans" },{ 137,"Cat Food" },{ 138,"Cat Food" },{ 139,"Dog Food" },{ 140,"Green Tea" },{ 141,"Lemon Tea" },{ 142,"Black Tea" },{ 143,"Peppermint" },{ 144,"Mint" },{ 145,"Valerian" },{ 146,"Big Sushi" },{ 147,"Small Sushi" },{ 148,"Smoked Salmon" },{ 149,"Crab Sticks" },{ 150,"Book - Electromagnetic" },{ 151,"Book - Surprise" },{ 152,"Book - ABC" },{ 153,"Book - Mother And Child" },{ 154,"Book - Colors" },{ 155,"Book - Piticha" },{ 156,"Book - OnceUpon" },{ 157,"Book - Krok" },{ 158,"Book - Adventures" },{ 159,"Book - Donnine" },{ 160,"Book - Vintage" },{ 161,"Book - I Wont Share" },{ 162,"Beer Pack" },{ 163,"Beer Pack" },{ 164,"Beer Pack" },{ 165,"Beer Barrel" },{ 166,"Beer Barrel" },{ 167,"Vodka" },{ 168,"Red Wine" },{ 169,"Rose Wine" },{ 170,"White Wine" },{ 171,"Beer Barrel" },{ 172,"Premium Vodka" },{ 173,"Japanese Whisky" },{ 174,"Premium Whisky" },{ 175,"Premium Whisky" },{ 176,"Hydrogen Peroxide" },{ 177,"Disinfectant" },{ 178,"Ibuprofen" },{ 179,"Paracetamol" },{ 180,"Adhesive Bandages" },{ 181,"Laxative" },{ 182,"Antihistamine" },{ 183,"Zinc Supplement" },{ 184,"Antioxidant" },{ 185,"Fish Oil" },{ 186,"Algae Pills" },{ 187,"Vitamins" },{ 188,"Melatonin" },{ 189,"Sunscreen" },{ 190,"Stretch Cream" },{ 191,"Red Apple Tray" },{ 192,"Green Apple Tray" },{ 193,"Clementine Tray" },{ 194,"Orange Tray" },{ 195,"Pear Tray" },{ 196,"Lemon Tray" },{ 197,"Mango Tray" },{ 198,"Avocado Tray" },{ 199,"Kiwi Tray" },{ 200,"Papaya Tray" },{ 201,"Strawberry Tray" },{ 202,"Cherry Tray" },{ 203,"Artichoke Tray" },{ 204,"Zucchini Tray" },{ 205,"Carrot Tray" },{ 206,"Tomato Tray" },{ 207,"Potato Tray" },{ 208,"Onion Tray" },{ 209,"Banana Pack" },{ 210,"Melon" },{ 211,"Pineapple" },{ 212,"Pumpkin" },{ 213,"Watermelon" },{ 214,"Baby Food: Vegetables" },{ 215,"Baby Food: Fish" },{ 216,"Baby Food: Fruits" },{ 217,"Baby Food: Meat" },{ 218,"Nutritive Milk Mix" },{ 219,"Nutritive Milk Powder" },{ 220,"Ecologic Diapers" },{ 221,"Basic Diapers" },{ 222,"Toddler Diapers" },{ 223,"Premium Diapers" },{ 224,"Aloe Baby Wipes " },{ 225,"Basic Baby Wipes" },{ 226,"Baby Powder" },{ 227,"Orange Soda" },{ 228,"Pineapple Soda" },{ 229,"Tropical Soda" },{ 230,"Green Tea Drink" },{ 231,"Red Tea Drink" },{ 232,"Lemon Tea Drink" },{ 233,"Cold Brew Coffee" },{ 234,"Blueberry Energy Drink" },{ 235,"Guava Energy Drink" },{ 236,"Lima Energy Drink" },{ 237,"Fruit Punch Energy Drink" },{ 238,"Mango Energy Drink" },{ 239,"Cola Energy Drink" },{ 240,"Sugar Free Energy Drink" },{ 241,"Basic Strawberry Ice Cream" },{ 242,"Lemon Ice Cream" },{ 243,"Coffee Ice Cream" },{ 244,"Stracciatella Ice Cream" },{ 245,"Strawberry Meringue Ice Cream" },{ 246,"Caramel Ice Cream" },{ 247,"Premium Strawberry Ice Cream" },{ 248,"Strawberry Cheesecake Ice Cream" },{ 249,"Premium Caramel Ice Cream" },{ 250,"Pink Strawberry Ice Cream" },{ 251,"Alcoholic Ice Cream" },{ 252,"Chickpeas" },{ 253,"Meatballs" },{ 254,"Lentils" },{ 255,"Tomato Soup" },{ 256,"Canned Corn" },{ 257,"Canned Peas" },{ 258,"Strawberry Seeds" },{ 259,"Raspberry Seeds" },{ 260,"Blueberry Seeds" },{ 261,"Pineapple Seeds" },{ 262,"Meyer Lemon Seeds" },{ 263,"Tomato Seeds" },{ 264,"Pepper Seeds" },{ 265,"Cucumber Seeds" },{ 266,"Radish Seeds" },{ 267,"Carrots Seeds" },{ 268,"Lawn Seeds" },{ 269,"Poppy Seeds" },{ 270,"Tulip Seeds" },{ 271,"Sunflower Seeds" },{ 272,"Petunia Seeds" },{ 273,"Hand Rake (A)" },{ 274,"Hand Rake (B)" },{ 275,"Hand Shovel" },{ 276,"Hand Cultivator" },{ 277,"Potting Soil" },{ 278,"Fertilizer" },{ 279,"Plant Pot Dish" },{ 280,"Plant Pot" },{ 281,"AA Batteries" },{ 282,"AAA Batteries" },{ 283,"C Batteries" },{ 284,"9V Batteries" },{ 285,"Universal TV Remote" },{ 286,"Universal Phone Charger" },{ 287,"Basic Prepaid Phone" },{ 288,"Basic Mouse" },{ 289,"Wifi Dongle" },{ 290,"Basic Earbuds" },{ 291,"Basic Keyboard" },{ 292,"Basic Gamepad" },{ 293,"USB Flash Drive (128GB)" },{ 294,"USB Flash Drive (256GB)" },{ 295,"USB Flash Drive (512GB)" },{ 296,"USB Flash Drive (1TB)" },{ 297,"Basic Speaker" },{ 298,"Basic Headphones" },{ 299,"Basic Gaming Console" },{ 300,"Garlic Tray" },{ 301,"Mushroom Tray" },{ 302,"Bell Pepper Tray" },{ 303,"Lettuce Tray" },{ 304,"Coconut" },{ 305,"Cauliflower" },{ 306,"Peanuts" },{ 307,"Almonds" },{ 308,"Hazelnuts" },{ 309,"Pistachios" },{ 310,"Raisins" },{ 311,"Cashew Nuts" },{ 312,"Shelled Walnuts" },{ 313,"Coconut Chips" },{ 314,"Baking Powder" },{ 315,"Baking Soda" },{ 316,"Cake Mix" },{ 317,"Cocoa Powder" },{ 318,"Cornstarch" },{ 319,"Icing Tube" },{ 320,"Candy Sprinkles" },{ 321,"Vanilla Extract" } };
    #endregion

    private static BetterSMTLoanSystem loanSystemInstance;

    [HarmonyPatch("OnStartClient"), HarmonyPostfix]
    private static void UpdateEscapeMenu() {
        GameObject escapeMenu = GameObject.Find("MasterOBJ/MasterCanvas/Menus/EscapeMenu/");
        GameObject quitButton = escapeMenu.transform.Find("QuitButton")?.gameObject;
        GameObject mainMenuButton = escapeMenu.transform.Find("MainMenuButton")?.gameObject;
        GameObject optionsButton = escapeMenu.transform.Find("OptionsButton")?.gameObject;
        quitButton.transform.localPosition = new Vector3(0f,0f,0f);
        mainMenuButton.transform.localPosition = new Vector3(0f,85f,0f);
        GameObject saveButton = Object.Instantiate(quitButton,escapeMenu.transform);
        saveButton.name = "SaveButton";

        foreach(PlayMakerFSM fsm in saveButton.GetComponents<PlayMakerFSM>()) {
            Object.Destroy(fsm);
        }

        Object.Destroy(saveButton.GetComponent<EventTrigger>());
        saveButton.transform.localPosition = new Vector3(0f,-125f,0f);
        saveButton.transform.localScale = quitButton.transform.localScale;

        TextMeshProUGUI textComponent = saveButton.GetComponentInChildren<TextMeshProUGUI>();
        if(textComponent != null) {
            textComponent.text = "Save Game (BSMT)";
        }

        Button buttonComp = saveButton.GetComponent<Button>();
        buttonComp.onClick.AddListener(() => {
            _ = GameData.Instance.StartCoroutine(SaveGame());
        });

        if(!GameData.Instance.isServer) {
            saveButton.SetActive(false);
        }
    }

    public static IEnumerator SaveGame() {
        NetworkSpawner spawner = GameData.Instance.GetComponent<NetworkSpawner>();
        if(spawner.isSaving) {
            BetterSMT.CreateImportantNotification("Saving already in progress");
            yield break;
        }

        BetterSMT.CreateImportantNotification("Saving Game");

        GameData.Instance.DoDaySaveBackup();

        PlayMakerFSM fsm = GameData.Instance.SaveOBJ.GetComponent<PlayMakerFSM>();
        HutongGames.PlayMaker.FsmBool isSavingVar = fsm.FsmVariables.GetFsmBool("IsSaving");
        isSavingVar.Value = true;
        fsm.SendEvent("Send_Data");

        float timeout = 10f;
        float elapsed = 0f;

        while(isSavingVar.Value) {
            if(elapsed > timeout) {
                BetterSMT.CreateImportantNotification("Save timed out.");
                yield break;
            }
            elapsed += Time.deltaTime;
            yield return null;
        }

        yield return spawner.SavePropsCoroutine(false);

        BetterSMT.CreateImportantNotification("Saving Finished");
    }

    [HarmonyPatch("OnStartClient"), HarmonyPostfix]
    private static void AutopayInvoices(DebtManager __instance) {
        if(__instance == null) {
            return;
        }

        __instance.GetComponent<DebtManager>().autopayInvoices = BetterSMT.AutoPayAllInvoices?.Value ?? false;
    }

    [HarmonyPatch("UserCode_CmdAlterFunds__Single"), HarmonyPrefix]
    private static bool UserCode_CmdAlterFunds__SinglePatch(float fundsToAdd,GameData __instance) {
        if(BetterSMT.ExpRate.Value != 1) {
            float value = __instance.gameFunds + fundsToAdd;
            value = Mathf.Clamp(value,0f,2.14E+09f);
            __instance.NetworkgameFunds = Mathf.Round(value * 100f) / 100f;
            if(fundsToAdd > 0f) {
                float value2 = 0.5f - (__instance.gameFranchiseLevel * 0.004f);
                value2 = Mathf.Clamp(value2,0.05f,1f);
                __instance.NetworkgameFranchiseExperience = (__instance.gameFranchiseExperience + (int)(fundsToAdd * value2)) * BetterSMT.ExpRate.Value;
                __instance.todaysFranchiseExperience += (int)(fundsToAdd * value2) * BetterSMT.ExpRate.Value;
                __instance.dayBenefits += (int)fundsToAdd;
            } else {
                __instance.otherCosts += fundsToAdd;
            }
            __instance.RpcAlterFunds(fundsToAdd);
            int num = 0;
            for(int i = 1; i < float.PositiveInfinity; i++) {
                num += i * 100;
                if(num > __instance.gameFranchiseExperience) {
                    if(i > __instance.lastAwardedFranchiseLevel) {
                        __instance.NetworkgameFranchisePoints = __instance.gameFranchisePoints + 1;
                        __instance.lastAwardedFranchiseLevel = i;
                    }
                    break;
                }
            }
            return false;
        } else {
            return true;
        }
    }

    [HarmonyPatch("OnStartClient"), HarmonyPostfix]
    private static void UpdateInvoiceMenu() {
        if(!BetterSMT.LoanEarly.Value) {
            return;
        }

        GameObject invoiceMenu = GameObject.Find("Interactables/Canvas_Manager/Tabs/Invoices_Tab/");
        GameObject original = invoiceMenu.transform.Find("PayThisInvoiceButton")?.gameObject;
        GameObject newButton = new("PayInvoiceEarlyButton",typeof(RectTransform),typeof(CanvasRenderer),typeof(Image),typeof(Button));
        newButton.transform.SetParent(invoiceMenu.transform,false);
        RectTransform newRect = newButton.GetComponent<RectTransform>();
        RectTransform originalRect = original.GetComponent<RectTransform>();
        newRect.anchorMin = originalRect.anchorMin;
        newRect.anchorMax = originalRect.anchorMax;
        newRect.pivot = originalRect.pivot;
        newRect.sizeDelta = originalRect.sizeDelta;
        newRect.anchoredPosition = new Vector2(431f,-109f);
        Image newImage = newButton.GetComponent<Image>();
        Image originalImage = original.GetComponent<Image>();
        newImage.sprite = originalImage.sprite;
        newImage.type = originalImage.type;
        newImage.color = originalImage.color;
        GameObject textGO = new("PayInvoiceEarly_Text",typeof(RectTransform),typeof(CanvasRenderer),typeof(TextMeshProUGUI));
        textGO.transform.SetParent(newButton.transform,false);
        RectTransform textRect = textGO.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;
        TextMeshProUGUI tmp = textGO.GetComponent<TextMeshProUGUI>();
        tmp.text = "Pay Loan Early";
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.fontSize = 24;
        tmp.color = Color.black;

        TextMeshProUGUI originalTMP = original.GetComponentInChildren<TextMeshProUGUI>();

        tmp.font = originalTMP.font;
        tmp.material = originalTMP.material;


        Button btn = newButton.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            if(loanSystemInstance != null && NetworkClient.active) {
                loanSystemInstance.CmdPayLoanEarly();
            }
        });

        Button originalBtn = original.GetComponent<Button>();
        btn.transition = originalBtn.transition;
        btn.colors = originalBtn.colors;
        btn.navigation = originalBtn.navigation;

        if(!GameData.Instance.isServer) {
            newButton.SetActive(false);
        }
    }

    [HarmonyPatch("Awake"), HarmonyPostfix]
    private static void EnsureLoanSystemComponent(GameData __instance) {
        loanSystemInstance = __instance.GetComponent<BetterSMTLoanSystem>();
        if(loanSystemInstance == null) {
            loanSystemInstance = __instance.gameObject.AddComponent<BetterSMTLoanSystem>();
        }
    }

    public class BetterSMTLoanSystem : NetworkBehaviour {
        [Command(requiresAuthority = false)]
        public void CmdPayLoanEarly() {

            DebtManager debtManager = GameData.Instance.GetComponent<DebtManager>();
            int totalLoan = debtManager.NetworkloanAmount;

            if(totalLoan <= 0) {
                BetterSMT.CreateImportantNotification("No active loan to pay.");
                return;
            }

            if(GameData.Instance.gameFunds < totalLoan) {
                BetterSMT.CreateImportantNotification("Not enough funds to pay off the loan.");
                return;
            }

            GameData.Instance.CmdAlterFundsWithoutExperience(-totalLoan);
            debtManager.NetworkloanAmount = 0;
            debtManager.NetworkloanPaymentPerDay = 0;

            for(int i = 0; i < debtManager.NetworkcurrentInvoicesData.Length; i++) {
                string invoice = debtManager.NetworkcurrentInvoicesData[i];
                if(!string.IsNullOrEmpty(invoice)) {
                    debtManager.GetInvoiceDataValues(invoice,out int invoiceTypeID,out _,out _,out _,out _);
                    if(invoiceTypeID == 0) {
                        debtManager.NetworkcurrentInvoicesData[i] = "";
                    }
                }
            }

            if(debtManager.loanDisclaimerContainerOBJ != null && debtManager.loanDisclaimerContainerOBJ.activeSelf) {
                debtManager.loanDisclaimerContainerOBJ.SetActive(false);
            }

            debtManager.GenerateExistingDebtsInUI();
            BetterSMT.CreateImportantNotification("Loan paid off early.");
        }
    }

    [HarmonyPatch(nameof(GameData.ServerCalculateNewInflation))]
    [HarmonyPostfix]
    public static void OptimizeProductPrices() {
        if(!BetterSMT.AutoAdjustPriceDaily.Value) {
            return;
        }

        ProductListing productListing = ProductListing.Instance;
        GameObject[] products = productListing.productPrefabs;
        float[] inflationMultipliers = productListing.tierInflation;
        float priceMultiplier = BetterSMT.AutoAdjustPriceDailyValue.Value;

        for(int i = 0; i < products.Length; i++) {
            Data_Product product = products[i]?.GetComponent<Data_Product>();
            if(product == null) {
                continue;
            }

            float basePrice = product.basePricePerUnit;
            int tier = product.productTier;
            float inflation = (tier >= 0 && tier < inflationMultipliers.Length) ? inflationMultipliers[tier] : 1f;
            float adjustedPrice = basePrice * inflation * priceMultiplier;
            float finalPrice = Mathf.Floor(adjustedPrice * 100) / 100f;

            productListing.CmdUpdateProductPrice(i,finalPrice);
        }
    }

    [HarmonyPatch("OnStartClient"), HarmonyPostfix]
    public static void ShowCounters() {
        if(BetterSMT.ShowPing.Value) {
            EnableUIElement("MasterOBJ/MasterCanvas/Ping","Ping");
        }

        if(BetterSMT.ShowFPS.Value) {
            EnableUIElement("MasterOBJ/MasterCanvas/FPSDisplay","FPSDisplay");
        }
    }

    private static void EnableUIElement(string path,string label) {
        GameObject obj = GameObject.Find(path);
        if(obj == null) {
            BetterSMT.Logger.LogWarning($"Couldn't find {label} object at path '{path}'");
            return;
        }
        obj.SetActive(true);
    }

    [HarmonyPatch("AddExpensiveList"), HarmonyPostfix]
    public static void AddExpensiveListPatch(GameData __instance,int productID) {
        NotifyAndTrack(
            __instance.productsTooExpensiveList,
            productID,
            BetterSMT.TooExpensiveNotifications.Value,
            "{0} is too expensive.",
            __instance
        );
    }

    [HarmonyPatch("AddNotFoundList"), HarmonyPostfix]
    public static void AddNotFoundListPatch(GameData __instance,int productID) {
        NotifyAndTrack(
            __instance.productsNotFoundList,
            productID,
            BetterSMT.MissingProductNotifications.Value,
            "{0} is not found on the shelf.",
            __instance
        );
    }

    private static void NotifyAndTrack(List<int> list,int productID,bool notifyEnabled,string messageTemplate,GameData __instance) {
        if(!list.Contains(productID)) {
            list.Add(productID);
        }

        if(notifyEnabled) {
            string productName = productNames.TryGetValue(productID,out string name) ? name : $"Product {productID}";
            PlayerObjectController playerController = GameObject.FindObjectOfType<PlayerObjectController>();
            string message = string.Format(messageTemplate,productName);
            playerController?.CmdSendMessage(message);
        }
    }

    [HarmonyPatch(typeof(GameData),"UserCode_CmdOpenSupermarket")]
    [HarmonyPostfix]
    public static void MaxCustomersNPCsPatch(GameData __instance) {
        if(__instance.isSupermarketOpen || (__instance.timeOfDay > 8f && __instance.timeOfDay < 23f)) {
            int playerCount = NetworkServer.connections.Count;
            int baseCart = BetterSMT.BaseCustomerCart.Value;
            int maxCart = BetterSMT.MaxCustomerCart.Value;
            int baseSpawns = BetterSMT.BaseCustomerSpawns.Value;
            int maxInStore = BetterSMT.MaxCustomerInStore.Value;

            __instance.maxProductsCustomersToBuy = Mathf.Clamp(
                baseCart + (__instance.gameDay / 2) + playerCount + __instance.difficulty,
                baseCart,
                maxCart + playerCount + __instance.difficulty
            );

            __instance.maxCustomersNPCs = Mathf.Clamp(
                baseSpawns + __instance.gameDay + ((playerCount - 1) * 4) + __instance.extraCustomersPerk + (__instance.difficulty * 2),
                baseSpawns,
                maxInStore + playerCount
            );
        }
    }

    [HarmonyPatch("TrashManager"), HarmonyPrefix]
    public static bool NextTimeToSpawnTrashPatch(GameData __instance) {
        return BetterSMT.DisableAllTrash.Value;
    }
}
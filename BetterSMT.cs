using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BetterSMT.Patches;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace BetterSMT;

[BepInPlugin(PluginInfo.PLUGIN_GUID,PluginInfo.PLUGIN_NAME,PluginInfo.PLUGIN_VERSION)]
public class BetterSMT : BaseUnityPlugin {
    private readonly Harmony harmony = new(PluginInfo.PLUGIN_GUID);
    public static BetterSMT Instance;
    internal static new ManualLogSource Logger { get; private set; } = null!;

    // === !Pillar Modification! ===
    public static ConfigEntry<float> PillarPrice;
    public static ConfigEntry<bool> PillarRubble;

    // === !Debt! ===
    public static ConfigEntry<bool> AutoPayAllInvoices;

    // === !Sales Settings! ===
    public static ConfigEntry<int> SalesActiveAmount;
    public static ConfigEntry<KeyboardShortcut> ClearSales;
    public static ConfigEntry<bool> ToggleClearSalesHotkey;
    public static ConfigEntry<bool> SalesToggle;
    public static ConfigEntry<KeyboardShortcut> SalesHotkey;

    // === !Product Settings!===
    public static ConfigEntry<bool> LowStockAlertEnabled;
    public static ConfigEntry<int> LowStockThreshold;
    public static ConfigEntry<bool> AutoOrderEnabled;
    public static ConfigEntry<int> AutoOrderCheckInterval;

    // === !Employee & Customer Settings! ===
    public static ConfigEntry<int> CustomersPerPerk;
    public static ConfigEntry<int> MaxCustomerInStore;
    public static ConfigEntry<int> BaseCustomerSpawns;
    public static ConfigEntry<int> BaseCustomerCart;
    public static ConfigEntry<int> MaxCustomerCart;
    public static ConfigEntry<int> EmployeesLevel;
    public static ConfigEntry<bool> EmployeesEnabled;
    public static ConfigEntry<float> EmployeeSpeedPerPerk;
    public static ConfigEntry<float> EmployeeRestockPerPerk;
    public static ConfigEntry<float> EmployeeCheckoutPerPerk;
    public static ConfigEntry<float> EmployeExtraCheckoutMoney;

    // === !Thieves & Crime Settings! ===
    public static ConfigEntry<bool> OneHitThief;
    public static ConfigEntry<bool> SelfCheckoutTheft;
    public static ConfigEntry<bool> DisableAllThieves;
    public static ConfigEntry<bool> AllNPCAreThieves;

    // === !Gameplay Settings! ===
    public static ConfigEntry<bool> InstantSelfCheckout;
    public static ConfigEntry<bool> FasterCheckout;
    public static ConfigEntry<bool> ShowFPS;
    public static ConfigEntry<bool> ShowPing;
    public static ConfigEntry<bool> DisableAllTrash;
    public static ConfigEntry<bool> AlwaysAbleToDeleteMode;
    public static ConfigEntry<bool> DeleteAllCheckouts;
    public static ConfigEntry<bool> FullDeletionRefund;
    public static ConfigEntry<bool> AllTrashToRecyclers;

    // === !Pricing Assistance! ===
    public static ConfigEntry<bool> roundDown;
    public static ConfigEntry<bool> NearestFive;
    public static ConfigEntry<bool> NearestTen;
    public static bool doublePrice = true;
    public static ConfigEntry<bool> ToggleDoublePrice;
    public static ConfigEntry<bool> AutoAdjustPriceDaily;
    public static ConfigEntry<float> AutoAdjustPriceDailyValue;
    public static bool notify = false;
    public static string notificationType;

    // === !Mini Transport Vehicle! ===
    public static ConfigEntry<bool> EnableMTV;
    public static ConfigEntry<int> MaxBoxes;
    public static ConfigEntry<float> AutoPickupRange;
    public static ConfigEntry<KeyboardShortcut> MTVHotkey;
    public static ConfigEntry<float> DropCooldown;

    // === !Random Features! ===
    public static ConfigEntry<int> ExpRate;
    public static ConfigEntry<bool> ShoplifterDetectionNotif;
    public static ConfigEntry<bool> OneClickCheckMark;
    public static ConfigEntry<bool> AllowFreePlacement;
    public static ConfigEntry<bool> CheatPlacement;
    public static ConfigEntry<bool> ProductStacking;
    public static ConfigEntry<bool> EnablePalletDisplaysPerk;
    public static ConfigEntry<bool> ReplaceCommasWithPeriods;
    public static ConfigEntry<string> CurrencyTypeToAny;
    public static ConfigEntry<bool> CardboardBalerBreak;
    public static ConfigEntry<bool> SelfCheckoutBreak;
    public static ConfigEntry<bool> CloserBoxSpawning;

    // === !Highlighting! ===
    public static ConfigEntry<bool> StorageHighlighting;

    // === !Hotkey Configurations! ===
    public static ConfigEntry<bool> ThirdPersonToggle;
    public static ConfigEntry<KeyboardShortcut> ThirdPersonHotkey;
    public static ConfigEntry<KeyboardShortcut> KeyboardShortcutDoublePrice;
    public static ConfigEntry<KeyboardShortcut> KeyboardShortcutRoundDownSwitch;
    public static ConfigEntry<KeyboardShortcut> KeyboardShortcutRoundDownToggle;
    public static ConfigEntry<KeyboardShortcut> PricingGunHotkey;
    public static ConfigEntry<bool> PricingGunToggle;
    public static ConfigEntry<KeyboardShortcut> BroomHotkey;
    public static ConfigEntry<bool> BroomToggle;
    public static ConfigEntry<KeyboardShortcut> DLCTabletHotkey;
    public static ConfigEntry<bool> DLCTabletToggle;
    public static ConfigEntry<KeyboardShortcut> EmptyHandsHotkey;
    public static ConfigEntry<bool> SledgeToggle;
    public static ConfigEntry<KeyboardShortcut> SledgeHotkey;
    public static ConfigEntry<bool> OsMartToggle;
    public static ConfigEntry<KeyboardShortcut> OsMartHotkey;
    public static ConfigEntry<bool> TrayToggle;
    public static ConfigEntry<KeyboardShortcut> TrayHotkey;
    public static ConfigEntry<KeyboardShortcut> LadderHotkey;
    public static ConfigEntry<bool> LadderToggle;
    public static ConfigEntry<KeyboardShortcut> ClockHotkey;
    public static ConfigEntry<bool> ClockToggle;

    // === !Random QoL! ===
    public static ConfigEntry<bool> LoanEarly;
    public static ConfigEntry<bool> NumberKeys;
    public static ConfigEntry<int> SelfCheckoutLimit;
    public static ConfigEntry<bool> TooExpensiveNotifications;
    public static ConfigEntry<bool> MissingProductNotifications;
    public static ConfigEntry<int> MaxBoxSize;
    public static ConfigEntry<bool> DisableBoxCollisions;
    public static ConfigEntry<bool> FastBoxSpawns;
    public static ConfigEntry<float> ClockSpeed;
    public static ConfigEntry<bool> ClockMorning;
    public static ConfigEntry<bool> AutoOrdering;
    public static ConfigEntry<bool> QuickStocking;
    public static ConfigEntry<int> CardboardBalerValue;
    public static ConfigEntry<bool> PalletProduct;
    public static ConfigEntry<bool> AllProduct;

    // === !Ordering! ===
    public static ConfigEntry<bool> OrderPackaging;
    public static ConfigEntry<float> OrderSpeedUp;
    public static ConfigEntry<float> OrderIncreasedMax;

    // === ! Save Settings! ===
    public static ConfigEntry<bool> AutoSaveEnabled;
    public static ConfigEntry<int> AutoSaveTimer;
    public static ConfigEntry<bool> AutoSaveDuringDay;
    public static ConfigEntry<bool> SaveGame;

    [System.Obsolete]
    private void Awake() {
        // === !Auto Save Settings! ===
        AutoSaveEnabled = base.Config.Bind("Save Settings","Enables Auto Saving",false,new ConfigDescription("Enables or disables automatic saving"));
        AutoSaveTimer = base.Config.Bind("Save Settings","Amount of time between saves",120,new ConfigDescription("Adjusts the amount of time between auto saves in seconds, default is 120seconds or 2minutes",new AcceptableValueRange<int>(30,900)));
        AutoSaveDuringDay = base.Config.Bind("Save Settings","Enables Auto Saving during the day",false,new ConfigDescription("Enables or disables saving while the store is open, default only autosaves while closed"));
        SaveGame = Config.Bind("Save Settings","Save Game Button",true,new ConfigDescription("Enables or disables the Save Game button in the ESC menu"));

        // === !Ordering! ===
        OrderPackaging = Config.Bind("Order Packaging","Enables custom order packaging",false,new ConfigDescription("Optionally does not spawn rubble when destroying a pillar"));
        OrderSpeedUp = base.Config.Bind("Order Packaging","Speeds up how often orders come",0f,new ConfigDescription("Works as a percent multiplier. 1.1 = 10% faster. 2.3 = 130% faster.",new AcceptableValueRange<float>(0f,500f)));
        OrderIncreasedMax = base.Config.Bind("Order Packaging","Increases max amount of orders per day",0f,new ConfigDescription("Flat number to increase the max amount of orders you get per day. Default was random value of 2 through 40.",new AcceptableValueRange<float>(0f,240)));

        // === !Pillar Mods! ===
        PillarRubble = Config.Bind("Pillar Mods","Disable Rubble",false,new ConfigDescription("Optionally does not spawn rubble when destroying a pillar"));
        PillarPrice = base.Config.Bind("Pillar Mods","Change Price",4000f,new ConfigDescription("Changes the price of destroying a pillar.",new AcceptableValueRange<float>(0f,50000f)));

        // === !Sales Settings! ===
        SalesHotkey = Config.Bind("Sales Settings","Sales Tablet Hotkey",new KeyboardShortcut(KeyCode.Z),new ConfigDescription("Hotkey to spawn a Sales Tablet in your hands."));
        SalesToggle = Config.Bind("Sales Settings","Sales Tablet Toggle",false,new ConfigDescription("Enables the hotkey to activate Sales Tablet"));
        ClearSales = Config.Bind("Sales Settings","Clear Sales",new KeyboardShortcut(KeyCode.X),new ConfigDescription("Hotkey to clear current sales."));
        ToggleClearSalesHotkey = base.Config.Bind("Sales Settings","Enables or disables hotkey to clear sales",false,new ConfigDescription("Enables or disables the hotkey to clear sales"));
        SalesActiveAmount = base.Config.Bind("Sales Settings","Amount of sales unlocked each perk",2,new ConfigDescription("Adjusts the amount of sales you unlock for each perk",new AcceptableValueRange<int>(1,100)));

        // === !Auto Ordering Settings! ===
        AutoOrderEnabled = base.Config.Bind("Auto Ordering","Enable Auto Ordering",false,new ConfigDescription("Automatically orders products when stock is low. Only works when Ordering Tablet is in your hands."));
        AutoOrderCheckInterval = base.Config.Bind("Auto Ordering","Auto Order Check Interval",30,new ConfigDescription("Time interval (in seconds) for checking product stock",new AcceptableValueRange<int>(10,600)));

        // === !Low Stock Alerts! ===
        LowStockAlertEnabled = base.Config.Bind("Low Stock Alerts","Enable Low Stock Alerts",false,new ConfigDescription("Show alerts when products drop below the threshold"));
        LowStockThreshold = base.Config.Bind("Low Stock Alerts","Low Stock Threshold",2,new ConfigDescription("The stock count at which alerts are triggered",new AcceptableValueRange<int>(1,1000)));

        // === !Employee & Customer Settings! ===
        EmployeExtraCheckoutMoney = base.Config.Bind("Employee & Customer Settings","Employe Increased Income While Checking Customer Out Perk",0.1f,new ConfigDescription("Adjust the amount of extra income you receive when an employee checks out a customer (Higher = more income)",new AcceptableValueRange<float>(0f,0.3f)));
        EmployeeCheckoutPerPerk = base.Config.Bind("Employee & Customer Settings","Employee Checkout Time Reduction Perk 1",.15f,new ConfigDescription("Adjust the amount of time employees wait to scan items in checkout (Perk 1) (Lower = slower)",new AcceptableValueRange<float>(0.01f,0.24f)));
        MaxCustomerCart = base.Config.Bind("Employee & Customer Settings","Maximum amount of product customers will buy",25,new ConfigDescription("Adjust the maximum amount of product customers will buy",new AcceptableValueRange<int>(1,75)));
        BaseCustomerCart = base.Config.Bind("Employee & Customer Settings","Minimum amount of product customers will buy",5,new ConfigDescription("Adjust the minimum amount of product customers will buy",new AcceptableValueRange<int>(1,15)));
        BaseCustomerSpawns = base.Config.Bind("Employee & Customer Settings","Minimum amount of customers that will spawn",3,new ConfigDescription("Adjust the minimum amount of customer's that can spawn",new AcceptableValueRange<int>(1,9)));
        MaxCustomerInStore = base.Config.Bind("Employee & Customer Settings","Max amount of customers in store",70,new ConfigDescription("Adjust the amount of customers that can spawn at one time",new AcceptableValueRange<int>(1,210)));
        CustomersPerPerk = base.Config.Bind("Employee & Customer Settings","Extra Customers per perk",1,new ConfigDescription("Adjust the amount of customers you gain per perk (Higher number = more customers)",new AcceptableValueRange<int>(1,5)));
        EmployeesLevel = base.Config.Bind("Employee & Customer Settings","Employees Level",0,new ConfigDescription("Adjust the level of employee's that spawn (1 sets all of their stats to minimum, 30 sets them all to max)",new AcceptableValueRange<int>(0,30)));
        EmployeeSpeedPerPerk = base.Config.Bind("Employee & Customer Settings","Employee Speed Per Perk",.2f,new ConfigDescription("Adjust the amount of speed employees gain per perk (Higher = faster)",new AcceptableValueRange<float>(.01f,.6f)));
        EmployeeRestockPerPerk = base.Config.Bind("Employee & Customer Settings","Employee Restock Time Reduction Per Perk",0.05f,new ConfigDescription("Adjust the amount of time it takes for employees to restock per perk (Lower = faster)",new AcceptableValueRange<float>(0.01f,0.15f)));

        // === !Thieves & Crime Settings! ===
        AllNPCAreThieves = base.Config.Bind("Thieves & Crime Settings","All Thieves",false,new ConfigDescription("Causes every NPC to be a thief"));
        SelfCheckoutTheft = base.Config.Bind("Thieves & Crime Settings","Self-Checkout Theft",true,new ConfigDescription("Enables or disables default game's theft from self checkout"));
        DisableAllThieves = base.Config.Bind("Thieves & Crime Settings","Disable Thieves",false,new ConfigDescription("Prevent thieves from spawning (Does not stop checkout-related thieves)"));
        OneHitThief = base.Config.Bind("Thieves & Crime Settings","Thiefs Drop Everything On Hit",false,new ConfigDescription("Thiefs Drop Everything On Hit"));

        // === !Gameplay Settings! ===
        InstantSelfCheckout = base.Config.Bind("Gameplay Setting","Faster Self-Checkout",false,new ConfigDescription("Customers place all items instantly on to the self-checkout"));
        FasterCheckout = base.Config.Bind("Gameplay Settings","Faster Checkout",false,new ConfigDescription("Customers place all items instantly on to the checkout"));
        ShowFPS = base.Config.Bind("Gameplay Settings","Show FPS Counter",false);
        ShowPing = base.Config.Bind("Gameplay Settings","Show Ping Counter",false);
        DisableAllTrash = base.Config.Bind("Gameplay Settings","Despawns trash",false,new ConfigDescription("Despawns all trash at the end of the day"));
        AlwaysAbleToDeleteMode = base.Config.Bind("Gameplay Settings","Always access to delete",false,new ConfigDescription("Delete shelves and others while customers are in store and store is open"));
        DeleteAllCheckouts = Config.Bind("Gameplay Settings","Enable or disable deleting all checkout lanes",false,new ConfigDescription("Adds the ability to delete every checkout lane"));
        FullDeletionRefund = Config.Bind("Gameplay Settings","Full refund on buildings",false,new ConfigDescription("Provides 100% of the cost of buildings when being deleted"));
        AllTrashToRecyclers = Config.Bind("Gameplay Settings","All Recyclers",false,new ConfigDescription("Turns the nearest trash can into a recycler without the perk."));

        // === !Highlighting! ===
        StorageHighlighting = Config.Bind("Highlighting","This feature has been deprecated from BetterSMT and moved to SuperQoLity.",false,new ConfigDescription("This feature has been deprecated from BetterSMT and moved to SuperQoLity."));

        // === !Mini Transport Vehicle! ===
        EnableMTV = Config.Bind("Mini Transport Vehicle","Enable custom Mini Transport Vehicle features",false,new ConfigDescription("Enables or disables custom Mini Transport Vehicle features below."));
        AutoPickupRange = base.Config.Bind("Mini Transport Vehicle","Change the range of auto-picking up boxes",3f,new ConfigDescription("Adjusts how far away a box will be automatically picked up onto the Mini Transport Vehicle.",new AcceptableValueRange<float>(1f,30f)));
        MaxBoxes = base.Config.Bind("Mini Transport Vehicle","Change the max boxes",6,new ConfigDescription("Adjusts the max amount of boxes the Mini Transport Vehicle will hold at one time.",new AcceptableValueRange<int>(6,16)));
        MTVHotkey = Config.Bind("Mini Transport Vehicle","Change the drop hotkey",new KeyboardShortcut(KeyCode.L),new ConfigDescription("Changes the hotkey used to dispense all boxes from the Mini Transport Vehicle instantly."));
        DropCooldown = base.Config.Bind("Mini Transport Vehicle","Item Pickup Cooldown",10f,new ConfigDescription("Changes how long it will wait to pickup boxes again after the drop hotkey has been pressed.",new AcceptableValueRange<float>(1f,30f)));


        // === !Random Features! ===
        ExpRate = base.Config.Bind("Random Features","EXP Rate",1,new ConfigDescription("Adjusts how much EXP you earn per transaction.",new AcceptableValueRange<int>(1,10)));
        ShoplifterDetectionNotif = Config.Bind("Random Features","Shoplifter Notification",false,new ConfigDescription("Adds a visual que to notify you when a shoplifter runs through anti-theft doors."));
        CloserBoxSpawning = Config.Bind("Random Features","Closer Box Spawning",false,new ConfigDescription("Causes boxes to spawn closer to the storage area"));
        OneClickCheckMark = Config.Bind("Random Features","Surveillance Camera One Click",false,new ConfigDescription("Makes all customers one click when using security console"));
        AllowFreePlacement = Config.Bind("Random Features","Disable Placement Blocking",false,new ConfigDescription("Enables or disables you to place structures wherever in the main area, even overlapping"));
        CheatPlacement = Config.Bind("Random Features","Disable PLacement Checks",false,new ConfigDescription("Similar to Free Placement, but allows building anywhere and everywhere"));
        ProductStacking = Config.Bind("Random Features","Enable product stacking",false,new ConfigDescription("Enables or disables most products in the game to stack on shelves"));
        EnablePalletDisplaysPerk = Config.Bind("Random Features","Enable pallet displays",false,new ConfigDescription("Enables pallet displays without unlocking the perk."));
        ReplaceCommasWithPeriods = Config.Bind("Random Features","Replace commas with periods",false,new ConfigDescription("Changes all commas in the game into periods."));
        CurrencyTypeToAny = Config.Bind("Random Features","CurrencySymbol","$",new ConfigDescription("Sets the currency symbol used in the game. Default is $."));
        CardboardBalerBreak = Config.Bind("Random Features","Enable or disable cardboard baler breaking",false,new ConfigDescription("Enables or disables the cardboard baler needing to be repaired."));
        SelfCheckoutBreak = Config.Bind("Random Features","Enable or disable Self Checkout breaking",false,new ConfigDescription("Enables or disables the self checkout needing to be repaired."));

        // === !Hotkey Configurations! ===
        LadderHotkey = Config.Bind("Hotkey Configurations","Sledgehammer Hotkey",new KeyboardShortcut(KeyCode.M),new ConfigDescription("Hotkey to spawn a Sledgehammer in your hands."));
        LadderToggle = Config.Bind("Hotkey Configurations","Sledgehammer Toggle",false,new ConfigDescription("Enables the hotkey to activate Sledgehammer"));
        SledgeHotkey = Config.Bind("Hotkey Configurations","Sledgehammer Hotkey",new KeyboardShortcut(KeyCode.J),new ConfigDescription("Hotkey to spawn a Sledgehammer in your hands."));
        SledgeToggle = Config.Bind("Hotkey Configurations","Sledgehammer Toggle",false,new ConfigDescription("Enables the hotkey to activate Sledgehammer"));
        OsMartHotkey = Config.Bind("Hotkey Configurations","Os Mart 2.0 Tablet Hotkey",new KeyboardShortcut(KeyCode.H),new ConfigDescription("Hotkey to spawn a Os Mart 2.0 Tablet in your hands."));
        OsMartToggle = Config.Bind("Hotkey Configurations","Os Mart 2.0 Toggle",false,new ConfigDescription("Enables the hotkey to activate Os Mart 2.0"));
        TrayHotkey = Config.Bind("Hotkey Configurations","Tray Hotkey",new KeyboardShortcut(KeyCode.K),new ConfigDescription("Hotkey to spawn a Tray in your hands."));
        TrayToggle = Config.Bind("Hotkey Configurations","Tray Toggle",false,new ConfigDescription("Enables the hotkey to activate Tray"));
        ClockToggle = Config.Bind("Hotkey Configurations","Enable hotkey for clock",false,new ConfigDescription("Enables or disabled hotkey activating clock."));
        ClockHotkey = Config.Bind("Hotkey Configurations","Toggle Clock",new KeyboardShortcut(KeyCode.O),new ConfigDescription("Hotkey to enable/disable the clock"));
        ThirdPersonHotkey = Config.Bind("Hotkey Configurations","Third Person Hotkey",new KeyboardShortcut(KeyCode.G),new ConfigDescription("Hotkey to enter and leave third person/first person."));
        ThirdPersonToggle = Config.Bind("Hotkey Configurations","Enable or disable third person",false,new ConfigDescription("Enables or disables the hotkey to enter and leave third person/first person"));
        PricingGunToggle = Config.Bind("Hotkey Configurations","Pricing Gun Toggle",false,new ConfigDescription("Enables the hotkey to activate Pricing Gun"));
        PricingGunHotkey = Config.Bind("Hotkey Configurations","Pricing Gun Hotkey",new KeyboardShortcut(KeyCode.Y),new ConfigDescription("Hotkey to spawn a Pricing Gun in your hands."));
        BroomToggle = Config.Bind("Hotkey Configurations","Broom Toggle",false,new ConfigDescription("Enables the hotkey to activate Broom"));
        BroomHotkey = Config.Bind("Hotkey Configurations","Broom Hotkey",new KeyboardShortcut(KeyCode.U),new ConfigDescription("Hotkey to spawn a Broom in your hands."));
        DLCTabletToggle = Config.Bind("Hotkey Configurations","DLC Tablet Toggle",false,new ConfigDescription("Enables the hotkey to activate DLC Tablet"));
        DLCTabletHotkey = Config.Bind("Hotkey Configurations","DLC Tablet Hotkey",new KeyboardShortcut(KeyCode.I),new ConfigDescription("Hotkey to spawn a DLC Tablet in your hands."));
        EmptyHandsHotkey = Config.Bind("Hotkey Configurations","Empty Hands Hotkey",new KeyboardShortcut(KeyCode.R),new ConfigDescription("Hotkey to remove active item in your hand."));

        // === !Pricing Assistance! ===
        AutoAdjustPriceDaily = base.Config.Bind("Pricing Assistance","Auto Adjust Prices Daily",false,new ConfigDescription("Enables or disables automatically doubling the price of products daily"));
        AutoAdjustPriceDailyValue = base.Config.Bind("Pricing Assistance","Adjust the amount prices are automatically set to every day",2f,new ConfigDescription("Adjusts the amount prices are set to be multiplied by daily. Value of 2x is 2$ * 2 = 4$. Value of 1.99x is 2$*1.99=3.98",new AcceptableValueRange<float>(1f,2f)));
        ToggleDoublePrice = Config.Bind("Double Price Gun","Enable or disable double price module",false,new ConfigDescription("Enables or disables the price gun automatically having 2x the market price"));
        KeyboardShortcutDoublePrice = Config.Bind("Double Price Gun","Enable Double Price module",new KeyboardShortcut(KeyCode.Q),new ConfigDescription("Hotkey to enable and disable double price module"));
        roundDown = Config.Bind("Double Price Gun","Enable rounding down",false,new ConfigDescription("Enables rounding down to prevent 'Too Expensive'"));
        NearestFive = Config.Bind("Double Price Gun","Enable rounding down to nearest 0.05",true,new ConfigDescription("Enable rounding down to the nearest fifth"));
        NearestTen = Config.Bind("Double Price Gun","Enable rounding down to nearest 0.10",false,new ConfigDescription("Enable rounding down to the nearest tenth"));
        KeyboardShortcutRoundDownSwitch = Config.Bind("Double Price Gun","Round Down Shortcuts",new KeyboardShortcut(KeyCode.Q,KeyCode.LeftControl),new ConfigDescription("Hotkey to round down the double price"));
        KeyboardShortcutRoundDownToggle = Config.Bind("Double Price Gun","Round Down Hotkey",new KeyboardShortcut(KeyCode.Q,KeyCode.LeftControl,KeyCode.LeftShift),new ConfigDescription("Hotkey to round down to setting set"));

        // === !Random QoL! ===
        PalletProduct = Config.Bind("Random QoL","More Product on Pallets",false,new ConfigDescription("Enables or disables allowing smaller products on pallets **Note: fully stocked pallets with smaller products can cause lag when being looked at"));
        AllProduct = Config.Bind("Random QoL","No Product Requirement",false,new ConfigDescription("Enables or disables the need for freezers, pegboards, fridges, etc. **Note: fully stocked pallets with smaller products can cause lag when being looked at"));
        LoanEarly = Config.Bind("Random QoL","Payoff Loans Early",false,new ConfigDescription("Enables or disables a button to pay off loans early"));
        NumberKeys = Config.Bind("Random QoL","Enables normal numbers",false,new ConfigDescription("Enables or disables using non-numpad numbers to set prices"));
        CardboardBalerValue = base.Config.Bind("Random QoL","Cardboard Baler",10,new ConfigDescription("Adjust the amount of boxes required for the cardboard baler to spit out a bale",new AcceptableValueRange<int>(1,50)));
        QuickStocking = Config.Bind("Random QoL","Enables quick stocking",false,new ConfigDescription("Enables or disables stocking the entire box onto shelf in one click"));
        AutoOrdering = Config.Bind("Random QoL","Enables auto-ordering items",false,new ConfigDescription("Enables or disables automatically adding enough stock to the shopping order when picking up the OS Mart device"));
        ClockMorning = Config.Bind("Random QoL","Enables clock usage in morning",false,new ConfigDescription("Enables or disables using the clock in the morning"));
        ClockSpeed = base.Config.Bind("Random QoL","Clock Speed",5f,new ConfigDescription("Adjust the amount of speed enabling the clock gives",new AcceptableValueRange<float>(1f,15f)));
        DisableBoxCollisions = Config.Bind("Random QoL","Enable or disable collision with boxes",false,new ConfigDescription("Enables or disables collision with boxes allowing them to stack inside of each other https://i.imgur.com/ffJrHOA.jpeg"));
        FastBoxSpawns = Config.Bind("Random QoL","Enable or disable fast spawning of boxes",false,new ConfigDescription("Enables or disables making purchases boxes spawn quickly https://i.imgur.com/92Ex4V6.png"));
        MissingProductNotifications = Config.Bind("Random QoL","Enable or disable notification Missing Product",false,new ConfigDescription("Enables or disables the notification for missing products"));
        TooExpensiveNotifications = Config.Bind("Random QoL","Enable or disable notification Too Expensive",false,new ConfigDescription("Enables or disables the notification for too expensive products"));
        SelfCheckoutLimit = base.Config.Bind("Random QoL","Product limit on self checkout",4,new ConfigDescription("Limits the amount of item's a customer can have before using the self checkout",new AcceptableValueRange<int>(0,100)));
        MaxBoxSize = base.Config.Bind("Random QoL","Modify amount of products in boxes",1,new ConfigDescription("** WARNING THIS IS EXTREMELY BUGGY IN MULTIPLAYER ** Multiples the amount of product in a box, aswell as it's cost. Higher = more products in box and higher cost https://imgur.com/a/QT5l2Ky",new AcceptableValueRange<int>(1,50)));
        AutoPayAllInvoices = base.Config.Bind("Debt","Enables or disables automatic invoice payment",false,new ConfigDescription("Enables or disables paying for invoices automatically"));

        Instance = this;
        Logger = base.Logger;
        harmony.PatchAll();
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_NAME} v{PluginInfo.PLUGIN_VERSION} is loaded!");
        Harmony.DEBUG = true;

        GameObject listener = new("ManualSaleClearHotkeyListener");
        _ = listener.AddComponent<ManualSaleClearHotkeyListener>();
        DontDestroyOnLoad(listener);

    }

    public static void CreateCanvasNotification(string text) {
        GameObject obj = UnityEngine.Object.Instantiate(GameCanvas.Instance.notificationPrefab,GameCanvas.Instance.notificationParentTransform);
        obj.GetComponent<TextMeshProUGUI>().text = text;
        obj.SetActive(value: true);
    }

    public static void CreateImportantNotification(string text) {
        GameObject obj = UnityEngine.Object.Instantiate(GameCanvas.Instance.importantNotificationPrefab,GameCanvas.Instance.importantNotificationParentTransform);
        obj.GetComponent<TextMeshProUGUI>().text = text;
        obj.SetActive(value: true);
    }

    private void Update() {
        if(ToggleDoublePrice.Value == true) {
            if(KeyboardShortcutDoublePrice.Value.IsDown()) {
                doublePrice = !doublePrice;
                notificationType = "priceToggle";
                notify = true;
            } else if(KeyboardShortcutRoundDownSwitch.Value.IsDown()) {
                if(NearestTen.Value) {
                    NearestTen.Value = false;
                    NearestFive.Value = true;
                } else {
                    NearestTen.Value = true;
                    NearestFive.Value = false;
                }
                notificationType = "roundDownSwitch";
                notify = true;
            } else if(KeyboardShortcutRoundDownToggle.Value.IsDown()) {
                roundDown.Value = !roundDown.Value;
                notificationType = "roundDownToggle";
                notify = true;
            }
        }

        if(NearestFive.Value && NearestTen.Value) {
            NearestTen.Value = false;
        }
    }

}
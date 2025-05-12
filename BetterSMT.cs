using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace BetterSMT;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class BetterSMT : BaseUnityPlugin {
    private readonly Harmony harmony = new(PluginInfo.PLUGIN_GUID);

    public static BetterSMT Instance;
    internal static new ManualLogSource Logger { get; private set; } = null!;

    // === !Debt! ===
    public static ConfigEntry<bool> AutoPayAllInvoices;

    // === !Sales Settings! ===
    public static ConfigEntry<int> SalesActiveAmount;
    public static ConfigEntry<bool> SalesToggle;
    public static ConfigEntry<KeyboardShortcut> SalesHotkey;

    // === !Auto Save Settings! ===
    public static ConfigEntry<bool> AutoSaveEnabled;
    public static ConfigEntry<int> AutoSaveTimer;
    public static ConfigEntry<bool> AutoSaveDuringDay;

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
    public static ConfigEntry<float> EmployeeCheckoutPerPerk1;
    public static ConfigEntry<float> EmployeeCheckoutPerPerk2;
    public static ConfigEntry<float> EmployeeCheckoutPerPerk3;
    public static ConfigEntry<float> EmployeExtraCheckoutMoney;

    // === !Cost Modifiers! ===
    public static ConfigEntry<float> LightCostMod;
    public static ConfigEntry<float> RentCostMod;
    public static ConfigEntry<float> EmployeeCostMod;

    // === !Thieves & Crime Settings! ===
    public static ConfigEntry<bool> OneHitThief;
    public static ConfigEntry<bool> SelfCheckoutTheft;
    public static ConfigEntry<bool> DisableAllThieves;
    public static ConfigEntry<bool> AllNPCAreThieves;

    // === !Gameplay Settings! ===
    public static ConfigEntry<bool> FasterCheckout;
    public static ConfigEntry<bool> ShowFPS;
    public static ConfigEntry<bool> ShowPing;
    public static ConfigEntry<bool> DisableAllTrash;
    public static ConfigEntry<bool> AlwaysAbleToDeleteMode;
    public static ConfigEntry<bool> DeleteAllCheckouts;
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

    // === !Random Features! ===
    public static ConfigEntry<bool> EnablePalletDisplaysPerk;
    public static ConfigEntry<bool> ReplaceCommasWithPeriods;
    public static ConfigEntry<string> CurrencyTypeToAny;

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
    public static ConfigEntry<int> SelfCheckoutLimit;
    public static ConfigEntry<bool> TooExpensiveNotifications;
    public static ConfigEntry<bool> MissingProductNotifications;
    public static ConfigEntry<int> MaxBoxSize;
    public static ConfigEntry<bool> DisableBoxCollisions;
    public static ConfigEntry<bool> FastBoxSpawns;
    public static ConfigEntry<float> ClockSpeed;
    public static ConfigEntry<bool> ClockMorning;

    private void Awake() {
        // === !Debt! ===
        AutoPayAllInvoices = base.Config.Bind(
            "Debt",
            "Enables or disables automatic invoice payment",
            false,
             new ConfigDescription("Enables or disables paying for invoices automatically")
        );

        // === !Sales Settings! ===
        SalesActiveAmount = base.Config.Bind(
            "Sales Settings",
            "Amount of sales unlocked each perk",
            2,
            new ConfigDescription("Adjusts the amount of sales you unlock for each perk",
                new AcceptableValueRange<int>(1, 100)
            )
        );

        // === !Auto Save Settings! ===
        AutoSaveEnabled = base.Config.Bind(
            "Auto Save Settings",
            "Enables Auto Saving",
            false,
             new ConfigDescription("Enables or disables automatic saving")
        );
        AutoSaveTimer = base.Config.Bind(
            "Auto Saving Settings",
            "Amount of time between saves",
            120,
            new ConfigDescription("Adjusts the amount of time between auto saves in seconds, default is 120seconds or 2minutes",
                new AcceptableValueRange<int>(30, 900)
            )
        );
        AutoSaveDuringDay = base.Config.Bind(
            "Auto Saving Settings",
            "Enables Auto Saving during the day",
            false,
             new ConfigDescription("Enables or disables saving while the store is open, default only autosaves while closed")
        );

        // === !Employee & Customer Settings! ===
        EmployeExtraCheckoutMoney = base.Config.Bind(
            "Employee & Customer Settings",
            "Employe Increased Income While Checking Customer Out Perk",
            0.1f,
            new ConfigDescription("Adjust the amount of extra income you receive when an employee checks out a customer (Higher = more income)",
                new AcceptableValueRange<float>(0f, 0.3f)
            )
        );
        EmployeeCheckoutPerPerk1 = base.Config.Bind(
            "Employee & Customer Settings",
            "Employee Checkout Time Reduction Perk 1",
            .15f,
            new ConfigDescription("Adjust the amount of time employees wait to scan items in checkout (Perk 1) (Lower = slower)",
                new AcceptableValueRange<float>(0.01f, 0.45f)
            )
        );
        EmployeeCheckoutPerPerk2 = base.Config.Bind(
            "Employee & Customer Settings",
            "Employee Checkout Time Reduction Perk 2",
            .2f,
            new ConfigDescription("Adjust the amount of time employees wait to scan items in checkout (Perk 2) (Lower = slower)",
                new AcceptableValueRange<float>(0.01f, 0.6f)
            )
        );
        EmployeeCheckoutPerPerk3 = base.Config.Bind(
            "Employee & Customer Settings",
            "Employee Checkout Time Reduction Perk 3",
            .15f,
            new ConfigDescription("Adjust the amount of time employees wait to scan items in checkout (Perk 3) (Lower = slower)",
                new AcceptableValueRange<float>(0.01f, 0.45f)
            )
        );
        MaxCustomerCart = base.Config.Bind(
            "Employee & Customer Settings",
            "Maximum amount of product customers will buy",
            25,
            new ConfigDescription("Adjust the maximum amount of product customers will buy",
                new AcceptableValueRange<int>(1, 75)
            )
        );
        BaseCustomerCart = base.Config.Bind(
            "Employee & Customer Settings",
            "Minimum amount of product customers will buy",
            5,
            new ConfigDescription("Adjust the minimum amount of product customers will buy",
                new AcceptableValueRange<int>(1, 15)
            )
        );
        BaseCustomerSpawns = base.Config.Bind(
            "Employee & Customer Settings",
            "Minimum amount of customers that will spawn",
            3,
            new ConfigDescription("Adjust the minimum amount of customer's that can spawn",
                new AcceptableValueRange<int>(1, 9)
            )
        );
        MaxCustomerInStore = base.Config.Bind(
            "Employee & Customer Settings",
            "Max amount of customers in store",
            70,
            new ConfigDescription("Adjust the amount of customers that can spawn at one time",
                new AcceptableValueRange<int>(1, 210)
            )
        );
        CustomersPerPerk = base.Config.Bind(
            "Employee & Customer Settings",
            "Extra Customers per perk",
            1,
            new ConfigDescription("Adjust the amount of customers you gain per perk (Higher number = more customers)",
                new AcceptableValueRange<int>(1, 5)
            )
        );
        EmployeesLevel = base.Config.Bind(
            "Employee & Customer Settings",
            "Employees Level",
            0,
            new ConfigDescription("Adjust the level of employee's that spawn (1 sets all of their stats to minimum, 11 sets them all to max)",
                new AcceptableValueRange<int>(0, 30)
            )
        );
        EmployeesEnabled = base.Config.Bind(
            "Employee & Customer Settings",
            "Employees Level Toggle",
            false,
             new ConfigDescription("Enables modifying employee levels")
        );
        EmployeeSpeedPerPerk = base.Config.Bind(
            "Employee & Customer Settings",
            "Employee Speed Per Perk",
            .2f,
            new ConfigDescription("Adjust the amount of speed employees gain per perk (Higher = faster)",
                new AcceptableValueRange<float>(.01f, .6f)
            )
        );
        EmployeeRestockPerPerk = base.Config.Bind(
            "Employee & Customer Settings",
            "Employee Restock Time Reduction Per Perk",
            0.05f,
            new ConfigDescription("Adjust the amount of time it takes for employees to restock per perk (Lower = faster)",
                new AcceptableValueRange<float>(0.01f, 0.15f)
            )
        );

        // === !Cost Modifiers! ===
        LightCostMod = base.Config.Bind(
            "Cost Modifiers",
            "Adjust the cost of Lights at the end of the day",
            10f,
            new ConfigDescription("Adjust the cost of lights at the end of the day (Higher = more expensive)",
                new AcceptableValueRange<float>(0.1f, 30f)
            )
        );
        EmployeeCostMod = base.Config.Bind(
            "Cost Modifiers",
            "Adjust the cost of Employee at the end of the day",
            10f,
            new ConfigDescription("Adjust the cost of Employee at the end of the day (Higher = more expensive)",
                new AcceptableValueRange<float>(0.1f, 30f)
            )
        );
        RentCostMod = base.Config.Bind(
            "Cost Modifiers",
            "Adjust the cost of Rent at the end of the day",
            10f,
            new ConfigDescription("Adjust the cost of Rent at the end of the day (Higher = more expensive)",
                new AcceptableValueRange<float>(0.1f, 30f)
            )
        );

        // === !Thieves & Crime Settings! ===
        AllNPCAreThieves = base.Config.Bind(
            "Thieves & Crime Settings",
            "All Thieves",
            false,
             new ConfigDescription("Causes every NPC to be a thief")
        );
        SelfCheckoutTheft = base.Config.Bind(
            "Thieves & Crime Settings",
            "Self-Checkout Theft",
            true,
             new ConfigDescription("Enables or disables default game's theft from self checkout")
        );
        DisableAllThieves = base.Config.Bind(
            "Thieves & Crime Settings",
            "Disable Thieves",
            false,
             new ConfigDescription("Prevent thieves from spawning (Does not stop checkout-related thieves)")
        );
        OneHitThief = base.Config.Bind(
            "Thieves & Crime Settings",
            "Thiefs Drop Everything On Hit",
            false,
             new ConfigDescription("Thiefs Drop Everything On Hit")
        );

        // === !Gameplay Settings! ===
        FasterCheckout = base.Config.Bind(
            "Gameplay Settings",
            "Faster Checkout",
            false,
            new ConfigDescription("Customers place all items instantly on to the checkout")
        );
        ShowFPS = base.Config.Bind(
            "Gameplay Settings",
            "Show FPS Counter",
            false
        );
        ShowPing = base.Config.Bind(
            "Gameplay Settings",
            "Show Ping Counter",
            false
        );
        DisableAllTrash = base.Config.Bind(
            "Gameplay Settings",
            "Despawns trash",
            false,
             new ConfigDescription("Despawns all trash at the end of the day")
        );
        AlwaysAbleToDeleteMode = base.Config.Bind(
            "Gameplay Settings",
            "Always access to delete",
            false,
             new ConfigDescription("Delete shelves and others while customers are in store and store is open")
        );
        DeleteAllCheckouts = Config.Bind(
            "Gameplay Settings",
            "Enable or disable deleting all checkout lanes",
            false,
            new ConfigDescription("Adds the ability to delete every checkout lane")
        );
        AllTrashToRecyclers = Config.Bind(
            "Gameplay Settings",
            "All Recyclers",
            false,
            new ConfigDescription("Turns the nearest trash can into a recycler without the perk.")
        );

        // === !Highlighting! ===
        StorageHighlighting = Config.Bind(
            "Highlighting",
            "Enable or disable highlighting",
            false,
            new ConfigDescription("Enables or disables highlighting of product and storage shelves when holding a box")
        );

        // === !Random Features! ===
        EnablePalletDisplaysPerk = Config.Bind(
            "Random Features",
            "Enable pallet displays",
            false,
            new ConfigDescription("Enables pallet displays without unlocking the perk.")
        );
        ReplaceCommasWithPeriods = Config.Bind(
            "Random Features",
            "Replace commass with periods",
            false,
            new ConfigDescription("Changes all commas in the game into periods.")
        );
        CurrencyTypeToAny = Config.Bind(
            "Random Features",
            "CurrencySymbol",
            "$",
            new ConfigDescription("Sets the currency symbol used in the game. Default is $.")
        );

        // === !Hotkey Configurations! ===
        SalesHotkey = Config.Bind(
            "Sales Settings",
            "Sales Tablet Hotkey",
            new KeyboardShortcut(KeyCode.L),
            new ConfigDescription("Hotkey to spawn a Sales Tablet in your hands.")
        );
        SalesToggle = Config.Bind(
            "Sales Settings",
            "Sales Tablet Toggle",
            false,
            new ConfigDescription("Enables the hotkey to activate Sales Tablet")
        );
        LadderHotkey = Config.Bind(
            "Hotkey Configurations",
            "Sledgehammer Hotkey",
            new KeyboardShortcut(KeyCode.M),
            new ConfigDescription("Hotkey to spawn a Sledgehammer in your hands.")
        );
        LadderToggle = Config.Bind(
            "Hotkey Configurations",
            "Sledgehammer Toggle",
            false,
            new ConfigDescription("Enables the hotkey to activate Sledgehammer")
        );

        SledgeHotkey = Config.Bind(
            "Hotkey Configurations",
            "Sledgehammer Hotkey",
            new KeyboardShortcut(KeyCode.J),
            new ConfigDescription("Hotkey to spawn a Sledgehammer in your hands.")
        );
        SledgeToggle = Config.Bind(
            "Hotkey Configurations",
            "Sledgehammer Toggle",
            false,
            new ConfigDescription("Enables the hotkey to activate Sledgehammer")
        );

        OsMartHotkey = Config.Bind(
            "Hotkey Configurations",
            "Os Mart 2.0 Tablet Hotkey",
            new KeyboardShortcut(KeyCode.H),
            new ConfigDescription("Hotkey to spawn a Os Mart 2.0 Tablet in your hands.")
        );

        OsMartToggle = Config.Bind(
            "Hotkey Configurations",
            "Os Mart 2.0 Toggle",
            false,
            new ConfigDescription("Enables the hotkey to activate Os Mart 2.0")
        );
        TrayHotkey = Config.Bind(
            "Hotkey Configurations",
            "Tray Hotkey",
            new KeyboardShortcut(KeyCode.K),
            new ConfigDescription("Hotkey to spawn a Tray in your hands.")
        );
        TrayToggle = Config.Bind(
            "Hotkey Configurations",
            "Tray Toggle",
            false,
            new ConfigDescription("Enables the hotkey to activate Tray")
        );
        ClockToggle = Config.Bind(
            "Hotkey Configurations",
            "Enable hotkey for clock",
            false,
            new ConfigDescription("Enables or disabled hotkey activating clock.")
        );
        ClockHotkey = Config.Bind(
            "Hotkey Configurations",
            "Toggle Clock",
            new KeyboardShortcut(KeyCode.O),
            new ConfigDescription("Hotkey to enable/disable the clock")
        );
        ThirdPersonHotkey = Config.Bind(
            "Hotkey Configurations",
            "Third Person Hotkey",
            new KeyboardShortcut(KeyCode.G),
            new ConfigDescription("Hotkey to enter and leave third person/first person.")
        );
        ThirdPersonToggle = Config.Bind(
            "Hotkey Configurations",
            "Enable or disable third person",
            false,
            new ConfigDescription("Enables or disables the hotkey to enter and leave third person/first person")
        );
        PricingGunToggle = Config.Bind(
            "Hotkey Configurations",
            "Pricing Gun Toggle",
            false,
            new ConfigDescription("Enables the hotkey to activate Pricing Gun")
        );
        PricingGunHotkey = Config.Bind(
            "Hotkey Configurations",
            "Pricing Gun Hotkey",
            new KeyboardShortcut(KeyCode.Y),
            new ConfigDescription("Hotkey to spawn a Pricing Gun in your hands.")
        );
        BroomToggle = Config.Bind(
            "Hotkey Configurations",
            "Broom Toggle",
            false,
            new ConfigDescription("Enables the hotkey to activate Broom")
        );
        BroomHotkey = Config.Bind(
            "Hotkey Configurations",
            "Broom Hotkey",
            new KeyboardShortcut(KeyCode.U),
            new ConfigDescription("Hotkey to spawn a Broom in your hands.")
        );
        DLCTabletToggle = Config.Bind(
            "Hotkey Configurations",
            "DLC Tablet Toggle",
            false,
            new ConfigDescription("Enables the hotkey to activate DLC Tablet")
        );
        DLCTabletHotkey = Config.Bind(
            "Hotkey Configurations",
            "DLC Tablet Hotkey",
            new KeyboardShortcut(KeyCode.I),
            new ConfigDescription("Hotkey to spawn a DLC Tablet in your hands.")
        );
        EmptyHandsHotkey = Config.Bind(
            "Hotkey Configurations",
            "Empty Hands Hotkey",
            new KeyboardShortcut(KeyCode.R),
            new ConfigDescription("Hotkey to remove active item in your hand.")
        );

        // === !Pricing Assistance! ===
        AutoAdjustPriceDaily = base.Config.Bind(
             "Pricing Assistance",
             "Auto Adjust Prices Daily",
             false,
              new ConfigDescription("Enables or disables automatically doubling the price of products daily")
         );
        AutoAdjustPriceDailyValue = base.Config.Bind(
            "Pricing Assistance",
            "Adjust the amount prices are automatically set to every day",
            2f,
            new ConfigDescription("Adjusts the amount prices are set to be multiplied by daily. Value of 2x is 2$ * 2 = 4$. Value of 1.99x is 2$*1.99=3.98",
                new AcceptableValueRange<float>(1f, 2f)
            )
        );
        ToggleDoublePrice = Config.Bind(
            "Double Price Gun",
            "Enable or disable double price module",
            false,
            new ConfigDescription("Enables or disables the price gun automatically having 2x the market price")
        );
        KeyboardShortcutDoublePrice = Config.Bind(
            "Double Price Gun",
            "Enable Double Price module",
            new KeyboardShortcut(KeyCode.Q),
            new ConfigDescription("Hotkey to enable and disable double price module")
        );
        roundDown = Config.Bind(
            "Double Price Gun",
            "Enable rounding down",
            false,
            new ConfigDescription("Enables rounding down to prevent 'Too Expensive'")
        );
        NearestFive = Config.Bind(
            "Double Price Gun",
            "Enable rounding down to nearest 0.05",
            true,
            new ConfigDescription("Enable rounding down to the nearest fifth")
        );
        NearestTen = Config.Bind(
            "Double Price Gun",
            "Enable rounding down to nearest 0.10",
            false,
            new ConfigDescription("Enable rounding down to the nearest tenth")
         );
        KeyboardShortcutRoundDownSwitch = Config.Bind(
            "Double Price Gun",
            "Round Down Shortcuts",
            new KeyboardShortcut(KeyCode.Q, KeyCode.LeftControl),
            new ConfigDescription("Hotkey to round down the double price")
            );
        KeyboardShortcutRoundDownToggle = Config.Bind(
            "Double Price Gun",
            "Round Down Hotkey",
            new KeyboardShortcut(KeyCode.Q, KeyCode.LeftControl, KeyCode.LeftShift),
            new ConfigDescription("Hotkey to round down to setting set")
        );

        // === !Random QoL! ===
        ClockMorning = Config.Bind(
            "Random QoL",
            "Enables clock usage in morning",
            false,
            new ConfigDescription("Enables or disables using the clock in the morning")
        );
        ClockSpeed = base.Config.Bind(
            "Random QoL",
            "Clock Speed",
            5f,
            new ConfigDescription("Adjust the amount of speed enabling the clock gives",
                new AcceptableValueRange<float>(1f, 15f)
            )
        );
        DisableBoxCollisions = Config.Bind(
            "Random QoL",
            "Enable or disable collision with boxes",
            false,
            new ConfigDescription("Enables or disables collision with boxes allowing them to stack inside of each other https://i.imgur.com/ffJrHOA.jpeg")
        );
        FastBoxSpawns = Config.Bind(
            "Random QoL",
            "Enable or disable fast spawning of boxes",
            false,
            new ConfigDescription("Enables or disables making purchases boxes spawn quickly https://i.imgur.com/92Ex4V6.png")
        );
        MissingProductNotifications = Config.Bind(
            "Random QoL",
            "Enable or disable notification Missing Product",
            false,
            new ConfigDescription("Enables or disables the notification for missing products")
        );
        TooExpensiveNotifications = Config.Bind(
            "Random QoL",
            "Enable or disable notification Too Expensive",
            false,
            new ConfigDescription("Enables or disables the notification for too expensive products")
        );
        SelfCheckoutLimit = base.Config.Bind(
            "Random QoL",
            "Product limit on self checkout",
            4,
            new ConfigDescription("Limits the amount of item's a customer can have before using the self checkout",
                new AcceptableValueRange<int>(0, 100)
            )
        );
        MaxBoxSize = base.Config.Bind(
            "Random QoL",
            "Modify amount of products in boxes",
            1,
            new ConfigDescription("** WARNING THIS IS EXTREMELY BUGGY IN MULTIPLAYER ** Multiples the amount of product in a box, aswell as it's cost. Higher = more products in box and higher cost https://imgur.com/a/QT5l2Ky",
                new AcceptableValueRange<int>(1, 25)
            )
        );

        Instance = this;
        Logger = base.Logger;
        harmony.PatchAll();
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_NAME} v{PluginInfo.PLUGIN_VERSION} is loaded!");
    }

    public static void CreateCanvasNotification(string text) {
        GameObject obj = UnityEngine.Object.Instantiate(GameCanvas.Instance.notificationPrefab, GameCanvas.Instance.notificationParentTransform);
        obj.GetComponent<TextMeshProUGUI>().text = text;
        obj.SetActive(value: true);
    }
    public static void CreateImportantNotification(string text) {
        GameObject obj = UnityEngine.Object.Instantiate(GameCanvas.Instance.importantNotificationPrefab, GameCanvas.Instance.importantNotificationParentTransform);
        obj.GetComponent<TextMeshProUGUI>().text = text;
        obj.SetActive(value: true);
    }

    private void Update() {
        if (ToggleDoublePrice.Value == true) {
            if (KeyboardShortcutDoublePrice.Value.IsDown()) {
                doublePrice = !doublePrice;
                notificationType = "priceToggle";
                notify = true;
            } else if (KeyboardShortcutRoundDownSwitch.Value.IsDown()) {
                if (NearestTen.Value) {
                    NearestTen.Value = false;
                    NearestFive.Value = true;
                } else {
                    NearestTen.Value = true;
                    NearestFive.Value = false;
                }
                notificationType = "roundDownSwitch";
                notify = true;
            } else if (KeyboardShortcutRoundDownToggle.Value.IsDown()) {
                roundDown.Value = !roundDown.Value;
                notificationType = "roundDownToggle";
                notify = true;
            }
        }
    }

    private void ConfigSettingChanged(object sender, System.EventArgs e) {
        if (NearestFive.Value) {
            if (NearestTen.Value && NearestFive.Value) {
                NearestTen.Value = false;
            }
        }
    }
}


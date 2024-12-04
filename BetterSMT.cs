using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace BetterSMT;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class BetterSMT : BaseUnityPlugin
{
    private readonly Harmony harmony = new(PluginInfo.PLUGIN_GUID);

    public static BetterSMT Instance;
    internal static new ManualLogSource Logger { get; private set; } = null!;

    // === Employee-related settings ===
    public static ConfigEntry<int> EmployeesPerPerk;
    public static ConfigEntry<int> CustomersPerPerk;
    public static ConfigEntry<float> EmployeeSpeedPerPerk;
    public static ConfigEntry<float> EmployeeRestockPerPerk;
    public static ConfigEntry<float> EmployeeCheckoutPerPerk1;
    public static ConfigEntry<float> EmployeeCheckoutPerPerk2;
    public static ConfigEntry<float> EmployeeCheckoutPerPerk3;
    public static ConfigEntry<float> EmployeExtraCheckoutMoney;

    // === Cost Modifiers ===
    public static ConfigEntry<float> LightCostMod;
    public static ConfigEntry<float> RentCostMod;
    public static ConfigEntry<float> EmployeeCostMod;

    // === Thieves & Crime-related settings ===
    public static ConfigEntry<bool> OneHitThief;
    public static ConfigEntry<bool> SelfCheckoutTheft;
    public static ConfigEntry<bool> DisableAllThieves;
    public static ConfigEntry<bool> AllNPCAreThieves;

    // === Gameplay-related settings ===
    public static ConfigEntry<bool> FasterCheckout;
    public static ConfigEntry<bool> ShowFPS;
    public static ConfigEntry<bool> ShowPing;
    public static ConfigEntry<bool> DisableTrash;
    public static ConfigEntry<bool> AlwaysDeleteMode;
    public static ConfigEntry<bool> DeleteProduct;
    public static ConfigEntry<bool> AutoAdjustPriceDaily;
    public static ConfigEntry<float> AutoAdjustPriceDailyValue;
    public static ConfigEntry<bool> DisableBoxCollision;   

    // === Price Adjustments ===
    public static ConfigEntry<bool> ReplaceCommasWithPeriods;
    public static ConfigEntry<bool> roundDown;
    public static ConfigEntry<bool> NearestFive;
    public static ConfigEntry<bool> NearestTen;
    public static ConfigEntry<bool> RemovePillars;
    public static ConfigEntry<bool> OrderingPriceGun;
    public static ConfigEntry<KeyboardShortcut> OrderingPriceGunHotkey;
    public static bool doublePrice = true;
    public static ConfigEntry<bool> OrderingPriceGunToggle;

    // === Hotkeys ===
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

    // === Notification & Miscellaneous ===
    public static bool notify = false;
    public static string notificationType;
    public static ConfigEntry<int> SelfCheckoutLimit;
    public static ConfigEntry<int> MaxBoxAmountModifier;

    private void Awake()
    {

        MaxBoxAmountModifier = base.Config.Bind(
            "QoL",
            "Raise Product Amount per Box",
            1,
            new ConfigDescription("Multiples the amount of product in a box. Default 30 in a box times 5 would make the box have 150. This also increases its cost on the market accordingly.",
                new AcceptableValueRange<int>(1, 10)
            )
        );

        DisableBoxCollision = Config.Bind(
            "Utility",
            "Enable or disable box collision",
            false,
            new ConfigDescription("Enables or disables box collision")
        );

        OrderingPriceGun = Config.Bind(
            "Utility",
            "Enable or disable ordering from price gun",
            false,
            new ConfigDescription("Enables the hotkey to order product using the price gun")
        );

        OrderingPriceGunHotkey = Config.Bind(
            "Utility",
            "Pricing Gun Order Hotkey",
            new KeyboardShortcut(KeyCode.E),
            new ConfigDescription("Hotkey to order the product the price gun is looking at.")
        );

        RemovePillars = Config.Bind(
            "Utility",
            "Removes Pillars & Beams",
            false,
            new ConfigDescription("Removes most of the pillars & beams from the main portion of the store. **Be warned** camera UI does glitch out when standing where " +
                "a pillar would usually go. Aswell increases the load time considerably for now. For an idea what this does, check this link: https://i.imgur.com/OBeBj5i.jpeg")
        );

        PricingGunToggle = Config.Bind(
            "Utility",
            "Pricing Gun Toggle",
            false,
            new ConfigDescription("Enables the hotkey to activate Pricing Gun")
        );

        PricingGunHotkey = Config.Bind(
            "Utility",
            "Pricing Gun Hotkey",
            new KeyboardShortcut(KeyCode.Y),
            new ConfigDescription("Hotkey to spawn a Pricing Gun in your hands.")
        );

        BroomToggle = Config.Bind(
            "Utility",
            "Broom Toggle",
            false,
            new ConfigDescription("Enables the hotkey to activate Broom")
        );

        BroomHotkey = Config.Bind(
            "Utility",
            "Broom Hotkey",
            new KeyboardShortcut(KeyCode.U),
            new ConfigDescription("Hotkey to spawn a Broom in your hands.")
        );

        DLCTabletToggle = Config.Bind(
            "Utility",
            "DLC Tablet Toggle",
            false,
            new ConfigDescription("Enables the hotkey to activate DLC Tablet")
        );

        DLCTabletHotkey = Config.Bind(
            "Utility",
            "DLC Tablet Hotkey",
            new KeyboardShortcut(KeyCode.I),
            new ConfigDescription("Hotkey to spawn a DLC Tablet in your hands.")
        );

        EmptyHandsHotkey = Config.Bind(
            "Utility",
            "Empty Hands Hotkey",
            new KeyboardShortcut(KeyCode.R),
            new ConfigDescription("Hotkey to remove active item in your hand.")
        );

        KeyboardShortcutDoublePrice = Config.Bind(
            "Double Price",
            "Enable Double Price module",
            new KeyboardShortcut(KeyCode.Q),
            new ConfigDescription("Hotkey to enable and disable double price module")
        );

        roundDown = Config.Bind(
            "Double Price",
            "Enable rounding down",
            false,
            new ConfigDescription("Enables rounding down to prevent 'Too Expensive'")
        );

        NearestFive = Config.Bind(
            "Double Price",
            "Enable rounding down to nearest 0.05",
            true,
            new ConfigDescription("Enable rounding down to the nearest fifth")
        );

        NearestTen = Config.Bind(
            "Double Price",
            "Enable rounding down to nearest 0.10",
            false,
            new ConfigDescription("Enable rounding down to the nearest tenth")
         );

        KeyboardShortcutRoundDownSwitch = Config.Bind(
            "Double Price",
            "Round Down Shortcuts",
            new KeyboardShortcut(KeyCode.Q, KeyCode.LeftControl),
            new ConfigDescription("Hotkey to round down the double price")
            );

        KeyboardShortcutRoundDownToggle = Config.Bind(
            "Double Price",
            "Round Down Hotkey",
            new KeyboardShortcut(KeyCode.Q, KeyCode.LeftControl, KeyCode.LeftShift),
            new ConfigDescription("Hotkey to round down to setting set")
        );

        EmployeesPerPerk = base.Config.Bind(
            "Employees",
            "Employees Per Perk",
            1,
            new ConfigDescription("Adjust the amount of employees you gain per perk (Higher number = more employees)",
                new AcceptableValueRange<int>(0, 5)
            )
        );

        SelfCheckoutLimit = base.Config.Bind(
            "Self-Checkout",
            "Product limit on self checkout",
            18,
            new ConfigDescription("Limits the amount of item's a customer can have before using the self checkout",
                new AcceptableValueRange<int>(0, 250)
            )
        );

        EmployeeSpeedPerPerk = base.Config.Bind(
            "Employees",
            "Employee Speed Per Perk",
            .2f,
            new ConfigDescription("Adjust the amount of speed employees gain per perk (Higher = faster)",
                new AcceptableValueRange<float>(.2f, 3f)
            )
        );

        EmployeeRestockPerPerk = base.Config.Bind(
            "Employees",
            "Employee Restock Time Reduction Per Perk",
            0.05f,
            new ConfigDescription("Adjust the amount of time it takes for employees to restock per perk (Lower = faster)",
                new AcceptableValueRange<float>(0.01f, 0.1f)
            )
        );

        LightCostMod = base.Config.Bind(
            "Immersion",
            "Adjust the cost of Lights at the end of the day",
            10f,
            new ConfigDescription("Adjust the cost of lights at the end of the day (Higher = more expensive)",
                new AcceptableValueRange<float>(0.1f, 50f)
            )
        );

        AllNPCAreThieves = base.Config.Bind(
            "Thieves",
            "All Thieves",
            false,
             new ConfigDescription("Causes every NPC to be a thief")
        );

        AutoAdjustPriceDaily = base.Config.Bind(
            "QoL",
            "Auto Adjust Prices Daily",
            false,
             new ConfigDescription("Enables or disables automatically doubling the price of products daily")
        );

        AutoAdjustPriceDailyValue = base.Config.Bind(
            "QoL",
            "Adjust the amount prices are automatically set to every day",
            2f,
            new ConfigDescription("Adjusts the amount prices are set to be multiplied by daily. Value of 2x is 2$ * 2 = 4$. Value of 1.99x is 2$*1.99=3.98",
                new AcceptableValueRange<float>(1f, 2f)
            )
        );

        SelfCheckoutTheft = base.Config.Bind(
            "Self-Checkout",
            "Self-Checkout Theft",
            true,
             new ConfigDescription("Enables or disables default game's theft from self checkout")
        );

        DisableTrash = base.Config.Bind(
            "Trash",
            "Despawns trash",
            false,
             new ConfigDescription("Despawns all trash at the end of the day")
        );

        DisableAllThieves = base.Config.Bind(
            "Thieves",
            "Disable Thieves",
            false,
             new ConfigDescription("Prevent thieves from spawning (Does not stop checkout-related thieves)")
        );

        EmployeeCostMod = base.Config.Bind(
            "Immersion",
            "Adjust the cost of Employee at the end of the day",
            10f,
            new ConfigDescription("Adjust the cost of Employee at the end of the day (Higher = more expensive)",
                new AcceptableValueRange<float>(0.1f, 50f)
            )
        );

        RentCostMod = base.Config.Bind(
            "Immersion",
            "Adjust the cost of Rent at the end of the day",
            10f,
            new ConfigDescription("Adjust the cost of Rent at the end of the day (Higher = more expensive)",
                new AcceptableValueRange<float>(0.1f, 50f)
            )
        );

        EmployeExtraCheckoutMoney = base.Config.Bind(
            "Employees",
            "Employe Increased Income While Checking Customer Out Perk",
            0.1f,
            new ConfigDescription("Adjust the amount of extra income you receive when an employee checks out a customer (Higher = more income)",
                new AcceptableValueRange<float>(0f, 0.25f)
                )
            );

        EmployeeCheckoutPerPerk1 = base.Config.Bind(
            "Employees",
            "Employee Checkout Time Reduction Perk 1",
            .15f,
            new ConfigDescription("Adjust the amount of time employees wait to scan items in checkout (Perk 1) (Lower = slower)",
                new AcceptableValueRange<float>(0.01f, 0.25f)
            )
        );

        EmployeeCheckoutPerPerk2 = base.Config.Bind(
            "Employees",
            "Employee Checkout Time Reduction Perk 2",
            .2f,
            new ConfigDescription("Adjust the amount of time employees wait to scan items in checkout (Perk 2) (Lower = slower)",
                new AcceptableValueRange<float>(0.01f, 0.25f)
            )
        );

        EmployeeCheckoutPerPerk3 = base.Config.Bind(
            "Employees",
            "Employee Checkout Time Reduction Perk 3",
            .15f,
            new ConfigDescription("Adjust the amount of time employees wait to scan items in checkout (Perk 3) (Lower = slower)",
                new AcceptableValueRange<float>(0.01f, 0.25f)
            )
        );

        CustomersPerPerk = base.Config.Bind(
            "Customers",
            "Extra Customers per perk",
            1,
            new ConfigDescription("Adjust the amount of customers you gain per perk (Higher number = more customers)",
                new AcceptableValueRange<int>(1, 10)
            )
        );

        AlwaysDeleteMode = base.Config.Bind(
            "Building",
            "Always access to delete",
            false,
             new ConfigDescription("Delete shelves and others while customers are in store and store is open")
        );

        DeleteProduct = base.Config.Bind(
            "Building",
            "Delete shelves with product",
            false,
             new ConfigDescription("***WARNING*** THIS WILL ALLOW YOU TO DELETE SHELVES WITH PRODUCT. THIS WILL NOT REFUND MONEY.")
        );

        OneHitThief = base.Config.Bind(
            "Thieves",
            "Thiefs Drop Everything On Hit",
            false,
             new ConfigDescription("Thiefs Drop Everything On Hit")
        );

        FasterCheckout = base.Config.Bind(
            "Customers",
            "Faster Checkout",
            false,
            new ConfigDescription("Customers place all items instantly on to the checkout")
        );

        ReplaceCommasWithPeriods = base.Config.Bind(
            "Other",
            "Replace Commas with Periods",
            false
        );

        ShowFPS = base.Config.Bind(
            "Other",
            "Show FPS Counter",
            false
        );

        ShowPing = base.Config.Bind(
            "Other",
            "Show Ping Counter",
            false
        );

        Instance = this;
        Logger = base.Logger;
        harmony.PatchAll();
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_NAME} v{PluginInfo.PLUGIN_VERSION} is loaded!");
    }
    public static string ReplaceCommas(string text)
    {
        if (!ReplaceCommasWithPeriods.Value)
        {
            return text;
        }

        text = text.Replace("$", string.Empty);
        text = text.Replace(char.Parse(","), char.Parse("."));
        if (!text.Contains("."))
        {
            text += ".00";
        }
        return "$" + text;
    }

    public static void CreateCanvasNotification(string text)
    {
        GameObject obj = Object.Instantiate(GameCanvas.Instance.notificationPrefab, GameCanvas.Instance.notificationParentTransform);
        obj.GetComponent<TextMeshProUGUI>().text = text;
        obj.SetActive(value: true);
    }
    public static void CreateImportantNotification(string text)
    {
        GameObject obj = Object.Instantiate(GameCanvas.Instance.importantNotificationPrefab, GameCanvas.Instance.importantNotificationParentTransform);
        obj.GetComponent<TextMeshProUGUI>().text = text;
        obj.SetActive(value: true);
    }

    private void Update()
    {
        if (KeyboardShortcutDoublePrice.Value.IsDown())
        {
            doublePrice = !doublePrice;
            notificationType = "priceToggle";
            notify = true;
        }
        else if (KeyboardShortcutRoundDownSwitch.Value.IsDown())
        {
            if (NearestTen.Value)
            {
                NearestTen.Value = false;
                NearestFive.Value = true;
            }
            else
            {
                NearestTen.Value = true;
                NearestFive.Value = false;
            }
            notificationType = "roundDownSwitch";
            notify = true;
        }
        else if (KeyboardShortcutRoundDownToggle.Value.IsDown())
        {
            roundDown.Value = !roundDown.Value;
            notificationType = "roundDownToggle";
            notify = true;
        }
    }

    private void ConfigSettingChanged(object sender, System.EventArgs e)
    {
        if (NearestFive.Value)
        {
            if (NearestTen.Value && NearestFive.Value)
            {
                NearestTen.Value = false;
            }
        }
    }
}


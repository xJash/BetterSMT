using BepInEx;
using BepInEx.Logging;
using BetterSMT;
using HarmonyLib;
using BepInEx.Configuration;
using TMPro;
using UnityEngine;

namespace BetterSMT;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class BetterSMT : BaseUnityPlugin
{
    private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

    public static BetterSMT Instance;
    internal new static ManualLogSource Logger { get; private set; } = null!;

    public static ConfigEntry<int> EmployeesPerPerk;
    public static ConfigEntry<int> CustomersPerPerk;
    public static ConfigEntry<float> EmployeeSpeedPerPerk;
    public static ConfigEntry<float> EmployeeRestockPerPerk;
    public static ConfigEntry<float> EmployeeCheckoutPerPerk1;
    public static ConfigEntry<float> EmployeeCheckoutPerPerk2;
    public static ConfigEntry<float> EmployeeCheckoutPerPerk3;
    public static ConfigEntry<float> EmployeExtraCheckoutMoney;
    public static ConfigEntry<float> LightCostMod;
    public static ConfigEntry<float> RentCostMod;
    public static ConfigEntry<float> EmployeeCostMod;
    public static ConfigEntry<float> ThiefStealAmount;
    public static ConfigEntry<float> ThiefAmount;
    public static ConfigEntry<bool> OneHitThief;
    public static ConfigEntry<bool> ReplaceCommasWithPeriods;
    public static ConfigEntry<bool> FasterCheckout;
    public static ConfigEntry<bool> ShowFPS;
    public static ConfigEntry<bool> ShowPing;
    // public static ConfigEntry<bool> ReplaceCurrencyWithNew;
    private const string MyGUID = "SupermarketTogether.plugins.DoublePrices";
    private const string PluginName = "double-prices";
    private const string VersionString = "1.1.0";
    // Config entry key strings
    // These will appear in the config file created by BepInEx and can also be used
    // by the OnSettingsChange event to determine which setting has changed.
    public static string KeyboardShortcutDoublePriceKey = "Double price toggle";
    public static string KeyboardShortcutRoundDownSwitchKey = "Round down switch";
    public static string KeyboardShortcutRoundDownToggleKey = "Round down toggle";

    public static string roundDownKey = "Round down";
    public static string NearestFiveKey = "Round down to nearest 0.05";
    public static string NearestTenKey = "Round down to nearest 0.10";
    // Configuration entries. Static, so can be accessed directly elsewhere in code via
    // e.g.
    // float myFloat = fuck_coolPlugin.FloatExample.Value;
    // TODO Change this code or remove the code if not required.
    public static ConfigEntry<KeyboardShortcut> KeyboardShortcutDoublePrice;
    public static ConfigEntry<KeyboardShortcut> KeyboardShortcutRoundDownSwitch;
    public static ConfigEntry<KeyboardShortcut> KeyboardShortcutRoundDownToggle;
    public static ConfigEntry<bool> roundDown;
    public static ConfigEntry<bool> NearestFive;
    public static ConfigEntry<bool> NearestTen;

    private static readonly Harmony Harmony = new Harmony(MyGUID);
    public static ManualLogSource Log = new ManualLogSource(PluginName);

    public static bool doublePrice = true;

    public static bool notify = false;
    public static string notificationType;
    private void Awake()
    {
        // Double Price setting

        KeyboardShortcutDoublePrice = Config.Bind("General",
        KeyboardShortcutDoublePriceKey,
            new KeyboardShortcut(KeyCode.Q));

        // Round down settings

        roundDown = Config.Bind("Round Down", roundDownKey, false);
        NearestFive = Config.Bind("Round Down", NearestFiveKey, true);
        NearestTen = Config.Bind("Round Down", NearestTenKey, false);

        // Round down shortcuts settings

        KeyboardShortcutRoundDownSwitch = Config.Bind("Round Down Shortucts",
        KeyboardShortcutRoundDownSwitchKey,
        new KeyboardShortcut(KeyCode.Q, KeyCode.LeftControl));

        KeyboardShortcutRoundDownToggle = Config.Bind("Round Down Shortucts",
        KeyboardShortcutRoundDownToggleKey,
        new KeyboardShortcut(KeyCode.Q, KeyCode.LeftControl, KeyCode.LeftShift));

        Instance = this;
        Logger = base.Logger;

        EmployeesPerPerk = base.Config.Bind(
            "Perks",
            "Employees Per Perk",
            1,
            new ConfigDescription("Adjust the amount of employees you gain per perk",
                new AcceptableValueRange<int>(0, 5)
            )
        );

        EmployeeSpeedPerPerk = base.Config.Bind(
            "Perks",
            "Employee Speed Per Perk",
            .2f,
            new ConfigDescription("Adjust the amount of speed employees gain per perk",
                new AcceptableValueRange<float>(.2f, 1f)
            )
        );

        EmployeeRestockPerPerk = base.Config.Bind(
            "Perks",
            "Employee Restock Time Reduction Per Perk",
            0.05f,
            new ConfigDescription("Adjust the amount of time it takes for employees to restock per perk",
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

        //ThiefStealAmount = base.Config.Bind(
        //    "Misc",
        //    "Adjust the amount of items a thief steals",
        //    10f,
        //    new ConfigDescription("Adjust the amount of items a thief steals",
        //        new AcceptableValueRange<float>(0.1f, 50f)
        //    )
        //);
        //
        //ThiefAmount = base.Config.Bind(
        //    "Misc",
        //    "Adjust the amount of thieves your store will get",
        //    1f,
        //    new ConfigDescription("Adjust the amount of thieves your store will get",
        //        new AcceptableValueRange<float>(0f, 100f)
        //    )
        //);

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
            "Perks",
            "Employe Increased Income While Checking Customer Out Perk",
            0.1f,
            new ConfigDescription("Adjust the amount of extra income you receive when an employee checks out a customer (Higher = more )",
                new AcceptableValueRange<float>(0.05f, 0.25f)
                )
            );

        EmployeeCheckoutPerPerk1 = base.Config.Bind(
            "Perks",
            "Employee Checkout Time Reduction Perk 1",
            .15f,
            new ConfigDescription("Adjust the amount of time employees wait to scan items in checkout (Perk 1) (Lower = slower)",
                new AcceptableValueRange<float>(0.01f, 0.25f)
            )
        );
        
        EmployeeCheckoutPerPerk2 = base.Config.Bind(
            "Perks",
            "Employee Checkout Time Reduction Perk 2",
            .2f,
            new ConfigDescription("Adjust the amount of time employees wait to scan items in checkout (Perk 2) (Lower = slower)",
                new AcceptableValueRange<float>(0.01f, 0.25f)
            )
        );
        
        EmployeeCheckoutPerPerk3 = base.Config.Bind(
            "Perks",
            "Employee Checkout Time Reduction Perk 3",
            .15f,
            new ConfigDescription("Adjust the amount of time employees wait to scan items in checkout (Perk 3) (Lower = slower)",
                new AcceptableValueRange<float>(0.01f, 0.25f)
            )
        );

        CustomersPerPerk = base.Config.Bind(
            "Perks",
            "Extra Customers per perk",
            1,
            new ConfigDescription("Adjust the amount of customers you gain per perk",
                new AcceptableValueRange<int>(0, 10)
            )
        );

        OneHitThief = base.Config.Bind(
            "Thiefs",
            "Thiefs Drop Everything On Hit",
            false
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

        harmony.PatchAll();

        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_NAME} v{PluginInfo.PLUGIN_VERSION} is loaded!");
    }
    public static string ReplaceCommas(string text)
    {
        if (!ReplaceCommasWithPeriods.Value) return text;
        text = text.Replace("$", string.Empty);
        text = text.Replace(char.Parse(","), char.Parse("."));
        if (!text.Contains("."))
        {
            text += ".00";
        }
        return "$" + text;
    }

    //public static string ReplaceCurrency(string text)
    //{
    //    if (!ReplaceCurrencyWithNew.Value) return text;
    //    text = text.Replace("$", string.Empty);
    //    text = text.Replace(char.Parse(","), char.Parse("."));
    //    if (!text.Contains("."))
    //    {
    //        text += ".00";
    //    }
    //    return "$" + text;
    //}

    public static void CreateCanvasNotification(string text)
    {
        //if (!GameCanvas.Instance.inCooldown)
        //{
            GameObject obj = Object.Instantiate(GameCanvas.Instance.notificationPrefab, GameCanvas.Instance.notificationParentTransform);
            obj.GetComponent<TextMeshProUGUI>().text = text;
            obj.SetActive(value: true);
            //GameCanvas.Instance.StartCoroutine(GameCanvas.Instance.NotificationCooldown());
        //}
    }
    public static void CreateImportantNotification(string text)
    {
        //if (!GameCanvas.Instance.inCooldown)
        //{
            GameObject obj = Object.Instantiate(GameCanvas.Instance.importantNotificationPrefab, GameCanvas.Instance.importantNotificationParentTransform);
            obj.GetComponent<TextMeshProUGUI>().text = text;
            obj.SetActive(value: true);
            //GameCanvas.Instance.StartCoroutine(GameCanvas.Instance.NotificationCooldown());
        //}

    }

    /// <summary>
    /// Code executed every frame. See below for an example use case
    /// to detect keypress via custom configuration.
    /// </summary>
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
        SettingChangedEventArgs settingChangedEventArgs = e as SettingChangedEventArgs;

        // Check if null and return
        if (settingChangedEventArgs == null)
        {
            return;
        }

        // Turn off nearest 10 if both true
        if (settingChangedEventArgs.ChangedSetting.Definition.Key == NearestFiveKey || settingChangedEventArgs.ChangedSetting.Definition.Key == NearestTenKey)
        {
            if (NearestTen.Value && NearestFive.Value)
                NearestTen.Value = false;
        }
    }
    

}


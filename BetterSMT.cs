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
    public static ConfigEntry<bool> OneHitThief;
    public static ConfigEntry<bool> ReplaceCommasWithPeriods;
    public static ConfigEntry<bool> FasterCheckout;
    public static ConfigEntry<bool> ShowFPS;
    public static ConfigEntry<bool> ShowPing;


    private void Awake()
    {
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
            true
        );

        FasterCheckout = base.Config.Bind(
            "Customers",
            "Faster Checkout",
            true,
            new ConfigDescription("Customers place all items instantly on to the checkout")
        );

        ReplaceCommasWithPeriods = base.Config.Bind(
            "Other",
            "Replace Commas with Periods",
            true
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
}
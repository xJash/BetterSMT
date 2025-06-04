using BepInEx.Configuration;
using HarmonyLib;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BetterSMT.Patches;

[HarmonyPatch(typeof(GameData))]
public static class Patch_AddEarlyLoanPaymentButton {
    private static BetterSMTLoanSystem loanSystemInstance;

    [HarmonyPatch("OnStartClient"), HarmonyPostfix]
    private static void AutopayInvoices(DebtManager __instance) {
        if (__instance == null) {
            return;
        }

        __instance.autopayInvoices = BetterSMT.AutoPayAllInvoices?.Value ?? false;
    }

    [HarmonyPatch("OnStartClient"), HarmonyPostfix]
    private static void UpdateInvoiceMenu() {
        if (!BetterSMT.LoanEarly.Value) {
            return; 
        }
        GameObject invoiceMenu = GameObject.Find("Interactables/Canvas_Manager/Tabs/Invoices_Tab/");
        if (invoiceMenu == null) {
            BetterSMT.Logger.LogWarning("Invoice Menu not found.");
            return;
        }

        GameObject original = invoiceMenu.transform.Find("PayThisInvoiceButton")?.gameObject;
        if (original == null) {
            BetterSMT.Logger.LogWarning("PayThisInvoiceButton not found.");
            return;
        }

        GameObject newButton = new("PayInvoiceEarlyButton", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Button));
        newButton.transform.SetParent(invoiceMenu.transform, false);
        RectTransform newRect = newButton.GetComponent<RectTransform>();
        RectTransform originalRect = original.GetComponent<RectTransform>();
        newRect.anchorMin = originalRect.anchorMin;
        newRect.anchorMax = originalRect.anchorMax;
        newRect.pivot = originalRect.pivot;
        newRect.sizeDelta = originalRect.sizeDelta;
        newRect.anchoredPosition = new Vector2(431f, -109f);

        Image newImage = newButton.GetComponent<Image>();
        Image originalImage = original.GetComponent<Image>();
        newImage.sprite = originalImage.sprite;
        newImage.type = originalImage.type;
        newImage.color = originalImage.color;

        GameObject textGO = new("PayInvoiceEarly_Text", typeof(RectTransform), typeof(CanvasRenderer), typeof(TextMeshProUGUI));
        textGO.transform.SetParent(newButton.transform, false);

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
        if (originalTMP != null) {
            tmp.font = originalTMP.font;
            tmp.material = originalTMP.material;
        }

        Button btn = newButton.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            BetterSMT.Logger.LogInfo("Pay Invoice Early button clicked.");
            if (loanSystemInstance != null && NetworkClient.active) {
                loanSystemInstance.CmdPayLoanEarly();
            } else {
                BetterSMT.CreateImportantNotification("Loan system not initialized.");
            }
        });

        Button originalBtn = original.GetComponent<Button>();
        btn.transition = originalBtn.transition;
        btn.colors = originalBtn.colors;
        btn.navigation = originalBtn.navigation;

        if (!GameData.Instance.isServer) {
            newButton.SetActive(false);
        }
    }

    [HarmonyPatch("Awake"), HarmonyPostfix]
    private static void EnsureLoanSystemComponent(GameData __instance) {
        loanSystemInstance = __instance.GetComponent<BetterSMTLoanSystem>();
        if (loanSystemInstance == null) {
            loanSystemInstance = __instance.gameObject.AddComponent<BetterSMTLoanSystem>();
        }
    }

    public class BetterSMTLoanSystem : NetworkBehaviour {
        [Command(requiresAuthority = false)]
        public void CmdPayLoanEarly() {
            BetterSMT.Logger.LogInfo("CmdPayLoanEarly started");

            if (GameData.Instance == null) {
                BetterSMT.Logger.LogError("GameData.Instance is null!");
                return;
            }

            var debtManager = GameData.Instance.GetComponent<DebtManager>();
            if (debtManager == null) {
                BetterSMT.Logger.LogError("DebtManager component is null!");
                return;
            }

            if (debtManager.NetworkcurrentInvoicesData == null) {
                BetterSMT.Logger.LogError("DebtManager.NetworkcurrentInvoicesData is null!");
                return;
            }

            if (debtManager.loanDisclaimerContainerOBJ == null) {
                BetterSMT.Logger.LogWarning("DebtManager.loanDisclaimerContainerOBJ is null!");
            }

            int totalLoan = debtManager.NetworkloanAmount;
            BetterSMT.Logger.LogInfo($"Loan amount: {totalLoan}");

            if (totalLoan <= 0) {
                BetterSMT.CreateImportantNotification("No active loan to pay.");
                return;
            }

            if (GameData.Instance.gameFunds < totalLoan) {
                BetterSMT.CreateImportantNotification("Not enough funds to pay off the loan.");
                return;
            }

            GameData.Instance.CmdAlterFundsWithoutExperience(-totalLoan);
            debtManager.NetworkloanAmount = 0;
            debtManager.NetworkloanPaymentPerDay = 0;

            for (int i = 0; i < debtManager.NetworkcurrentInvoicesData.Length; i++) {
                string invoice = debtManager.NetworkcurrentInvoicesData[i];
                if (!string.IsNullOrEmpty(invoice)) {
                    debtManager.GetInvoiceDataValues(invoice, out int invoiceTypeID, out _, out _, out _, out _);
                    if (invoiceTypeID == 0) {
                        debtManager.NetworkcurrentInvoicesData[i] = "";
                    }
                }
            }

            if (debtManager.loanDisclaimerContainerOBJ != null && debtManager.loanDisclaimerContainerOBJ.activeSelf) {
                debtManager.loanDisclaimerContainerOBJ.SetActive(false);
            }

            debtManager.GenerateExistingDebtsInUI();

            BetterSMT.CreateImportantNotification("Loan paid off early.");
        }
    }
}

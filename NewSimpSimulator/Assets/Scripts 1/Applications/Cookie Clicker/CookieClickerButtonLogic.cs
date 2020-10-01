using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookieClickerButtonLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalProfitsText;
 

    [SerializeField] private Image cooldownImage;
    [SerializeField] private TextMeshProUGUI buttonText;

    [SerializeField] private TextMeshProUGUI upgradeCostText;
    [SerializeField] private TextMeshProUGUI upgradeMoneyPerClickText;
    [SerializeField] private TextMeshProUGUI upgradeCooldownText;

    [SerializeField] MoneyManager moneyManager;

    [SerializeField] private float baseMoneyPerClickAmount;
    [SerializeField] private float baseUpgradeCoolDown;

    private float currentMoneyPerClickAmount;
    private float currentClickCooldown;

    private float currentClickTime = 0;
    private int currentUpgradeIndex = 0;

    [System.Serializable]
    public class ButtonUpgrades
    {
        [SerializeField] private string upgradeName;

        public float upgradeCost;
        public float moneyPerClickAmount;
        public float upgradeCooldown;
    }

    [SerializeField] private ButtonUpgrades[] buttonUpgrades;

    // Start is called before the first frame update
    void Start()
    {
        currentMoneyPerClickAmount = baseMoneyPerClickAmount;
        currentClickCooldown = baseUpgradeCoolDown;
    }

    private void Update()
    {
        UpdateUI();

        //(currentX - minX) / (maxX - minX)
        cooldownImage.fillAmount = (currentClickTime - currentClickCooldown) / (0 - currentClickCooldown);

        currentClickTime -= Time.deltaTime;
    }

    private void UpdateUI()
    {
        //button
        buttonText.text = "$" + currentMoneyPerClickAmount.ToString("F2");

        //upgrade
        if (currentUpgradeIndex == buttonUpgrades.Length)
        {
            upgradeCostText.text = "Upgrade Cost: N/A";
            upgradeMoneyPerClickText.text = "Upgrade: MAX";
            upgradeCooldownText.text = "Upgrade: MAX";
        }
        else
        {
            upgradeCostText.text = "Upgrade Cost: $" + buttonUpgrades[currentUpgradeIndex].upgradeCost.ToString("F2");
            upgradeMoneyPerClickText.text = "Upgrade: $" + buttonUpgrades[currentUpgradeIndex].moneyPerClickAmount.ToString("F2") + " per click";
            upgradeCooldownText.text = "Upgrade: " + buttonUpgrades[currentUpgradeIndex].upgradeCooldown.ToString("F2") + " sec cooldown";
        }
    }

    public void Upgrade()
    {
        if (currentUpgradeIndex == buttonUpgrades.Length) return;

        if (moneyManager.Purchase(buttonUpgrades[currentUpgradeIndex].upgradeCost))
        {
            currentClickTime = 0;
            currentMoneyPerClickAmount = buttonUpgrades[currentUpgradeIndex].moneyPerClickAmount;
            currentClickCooldown = buttonUpgrades[currentUpgradeIndex].upgradeCooldown;
            currentUpgradeIndex++;
        }
    }

    public void OnClick()
    {
        if (currentClickTime > 0) return;

        moneyManager.UpdateWallet(currentMoneyPerClickAmount);
        currentClickTime = currentClickCooldown;
    }

}

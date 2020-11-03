using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI accountBalanceUIText;
    [SerializeField] private TextMeshProUGUI totalCookieClickerMoneyUIText;
    [SerializeField] private TextMeshProUGUI totalBitMinedMoneyUIText;
    [SerializeField] private TextMeshProUGUI totalGPUsUIText;
    [SerializeField] private TextMeshProUGUI GPUsMiningRateUIText;
    [SerializeField] private EGirlMoneyManager eGirlMoneyManager;
    [SerializeField] private TextMeshProUGUI transactionHistory;
    [HideInInspector] public float totalCookieClickerMoney = 0;

    [HideInInspector] public string transactionHistoryString = "";

    private float totalBitMinedMoney = 0;
    private float dailyRate = 5;
    [HideInInspector] public float accountBalance = 0;
    private int numGPUs = 1;

    void Update()
    {
        accountBalanceUIText.text = "Account Balance: $" + accountBalance.ToString("F2");

        totalCookieClickerMoneyUIText.text = "Total Profits: $" + totalCookieClickerMoney.ToString("F2");
        totalBitMinedMoneyUIText.text = "Total Profits: $" + totalBitMinedMoney.ToString("F2");

        transactionHistory.text = transactionHistoryString;
    }

    public void UpdateWallet()
    {
        totalBitMinedMoney += (dailyRate / 1440f);
        accountBalance += (dailyRate / 1440f);
    }

    public void UpdateWallet(float _amount)
    {
        accountBalance += _amount;
        totalCookieClickerMoney += _amount;
    }




    public void DonateMoney(float _cost, int _perkIndex, string _transactionName)
    {
        if (_cost > accountBalance) return;

        accountBalance -= _cost;
        eGirlMoneyManager.UpdateDonations(_cost);
        //call perk to be activated

        transactionHistoryString = "<align=left>" + _transactionName + ":</align>\n<align=right><color=red>$" + _cost.ToString("F2") + "</color></align>\n\n" + transactionHistory.text;
    }

    public void UpgradeBitMiner(float _cost, float _dailyRateIncrease, string _transactionName)
    {
        if (_cost > accountBalance) return;

        accountBalance -= _cost;
        dailyRate += _dailyRateIncrease;
        numGPUs++;
        GPUsMiningRateUIText.text = "Current Mining Rate: \n$" + dailyRate + "<size=6>per/day</size>";
        totalGPUsUIText.text = "Number of GPUs: " + numGPUs;
        transactionHistoryString = "<align=left>" + _transactionName + ":</align>\n<align=right><color=red>$" + _cost.ToString("F2") + "</color></align>\n\n" + transactionHistory.text;
    }

    public bool Purchase(float _cost, string _transactionName)
    {
        if (_cost > accountBalance) return false;

        accountBalance -= _cost;
        transactionHistoryString = "<align=left>" + _transactionName + ":</align>\n<align=right><color=red>$" + _cost.ToString("F2") + "</color></align>\n\n" + transactionHistory.text;
        return true;
    }
}

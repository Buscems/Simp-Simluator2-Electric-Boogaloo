using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BitminerUpgrades : MonoBehaviour
{
    [SerializeField] private MoneyManager moneyManager;

    [SerializeField] private float upgradeCost;
    [SerializeField] private float moneyPerDayIncrease;
    [SerializeField] private string transactionName;

    public void OnClick()
    {
        moneyManager.UpgradeBitMiner(upgradeCost, moneyPerDayIncrease, transactionName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AccountBalance : MonoBehaviour
{
    [SerializeField] private MoneyManager moneyManager;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Account Balance:\n$" + moneyManager.accountBalance.ToString("F2");
    }
}

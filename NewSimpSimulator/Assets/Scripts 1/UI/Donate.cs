using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Donate : MonoBehaviour
{
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private GameObject perkDescriptionPanel;
    [SerializeField] private TextMeshProUGUI perkText;

    [TextArea]
    [SerializeField] private string donationDescription;
    [SerializeField] private int cost;
    [SerializeField] private int perkIndex;

    public void OnHoverEnter()
    {
        perkDescriptionPanel.SetActive(true);
        perkText.text = donationDescription;
    }

    public void OnHoverExit()
    {
        perkDescriptionPanel.SetActive(false);
    }

    public void OnClick()
    {
        moneyManager.DonateMoney(cost, perkIndex);
    }
}

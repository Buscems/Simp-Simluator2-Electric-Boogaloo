using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DonateButton : MonoBehaviour
{
    [SerializeField] private DonationButtonMovement[] buttons;
    [SerializeField] private GameObject donateButton;

    public void SpreadOut()
    {
        donateButton.SetActive(false);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SpreadOut(true);        
        }
    }

    public void ComeIn()
    {
        donateButton.SetActive(true);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SpreadOut(false);
        }
    }
}

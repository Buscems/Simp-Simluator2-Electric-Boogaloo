using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodAndEnergyManager : MonoBehaviour
{
    [SerializeField] private Image hungerMeter;
    [SerializeField] private Image energyMeter;
    [SerializeField] private TextMeshProUGUI hungerText;
    [SerializeField] private TextMeshProUGUI energyText;

    private int maxHunger = 100;
    private int maxEnergy = 100;

    private float currentHunger = 100;
    private float currentEnergy = 100;

    private float hungerLostPerDay = 100;
    private float energyLostPerDay = 100;

    // Start is called before the first frame update
    void Start()
    {
        //Get percentage of way to something
        //(currentX - minX) / (maxX - minX)

        hungerMeter.fillAmount = 100 * (currentHunger - 0) / (maxHunger - 0);
        energyMeter.fillAmount = 100 * (currentEnergy - 0) / (maxEnergy - 0);
    }

    // Update is called once per frame
    void Update()
    {
        hungerText.text = (hungerMeter.fillAmount * 100).ToString("F0") + " / " + maxHunger;
        energyText.text = (energyMeter.fillAmount * 100).ToString("F0") + " / " + maxEnergy;

        //update hunger and energy
        hungerMeter.fillAmount = (currentHunger - 0f) / (maxHunger - 0f);
        energyMeter.fillAmount = (currentEnergy - 0f) / (maxEnergy - 0f);
    }

    public void UpdateHunger()
    {
        currentHunger -= hungerLostPerDay / 1440f;
    }

    public void UpdateEnergy()
    {
        currentEnergy -= energyLostPerDay / 1440f;
    }
}

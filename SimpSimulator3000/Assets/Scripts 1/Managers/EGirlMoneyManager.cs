using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EGirlMoneyManager : MonoBehaviour
{
    [SerializeField] private Image donationGoalProgressBar;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI donationGoalText;

    [System.Serializable]
    public class DonationGoals
    {
        public string nameOfGoal;
        public float moneyNeeded;
        public int instructionIndex;
    }

    [SerializeField] private DonationGoals[] donationGoals;

    private int donationGoalIndex = 0;
    private float currentDonations = 0;

    private void Start()
    {
        float percentage = (currentDonations - 0) / (donationGoals[donationGoalIndex].moneyNeeded - 0);
        donationGoalProgressBar.fillAmount = percentage;
        progressText.text = "Goal: $" + currentDonations.ToString("F2") + "/$" + donationGoals[donationGoalIndex].moneyNeeded;
        donationGoalText.text = donationGoals[donationGoalIndex].nameOfGoal;
    }

    private void Update()
    {
       if(currentDonations > donationGoals[donationGoalIndex].moneyNeeded)
        {
            CheckDonationGoals();
        }

        //(currentX - minX) / (maxX - minX)
        float percentage = (currentDonations - 0) / (donationGoals[donationGoalIndex].moneyNeeded - 0);
        donationGoalProgressBar.fillAmount = percentage;
        progressText.text = "Goal: $" + currentDonations.ToString("F2") + "/$" + donationGoals[donationGoalIndex].moneyNeeded;
    }

    private void CheckDonationGoals()
    {
        currentDonations -= donationGoals[donationGoalIndex].moneyNeeded;
        donationGoalIndex++;
        donationGoalText.text = donationGoals[donationGoalIndex].nameOfGoal;
    }

    public void UpdateDonations(float _amount)
    {
        currentDonations += _amount;
    }
}

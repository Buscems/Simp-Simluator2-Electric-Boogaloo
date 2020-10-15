using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private FoodAndEnergyManager foodAndEnergyManager;

    [SerializeField] private TextMeshProUGUI clockTime;
    [SerializeField] private TextMeshProUGUI clockDate;
    [SerializeField] private TextMeshProUGUI phoneTime;

    [SerializeField] private TextMeshProUGUI clockDate2;

    private int hour = 12;
    private int minute = 0;
    private bool am = true;
    private int month = 0;
    private int day = 1;
    private int dayOfTheWeek = 0;

    //how long is an in-game minute
    private float minuteLength = 2f;

    private class Months
    {
        public string monthName;
        public int maxDays;

        public Months(string name, int days)
        {
            monthName = name;
            maxDays = days;
        }
    }

    private Months[] monthInformationReference =
    {
     new Months("JAN", 31),
     new Months("FEB", 28),
     new Months("MAR", 31),
     new Months("APR", 30),
     new Months("MAY", 31),
     new Months("JUN", 30),
     new Months("JUL", 31),
     new Months("AUG", 31),
     new Months("SEP", 30),
     new Months("OCT", 31),
     new Months("NOV", 30),
     new Months("DEC", 31)
    };

    private string[] dayInformationReference =
    {
     "Monday",
     "Tuesday",
     "Wednesday",
     "Thursday",
     "Friday",
     "Saturday",
     "Sunday"
    };


    private IEnumerator Clock()
    {
        yield return new WaitForSeconds(minuteLength);
        moneyManager.UpdateWallet();
        foodAndEnergyManager.UpdateEnergy();
        foodAndEnergyManager.UpdateHunger();
        UpdateTime();
        StartCoroutine(Clock());
    }

    private void UpdateTime()
    {
        minute++;
        if(minute == 60)
        {
            hour++;

            if (hour == 12)
            {
                am = !am;
                if (am)
                {
                    UpdateDay();
                }
            }
            else if(hour == 13)
            {
                hour = 1;
            }

            minute = 0;
        }
    }

    private void UpdateDay()
    {
        day++;
        dayOfTheWeek++;

        if(dayOfTheWeek > dayInformationReference.Length)
        {
            day = 0;
        }

        if(day > monthInformationReference[month].maxDays)
        {
            day = 1;
            month++;

            if(month > 11)
            {
                month = 0;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Clock());      
    }

    // Update is called once per frame
    void Update()
    {
        clockTime.text = (hour < 10 ? "0" + hour.ToString() : hour.ToString()) + ":" + (minute < 10 ? "0" + minute.ToString() : minute.ToString()) + (am ? "AM" : "PM");
        clockDate.text = dayInformationReference[dayOfTheWeek] + " " + monthInformationReference[month].monthName + " " + day.ToString();
        phoneTime.text = (hour < 10 ? "0" + hour.ToString() : hour.ToString()) + ":" + (minute < 10 ? "0" + minute.ToString() : minute.ToString()) + (am ? "AM" : "PM");

        clockDate2.text = clockTime.text + "\n" + dayInformationReference[dayOfTheWeek] + "\n" + monthInformationReference[month].monthName + " " + day.ToString();
    }
}

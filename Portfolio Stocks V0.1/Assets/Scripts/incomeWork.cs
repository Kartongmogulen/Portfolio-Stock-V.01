using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class incomeWork : MonoBehaviour
{
    public float incomeWorkPerMonth;
    public float totalIncomeFromWork;

    public Text incomeWorkText;

    private void Start()
    {
        incomeNowUpdate();
    }

    public void incomeDuringLife()
    {
        totalIncomeFromWork += incomeWorkPerMonth;
    }

    public void incomeNowUpdate() { 

    incomeWorkText.text = "Work/month: " + incomeWorkPerMonth;

    }
}

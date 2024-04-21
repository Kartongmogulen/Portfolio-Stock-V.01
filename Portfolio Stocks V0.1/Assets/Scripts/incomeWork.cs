using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class incomeWork : MonoBehaviour
{
    [Range(90,110)] public float incomeWorkPerMonth;
    public float totalIncomeFromWork;

    public Text incomeWorkText;

    private void Start()
    {
        //incomeWorkPerMonth = 200; //TESTA HUR RANGE FUNGERAR
        Invoke("incomeNowUpdate", 0.01f);
        //incomeNowUpdate();
    }

    public void incomeDuringLife()
    {
        totalIncomeFromWork += incomeWorkPerMonth;
    }

    public void incomeNowUpdate() { 

    incomeWorkText.text = " Work/month: " + incomeWorkPerMonth;

    }
}

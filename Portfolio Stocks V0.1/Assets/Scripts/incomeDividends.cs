using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incomeDividends : MonoBehaviour
{
    //Hanterar intäkter från utdelning

    public GameObject ScriptsStockGO;

    public List<float> incomePerYear;
    public float totalIncome;
    public float incomeDividendPreviousYear;

    int i = 0;

    public void updateIncomeDividends()
    {
       
        incomePerYear.Add(ScriptsStockGO.GetComponent<dividendRecieved>().divRecPerYear[ScriptsStockGO.GetComponent<dividendRecieved>().divRecPerYear.Count-1]);

        totalIncome += incomePerYear[i];
        incomeDividendPreviousYear = incomePerYear[incomePerYear.Count - 1];

        i++;

        //GetComponent<totalCash>().incomeDividend(incomeDividendPreviousYear); 
    }
}

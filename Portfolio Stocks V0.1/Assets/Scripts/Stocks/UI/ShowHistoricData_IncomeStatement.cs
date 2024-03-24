using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHistoricData_IncomeStatement : MonoBehaviour
{
    public List<Text> yearsHeader;
    public List<Text> RevenueText;
    public List<Text> CostText;
    public List<Text> EarningsText;
    //public List<Text> PayoutRatioText;

    public void updateRevenue(incomeStatement stockPrefab)
    {
        //Debug.Log("RevenueText.Count: " + RevenueText.Count);
        for (int i = 0; i < RevenueText.Count; i++)
        {
            //Debug.Log("Iteration: " + i);
            RevenueText[i].text = "" + stockPrefab.getRevenue()[stockPrefab.getRevenue().Count - RevenueText.Count + i];
        }
    }

    public void updateCost(incomeStatement stockPrefab)
    {
        Debug.Log("CostText.Count: " + CostText.Count);
        for (int i = 0; i < CostText.Count; i++)
        {
            Debug.Log("Iteration: " + i);
            CostText[i].text = "" + stockPrefab.getCost()[i];
        }
    }

}

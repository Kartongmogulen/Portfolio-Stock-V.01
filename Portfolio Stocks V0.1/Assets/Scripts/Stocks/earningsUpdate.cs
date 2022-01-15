using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earningsUpdate : MonoBehaviour
{

    public stock Stock;

    public float newEPS;
    public float oldEPS;

    public float EPSGrowthForPreviousYear;

    public void updateEarnings(stock Stock)
    {
        oldEPS = Stock.EPSnow;

        EPSGrowthForPreviousYear = Random.Range(Stock.EPSGrowthMin, Stock.EPSGrowthMax)/100;
        Debug.Log("EPS Growth: " + EPSGrowthForPreviousYear);

        newEPS = Mathf.Round(oldEPS * (1 + EPSGrowthForPreviousYear)*100)/100;
        Stock.EPSnow = newEPS;
        Stock.EPSHistory.Add(newEPS);
    }
}

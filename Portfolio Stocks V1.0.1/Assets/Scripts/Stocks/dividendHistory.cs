using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dividendHistory : MonoBehaviour
{
    //Utdelning bolaget gett ut 
    [SerializeField] List<float> dividendPaid;   

   public void saveDividendHistory(float dividend)
    {
        dividendPaid.Add(dividend);
    }

    public float getHistoricDividend(int index)
    {
        return dividendPaid[index];
    }

    public int lengthDividendHistory()
    {
        return dividendPaid.Count;
    }
}

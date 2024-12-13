using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class annulizedChangeOverAPeriod : MonoBehaviour
{
    [SerializeField] float annualChange;

    public economicClimate EconomicClimate;// F�R TEST

    public float calculate(float startValue, float endValue, int startYear, int endYear)
    {
    // Ange de tv� v�rdena
    //double startValue = 1000.0; // Det ursprungliga v�rdet
    //double endValue = 1200.0;   // Det slutliga v�rdet

    // Ange �ret n�r de tv� v�rdena observerades
    //int startYear = 2020;
    //int endYear = 2021;

    // Ber�kna �rlig f�r�ndring
   annualChange = (endValue - startValue) / (endYear - startYear);

    // Skriv ut resultatet
    Debug.Log("Det �rliga �ndringsv�rdet �r: " + annualChange);

        // Om du vill ha resultatet som en procent, anv�nd f�ljande kod ist�llet:
        // double annualChangePercent = ((endValue - startValue) / startValue) * 100;
        // Console.WriteLine("Det �rliga �ndringsprocentet �r: " + annualChangePercent + "%");

        return annualChange;
    }

    public void testChangeForPeriod()
    {
        annualChange = calculate(EconomicClimate.totalBNPlist[0], EconomicClimate.totalBNPlist[EconomicClimate.totalBNPlist.Count - 1], 0, EconomicClimate.totalBNPlist.Count);
        Debug.Log("Startv�rde BNP: " + EconomicClimate.totalBNPlist[0]);
        Debug.Log("Slutv�rde BNP: " + EconomicClimate.totalBNPlist[EconomicClimate.totalBNPlist.Count - 1]);
        Debug.Log("Antal �r: " + EconomicClimate.totalBNPlist.Count);
    }
}


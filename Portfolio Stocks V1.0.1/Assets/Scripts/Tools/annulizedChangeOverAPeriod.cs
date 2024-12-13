using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class annulizedChangeOverAPeriod : MonoBehaviour
{
    [SerializeField] float annualChange;

    public economicClimate EconomicClimate;// FÖR TEST

    public float calculate(float startValue, float endValue, int startYear, int endYear)
    {
    // Ange de två värdena
    //double startValue = 1000.0; // Det ursprungliga värdet
    //double endValue = 1200.0;   // Det slutliga värdet

    // Ange året när de två värdena observerades
    //int startYear = 2020;
    //int endYear = 2021;

    // Beräkna årlig förändring
   annualChange = (endValue - startValue) / (endYear - startYear);

    // Skriv ut resultatet
    Debug.Log("Det årliga ändringsvärdet är: " + annualChange);

        // Om du vill ha resultatet som en procent, använd följande kod istället:
        // double annualChangePercent = ((endValue - startValue) / startValue) * 100;
        // Console.WriteLine("Det årliga ändringsprocentet är: " + annualChangePercent + "%");

        return annualChange;
    }

    public void testChangeForPeriod()
    {
        annualChange = calculate(EconomicClimate.totalBNPlist[0], EconomicClimate.totalBNPlist[EconomicClimate.totalBNPlist.Count - 1], 0, EconomicClimate.totalBNPlist.Count);
        Debug.Log("Startvärde BNP: " + EconomicClimate.totalBNPlist[0]);
        Debug.Log("Slutvärde BNP: " + EconomicClimate.totalBNPlist[EconomicClimate.totalBNPlist.Count - 1]);
        Debug.Log("Antal år: " + EconomicClimate.totalBNPlist.Count);
    }
}


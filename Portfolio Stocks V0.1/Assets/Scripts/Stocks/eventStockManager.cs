using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventStockManager : MonoBehaviour
{
    //[SerializeField] int frequency; //Hur ofta en h�ndelse intr�ffar
    [SerializeField] enum frequency { None, OncePerYear, Quarterly, Montlhy };
    [SerializeField] frequency Frequency;

    [SerializeField] int sectorEventProb; //Slh att det �r sektorn som drabbas annars bolag

    //[SerializeField] int positiveProbability; // Sannolikheten f�r en positiv h�ndelse (0 till 100)

    [SerializeField] economicClimate EconomicClimate;

   

    public void doesEventOccur(int month)
    {
        //Debug.Log("M�nad: " + month);
        if(Frequency == frequency.OncePerYear && month == 1 )
        {
            Debug.Log("H�ndelse intr�ffar 1 ggr per �r i januari");
            positiveOrNegativeEvent();
        }
    }

    //Sker en positiv eller negativ h�ndelse
    public void positiveOrNegativeEvent()
    {
       if (EconomicClimate.RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Expanssion)
        {
            Debug.Log("Positiv h�ndelse!");
        }

        if (EconomicClimate.RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Rececssion)
        {
            Debug.Log("Negativ h�ndelse!");
        }

        sectorOrCompanyEvent();
    }

    public void sectorOrCompanyEvent()
    {
        int random = Random.Range(0, 100);
        if(random <= sectorEventProb)
        {
            Debug.Log("Sektorn drabbas: " + random);
        }
        else
        {
            Debug.Log("Bolag drabbas: " + random);
        }
    }

    
}

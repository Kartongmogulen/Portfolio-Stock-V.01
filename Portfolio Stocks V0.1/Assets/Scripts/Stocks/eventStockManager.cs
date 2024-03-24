using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventStockManager : MonoBehaviour
{
    //[SerializeField] int frequency; //Hur ofta en händelse inträffar
    [SerializeField] enum frequency { None, OncePerYear, Quarterly, Montlhy };
    [SerializeField] frequency Frequency;

    [SerializeField] int sectorEventProb; //Slh att det är sektorn som drabbas annars bolag

    //[SerializeField] int positiveProbability; // Sannolikheten för en positiv händelse (0 till 100)

    [SerializeField] economicClimate EconomicClimate;

   

    public void doesEventOccur(int month)
    {
        //Debug.Log("Månad: " + month);
        if(Frequency == frequency.OncePerYear && month == 1 )
        {
            Debug.Log("Händelse inträffar 1 ggr per år i januari");
            positiveOrNegativeEvent();
        }
    }

    //Sker en positiv eller negativ händelse
    public void positiveOrNegativeEvent()
    {
       if (EconomicClimate.RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Expanssion)
        {
            Debug.Log("Positiv händelse!");
        }

        if (EconomicClimate.RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Rececssion)
        {
            Debug.Log("Negativ händelse!");
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

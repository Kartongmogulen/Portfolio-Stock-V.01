using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Price", menuName = "Needs/Price")]
public class Price_SupplyDemand : ScriptableObject
{
    [SerializeField] float minimumPrice;

    /*
    public float price(int utbud, int efterfragan, float startPris)
    {

        //PRISET BLIR 0 DÅ UTBUDET BLIR DUBBELT SÅ HÖGT EFTERFRÅGAN
        //VID SUPPLY 110 OCH DEMAND 200 GÅR PRISET FRÅN 20/ENHET TILL 10/ENHET

        // Om utbudet är mindre än efterfrågan, höj priset
        if (utbud<efterfragan)
        {
            // Beräkna en ökning baserat på skillnaden mellan utbud och efterfrågan
            float ökning = (efterfragan - utbud) / utbud * startPris;
            Debug.Log("Ökning: " + ökning);
            return startPris + ökning;
        }
        // Om utbudet är större än eller lika med efterfrågan, sänk priset
        else
        {
            // Beräkna en minskning baserat på skillnaden mellan utbud och efterfrågan
            float minskning = (utbud - efterfragan) / efterfragan * startPris;
            Debug.Log("Minskning: " + minskning);
            return startPris - minskning;
        }
    }
    */

    public float price(int utbud, int efterfragan, float jämnviktsPris)
    {
        //Skillnaden mellan Utbud och Efterfrågan
        float diffBetweenSupplyDemand = (efterfragan*100) / utbud - 100;

        //Debug.Log("Utbud: " + utbud);
        //Debug.Log("Efterfrågan: " + efterfragan);

        //Debug.Log("Diff (Utbud/Efterfrågan): " + diffBetweenSupplyDemand);

        //Bestäm pris
        float price = (diffBetweenSupplyDemand/100) * jämnviktsPris + jämnviktsPris;

        //Kan ej bli lägre än ett Minimumpris
        if (price < minimumPrice)
        {
            price = minimumPrice;
        }

        return price;
    }
}


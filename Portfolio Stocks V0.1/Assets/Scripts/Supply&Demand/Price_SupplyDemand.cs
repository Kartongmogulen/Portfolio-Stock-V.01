using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Price", menuName = "Needs/Price")]
public class Price_SupplyDemand : ScriptableObject
{

    public float price(int utbud, int efterfragan, float startPris)
    {
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
}


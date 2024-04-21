using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Price", menuName = "Needs/Price")]
public class Price_SupplyDemand : ScriptableObject
{

    public float price(int utbud, int efterfragan, float startPris)
    {
        // Om utbudet �r mindre �n efterfr�gan, h�j priset
        if (utbud<efterfragan)
        {
            // Ber�kna en �kning baserat p� skillnaden mellan utbud och efterfr�gan
            float �kning = (efterfragan - utbud) / utbud * startPris;
            Debug.Log("�kning: " + �kning);
            return startPris + �kning;
        }
        // Om utbudet �r st�rre �n eller lika med efterfr�gan, s�nk priset
        else
        {
            // Ber�kna en minskning baserat p� skillnaden mellan utbud och efterfr�gan
            float minskning = (utbud - efterfragan) / efterfragan * startPris;
            Debug.Log("Minskning: " + minskning);
            return startPris - minskning;
        }
    }
}


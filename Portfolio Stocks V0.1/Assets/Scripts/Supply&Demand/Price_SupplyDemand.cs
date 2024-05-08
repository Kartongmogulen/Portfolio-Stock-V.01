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

        //PRISET BLIR 0 D� UTBUDET BLIR DUBBELT S� H�GT EFTERFR�GAN
        //VID SUPPLY 110 OCH DEMAND 200 G�R PRISET FR�N 20/ENHET TILL 10/ENHET

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
    */

    public float price(int utbud, int efterfragan, float j�mnviktsPris)
    {
        //Skillnaden mellan Utbud och Efterfr�gan
        float diffBetweenSupplyDemand = (efterfragan*100) / utbud - 100;

        //Debug.Log("Utbud: " + utbud);
        //Debug.Log("Efterfr�gan: " + efterfragan);

        //Debug.Log("Diff (Utbud/Efterfr�gan): " + diffBetweenSupplyDemand);

        //Best�m pris
        float price = (diffBetweenSupplyDemand/100) * j�mnviktsPris + j�mnviktsPris;

        //Kan ej bli l�gre �n ett Minimumpris
        if (price < minimumPrice)
        {
            price = minimumPrice;
        }

        return price;
    }
}


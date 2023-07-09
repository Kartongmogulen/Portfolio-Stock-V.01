using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standardDeviationCalculation : MonoBehaviour
{

    public averageCalculation AverageCalculation;
    [SerializeField] float averagePrices;
    public List<float> pricesDeviationFromMean;
    [SerializeField] float sumPriceDeviationFromMean;
    [SerializeField] float standardDeviation;
    [SerializeField] float amountToTakeInCalcualtion; //Hur m�nga v�rden tidsserien ska inneh�lla

    public float calculateStandardDeviation(List<float> priceData)
    {
        //prices = Stock.StockPrice;

        averagePrices = AverageCalculation.listOfFloats(priceData);

        Debug.Log("Medelv�rde: " + averagePrices);

        //Skapar lista med differensen mellan medelpriset och priset
        for (int i = 0; i < priceData.Count; i++)
        {
            pricesDeviationFromMean.Add(0);
            pricesDeviationFromMean[i] = averagePrices - priceData[i];
        }

        //
        foreach (float f in pricesDeviationFromMean)
        {
            //Debug.Log("Avvikelse i kvadrat: " + Mathf.Pow(f, 2));
            sumPriceDeviationFromMean += Mathf.Pow(f, 2);

        }

        //Ber�knar standardavvkielse 
        amountToTakeInCalcualtion = priceData.Count;
        standardDeviation = Mathf.Pow(sumPriceDeviationFromMean / amountToTakeInCalcualtion, 0.5f);

        return standardDeviation;
    }
}

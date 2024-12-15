using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceCalculator
{
    private readonly IMarketDataProvider _marketDataProvider;
    [SerializeField] float valueDCF;

    public PriceCalculator(IMarketDataProvider marketDataProvider)
    {
        _marketDataProvider = marketDataProvider;
    }

    public float CalculateDCFPrice(float eps, float growthRate, int period)
    {
        valueDCF = 0;//Nollställer

        float discountRate = _marketDataProvider.GetDiscountRate();
        float volatility = _marketDataProvider.GetVolatility();
        float adjustedRate = discountRate + volatility;

        for (int i = 1; i < period; i++)
        {
            eps = eps * Mathf.Pow(1 + growthRate, i); //Prognostiserad EPS i framtiden
            valueDCF += eps / Mathf.Pow((1 + adjustedRate), i); //Diskonterat kassaflöde för perioden
        }

        return valueDCF;
        // Grundläggande DCF-formel
        //return Mathf.Pow(eps * (1 + growthRate), period) / (1 + adjustedRate);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceCalculator
{
    private readonly IMarketDataProvider _marketDataProvider;

    public PriceCalculator(IMarketDataProvider marketDataProvider)
    {
        _marketDataProvider = marketDataProvider;
    }

    public float CalculateDCFPrice(float eps, float growthRate, int period)
    {
        float discountRate = _marketDataProvider.GetDiscountRate();
        float volatility = _marketDataProvider.GetVolatility();
        float adjustedRate = discountRate + volatility;

        // Grundläggande DCF-formel
        return Mathf.Pow(eps * (1 + growthRate), period) / (1 + adjustedRate);
    }
}

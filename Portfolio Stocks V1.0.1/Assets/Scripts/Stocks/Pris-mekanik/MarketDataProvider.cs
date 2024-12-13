using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketDataProvider : MonoBehaviour, IMarketDataProvider
{
    private float _stockMarketPremium;
    private float _riskFreeRate;
    private float _volatility;

    public MarketDataProvider(float initialPremium, float initialRiskFreeRate, float volatility)
    {
        _stockMarketPremium = initialPremium;
        _riskFreeRate = initialRiskFreeRate;
        _volatility = volatility;
    }

    public float GetDiscountRate()
    {
        return _riskFreeRate + _stockMarketPremium;
    }

    public float GetVolatility()
    {
        return UnityEngine.Random.Range(-_volatility, _volatility);
    }

    public void UpdateMarketConditions(float newPremium, float newRiskFreeRate)
    {
        _stockMarketPremium = newPremium;
        _riskFreeRate = newRiskFreeRate;
    }
}

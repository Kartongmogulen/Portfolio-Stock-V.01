public interface IMarketDataProvider
{
    float GetDiscountRate();
    float GetVolatility();
    void UpdateMarketConditions(float newPremium, float newRiskFreeRate);
}


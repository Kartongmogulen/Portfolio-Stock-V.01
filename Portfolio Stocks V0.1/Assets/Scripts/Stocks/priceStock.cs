using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class priceStock : MonoBehaviour
{
    public List<float> StockPrice;
    public float priceNow;
	[SerializeField] float volatilityAbs;
	[SerializeField] float volatilityPercent;

	public void updatePriceNow(float priceNew)
	{
		StockPrice.Add(priceNew);
		//priceNow = StockPrice[StockPrice.Count - 1];
	}

	public void setVolatilityAbs(float setVolatility)
	{
		volatilityAbs = setVolatility;
	}

	public void setVolatilityPercent(float volatility, float average)
	{
		volatilityPercent = volatility/average;
	}

	public float getVolatilityPercent()
	{
		return volatilityPercent;
	}
}

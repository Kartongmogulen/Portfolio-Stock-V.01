using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class priceStock : MonoBehaviour
{
    public List<float> StockPrice;
    public float priceNow;
	[SerializeField] float volatilityAbs;
	[SerializeField] float volatilityPercent;

	//Trailing Twelve Month	
	[SerializeField] int amountOfValuesToGet12Month; //Om det är månadsvärden ska det vara 12. Veckodata = 52;
	public List<float> allDataBeforeCleaning; //All data innan man rensat
	[SerializeField] float trailingTwelweMonthLow;
	[SerializeField] float trailingTwelweMonthHigh;
	[SerializeField] List<float> last12Numbers;

	private void Start()
	{
		Invoke("calculate_TrailingTwelveMonth_PriceHighLow",0.1f);
	}

	public float getTrailingTwelveMonthLow()
	{
		return trailingTwelweMonthLow;
	}

	public float getTrailingTwelveMonthHigh()
	{
		return trailingTwelweMonthHigh;
	}

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

	public void calculate_TrailingTwelveMonth_PriceHighLow()
	{
		//Hämta data
		allDataBeforeCleaning = StockPrice;
		last12Numbers = allDataBeforeCleaning.GetRange(allDataBeforeCleaning.Count - amountOfValuesToGet12Month, amountOfValuesToGet12Month);

		//Högsta värdet
		trailingTwelweMonthHigh = findHighestValue(last12Numbers);

		//Lägsta värdet
		trailingTwelweMonthLow = findLowestValue(last12Numbers);
		
	}

	public float findHighestValue(List<float> values)
	{
		float valueHigh = values[0];

		foreach (float number in values)
		{
			if (number > valueHigh)
			{
				valueHigh = number;
			}
		}
		return valueHigh;
	}

	public float findLowestValue(List<float> values)
	{
		float valueLow = values[0];

		foreach (float number in values)
		{
			if (number < valueLow)
			{
				valueLow = number;
			}
		}
		return valueLow;
	}
}

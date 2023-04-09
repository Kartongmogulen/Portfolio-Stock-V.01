using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class priceStock : MonoBehaviour
{
    public List<float> StockPrice;
    public float priceNow;

	public void updatePriceNow(float priceNew)
	{
		StockPrice.Add(priceNew);
		//priceNow = StockPrice[StockPrice.Count - 1];
	}
}

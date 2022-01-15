using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stock : MonoBehaviour
{

	public string sectorName;

	public float divPolicyChangeDiv;
	public float divPolicyMaxPayouRatio;
	public bool companyPaysDividend;
	public float startPayDividendWhenEPS;
	public float divPayout;

	public float EPSnow;
	public List<float> EPSHistory;
	public float EPSGrowthMin;
	public float EPSGrowthMax;

	public List<float> StockPrice;
	public float priceNow;

	public void updatePriceNow(float priceNew)
	{
		StockPrice.Add(priceNew);
		//priceNow = StockPrice[StockPrice.Count - 1];
	}

}

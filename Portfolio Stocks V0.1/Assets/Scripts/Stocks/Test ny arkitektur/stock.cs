using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stock : MonoBehaviour
{

	//public string sectorName;
	public int indexPrefabList; //Alla prefabs f�r ett nummer som motsvarar denna i listan f�r alla prefabs. Underl�tta vid script f�r att h�mta data f�r specifikt bolag.
	public sectorNameEnum SectorNameEnum;
	public string nameOfCompany;

	public float divPolicyChangeDiv;
	public float divPolicyMaxPayouRatio;
	public bool companyPaysDividend;
	public float startPayDividendWhenEPS;
	public float divPayout;
	public float lastDivPayout;

	public float EPSnow;
	public List<float> EPSHistory;
	public float EPSGrowthMin;
	public float EPSGrowthMax;

	public List<float> StockPrice;
	public float priceNow;
	public float trailingTwelweMonthHigh;
	public float trailingTwelweMonthLow;

	public void updatePriceNow(float priceNew)
	{
		StockPrice.Add(priceNew);
		//priceNow = StockPrice[StockPrice.Count - 1];
	}

	public void saveDividendHistory()
	{
		GetComponent<dividendHistory>().dividendPaid.Add(divPayout);
		lastDivPayout = GetComponent<dividendHistory>().dividendPaid[GetComponent<dividendHistory>().dividendPaid.Count - 1];
	}

}

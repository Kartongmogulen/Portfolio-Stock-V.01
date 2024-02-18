using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stock : MonoBehaviour
{
	[Header("Starting values")]
	//public string sectorName;
	public float divPolicyChangeDiv;
	public float divPolicyMaxPayouRatio;
	public bool companyPaysDividend;
	public float startPayDividendWhenEPS;
	public float divPayout;
	
	public float EPSnow;
	public sectorNameEnum SectorNameEnum;
	public float EPSGrowthMin;
	public float EPSGrowthMax;

	[Header("Historic data")]
	public List<float> EPSHistory;
	[SerializeField] List<float> EPSChangeYoYHistory;
	public List<float> StockPrice;
	
	[Header("Other")]
	public string nameOfCompany;
	public int indexPrefabList; //Alla prefabs får ett nummer som motsvarar denna i listan för alla prefabs. Underlätta vid script för att hämta data för specifikt bolag.
	public float priceNow;
	public float trailingTwelweMonthHigh;
	public float trailingTwelweMonthLow;
	public float lastDivPayout;
	public float volatilityAbs;
	public float volatilityPercent;


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

	public void setEPSChangeYoYHistory()
	{
		//Debug.Log("EPS Change: " + EPSHistory.Count);
		if (EPSHistory.Count > 1) 
		{
			float percentChange = Mathf.Round(((EPSHistory[EPSHistory.Count - 1]) / (EPSHistory[EPSHistory.Count - 2]) - 1)*100)/100;
			EPSChangeYoYHistory.Add(percentChange);
		}
	}
}

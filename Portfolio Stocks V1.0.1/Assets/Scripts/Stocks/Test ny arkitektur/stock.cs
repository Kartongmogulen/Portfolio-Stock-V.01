using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stock : MonoBehaviour, IDividendPayingCompany
{
	[Header("Starting values")]
	//public string sectorName;
	public float divPolicyChangeDiv;
	public float divPolicyMaxPayouRatio;
	public bool companyPaysDividend;
	public float startPayDividendWhenEPS;
	[SerializeField] private float dividendPerShare;
	//[SerializeField] private float dividendPerShareStart;

	//[SerializeField] private float dividendPerShare;

	//public float DividendPerShare => dividendPerShare; // Returnerar utdelning per aktie

	public float DividendPerShare
	{
		get => dividendPerShare;
		set => dividendPerShare = Mathf.Clamp(RoundToTwoDecimals(value), 0, divPolicyMaxPayouRatio * EPSnow);
	}

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
	public float basePrice;
	public float CurrentPrice;
	public float trailingTwelweMonthHigh;
	public float trailingTwelweMonthLow;
	public float lastDivPayout;
	public float volatilityAbs;
	public float volatilityPercent;
	private PriceCalculator _priceCalculator;
	private MarketTrendManager _marketTrendManager;


	public void Initialize(PriceCalculator priceCalculator, MarketTrendManager marketTrendManager)
	{
		_priceCalculator = priceCalculator;
		_marketTrendManager = marketTrendManager;

	}

	public void UpdateDividendsEndOfYear()
	{
		// Höj utdelningen med den angivna procenten.
		float newDividend =dividendPerShare * (1 + divPolicyChangeDiv / 100f);
		//Debug.Log("Ny utdelning utan att beakta tak: " + newDividend);
		//Debug.Log("Utdelningstak: " + divPolicyMaxPayouRatio * EPSnow);
		
		// Kontrollera att utdelningen ligger inom det tillåtna intervallet.
		if (newDividend > divPolicyMaxPayouRatio * EPSnow)
		{
			//Debug.Log("Slår i utdelningstak");
			DividendPerShare = divPolicyMaxPayouRatio * EPSnow; // Justera till maxvärdet.
		}
		else
		{
			DividendPerShare = newDividend; // Använd höjningen.
		}


		//return DividendPerShare;
		//Debug.Log($"New dividend per share: {DividendPerShare}");
	}

	public void UpdatePrice()
	{
		
		basePrice = _priceCalculator.CalculateDCFPrice(EPSnow, Random.Range(EPSGrowthMin,EPSGrowthMax)/100, 10); //Har "period" hårdkodad till 10 då det finns tillräckligt med slump i beräkningen redan
																												  // Kontrollera om företaget är "hett"
		float multiplier = _marketTrendManager.GetCompanyMultiplier(gameObject);

		// Kontrollera om sektorn är "het"
		if (_marketTrendManager.IsSectorHot(SectorNameEnum))
		{
			multiplier += _marketTrendManager.PricePremium/100; // Lägg till extra boost om sektorn också är het
		}

		//Debug.Log($"[Company: {name}] Baspris utan prispremium: {basePrice})");
		CurrentPrice = basePrice * multiplier;
		//Debug.Log($"[Company: {name}] Nytt pris: {CurrentPrice} (Multiplier: {multiplier})");

		savePrice(CurrentPrice);
	}

	public void savePrice(float priceNew)
	{
		StockPrice.Add(priceNew);
	}

	/*
	public void updatePriceNow(float priceNew)
	{
		StockPrice.Add(priceNew);
		//priceNow = StockPrice[StockPrice.Count - 1];
	}
	*/

	public void saveDividendHistory()
	{
		GetComponent<dividendHistory>().saveDividendHistory(dividendPerShare);
		lastDivPayout = GetComponent<dividendHistory>().getHistoricDividend(GetComponent<dividendHistory>().lengthDividendHistory() - 1);
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

	public void adjustEPSGrowth(bool max, float change)
	{
		//Debug.Log("EPS Growth script");
		if (max == true)
		{
			EPSGrowthMax += change;
			EPSGrowthMin += change;
			//Debug.Log("EPS growth MAX ändrad med: " + change);
		}

		if(max == false)
		{
			EPSGrowthMax += change;
			EPSGrowthMin += change;
			//Debug.Log("EPS growth MIN ändrad med: " + change);
		}
	}

	private float RoundToTwoDecimals(float value)
	{
		return Mathf.Round(value * 100f) / 100f;
	}
}

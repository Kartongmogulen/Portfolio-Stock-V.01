﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class priceChange : MonoBehaviour
{
	[Header("Inputparameter for Price")]
	//Beräkning parametrar
	public float discountRate; //Ska ha formen 0.01 = 1 %. Borde ändars i något övergripande script kring marknadsförhållande
	public float discountRateVolatility; //Hur mycket diskonteringsräntan kan ändras
	public int period;
	[SerializeField] int numberOfYears_RevenueGrowth; //Antal år vid beräkning

	[Header("Other")]
	public GameObject StockMarketGO;
	public stockMarketManager StockMarketManager;
	public bondMarketManager BondMarketManager;

	public BondSelectedInfoButton bondSelectedInfoButton;
	public float riskFreeRate;
	public float stockMarketPremium;

	public DCF dcf;
	//public PECalculation pECalculation;

	//Info från bolag
	public float minEPSGrowth;
	public float maxEPSGrowth;
	public float EPS;

	[Tooltip("Om bolaget ej är lönsamt. Vad värderar marknaden det till.")]
	public float ifEPSNegativeMarketEPSValue; //Om bolaget ej är lönsamt. Vad värderar marknaden det till.

	public float valueDCFMin;
	public float valueDCFMax;
	
	public float stockPriceNow;

	//Script för att ändra priset på aktien

	private int i = 0;

	public GameObject MainCanvasGO;
	public GameObject PanelSectorGO;

	public int amountPriceChange; //Hur många gånger har scriptet priceChange körts.

	//Indistri
	public float minEPSGrowth_Industri; //SCHABLON FÖR ATT BLI KLAR MED SNABBARE
	public float maxEPSGrowth_Industri; //SCHABLON FÖR ATT BLI KLAR MED SNABBARE

	/*
	//Utilities
	public float utiStockPriceBefore;
	public float utiStockPriceNow; //Priset för en aktie nu
	public float utiEPSchange;
	//public float utilitiesPriceStart; //Priset för en aktie vid start
	public float utiBetaEPS; //Hur mycket varierar EPS utifrån den globala ekonomin
	public float utiBetaEPSThisTurn; //Hur mycket EPS varierar just denna runda
	public float[] vollaUti; //Volatilitet 

	//Finance
	public float finStockPriceBefore;
	public float finStockPriceNow; //Priset för en aktie nu
	public float vollaFin; //Volatilitet 


	//Technology
	public float techStockPriceBefore;
	public float techStockPriceNow; //Priset för en aktie nu
	public float vollaTech;
	*/
	

	//Text
	public Text utiPriceText;
	public Text finPriceText;
	public Text techPriceText;

	void Awake()
	{
		dcf = GetComponent<DCF>();
	}

	void Start() 
	{
		StockMarketManager = StockMarketGO.GetComponent<stockMarketManager>();
	}

	public float DCFbasedPriceTest(stock Stock)
	{
		riskFreeRate = BondMarketManager.bondMarketListGO[BondMarketManager.bondMarketListGO.Count-1].GetComponent<bondInfoPrefab>().rate/100;
		discountRate = riskFreeRate + stockMarketPremium;
		
		//Min värdering
		if (Stock.EPSnow < 0)
		{
			dcf.DCFCalculation(discountRate + Random.Range(-discountRateVolatility, discountRateVolatility), ifEPSNegativeMarketEPSValue, Stock.EPSGrowthMin, period);
			valueDCFMin = Mathf.RoundToInt(dcf.valueDCF);
		}
		else
		{
			dcf.DCFCalculation(discountRate + Random.Range(-discountRateVolatility, discountRateVolatility), Stock.EPSnow, Stock.EPSGrowthMin, period);
			valueDCFMin = Mathf.RoundToInt(dcf.valueDCF);
		}

		//Max värdering
		if (Stock.EPSnow < 0)
		{
			dcf.DCFCalculation(discountRate + Random.Range(-discountRateVolatility, discountRateVolatility), ifEPSNegativeMarketEPSValue, Stock.EPSGrowthMax, period);
			valueDCFMax = Mathf.RoundToInt(dcf.valueDCF);
		}
		else
		{
			dcf.DCFCalculation(discountRate + Random.Range(-discountRateVolatility, discountRateVolatility), Stock.EPSnow, Stock.EPSGrowthMax, period);
			valueDCFMax = Mathf.RoundToInt(dcf.valueDCF);
		}
		//Spara priset för bolaget
		stockPriceNow = Mathf.RoundToInt(Random.Range(valueDCFMin, valueDCFMax));

		return stockPriceNow;	
	}

	public void changePriceStock(){

		//PRISMODELLER
		amountPriceChange++;
		DCFbasedPrice();

	}

	public void DCFbasedPrice()
	{
		
		foreach (GameObject stockPrefab in StockMarketManager.StockPrefabAllList)
		{
			EPS = stockPrefab.GetComponent<stock>().EPSnow;
			minEPSGrowth = stockPrefab.GetComponent<stock>().EPSGrowthMin;
			maxEPSGrowth = stockPrefab.GetComponent<stock>().EPSGrowthMax;

			dcf.DCFCalculation(discountRate, EPS, minEPSGrowth, period);
			valueDCFMin = Mathf.RoundToInt(dcf.valueDCF);

			dcf.DCFCalculation(discountRate, EPS, maxEPSGrowth, period);
			valueDCFMax = Mathf.RoundToInt(dcf.valueDCF);
		}

	}

	public float HistoricRevenueGrowth(incomeStatement stockPrefab, int numberOfYearsForCalc)
	{
		//Intäkter
		float revenueToday = stockPrefab.getRevenue()[(stockPrefab.getRevenue().Count-1)];
		//Debug.Log("Intäkter idag: " + revenueToday);

		float revenueHistory = stockPrefab.getRevenue()[(stockPrefab.getRevenue().Count - numberOfYearsForCalc-1)];
		//Debug.Log("Intäkter historik: " + revenueHistory);
		//float revenueGrowth = StockMarketGO.GetComponent<stockMarketInventory>().masterList[0].GetComponent<incomeStatement>().getRevenue();

		float powerOf = 1 / (float)numberOfYearsForCalc; //Vad beräkningen ska höja upp med för att få tillväxttakt/år
		//Debug.Log("Power of: " + powerOf);
		float revenueGrowthRate = Mathf.Pow((revenueToday / revenueHistory),powerOf);

		return revenueGrowthRate;
	}

	public int DCFbasedPrice_HistoricRevenueGrowth(incomeStatement stockPrefab)
	{
		float revenueToday = stockPrefab.getRevenue()[stockPrefab.getRevenue().Count - 1];

		dcf.DCFCalculation(discountRate + Random.Range(0, discountRateVolatility), revenueToday, HistoricRevenueGrowth(stockPrefab, numberOfYears_RevenueGrowth), period);
		valueDCFMin = Mathf.RoundToInt(dcf.valueDCF);

		dcf.DCFCalculation(discountRate + Random.Range(-discountRateVolatility, 0), revenueToday, HistoricRevenueGrowth(stockPrefab, numberOfYears_RevenueGrowth), period);
		valueDCFMax = Mathf.RoundToInt(dcf.valueDCF);
		//Debug.Log("DCF min: " + valueDCFMin);

		return Mathf.RoundToInt(Random.Range(valueDCFMin, valueDCFMax));
	}

	public float DCFbasedPrice_OneCompany_IncomeStatement(incomeStatement IncomeStatement)
	{


		EPS = 1;	
		EPS = IncomeStatement.EarningPerShareHistory[IncomeStatement.EarningPerShareHistory.Count-1];
			//Debug.Log("EPS: " + EPS);
			minEPSGrowth = minEPSGrowth_Industri;
			maxEPSGrowth = maxEPSGrowth_Industri;

		//Debug.Log("EPS growth min: " + minEPSGrowth_Industri);
		//Debug.Log("EPS growth max: " + maxEPSGrowth_Industri);

		dcf.DCFCalculation(discountRate, EPS, minEPSGrowth, period);
			valueDCFMin = Mathf.RoundToInt(dcf.valueDCF);
		//Debug.Log("Value DCF min: " + valueDCFMin);

			dcf.DCFCalculation(discountRate, EPS, maxEPSGrowth, period);
			valueDCFMax = Mathf.RoundToInt(dcf.valueDCF);
		//Debug.Log("Value DCF max: " + valueDCFMax);

		return Mathf.RoundToInt(Random.Range(valueDCFMin, valueDCFMax));
	}

	public void showInfoStock ()
	{
		/*
		utiPriceText.text = "Price: " + utiStockPriceNow;
		finPriceText.text = "Price: " + finStockPriceNow;
		techPriceText.text = "Price: " + techStockPriceNow;
		*/
	}

	public void changePriceStockTest()
	{
		//DCFbasedPrice_HistoricRevenueGrowth(StockMarketGO.GetComponent<stockMarketInventory>().masterList[0].GetComponent<incomeStatement>().getRevenue()[(StockMarketGO.GetComponent<stockMarketInventory>().masterList[0].GetComponent<incomeStatement>().getRevenue().Count - 1)]);
	}
}


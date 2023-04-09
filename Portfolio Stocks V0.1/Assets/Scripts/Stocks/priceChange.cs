using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class priceChange : MonoBehaviour
{
	public GameObject StockMarketGO;
	public stockMarketManager StockMarketManager;

	//public stockMarketInventory ChooseStockPanel;

	//Info från bolag
	public float minEPSGrowth;
	public float maxEPSGrowth;
	public float EPSnow;
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

	//Steg 3.1.1
	public materialsInfoStock MaterialsInfoStock;
	public int amountTechCompanies;

	//Steg 3.1
	public float discountRate; //Ska ha formen 0.01 = 1 %. Borde ändars i något övergripande script kring marknadsförhållande
	public float discountRateVolatility; //Hur mycket diskonteringsräntan kan ändras
	public int period;

	public techInfoStock TechInfoStock;
	public utilitiesInfoStock UtilitiesInfoStock;
	public DCF dcf;
	public PECalculation pECalculation;

	public int amountUtiCompanies;
	public float[] priceNowUti; //Priserna för företagen inom Uti nu
	public float[] priceUtiCompBefore;
	public float[] priceUtiCompAfter;
	public float[] utiCompEPS;
	public float EPS;

	public float[] priceNowTech; //Priserna för företagen inom Tech nu

	public float[] priceNowMaterial; //Priserna för företagen inom Material nu



	public float[] valueDCFMinTech;
	public float[] valueDCFMaxTech;

	public float[] valueDCFMinUti;
	public float[] valueDCFMaxUti;

	public float[] valueDCFMinMaterial;
	public float[] valueDCFMaxMaterial;

	public float priceUtiCompOneBefore;
	public float priceUtiCompOneAfter;

	public float priceUtiCompTwoBefore;
	public float priceUtiCompTwoAfter;



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

	//Text
	public Text utiPriceText;
	public Text finPriceText;
	public Text techPriceText;

	public Text EPSchangeThisTurnTest;


	//Steg 1
	public int ecoClimate;

	public float STEP1utiPriceEarning; // Fasta P/E-talet för sektorn
									   //public float utiDivNow;

	public float STEP1finPriceEarning;
	//public float finDivNow;

	public float STEP1techPriceEarning;
	public float techDivNow;

	//STEP 2
	//public float utiEPSNow;
	public float finEPSNow;
	public float techEPSNow;

	//public List<float> utiEPSNow = new List<float> ();

	//public List<float> priceUtiComp = new List<float> ();


	void Awake()
	{
		/*
		TechInfoStock = GetComponent<techInfoStock> ();
		UtilitiesInfoStock = GetComponent<utilitiesInfoStock> ();
		MaterialsInfoStock = GetComponent<materialsInfoStock> ();
		*/

		dcf = GetComponent<DCF>();

	}

	void Start() {

		StockMarketManager = StockMarketGO.GetComponent<stockMarketManager>();

		//DCFbasedPriceTest ();

		//changePriceStock ();

		//STEP1utiPriceEarning = MainCanvasGO.GetComponent<infoStockSector> ().STEP1utiPE;

		//UtilitiesInfoStock.companyOnePriceHist.Add (UtilitiesInfoStock.EPS [0] * STEP1utiPriceEarning);
		//UtilitiesInfoStock.companyTwoPriceHist.Add (UtilitiesInfoStock.EPS [0] * STEP1utiPriceEarning);
		//Debug.Log("EPS: " + UtilitiesInfoStock.EPS[0]);
		//Debug.Log("Price before: " + priceUtiCompBefore[i]);
		//for (int i = 0; i < 3; i++){
		//priceUtiCompBefore [i] = UtilitiesInfoStock.EPS [i] * STEP1utiPriceEarning;

		//}
	}

	public float DCFbasedPriceTest(stock Stock)
	{

		/*for (int i = 0; i < StockMarketInventory.Stock.Count; i++) {
			minEPSGrowth = StockMarketInventory.Stock[i].EPSGrowthMin;
			maxEPSGrowth = StockMarketInventory.Stock[i].EPSGrowthMax;
			EPSnow = StockMarketInventory.Stock[i].EPSnow;
			*/
		/*for (int i = 0; i < StockList.Count; i++) {
			Debug.Log("Körningar DCF: ");
			Debug.Log("Discount Rate: " + discountRate);
			Debug.Log("EPSnow: " + StockList[i].EPSnow);
			*/

		//Debug.Log("Diskonteringsränta Volla: " + (discountRate + Random.Range(-discountRateVolatility, discountRateVolatility)));

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
		//StockMarketInventory.Stock[i].updatePriceNow();
	
	}

	public void changePriceStock(){

		//PRISMODELLER
		//oldPriceAddVolla ();
		amountPriceChange++;
		DCFbasedPrice();

	}

	//Priset baserar sig på gammalt pris + volla
	public void DCFbasedPrice()
	{
		//amountUtiCompanies = UtilitiesInfoStock.amountCompanies;
		//amountTechCompanies = TechInfoStock.amountCompanies;


		//DCF för varje bolag. Min och Max värde
		//Utilitites
		for (int i = 0; i < amountUtiCompanies; i++) {

			EPS = UtilitiesInfoStock.EPSNow [i];

			minEPSGrowth = UtilitiesInfoStock.utiCompanyMinEPSGrowth[i];
			maxEPSGrowth = UtilitiesInfoStock.utiCompanyMaxEPSGrowth[i];

			dcf.DCFCalculation (discountRate, EPS, minEPSGrowth, period);
			valueDCFMinUti[i] = Mathf.RoundToInt(dcf.valueDCF);

			dcf.DCFCalculation (discountRate, EPS, maxEPSGrowth, period);
			valueDCFMaxUti[i] = Mathf.RoundToInt(dcf.valueDCF);
		}

		//Technology
		for (int i = 0; i < amountTechCompanies; i++) {
			
			EPS = TechInfoStock.EPSNow [i];

			minEPSGrowth = TechInfoStock.CompanyMinEPSGrowth[i];
			maxEPSGrowth = TechInfoStock.CompanyMaxEPSGrowth[i];

			dcf.DCFCalculation (discountRate, EPS, minEPSGrowth, period);
			valueDCFMinTech[i] = Mathf.RoundToInt(dcf.valueDCF);

			dcf.DCFCalculation (discountRate, EPS, maxEPSGrowth, period);
			valueDCFMaxTech[i] = Mathf.RoundToInt(dcf.valueDCF);
		}


		//Materials
		for (int i = 0; i < 3; i++) {

			EPS = MaterialsInfoStock.EPSNow [i];
			minEPSGrowth = MaterialsInfoStock.CompanyMinEPSGrowth[i];
			maxEPSGrowth = MaterialsInfoStock.CompanyMaxEPSGrowth[i];

			dcf.DCFCalculation (discountRate, EPS, minEPSGrowth, period);
			valueDCFMinMaterial[i] = Mathf.RoundToInt(dcf.valueDCF);

			dcf.DCFCalculation (discountRate, EPS, maxEPSGrowth, period);
			valueDCFMaxMaterial[i] = Mathf.RoundToInt(dcf.valueDCF);

		}

		for (int i = 0; i < 3; i++) {

			if (i == 0) {

				priceNowUti[i] = Mathf.RoundToInt(Random.Range (valueDCFMinUti [i], valueDCFMaxUti [i]));
				priceNowTech [i] = Mathf.RoundToInt (Random.Range (valueDCFMinTech [i], valueDCFMaxTech [i]));
				priceNowMaterial [i] = Mathf.RoundToInt (Random.Range (valueDCFMinMaterial [i], valueDCFMaxMaterial [i]));
				//UtilitiesInfoStock.companyOnePriceHist.Add (Mathf.RoundToInt(Random.Range (valueDCFMinUti [i], valueDCFMaxUti [i])));
				UtilitiesInfoStock.companyOnePriceHist.Add (priceNowUti[i]);
				TechInfoStock.companyOnePriceHist.Add (priceNowTech [i]);
				MaterialsInfoStock.companyOnePriceHist.Add (priceNowMaterial[i]);
		
			}

			if (i == 1) {
				priceNowUti[i] = Mathf.RoundToInt(Random.Range (valueDCFMinUti [i], valueDCFMaxUti [i]));
				priceNowTech [i] = Mathf.RoundToInt (Random.Range (valueDCFMinTech [i], valueDCFMaxTech [i]));
				priceNowMaterial [i] = Mathf.RoundToInt (Random.Range (valueDCFMinMaterial [i], valueDCFMaxMaterial [i]));
				UtilitiesInfoStock.companyTwoPriceHist.Add (priceNowUti[i]);
				TechInfoStock.companyTwoPriceHist.Add (priceNowTech [i]);
				MaterialsInfoStock.companyTwoPriceHist.Add (priceNowMaterial [i]);
			}

			if (i == 2) {
				priceNowUti[i] = Mathf.RoundToInt(Random.Range (valueDCFMinUti [i], valueDCFMaxUti [i]));
				priceNowTech [i] = Mathf.RoundToInt (Random.Range (valueDCFMinTech [i], valueDCFMaxTech [i]));
				priceNowMaterial [i] = Mathf.RoundToInt (Random.Range (valueDCFMinMaterial [i], valueDCFMaxMaterial [i]));
				UtilitiesInfoStock.companyThreePriceHist.Add (priceNowUti[i]);
				TechInfoStock.companyThreePriceHist.Add (priceNowTech [i]);
				MaterialsInfoStock.companyThreePriceHist.Add (priceNowMaterial [i]);
			}
		}

	}

	public void oldPriceAddVolla()
	{

		for (int i = 0; i < 2; i++) {
			vollaUti [i] = Random.Range (-MainCanvasGO.GetComponent<infoStockSector> ().volatilityUti, MainCanvasGO.GetComponent<infoStockSector> ().volatilityUti);

		}

		utiCompEPS  [0] = UtilitiesInfoStock.EPSNow[0];

		priceUtiCompOneBefore = UtilitiesInfoStock.companyOnePriceHist[i];
		priceUtiCompOneAfter = priceUtiCompOneBefore*(1+vollaUti [0]);
		UtilitiesInfoStock.companyOnePriceHist.Add (priceUtiCompOneAfter);

		priceUtiCompTwoBefore = UtilitiesInfoStock.companyTwoPriceHist[i];
		priceUtiCompTwoAfter = priceUtiCompTwoBefore*(1+vollaUti [1]);
		UtilitiesInfoStock.companyTwoPriceHist.Add (priceUtiCompTwoAfter);

		i++;
	}

	public void showInfoStock ()
	{
		utiPriceText.text = "Price: " + utiStockPriceNow;
		finPriceText.text = "Price: " + finStockPriceNow;
		techPriceText.text = "Price: " + techStockPriceNow;
	}

	public void changePriceStockTest(){
		utiStockPriceNow = utiStockPriceNow + 1f;
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseTechCompany : MonoBehaviour
{
	public GameObject stockMarketGO;
	public GameObject playerScriptsGO;
	public GameObject stocksUiScriptsGO;
	public stockMarketManager StockMarketManager;

	public priceChange PriceChange;
	public portfolioStock PortfolioStock;

	public GameObject buttonsScriptsGO;
	public stocksUnlockInfo StocksUnlockInfo;

	public Text divYieldText;
	public Text divPayoutText;
	public Text divShareText;
	public Text divPolicyText;
	public Text priceText;

	public Text EPSText;
	public Text EPSGrowth;
	public Text PEtext;

	public Text GAVtext;

	public Text ownedStocks;

	private float divPayoutShare;

	public int activeCompany;
	public float activeCompanyPrice;
	public float divPayout;
	public float EPSnow;

	void Awake()
	{
		StockMarketManager = stockMarketGO.GetComponent<stockMarketManager>();
		PriceChange = GetComponent<priceChange> ();
		PortfolioStock = playerScriptsGO.GetComponent<portfolioStock>();
		StocksUnlockInfo = buttonsScriptsGO.GetComponent<stocksUnlockInfo> ();
	}

	public void companyNumber (int i)
	{
		activeCompany = i;

		divPayout = Mathf.Round(StockMarketManager.StockTechList[i].divPayout);
		activeCompanyPrice = StockMarketManager.StockTechList[i].StockPrice[StockMarketManager.StockTechList[i].StockPrice.Count - 1];

		divYieldText.text = "Div. yield: " + Mathf.Round(divPayout / activeCompanyPrice * 10000) / 100 + "%";

		divPayoutText.text = "Annual dividend: " + divPayout;

		EPSnow = StockMarketManager.StockTechList[i].EPSnow;
		divPayoutShare = divPayout / EPSnow;
		divShareText.text = "Div.Share: " + Mathf.Round(divPayoutShare * 100) + "%";

		//Info spelaren måste låsa upp
		if (StocksUnlockInfo.techDivPolicyUnlocked[i] == 1 && StockMarketManager.StockTechList[i].companyPaysDividend == true)
		{
			divPolicyText.text = "Maximum payout ratio: " + StockMarketManager.StockTechList[i].divPolicyMaxPayouRatio + "% and aims to increase the dividend with " + StockMarketManager.StockTechList[i].divPolicyChangeDiv + "% per year.";
			//return;
			Debug.Log("Unlock Div");
		}

		if (StocksUnlockInfo.techDivPolicyUnlocked[i] == 1 && StockMarketManager.StockTechList[i].companyPaysDividend == false)
		{
			divPolicyText.text = "Focus on growth and will not pay a dividend";
			//return;
		}

		if (StocksUnlockInfo.techDivPolicyUnlocked[i] == 0)
		{
			//Debug.Log("Unlock Div NO");
			divPolicyText.text = "Div.Policy: LOCKED. Cost (Time Points): " + StocksUnlockInfo.divPolicyUnlockCost;
		}

		EPSText.text = "EPS: " + EPSnow;
		PEtext.text = "P/E: " + Mathf.Round((activeCompanyPrice / EPSnow) * 10) / 10;

		//Info spelaren måste låsa upp
		if (StocksUnlockInfo.techEPSGrowthUnlocked[i] == 1)
		{
			Debug.Log("EPS unlock Tech");
			EPSGrowth.text = "EPS Growth: " + StockMarketManager.StockTechList[i].EPSGrowthMin + " to " + StockMarketManager.StockTechList[i].EPSGrowthMax + "%/year";
		}
		else
		{
			EPSGrowth.text = "EPS Growth: LOCKED. Cost (Time Points): " + StocksUnlockInfo.epsGrowthUnlockCost;
		}

		GAVtext.text = "GAV: " + Mathf.Round(PortfolioStock.techGAV[i] * 10) / 10;

		ownedStocks.text = "Owned: " + PortfolioStock.techCompanySharesOwned[i];

		priceText.text = "Price: " + activeCompanyPrice;

		//Historisk data
		stocksUiScriptsGO.GetComponent<ShowHistoricData>().updateAllHistoricData(StockMarketManager.StockTechList[i]);

		//Data spelaren känner till
		buttonsScriptsGO.GetComponent<dataPlayerKnowsButtonUnlock>().chooseStock(StockMarketManager.StockTechList[i]);

	}

	public void companyOne()
	{
		companyNumber(0);
	}

	public void companyTwo()
	{
		companyNumber(1);
	}

	public void companyThree()
	{
		companyNumber(2);
	}

}

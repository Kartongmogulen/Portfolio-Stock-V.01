using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseUtiCompany : MonoBehaviour
{
	public GameObject stockMarketGO;
	public GameObject playerScriptsGO;
	public stockMarketManager StockMarketManager;

	public priceChange PriceChange;
	public portfolioStock PortfolioStock;

	public GameObject buttonsScriptsGO;
	public stocksUnlockInfo StocksUnlockInfo;

	public Text divYieldText;
	public Text divPayoutText;
	public Text divUtiShareText;
	public Text divPolicyText;
	public Text priceText;

	public Text EPSText;
	public Text EPSGrowth;
	public Text PEtext;

	public Text GAVtext;

	public Text ownedStocks;

	public int activeCompany;
	public float activeCompanyPrice;

	private float divPayoutShare;

	void Awake()
	{

		StockMarketManager = stockMarketGO.GetComponent<stockMarketManager>();

		//UtilitiesInfoStock = GetComponent<utilitiesInfoStock> ();
		PriceChange = GetComponent<priceChange> ();
		PortfolioStock = playerScriptsGO.GetComponent<portfolioStock> ();
		StocksUnlockInfo = buttonsScriptsGO.GetComponent<stocksUnlockInfo> ();
	}

	public void companyNumber (int i)
	{
		activeCompany = i;
		
		divYieldText.text = "Div. yield: " + Mathf.Round(StockMarketManager.StockUtiList[i].divPayout / StockMarketManager.StockUtiList[i].StockPrice[StockMarketManager.StockUtiList[i].StockPrice.Count-1] * 10000)/100 + "%";

		divPayoutText.text = "Annual dividend: " + StockMarketManager.StockUtiList[i].divPayout;
		divPayoutShare = StockMarketManager.StockUtiList[i].divPayout/ StockMarketManager.StockUtiList[i].EPSnow;

		divUtiShareText.text = "Div.Share: " + Mathf.Round(divPayoutShare*100) + "%";

		//Info spelaren måste låsa upp
		if (StocksUnlockInfo.utiDivPolicyUnlocked [i] == 1) {
			divPolicyText.text = "Maximum payout ratio: " + StockMarketManager.StockUtiList[i].divPolicyMaxPayouRatio + "% and aims to increase the dividend with " + StockMarketManager.StockUtiList[i].divPolicyChangeDiv + "% per year.";
		} else {
			divPolicyText.text = "Div.Policy: LOCKED. Cost (Time Points): " + StocksUnlockInfo.divPolicyUnlockCost;
		}

		EPSText.text = "EPS: " + Mathf.Round(StockMarketManager.StockUtiList[i].EPSnow * 100)/100;
		PEtext.text = "P/E: " + Mathf.Round((activeCompanyPrice / StockMarketManager.StockUtiList[i].EPSnow) * 10) / 10;

		//Info spelaren måste låsa upp
		if (StocksUnlockInfo.utiEPSGrowthUnlocked [i] == 1) {
			EPSGrowth.text = "EPS Growth: " + StockMarketManager.StockUtiList[i].EPSGrowthMin + " to " + StockMarketManager.StockUtiList[i].EPSGrowthMax + "%/year";
		} else {
			EPSGrowth.text = "EPS Growth: LOCKED. Cost (Time Points): " + StocksUnlockInfo.epsGrowthUnlockCost;
		}

		GAVtext.text = "GAV: " +  Mathf.Round(PortfolioStock.utiGAV [i]*10)/10;

		ownedStocks.text = "Owned: " + PortfolioStock.utiCompanySharesOwned [i];

		activeCompanyPrice = StockMarketManager.StockUtiList[i].StockPrice[StockMarketManager.StockUtiList[i].StockPrice.Count - 1];
		priceText.text = "Price: " + activeCompanyPrice;

		
	}

	public void companyOne()
	{
		companyNumber (0);
	}

	public void companyTwo()
	{
		companyNumber (1);
	}

	public void companyThree()
	{
		companyNumber (2);
	}

}

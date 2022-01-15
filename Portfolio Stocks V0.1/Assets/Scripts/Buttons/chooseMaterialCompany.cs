using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseMaterialCompany : MonoBehaviour
{

	public materialsInfoStock MaterialsInfoStock;
	public priceChange PriceChange;
	public portfolioStock PortfolioStock;

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

	[SerializeField] 
	private float divPayoutShare;

	public int activeCompany;
	public float activeCompanyPrice;

	void Awake()
	{
		MaterialsInfoStock = GetComponent<materialsInfoStock> ();
		PriceChange = GetComponent<priceChange> ();
		PortfolioStock = GetComponent<portfolioStock> ();
	}

	public void companyNumber (int i)
	{
		activeCompany = i;
		divPayoutText.text = "Annual dividend: " + Mathf.Round(MaterialsInfoStock.divPayout [i]*100)/100;

		divPayoutShare = MaterialsInfoStock.divPayoutShare[i];

		divShareText.text = "Div.Share: " + Mathf.Round(divPayoutShare*100) + "%";

		divPolicyText.text = "Maximum payout ratio: " + MaterialsInfoStock.dividendMaxPayout [i] + "% and aims to increase the dividend with " + MaterialsInfoStock.dividendPayoutIncrease[i] + "% per year.";
		EPSText.text = "EPS: " + MaterialsInfoStock.EPSNow [i];

		EPSGrowth.text = "EPS Growth: " + MaterialsInfoStock.CompanyMinEPSGrowth [i] + " to " + MaterialsInfoStock.CompanyMaxEPSGrowth [i] + "%/year";

		GAVtext.text = "GAV: " + Mathf.Round(PortfolioStock.materialsGAV [i]*10)/10;

		ownedStocks.text = "Owned: " + PortfolioStock.materialsCompanySharesOwned [i];

	}

	public void companyOne()
	{
		
		companyNumber (0);

		priceText.text = "Price: " + MaterialsInfoStock.companyOnePriceHist[PriceChange.amountPriceChange];
		divYieldText.text = "Div. yield: " + Mathf.Round(MaterialsInfoStock.divPayout[0]/MaterialsInfoStock.companyOnePriceHist[PriceChange.amountPriceChange]*10000)/100 + "%";
		PEtext.text = "P/E: " + Mathf.Round((MaterialsInfoStock.companyOnePriceHist[PriceChange.amountPriceChange]/MaterialsInfoStock.EPSNow [0])*100)/100;

		activeCompanyPrice = MaterialsInfoStock.companyOnePriceHist[PriceChange.amountPriceChange];
	}

	public void companyTwo()
	{
		companyNumber (1);

		priceText.text = "Price: " + MaterialsInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange];
		Debug.Log ("Mat 2");
		divYieldText.text = "Div. yield: " + Mathf.Round(MaterialsInfoStock.divPayout[1]/MaterialsInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange]*10000)/100 + "%";
		PEtext.text = "P/E: " + Mathf.Round((MaterialsInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange]/MaterialsInfoStock.EPSNow [1])*100)/100;

		activeCompanyPrice = MaterialsInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange];
	}
}

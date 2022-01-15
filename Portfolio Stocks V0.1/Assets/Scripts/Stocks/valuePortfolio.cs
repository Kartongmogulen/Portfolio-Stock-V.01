using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valuePortfolio : MonoBehaviour
{
	public float totalValueSector;
	public List<stock> stockList;

	public float valueSector(List<float> companySharesOwned, List<stock> stockList)
	{
		for (int i = 0; i < companySharesOwned.Count; i++)
		{
			totalValueSector += stockList[i].StockPrice[stockList[i].StockPrice.Count-1] * companySharesOwned[i];
		}

		//valuePortfolioText.text = "Value: " + totalValuePortfolio;

		//utiGAV = stockScriptsGO.GetComponent<GAV>().stockListCalculation(utiCompanySharesOwned, utiTotalInvest);

		return totalValueSector;
	}
}

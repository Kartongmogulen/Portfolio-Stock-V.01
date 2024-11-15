using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stockSpecificCompany100 : MonoBehaviour
{
	public GameObject playerPanelGO;
	float startMoney;
	float incomeFromWork;
	float moneyNow;
	//public int companyIndex;

	public GameObject StockScriptGO;
	public stockMarketInventory StockMarketInventory;
	float priceStock;

	float amountToInvestThisRound;
	//public float valueIndexPortfolio;
	float newSharesThisRound;
	public float totalSharesPortfolio;
	public List<float> totalValuePortfolio;
	public float totalInvestment;
	public List<float> returnOnInvestment;
	public List<float> dividendsRecieved;
	public float totalDividendsRecieved;

	//public Text strategyName;
	//public Text valuePortfolioText;
	//public Text returnPortfolioText;

	int i;

	void Start()
	{

		//strategyName.text = "Index: 100%";

		startMoney = playerPanelGO.GetComponent<moneyManager> ().MoneyNow;
		incomeFromWork = playerPanelGO.GetComponent<incomeWork>().incomeWorkPerMonth; //Hämtar inkomst
		moneyNow = startMoney; //Hur mycket pengar spelaren har vid start
		//investCompany();
	}

	public void investCompany(int companyIndex)
	{
		
		priceStock = StockMarketInventory.Stock[companyIndex].StockPrice[i];
		newSharesThisRound = Mathf.FloorToInt(moneyNow / priceStock); //Antal aktier som kan köpas
		totalSharesPortfolio += newSharesThisRound; // Adderar antalet aktier till "portföljen"

		amountToInvestThisRound = newSharesThisRound * priceStock; //Hur mycket som investeras under rundan
		totalInvestment += amountToInvestThisRound;
		moneyNow = moneyNow - amountToInvestThisRound; //Värdet av köpta aktier subtraheras
		moneyNow = moneyNow + incomeFromWork;

		totalValuePortfolio.Add(totalSharesPortfolio * priceStock);
		//returnOnInvestment.Add((totalSharesPortfolio * priceStock) / totalInvestment-1);
		returnOnInvestment.Add(Mathf.Round((totalValuePortfolio[i] / totalInvestment - 1) * 10000) / 100);
		i++;

		totalDividendsrecieved();
	}

	public void recieveDividens(int companyIndex)
	{
		dividendsRecieved.Add(totalSharesPortfolio * StockMarketInventory.Stock[companyIndex].lastDivPayout);
		//Debug.Log("Pengar INNAN Utdelning: " + moneyNow);
		moneyNow += dividendsRecieved[dividendsRecieved.Count-1];
		//Debug.Log("Pengar EFTER Utdelning: " + moneyNow);
	}

	public float totalDividendsrecieved()
	{
		totalDividendsRecieved = 0; //Nollställer
		//int result = 0;
		foreach (float itm in dividendsRecieved)
		{
			totalDividendsRecieved += itm;
		}

		return totalDividendsRecieved;
	}
}

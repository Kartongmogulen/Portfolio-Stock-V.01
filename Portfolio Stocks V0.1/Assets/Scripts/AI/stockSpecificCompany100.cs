using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stockSpecificCompany100 : MonoBehaviour
{
	public GameObject playerPanelGO;
	public float startMoney;
	public float incomeFromWork;
	public float moneyNow;
	public int companyIndex;

	public GameObject StockScriptGO;
	public stockMarketInventory StockMarketInventory;
	public float priceStock;

	public float amountToInvestThisRound;
	//public float valueIndexPortfolio;
	public float newSharesThisRound;
	public float totalSharesPortfolio;
	public List<float> totalValuePortfolio;
	public float totalInvestment;

	//public Text strategyName;
	//public Text valuePortfolioText;
	//public Text returnPortfolioText;

	int i;

	void Start()
	{

		//strategyName.text = "Index: 100%";

		startMoney = playerPanelGO.GetComponent<totalCash> ().moneyStart;
		incomeFromWork = playerPanelGO.GetComponent<incomeWork>().incomeWorkPerMonth; //Hämtar inkomst
		moneyNow = startMoney; //Hur mycket pengar spelaren har vid start
		//investCompany();
	}

	public void investCompany()
	{
		
		priceStock = StockMarketInventory.Stock[companyIndex].StockPrice[i];
		newSharesThisRound = Mathf.FloorToInt(moneyNow / priceStock); //Antal aktier som kan köpas
		totalSharesPortfolio += newSharesThisRound; // Adderar antalet aktier till "portföljen"

		amountToInvestThisRound = newSharesThisRound * priceStock; //Hur mycket som investeras under rundan
		totalInvestment += amountToInvestThisRound;
		moneyNow = moneyNow - amountToInvestThisRound; //Värdet av köpta aktier subtraheras
		moneyNow = moneyNow + incomeFromWork;

		totalValuePortfolio.Add(totalSharesPortfolio * priceStock);

		i++;
	}
}

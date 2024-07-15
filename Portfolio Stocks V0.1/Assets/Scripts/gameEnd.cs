using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameEnd : MonoBehaviour
{
	public GameObject playerGO;
	public GameObject playerScriptsGO;
	public GameObject calcutaionToolsScriptsGO;

	public HighscoreManager highscoreManager;
	public totalCash TotalCash;

	public GameObject MainCanvasGO;
	public GameObject endGamePanel;
	public GameObject PlayerPanelGO;
	public GameObject EconomyScriptsGO;
	//public GameObject SectorPanelGO;
	public GameObject bottomPanelGO;
	public GameObject realEstatePanelGO;
	public GameObject bondsPanelGO;

	public Text textEndGame;
	public Text incomeWorkText;
	public Text incomeDivText;
	public Text incomeDivPerYear;
	public Text assetsValueText;
	public Text incomeBondsLifetimeText;
	public Text capGainStockText;
	public Text sharpeRatioText;
	public Text totalReturnAssets;
	public Text playerReturnVsIndexText;
	public Text playerReturnVsBestStockText;

	public float incomeDuringLifeWork;
	public float incomeDuringLifeDividend;
	public float incomeDividendRestOfLifePerYear;

	public float utiAmount;
	public float finAmount;
	public float techAmount;

	public float utiDiv;
	public float finDiv;
	public float techDiv;

	public float divPerYear;

	public float incomeBondsLifetime;

	public float incomeRentLifetime;

	[SerializeField] float wealthValue;
	public float assetsValue;
	public float stockPortfolioValue;
	public float bondPortfolioValue;
	public float realestateValue;
	public float capGainStockAmount;
	public float capGainStockPercent;
	public float totBusinessValue;

	public float stocksInvestmentTotAmount;
	public float bondsInvestmentTotAmount;
	public float realEstateInvestmentTotAmount;
	public float businessInvestmentTotAmount;
	public float totalInvestAssets;

	public void endOfGame()
    {
		//Income
		incomeDuringLifeWork = playerGO.GetComponent<incomeWork>().totalIncomeFromWork;
		incomeDuringLifeDividend = playerGO.GetComponent<incomeDividends>().totalIncome;

		divPerYear = playerGO.GetComponent<incomeDividends>().incomeDividendPreviousYear;

		//Value assets
		//playerScriptsGO.GetComponent<portfolioStock>().showPortfolioData();

		playerScriptsGO.GetComponent<portfolioStock>().showPortfolioData_1850();

		stockPortfolioValue = playerScriptsGO.GetComponent<portfolioStock>().totalValuePortfolio;
		//bondPortfolioValue = PlayerPanelGO.GetComponent<bondsPortfolio>().totalValueBonds;
		//realEstatePanelGO.GetComponent<buyRealEstate>().valueRealEstate();
		//realestateValue = realEstatePanelGO.GetComponent<buyRealEstate>().valueRE;
		//totBusinessValue  = PlayerPanelGO.GetComponent<ownedBusiness>().totValueBusiness;
			
		assetsValue = stockPortfolioValue+bondPortfolioValue+realestateValue+totBusinessValue;

		//Update text
		endGamePanel.SetActive (true);
		realEstatePanelGO.SetActive (false);
		bondsPanelGO.SetActive (false);
		//SectorPanelGO.SetActive (false);

		//totalReturn ();

		//playerScriptsGO.GetComponent<portfolioStock>().returnPortfolio();
		playerScriptsGO.GetComponent<portfolioStock>().returnFromSector_1850();
		//capGainStockAmount = playerScriptsGO.GetComponent<portfolioStock>().totalReturnPortfolioAmount;
		//capGainStockPercent = playerScriptsGO.GetComponent<portfolioStock>().totalReturnPortfolioPercent;

		textEndGame.text = "The end!";
		incomeWorkText.text = "Income from Work: " + incomeDuringLifeWork;
		incomeDivText.text = "Income from Dividends: " + incomeDuringLifeDividend;
		assetsValueText.text = "Assets value: " + assetsValue;
		incomeBondsLifetimeText.text = "Bonds income: " + incomeBondsLifetime;
		incomeDivPerYear.text = "Income/year to live from: " + divPerYear;
		capGainStockText.text = "Capital Gain from Stocks: " + capGainStockAmount + "(" + Mathf.Round(capGainStockPercent*10000)/100 + "%)";
		sharpeRatioText.text = "Sharpe Ratio Portfolio: " + calcutaionToolsScriptsGO.GetComponent<sharpeKvotPortfolio>().getSharpeRatio();
		totalReturnAssets.text = "Total Return Assets: " + Mathf.Round((assetsValue / totalInvestAssets-1)*100) + " %";
		playerReturnVsIndexText.text = "Players return (%): " + Mathf.Round(capGainStockPercent * 10000) / 100 + " Vs Index (%): " + (EconomyScriptsGO.GetComponent<economicClimate>().totalBNPlist[EconomyScriptsGO.GetComponent<economicClimate>().totalBNPlist.Count-1]-100);
		//playerReturnVsBestStockText.text = "Players return (%): " + Mathf.Round(capGainStockPercent * 10000) / 100 + " Vs Best stock (%): " + Mathf.Round(playerScriptsGO.GetComponent<compareStockReturn>().highestReturn() * 10000) / 10000;

		saveHighScore();
		highscoreManager.endGame();
	}

	public void saveHighScore()
	{
		stockPortfolioValue = playerScriptsGO.GetComponent<portfolioStock>().totalValuePortfolio;
		wealthValue = stockPortfolioValue + TotalCash.moneyNow;
		//assetsValue = 5000;
		//SPARA RESULTAT
		highscoreManager.AddHighscore(Mathf.RoundToInt(wealthValue));
	}

	//Total return for the player. (Return / Invested capital)
	public void totalReturn(){

		//PlayerPanelGO.GetComponent<portfolio> ().totalInvestedStock ();
		//PlayerPanelGO.GetComponent<portfolio>().totalReturnStock ();

		//Return (Dividend + Interest + Rent + Capital gains)
		//incomeDuringLifeDividend = PlayerPanelGO.GetComponent<totalCash>().incomeTotDivNow;
		//incomeBondsLifetime = PlayerPanelGO.GetComponent<totalCash>().incomeBondsLifetime;
		//incomeRentLifetime = PlayerPanelGO.GetComponent<totalCash> ().incomeRealEstateLifetime;
		//capGainStockAmount = PlayerPanelGO.GetComponent<portfolio>().totalReturnAmountStocks;
		

		//Invested capital (Stocks + Bonds + Real Estate + Business)
		//stocksInvestmentTotAmount = PlayerPanelGO.GetComponent<portfolio>().totalStockInvestment;
		bondsInvestmentTotAmount = PlayerPanelGO.GetComponent<bondsPortfolio>().totalBondsInvest;
		realEstateInvestmentTotAmount = PlayerPanelGO.GetComponent<realEstatePortfolio>().totInvestRealEstate;
		businessInvestmentTotAmount = PlayerPanelGO.GetComponent<ownedBusiness>().totalInvestAmount;

		totalInvestAssets = stocksInvestmentTotAmount + bondsInvestmentTotAmount + realEstateInvestmentTotAmount + businessInvestmentTotAmount;
	
	}

}

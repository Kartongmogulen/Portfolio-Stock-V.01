using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Scriptet uppdaterar tiden då spelaren beslutar sig för att rundan är över

public class endRoundButton : MonoBehaviour
{
	/*
	public Text DateNowText;
	public int year;
	public int month;
	*/
	[Tooltip("Antal månader som ska simuleras vid varje aktivering")]
	public int multiMonthSim;

	public GameObject playerScriptsGO;
	public GameObject managerScriptsGO;
	//public GameObject playerGO;

	public int timePoints; //Research/Time poäng.

	public GameObject MainCanvas; //Object where the main scripts are
	public GameObject visualisationScriptsGO;
	public GameObject stockMarketGO;
	public GameObject PanelSectorGO;
	public GameObject playerPanelGO;
	public GameObject bottomPanelGO;
	public GameObject debugPanelGO;
	public GameObject DataPointsGO;
	public GameObject StockScriptGO;
	public GameObject EconomyScriptGO;
	public GameObject PlayerScriptsGO;//Step 3.1.1
	public GameObject PlayerPerformanceUIScriptsGO;

	public sendMoneyHome SendMoneyHome;
	public timeManager TimeManager;

	public int globalEcoClimate;

	public float incomeFromWork;

	public int yearsBeforeEndGame;

	// SIMULERING 12 MÅNADER
	public bool stop12MonthSim= false;
	public int countMultiMonthSim;

	void Start(){
		//month = 1;
		//DateNowText.text = "Y: " + year + " M: " + month;
		//timePointsLeftText.GetComponent<Text>().enabled = false;
		InitializeDependencies();
		yearsBeforeEndGame = managerScriptsGO.GetComponent<gamePlayScopeManager>().yearsBeforeEndGameMaster;

		/*
		bottomPanelGO.GetComponent<busIncomeStatement>().revenueUpdateValue();
		bottomPanelGO.GetComponent<busIncomeStatement>().costOfRevUpdateValue();
		bottomPanelGO.GetComponent<busIncomeStatement>().grossMarginUpdateValue();
		bottomPanelGO.GetComponent<busIncomeStatement>().incomeStateUpdate();
		*/
	}

	private void InitializeDependencies()
	{
		/*
		 * _stockMarketManager = GetComponent<IStockMarketManager>();
		_timeManager = GetComponent<ITimeManager>();
		_portfolioManager = GetComponent<IPortfolioManager>();
		_gameEndManager = GetComponent<IGameEndManager>();
		_actionPointsManager = GetComponent<IActionPointsManager>();
		_eventManager = GetComponent<IEventManager>();
		_playerIncomeManager = GetComponent<IPlayerIncomeManager>();
		_debugManager = GetComponent<IDebugManager>();
		*/
	}

	public void endTurn_Fisher()
	{
		/*
		month++;//Add 1 to the month;
		DateNowText.text = "Y: " + year + " M: " + month;

		if (month > 12)
		{
			year++;
			month = 1;
			DateNowText.text = "Y: " + year + " M: " + month;
		}
		*/
	}

	public void endTurn() //Uppdaterar tid samt texten för vilken aktuell tid det är
	{
		//Aktier
		managerScriptsGO.GetComponent<stockPriceManager>().updateStockMarketPrice();
		StockScriptGO.GetComponent<trailing12MonthHighLowCalculation>().updateDataForStocks_StockComponent(stockMarketGO.GetComponent<stockMarketManager_1850>().StockMarketListGO);
		//StockScriptGO.GetComponent<priceChange>().changePriceStock(); //Uppdaterar pris för aktier
		//StockScriptGO.GetComponent<indexFunds> ().updateIndex (); //GÅ IGENOM DÅ INDEX LÄGGS TILL
		//StockScriptGO.GetComponent<PEG>().calculatePEG();
		//MainCanvas.GetComponent<infoStockSector>().histPriceSector(); //Spara historiska priser
		//DataPointsGO.GetComponent<windowGraph>().CreateGraph ();
		
		//Företag
		//playerPanelGO.GetComponent<ownedBusiness>().playerCashflow();

		//Pengar
		//playerPanelGO.GetComponent<totalCash>().cashflowFromBusiness();
		//playerScriptsGO.GetComponent<totalCash>().incomeWork();
		//Debug.Log("End Round Button Månad: " + month);

		//Portfölj
		//playerPanelGO.GetComponent<portfolio>().updatePortfolio(); //Uppdaterar utd för portföljen
		playerScriptsGO.GetComponent<portfolioStock>().valuePortfolio();
		//playerScriptsGO.GetComponent<portfolioStock>().showPortfolioData();
		//StockScriptGO.GetComponent<portfolioStock> ().returnPortfolio(); //Avkastning på portföljen
		
		//Utdelning
		//playerScriptsGO.GetComponent<incomeDividends>().incomeDivFromPortfolioNow(); //HANTERAS I ANNAT SCRIPT
		
		//Spelaren
		managerScriptsGO.GetComponent<actionPointsManager>().endRound();
		//playerScriptsGO.GetComponent<portfolioStock>().returnPortfolio();
		
		//Debug/Övriga spelare
		//debugPanelGO.GetComponent<Bonds100> ().investBonds ();
		debugPanelGO.GetComponent<Index100> ().investIndex ();


		//MainCanvas.GetComponent<news>().randomNews(); //NYHETER
		
		

		if (TimeManager.month ==	1) {

			HandleYearEnd();
			

			//Intäkter
			if(playerScriptsGO.GetComponentInChildren<incomeProduction>() != null)
			playerScriptsGO.GetComponentInChildren<incomeProduction>().incomeCalc();

			//UI
			PlayerPerformanceUIScriptsGO.GetComponent<endOfYearPerformanceUI>().activeEndOfYearPanel();

			/*
			MainCanvas.GetComponent<infoStockSector>().updateSectorRoundEnd();
			MainCanvas.GetComponent<infoStockSector>().histDiv ();
			MainCanvas.GetComponent<infoStockSector>().CAGR5year();
			MainCanvas.GetComponent<infoStockSector>().histEPS();
			bottomPanelGO.GetComponent<busIncomeStatement>().revenueUpdateValue();
			bottomPanelGO.GetComponent<busIncomeStatement>().costOfRevUpdateValue();
			bottomPanelGO.GetComponent<busIncomeStatement>().grossMarginUpdateValue();
			bottomPanelGO.GetComponent<busIncomeStatement>().incomeStateUpdate();
			playerPanelGO.GetComponent<ownedBusiness>().playerCashflow();
			*/
			StockScriptGO.GetComponent<yearsDivIncrease>().updateDivYearStreak();

			//debugPanelGO.GetComponent<Bonds100> ().dividendBonds ();
			debugPanelGO.GetComponent<endRoundButtonDebugg>().recieveDividends();
		
			//StockScriptGO.GetComponent<dividendRecieved> ().recievedDividends ();

			EconomyScriptGO.GetComponent<economicClimate> ().updateEcoClimate ();

			//Uppdaterar aktie-sektorer
			/*StockScriptGO.GetComponent<utilitiesInfoStock>().updateDataYearEnd();
			StockScriptGO.GetComponent<techInfoStock>().updateDataYearEnd();
			StockScriptGO.GetComponent<materialsInfoStock>().updateDataYearEnd();
			*/
			//playerPanelGO.GetComponent<incomeWork>().incomeLifeFromWork();

			/*
			if (TimeManager.year == yearsBeforeEndGame) //Vad som händer när spelet är slut
			{
				StartCoroutine(waitSoOtherScriptsCanFinish());
			}
			*/

			//Settler
			//Debug.Log("År: " + year);
			SendMoneyHome.timeForPlayerToSendMoney(TimeManager.year);

		}
		//playerPanelGO.GetComponent<totalCash>().incomeWork();
		//playerPanelGO.GetComponent<totalCash>().incomeRealEstate();
		managerScriptsGO.GetComponent<eventStockManager>().doesEventOccur(TimeManager.month);
	}

	public void HandleYearEnd()
	{
		StockScriptGO.GetComponent<companyNumbersUpdate>().updateYearEnd();
	}

	IEnumerator waitSoOtherScriptsCanFinish()
	{
		yield return new WaitForSeconds(0.25f);
		visualisationScriptsGO.GetComponent<gameEnd>().endOfGame();
	}

		public void endTurn12Mon() //Simulerar 12 månader i taget

	{
		
		stop12MonthSim = false;
		countMultiMonthSim = 0;

		while (stop12MonthSim == false){

			countMultiMonthSim++;
			endTurn(); //Kallar funktionen som körs varje gång man avslutar en runda
			debugPanelGO.GetComponent<endRoundButtonDebugg>().investInOnlyOneCompany();
			if (countMultiMonthSim == multiMonthSim)
			{
				stop12MonthSim = true;

			}

			if (countMultiMonthSim == 150){
				break;

			}


	}
		//playerPanelGO.GetComponent<portfolio>().updatePortfolio(); //Uppdaterar utd för portföljen
}

	/*public void timePointsLeft()//Om inte alla poäng (research/time) har använts.
	{
		timePoints = playerPanelGO.GetComponent<playerStats> ().RPleft;

		if (timePoints == 0) {
			endTurn ();
		}
			else 
			{

			timePointsLeftText.GetComponent<Text>().enabled = true;
				timePointsLeftText.text = "Time point left!";
			timePointsLeftText.GetComponent<Text> ().color = Color.red;

		}
	}
	*/
}
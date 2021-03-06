using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Scriptet uppdaterar tiden då spelaren beslutar sig för att rundan är över

public class endRoundButton : MonoBehaviour
{
	public Text DateNowText;
	public int year;
	public int month;

	public GameObject playerScriptsGO;
	public GameObject managerScriptsGO;
	public GameObject playerGO;

	public int timePoints; //Research/Time poäng.

	public GameObject MainCanvas; //Object where the main scripts are
	public GameObject stockMarketGO;
	public GameObject PanelSectorGO;
	public GameObject playerPanelGO;
	public GameObject bottomPanelGO;
	public GameObject debugPanelGO;
	public GameObject DataPointsGO;
	public GameObject StockScriptGO;
	public GameObject EconomyScriptGO;
	public GameObject PlayerScriptsGO;//Step 3.1.1

	public int globalEcoClimate;

	public float incomeFromWork;

	public int yearsBeforeEndGame;

	public Text timePointsLeftText;

	// SIMULERING 12 MÅNADER
	public bool stop12MonthSim= false;
	public int countMultiMonthSim;

	void Start(){
		month = 1;
		DateNowText.text = "Y: " + year + " M: " + month;
		timePointsLeftText.GetComponent<Text>().enabled = false;

		yearsBeforeEndGame = managerScriptsGO.GetComponent<gamePlayScopeManager>().yearsBeforeEndGameMaster;

		/*
		bottomPanelGO.GetComponent<busIncomeStatement>().revenueUpdateValue();
		bottomPanelGO.GetComponent<busIncomeStatement>().costOfRevUpdateValue();
		bottomPanelGO.GetComponent<busIncomeStatement>().grossMarginUpdateValue();
		bottomPanelGO.GetComponent<busIncomeStatement>().incomeStateUpdate();
		*/
	}

	public void endTurn() //Uppdaterar tid samt texten för vilken aktuell tid det är
	{
		timePointsLeftText.GetComponent<Text>().enabled = false;

		//month = month + 10;
		month++;//Add 1 to the month;
		DateNowText.text = "Y: " + year + " M: " + month;

		//Aktier
		managerScriptsGO.GetComponent<stockPriceManager>().updateStockMarketPrice();
		//StockScriptGO.GetComponent<priceChange>().changePriceStock(); //Uppdaterar pris för aktier
		//StockScriptGO.GetComponent<indexFunds> ().updateIndex (); //GÅ IGENOM DÅ INDEX LÄGGS TILL
		//StockScriptGO.GetComponent<PEG>().calculatePEG();
		//MainCanvas.GetComponent<infoStockSector>().histPriceSector(); //Spara historiska priser
		//DataPointsGO.GetComponent<windowGraph>().CreateGraph ();

		//Företag
		playerPanelGO.GetComponent<ownedBusiness>().playerCashflow();

		//Pengar
		//playerPanelGO.GetComponent<totalCash>().cashflowFromBusiness();
		playerGO.GetComponent<totalCash>().incomeWork();

		//Portfölj
		playerPanelGO.GetComponent<portfolio>().updatePortfolio(); //Uppdaterar utd för portföljen
																   //StockScriptGO.GetComponent<portfolioStock> ().returnPortfolio(); //Avkastning på portföljen

		//Spelaren
		managerScriptsGO.GetComponent<actionPointsManager>().endRound();

		//Debug/Övriga spelare
		debugPanelGO.GetComponent<Bonds100> ().investBonds ();
		debugPanelGO.GetComponent<Index100> ().investIndex ();

		//MainCanvas.GetComponent<news>().randomNews(); //NYHETER

		if (month > 11) {
			year++;
			month = 0;
			DateNowText.text = "Y: " + year + " M: " + month;

			//Utdelningar från föregående år innan värden uppdateras för bolagen
			StockScriptGO.GetComponent<dividendRecieved>().recievedDividends();
			playerGO.GetComponent<incomeDividends>().updateIncomeDividends();

			//playerPanelGO.GetComponent<totalCash>().incomeDividend();
			//playerPanelGO.GetComponent<totalCash>().incomeBonds();
			//globalEcoClimate = MainCanvas.GetComponent<globalEcoClimate>().globalEcoClimateValueNow;
			//MainCanvas.GetComponent<infoStockSector>().updateEarnings(globalEcoClimate); //Ändrar EPS för sektorn vid årets slut
			StockScriptGO.GetComponent<companyNumbersUpdate>().updateYearEnd();

			//Intäkter
			

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

			debugPanelGO.GetComponent<Bonds100> ().dividendBonds ();
		
			//StockScriptGO.GetComponent<dividendRecieved> ().recievedDividends ();

			EconomyScriptGO.GetComponent<EconomicClimate> ().updateEcoClimate ();

			//Uppdaterar aktie-sektorer
			/*StockScriptGO.GetComponent<utilitiesInfoStock>().updateDataYearEnd();
			StockScriptGO.GetComponent<techInfoStock>().updateDataYearEnd();
			StockScriptGO.GetComponent<materialsInfoStock>().updateDataYearEnd();
			*/
			//playerPanelGO.GetComponent<incomeWork>().incomeLifeFromWork();

			if (year == yearsBeforeEndGame) //Vad som händer när spelet är slut
			{
				MainCanvas.GetComponent<gameEnd>().endOfGame();
			}

		}
		//playerPanelGO.GetComponent<totalCash>().incomeWork();
		//playerPanelGO.GetComponent<totalCash>().incomeRealEstate();

	}

	public void endTurn12Mon() //Simulerar 12 månader i taget

	{
		
		stop12MonthSim = false;
		countMultiMonthSim = 0;

		while (stop12MonthSim == false){

			countMultiMonthSim++;
			endTurn(); //Kallar funktionen som körs varje gång man avslutar en runda

			if (countMultiMonthSim == 12){
				stop12MonthSim = true;

			}

			if (countMultiMonthSim == 15){
				break;

			}


	}
		playerPanelGO.GetComponent<portfolio>().updatePortfolio(); //Uppdaterar utd för portföljen
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
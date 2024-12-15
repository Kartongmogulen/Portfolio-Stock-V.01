using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoStockSector : MonoBehaviour
//Scriptet innehåller data om de olika sektorerna

{
	public Text ecoClimText;
	public Text ecoClimTextNumb;
	public GameObject MainCanvasGO;
	public GameObject PanelSectorGO;
	public GameObject PlayerPanelGO;
	public GameObject stockSectorPanelGO;
	public GameObject bottomPanelGO;
	public GameObject StockScriptGO;

	public int ecoClimateNow;
	public Text textEPS;
	public Text divPolicy;
	public Text divPerYear;
	public Text divYield;
	public Text divYearsIncreaseText;
	public Text CAGR5YearText; 
	public Text EPSGrowthText;

	public int activeSector; //Vilken sektor som är aktiv
	public Button ButtonAddOne;
	public int year;

	public float playerViewChangeEPSGrowth; //Hur EPS intervallet ändras beroende på lvl

	//Värden som måste bestämmas vid start

	//Utilities
	public float divUtiStart;
	public int utiEPSstart;
	public float volatilityUti; //Volatilitetens för sektorn
	public float STEP1utiPE;//Normalvärde för PE för sektorn. Utifrån detta värde varierar sedan priset
	public int[] utiEPSchange; //Hur EPS ändras beroende på ekonomiska klimatet
	public float utiEPSGrowthMin; //Minsta värdet EPS kan öka för Uti 
	public float utiEPSGrowthMax;  //Max värdet EPS kan öka för Uti 
	 

	//Div policy
	public float divPolMaxUti; //Taket för vad som betalats ut enligt policy
	public float divPolMinUti; //Minimi för vad som ska betalas ut enligt policy
	public float divPolRaiseUti; //Ökning av utdelning om utrymme finns

	//Finance
	public float divFinStart;
	public float financePriceStart; //Priset för en aktie vid start
	public float finEPSstart;
	public float STEP1finPE;
	public float bottomPriceFin; // Det lägsta priset man får betala för finans oavsett utd.
	public float volatilityFin; //Volatilitetens för sektorn
	public int[] finEPSchange; //Hur EPS ändras beroende på ekonomiska klimatet

	//Div policy
	public float divPolMaxFin; //Taket för vad som betalats ut enligt policy
	public float divPolMinFin; //Minimi för vad som ska betalas ut enligt policy
	public float divPolRaiseFin; //Ökning av utdelning om utrymme finns

	//Tech
	public float divTechStart;
	public float techEPSstart;
	public float techPriceStart; //Priset för en aktie vid start
	public float STEP1techPE;
	public float volatilityTech;
	public int[] techEPSchange; //Hur EPS ändras beroende på ekonomiska klimatet

	//Div policy
	public float divPolMaxTech; //Taket för vad som betalats ut enligt policy
	public float divPolMinTech; //Minimi för vad som ska betalas ut enligt policy
	public float divPolRaiseTech; //Ökning av utdelning om utrymme finns

	//Variabler som ej behöver bestämmas vid start
	public float yearCAGR;
	//Utilities
	public float divUtiShare;
	public float divUtiNow;
	public Text priceUtiText;
	public float utiEPSNow;
	public float[] utiEPSHist;
	public float[] utiPriceHist;

	public float utiEPSBeta;
	//public float startPE; //Vilket PE ska branschen starta på
	public float utiStockPrice;
	public float utiPENow;
	public float utiYearsDivRaise;
	public float utiYearsDivRaiseBefore;
	public float[] utiAnnualPayoutHist;
	public float utiCAGR5Year;
	//public Text utiYearsDivRaiseText;
	public Text volatilityUtiText;
	public Text PEUtiText1;
	public Text PEUtiText2;
	public Text divUtiShareText;
	public GameObject UtiPanelBuy;
	public GameObject UtiPanelSell;

	//Finance
	public float divFinShare;
	public float divFinNow;
	public float finPriceNow; //Priset för en aktie nu

	public float finEPSNow;
	public Text priceFinText;

	public float finPENow;
	public float finYearsDivRaise;
	public float finYearsDivRaiseBefore;
	public float[] finAnnualPayoutHist;
	public float finCAGR5Year;
	public Text volatilityFinText;
	public Text PEFinText1;
	public Text PEFinText2;
	public Text divFinShareText;
	public GameObject FinPanelBuy;
	public GameObject FinPanelSell;

	public float[] priceFinRound;
	public int roundInt; //Värde för att veta vilken runda som ska sparas.

	//Technology
	public float techPriceNow; //Priset för en aktie nu
	public float divTechNow;
	public float techYearsDivRaise;
	public float techYearsDivRaiseBefore;
	public float[] techAnnualPayoutHist;
	public float techCAGR5Year;

	public Text priceTechText;
	public float techEPSNow;
	public float divTechShare; //Payout ratio

	public float techPENow;
	public Text PETechText1;
	public Text PETechText2;
	public Text divTechShareText;
	public Text volatilityTechText;
	public GameObject TechPanelBuy;
	public GameObject TechPanelSell;

	//52WeekInterval
	public float[] uti52WeekData; //Data med varje månadsvärde den senaste 12 månaden
	public float[] fin52WeekData; //Data med varje månadsvärde den senaste 12 månaden
	public float[] tech52WeekData; //Data med varje månadsvärde den senaste 12 månaden
	public int roundInt52Week;
	public Text week52LowText;
	public float[] week52LowValue;
	public Text week52HighText;
	public float[] week52HighValue;
	float valueLow = float.PositiveInfinity;
	float valueHigh = float.PositiveInfinity;
	public int[] indexMinValue;
	public int[] indexMaxValue;

	void Start()
	{		
		utiEPSNow = utiEPSstart;
		divUtiNow = divUtiStart;

		finEPSNow = finEPSstart;
		divFinNow = divFinStart;

		techEPSNow = techEPSstart;
		divTechNow = divTechStart;

		//StockScriptGO.GetComponent<priceChange>().changePriceStock();
		//utiStockPrice = StockScriptGO.GetComponent<priceChange>().utiStockPriceNow;

		finPriceNow = financePriceStart;
		priceFinText.text = "Price: " + finPriceNow;

		techPriceNow = techPriceStart;
		priceTechText.text = "Price: " + techPriceNow; 

		infoUti();
		infoFin();
		infoTech();
		histDiv();
	}

	public void updateEarnings (int ecoClimate) {
		
		utiEPSNow = utiEPSNow + utiEPSchange[ecoClimate];
		finEPSNow = finEPSNow + finEPSchange[ecoClimate];
		techEPSNow = techEPSNow + techEPSchange[ecoClimate];

	}

	public void updateSectorRoundEnd(){

		//ecoClimateNow = MainCanvasGO.GetComponent<globalEcoClimate>().globalEcoClimateValueNow;

		updatePE();

		if (activeSector == 1){
			infoUti();}

		if (activeSector == 2){
			infoFin();}

		if (activeSector == 3){
			infoTech();
		}

		//week52HighLowText();

	}

	public void yearsOfDivRaise(float divBefore, float divAfter, int sector){


		if (divBefore<divAfter && sector == 1){
			
			utiYearsDivRaise++;
		
		}

		if (utiYearsDivRaiseBefore == utiYearsDivRaise && sector == 1){
			utiYearsDivRaise = 0;

		}
		utiYearsDivRaiseBefore = utiYearsDivRaise;

		if (divBefore<divAfter && sector == 2){

			finYearsDivRaise++;
		}
		if (finYearsDivRaiseBefore == finYearsDivRaise && sector == 2){
			finYearsDivRaise = 0;

		}
		finYearsDivRaiseBefore = finYearsDivRaise;
	

		if (divBefore<divAfter && sector == 3){

			techYearsDivRaise++;
		}
			if (techYearsDivRaiseBefore == techYearsDivRaise && sector == 3){
				techYearsDivRaise = 0;

			}
			techYearsDivRaiseBefore = techYearsDivRaise;

	}


	public void updateDividends() //Script för att uppdatera utdelningen vid årets slut
	{
		//divUtiNow = StockScriptGO.GetComponent<divPolicy>().utiDivPayoutAfter;
		//divFinNow = StockScriptGO.GetComponent<divPolicy>().finDivPayoutAfter;
		//divTechNow = StockScriptGO.GetComponent<divPolicy>().techDivPayoutAfter;

	}

	public void infoUti(){

		activeSector = 1;

		//Steg 1
	
		//utiStockPrice = StockScriptGO.GetComponent<priceChange>().utiStockPriceNow;
		divPerYear.text = "Annual payout: " + divUtiNow;
		divYield.text = "Div. Yield: " + Mathf.Round(divUtiNow/utiStockPrice*10000)/100 + "%";//Avrunda till 2 decimaler
		utiPENow = utiStockPrice/utiEPSNow;
		PEUtiText1.text = "P/E: " + Mathf.Round(utiPENow*100)/100;
		PEUtiText2.text = "P/E: " + Mathf.Round(utiPENow*100)/100;

		volatilityUtiText.text = "Volatility: " + volatilityUti*100 + "%";

		//STEP 2
		divUtiShare = Mathf.Round((divUtiNow*100)/utiEPSNow);
		divUtiShareText.text = "Div.Share: " + divUtiShare + "%";

		divPolicy.text = "Maximum payout ratio: " + divPolMaxUti*100 + "% and increase the dividend with " + divPolRaiseUti*100 + "% per year.";

		textEPS.text = "EPS: " + utiEPSNow;

		divYearsIncreaseText.text = "Years with div. raise: " + utiYearsDivRaise;

		//STEP 3
		week52HighLowText();
		CAGR5year ();

		//STEP 3.1 Stocks
		playerViewChangeEPSGrowth = PlayerPanelGO.GetComponent<playerStatsStocks>().playerIntervalView;
		EPSGrowthText.text = "EPS Growth/year: " + (utiEPSGrowthMin+playerViewChangeEPSGrowth) + "-" + (utiEPSGrowthMax+playerViewChangeEPSGrowth) +"%" +" True: " + utiEPSGrowthMin + "-" + utiEPSGrowthMax; ;
	}

	public void infoFin(){

		activeSector = 2;

		//finPriceNow = StockScriptGO.GetComponent<priceChange>().finStockPriceNow;
		divPerYear.text = "Annual payout: " + divFinNow;
		divYield.text = "Div. Yield: " + Mathf.Round(divFinNow/finPriceNow*10000)/100 + "%";//Avrunda till 2 decimaler
		finPENow = finPriceNow/finEPSNow;
		PEFinText1.text = "P/E: " + Mathf.Round(finPENow*100)/100;
		PEFinText2.text = "P/E: " + Mathf.Round(finPENow*100)/100;
		volatilityFinText.text = "Volatility: " + volatilityFin*100 + "%";

		//STEP 2
		divFinShare = Mathf.Round((divFinNow*100)/finEPSNow);
		divFinShareText.text = "Div.Share: " + divFinShare + "%";

		divPolicy.text = "Maximum payout ratio: " + divPolMaxFin*100 + "% and increase the dividend with " + divPolRaiseFin*100 + "% per year.";

		textEPS.text = "EPS: " + finEPSNow;

		divYearsIncreaseText.text = "Years with div. raise: " + finYearsDivRaise;

		week52HighLowText();
		CAGR5year ();
	}

	public void infoTech(){
		activeSector = 3;

		//techPriceNow = StockScriptGO.GetComponent<priceChange>().techStockPriceNow;
		divPerYear.text = "Annual payout: " + divTechNow;
		divYield.text = "Div. Yield: " + Mathf.Round(divTechNow/techPriceNow*10000)/100 + "%";//Avrunda till 2 decimaler
		techPENow = techPriceNow/techEPSNow;
		PETechText1.text = "P/E: " + Mathf.Round(techPENow*100)/100;
		PETechText2.text = "P/E: " + Mathf.Round(techPENow*100)/100;
		volatilityTechText.text = "Volatility: " + volatilityTech*100 + "%";

		//Step 2
		divTechShare = Mathf.Round((divTechNow*100)/techEPSNow);
		divTechShareText.text = "Div.Share: " + divTechShare + "%";

		divPolicy.text = "Maximum payout ratio: " + divPolMaxTech*100 + "% and increase the dividend with " + divPolRaiseTech*100 + "% per year.";

		textEPS.text = "EPS: " + techEPSNow;

		divYearsIncreaseText.text = "Years with div. raise: " + techYearsDivRaise;

		week52HighLowText();
		CAGR5year ();
	}

	public void updatePE(){

		//utiStockPrice = StockScriptGO.GetComponent<priceChange>().utiStockPriceNow;
		utiPENow = utiStockPrice/utiEPSNow;
		PEUtiText2.text = "P/E: " + Mathf.Round(utiPENow*100)/100;

		//finPriceNow = StockScriptGO.GetComponent<priceChange>().finStockPriceNow;
		finPENow = finPriceNow/finEPSNow;
		PEFinText2.text = "P/E: " + Mathf.Round(finPENow*100)/100;

		//techPriceNow = StockScriptGO.GetComponent<priceChange>().techStockPriceNow;
		techPENow = techPriceNow/techEPSNow;
		PETechText2.text = "P/E: " + Mathf.Round(techPENow*100)/100;
	}

	public void divChange (int ecoClimate){

		//ecoClimateNow = MainCanvasGO.GetComponent<globalEcoClimate>().globalEcoClimateValueNow;

		//STEP 1
		//techDiv [0] = techDiv [0] + techDivChange[0];
		//techDiv [1] = techDiv [1] + techDivChange[0];
		//techDiv [2] = techDiv [2] + techDivChange[0];
		//techDiv [3] = techDiv [3] + techDivChange[0];
		//techDiv [4] = techDiv [4] + techDivChange[0];
		//techDiv [5] = techDiv [5] + techDivChange[0];
		//techDiv [6] = techDiv [6] + techDivChange[0];

		//STEP 2
		//utilitesDiv [0] = utilitesDiv [0] + utiDivChange[ecoClimate];
		//utilitesDiv [1] = utilitesDiv [1] + utiDivChange[ecoClimate];
		//utilitesDiv [2] = utilitesDiv [2] + utiDivChange[ecoClimate];
		//utilitesDiv [3] = utilitesDiv [3] + utiDivChange[ecoClimate];
		//utilitesDiv [4] = utilitesDiv [4] + utiDivChange[ecoClimate];
		//utilitesDiv [5] = utilitesDiv [5] + utiDivChange[ecoClimate];
		//utilitesDiv [6] = utilitesDiv [6] + utiDivChange[ecoClimate];

		//financeDiv [0] = financeDiv [0] + finDivChange[ecoClimate];
		//financeDiv [1] = financeDiv [1] + finDivChange[ecoClimate];
		//financeDiv [2] = financeDiv [2] + finDivChange[ecoClimate];
		//financeDiv [3] = financeDiv [3] + finDivChange[ecoClimate];
		//financeDiv [4] = financeDiv [4] + finDivChange[ecoClimate];
		//financeDiv [5] = financeDiv [5] + finDivChange[ecoClimate];
		//financeDiv [6] = financeDiv [6] + finDivChange[ecoClimate];

		//techDiv [0] = techDiv [0] + techDivChange[ecoClimate];
		//techDiv [1] = techDiv [1] + techDivChange[ecoClimate];
		//techDiv [2] = techDiv [2] + techDivChange[ecoClimate];
		//techDiv [3] = techDiv [3] + techDivChange[ecoClimate];
		//techDiv [4] = techDiv [4] + techDivChange[ecoClimate];
		//techDiv [5] = techDiv [5] + techDivChange[ecoClimate];
		//techDiv [6] = techDiv [6] + techDivChange[ecoClimate];
	}

	public void histPriceSector (){

		if (roundInt < 12) {

			priceFinRound [roundInt] = finPriceNow;
			utiPriceHist [roundInt] = utiStockPrice;
			roundInt++;

		}

		if (roundInt >= 12) {

			utiPriceHist [12] = utiStockPrice;

			for (int i = 0; i < 13; i++){
				
				utiPriceHist [i] = utiPriceHist [i+1];

			}
		}

	}
	public void week52HighLowText(){
	
		week52LowText.text = "52 week low: " + week52LowValue[activeSector-1];
		week52HighText.text = "52 week high: " + week52HighValue[activeSector-1];

	}

	public void histDiv () //Historisk data för utdelning

	{
		utiAnnualPayoutHist[year] = divUtiNow;
		finAnnualPayoutHist[year] = divFinNow;
		techAnnualPayoutHist[year] = divTechNow;

		//year++;
	}

	public void histEPS () //Historisk data för utdelning

	{
		utiEPSHist[year] = utiEPSNow;
		//finAnnualPayoutHist[year] = divFinNow;
		//techAnnualPayoutHist[year] = divTechNow;

		year++;
	}

	public void CAGR5year(){
		
		if (year>5){
			
			utiCAGR5Year = (Mathf.Pow(utiAnnualPayoutHist[year-1]/utiAnnualPayoutHist[year-6],0.2f))-1;
			finCAGR5Year = (Mathf.Pow(finAnnualPayoutHist[year-1]/finAnnualPayoutHist[year-6],0.2f))-1;
			techCAGR5Year = (Mathf.Pow(techAnnualPayoutHist[year-1]/techAnnualPayoutHist[year-6],0.2f))-1;

		}

		if (activeSector == 1){

		CAGR5YearText.text = "5 year CAGR utd: " + Mathf.Round(utiCAGR5Year*10000)/100 + "%/year";

		}

		if (activeSector == 2){

			CAGR5YearText.text = "5 year CAGR utd: " + Mathf.Round(finCAGR5Year*10000)/100 + "%/year";

		}

		if (activeSector == 3){

			CAGR5YearText.text = "5 year CAGR utd: " + Mathf.Round(techCAGR5Year*10000)/100 + "%/year";

		}
	}

	public void changeVolatility(int sector, float volChange){

	if (sector == 0){

	}
	volatilityUti = volatilityUti + volChange;
	}
}

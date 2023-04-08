using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portfolio : MonoBehaviour
{
	//Script som hanterar innehaven i portföljen
	public GameObject panelSector;
	public GameObject MainCanvasGO;
	public GameObject playerPanelGO;
	public GameObject bottomPanelGO;
	public GameObject StockScriptGO;

	public int globalEcoClimate;
	public Text incomeDivPerYear; //Hur mycket portföljen ger i inkomst/år
	public float portfolioValue;
	public Text portfolioValueText;
	public float totalStockInvestment;

	public float returnPort; //Avkastning portfölj
	public Text returnPortText;
	public float totalReturnAmountStocks;

	//Utilities
	public float utiAmount; //Antal av Utilities-aktier
	public Text textUtiAmount;
	public float utiDivPerEcoClimate;
	public float utiDivPortfolio;
	public float utiShareOfPortfolio;
	public float utiSharePrice;

	public Text utiShareOfPortfolioText;

	public float totalInvestUti;
	public float totalAmountUtiBuy; //Totalt antal aktier som har köpts för att beräkna GAV
	public float utiGAV;
	public Text utiGAVtext;

	public float returnUti;
	public Text returnUtiText;

	//Finance
	public float finAmount; //Antal av Finance-aktier
	public Text textFinAmount;
	public float finDivPerEcoClimate;
	public float finDivPortfolio;
	public float finShareOfPortfolio;
	public float finSharePrice;

	public Text finShareOfPortfolioText;

	public float totalInvestFin;
	public float totalAmountFinBuy; //Totalt antal aktier som har köpts för att beräkna GAV
	public float finGAV;
	public Text finGAVtext;

	public float returnFin;
	public Text returnFinText;

	//Technology
	public float techAmount; //Antal av Technology-aktier
	public Text textTechAmount;
	public float techDivPerEcoClimate;
	public float techDivPortfolio;
	public float techShareOfPortfolio;
	public float techSharePrice;

	public Text techShareOfPortfolioText;

	public float totalInvestTech;
	public float totalAmountTechBuy; //Totalt antal aktier som har köpts för att beräkna GAV
	public float techGAV;
	public Text techGAVtext;

	public float returnTech;
	public Text returnTechText;


	//Index-fund
	public float indexAmount; //Antal andelar i index
	public Text textIndexAmount;
	public int indexDivPerEcoClimate;
	public float totalInvestIndex;
	public float indexGAV;
	public Text indexGAVtext;
	public float indexNAV;
	public float indexShareOfPortfolio;
	public Text indexShareOfPortfolioText;
	public float returnIndex;
	public Text returnIndexText;


	public float dividendPerRound; //Utdelning per runda
	public float dividendPerYear;
	//public Text divPerRoundText;

	//public Text Test3;

	void Update (){


		//Hur mycket utdelning som erhålls per runda
		//globalEcoClimate = MainCanvasGO.GetComponent<globalEcoClimate>().globalEcoClimateValueNow;
		utiDivPerEcoClimate = MainCanvasGO.GetComponent<infoStockSector>().divUtiNow;
		finDivPerEcoClimate = MainCanvasGO.GetComponent<infoStockSector>().divFinNow;
		techDivPerEcoClimate = MainCanvasGO.GetComponent<infoStockSector>().divTechNow;
		//indexDivPerEcoClimate = panelSector.GetComponent<indexFund>().divIndexFundNow;

		utiSharePrice = StockScriptGO.GetComponent<priceChange>().utiStockPriceNow;
		finSharePrice = StockScriptGO.GetComponent<priceChange>().finStockPriceNow;
		techSharePrice = StockScriptGO.GetComponent<priceChange>().techStockPriceNow;

		dividendPerYear = utiDivPortfolio + finDivPortfolio+techDivPortfolio;// + techDivPerEcoClimate*techAmount + indexDivPerEcoClimate*indexAmount;

		incomeDivPerYear.text = "Dividend/year: " + dividendPerYear;
		totalReturnStock ();
	}

	public void updatePortfolio ()// Uppdaterar portföljen med aktuellt data för det ekonomiska klimatet som råder
	{
		//globalEcoClimate = MainCanvasGO.GetComponent<globalEcoClimate>().globalEcoClimateValueNow;
		//utiDivPerEcoClimate = MainCanvasGO.GetComponent<infoStockSector>().divUtiNow;
		//finDivPerEcoClimate = MainCanvasGO.GetComponent<infoStockSector>().financeDiv[globalEcoClimate];
		//techDivPerEcoClimate = MainCanvasGO.GetComponent<infoStockSector>().techDiv[globalEcoClimate];

		/*
		utiDivPortfolio = utiDivPerEcoClimate*utiAmount;
		finDivPortfolio = finDivPerEcoClimate*finAmount;
		techDivPortfolio = techDivPerEcoClimate*techAmount;
		dividendPerYear = utiDivPortfolio + finDivPortfolio+techDivPortfolio;
		incomeDivPerYear.text = "Dividend/year: " + dividendPerYear;
		*/
		//GAV ();

	}

	public void sectorSharePortfolio (){

		//The sectors share of the portfolio

		utiSharePrice = StockScriptGO.GetComponent<priceChange>().utiStockPriceNow;
		finSharePrice = StockScriptGO.GetComponent<priceChange>().finStockPriceNow;
		techSharePrice = StockScriptGO.GetComponent<priceChange>().techStockPriceNow;
		indexNAV = StockScriptGO.GetComponent<indexFunds>().NAVIndexFund;

		portfolioValue = utiAmount*utiSharePrice + finAmount*finSharePrice + techAmount*techSharePrice + indexAmount*indexNAV;

		utiShareOfPortfolio = utiAmount*utiSharePrice / portfolioValue;
		utiShareOfPortfolioText.text = Mathf.Round(utiShareOfPortfolio*10000)/100 + "%";

		finShareOfPortfolio = finAmount*finSharePrice/portfolioValue;
		finShareOfPortfolioText.text = Mathf.Round(finShareOfPortfolio*10000)/100 + "%";

		techShareOfPortfolio = techAmount*techSharePrice/portfolioValue;
		techShareOfPortfolioText.text = Mathf.Round(techShareOfPortfolio*10000)/100 + "%";

		indexShareOfPortfolio = indexAmount*indexNAV/portfolioValue;
		indexShareOfPortfolioText.text = Mathf.Round(indexShareOfPortfolio*10000)/100 + "%";

		//Avkastning portfölj
		returnPort = (portfolioValue/(totalInvestUti+totalInvestFin+totalInvestTech)-1)*100;

		//Portfölj-värde
		portfolioValueText.text = "Value Portfolio: " + portfolioValue;
		returnPortText.text = "Return: " + Mathf.Round(returnPort*100)/100 + "%";

		sectorReturn();
	}

	public void addUtiAmount (int utiAmountAdd) {
		utiAmount = utiAmount + utiAmountAdd;
		textUtiAmount.text = "Utilities: " + utiAmount;
		utiDivPortfolio = utiDivPerEcoClimate*utiAmount;
		dividendPerYear = utiDivPortfolio;
		incomeDivPerYear.text = "Dividend/year: " + dividendPerYear;

		totalInvestUti = totalInvestUti + utiAmountAdd*utiSharePrice;
		//totalAmountUtiBuy = totalAmountUtiBuy+utiAmountAdd;
	}

	public void sellUtiAmount (int utiAmountSell) {
		utiAmount = utiAmount - utiAmountSell;
		textUtiAmount.text = "Utilities: " + utiAmount;
		utiDivPortfolio = utiDivPerEcoClimate*utiAmount;
		dividendPerYear = utiDivPortfolio;
		incomeDivPerYear.text = "Dividend/year: " + dividendPerYear;

		totalInvestUti = totalInvestUti - utiAmountSell*utiGAV;

		if (utiAmount == 0){
			totalInvestUti=0;
			//totalAmountUtiBuy=0;
		} 
	
	}

	public void addFinAmount (int finAmountAdd) {
		finAmount = finAmount+finAmountAdd;
		textFinAmount.text = "Finance: " + finAmount;
		finDivPortfolio = finDivPerEcoClimate*finAmount;
		dividendPerYear = finDivPortfolio;
		incomeDivPerYear.text = "Dividend/year: " + dividendPerYear;

		totalInvestFin = totalInvestFin + finAmountAdd*finSharePrice;
		//totalAmountFinBuy = totalAmountFinBuy+finAmountAdd;
	}

	public void sellFinAmount (int finAmountSell) {
		finAmount = finAmount - finAmountSell;
		textFinAmount.text = "Finance: " + finAmount;
		finDivPortfolio = finDivPerEcoClimate*finAmount;
		dividendPerYear = finDivPortfolio;
		incomeDivPerYear.text = "Dividend/year: " + dividendPerYear;

		totalInvestFin = totalInvestFin - finAmountSell*finGAV;

		if (finAmount == 0){
			totalInvestFin=0;
			totalAmountFinBuy = 0;
		} 

	}

	public void addTechAmount (int techAmountAdd) {
		techAmount = techAmount+techAmountAdd;
		textTechAmount.text = "Technology: " + techAmount;
		techDivPortfolio = techDivPerEcoClimate*techAmount;
		dividendPerYear = techDivPortfolio;
		incomeDivPerYear.text = "Dividend/year: " + dividendPerYear;

		totalInvestTech = totalInvestTech + techAmountAdd*techSharePrice;
		//totalAmountTechBuy = totalAmountTechBuy+techAmountAdd;
	}

	public void sellTechAmount (int techAmountSell) {
		techAmount = techAmount - techAmountSell;
		textTechAmount.text = "Technology: " + techAmount;
		techDivPortfolio = techDivPerEcoClimate*techAmount;
		dividendPerYear = techDivPortfolio;
		incomeDivPerYear.text = "Dividend/year: " + dividendPerYear;

		totalInvestTech = totalInvestTech - techAmountSell*techGAV;

		if (techAmount == 0){
			totalInvestTech=0;
			totalAmountTechBuy = 0;
		} 

	}

	public void addIndexAmount (float amount, float amountInvest) {
		indexAmount = indexAmount + amount;
		textIndexAmount.text = "Index-fund: " + Mathf.Round(indexAmount*100)/100;

		totalInvestIndex = totalInvestIndex + amountInvest;

		//Debug.Log ("Shares index: " + indexAmount);
		//Debug.Log ("Tot invest Index: " + totalInvestIndex);
	}

	public void sellIndexAmount (float amount, float amountInvest) {
		indexAmount = indexAmount - amount;
		textIndexAmount.text = "Index-fund: " + Mathf.Round(indexAmount*100)/100;
		totalInvestIndex = totalInvestIndex - amountInvest;

		if (indexAmount == 0){
			totalInvestIndex=0;
		} 

	}

	/*public void GAV (){

		//Utilities
		utiGAV = totalInvestUti/utiAmount;
		utiGAVtext.text = "" + utiGAV;

		//Finance
		finGAV = totalInvestFin/finAmount;
		finGAVtext.text = "" + finGAV;

		//Tech
		techGAV = totalInvestTech/techAmount;
		techGAVtext.text = "" + techGAV;

		indexGAV = totalInvestIndex/indexAmount;
		indexGAVtext.text = "" + indexGAV;

	}*/

	public void sectorReturn(){
		returnUti = ((utiSharePrice / utiGAV)-1)*100;
		returnUtiText.text = Mathf.Round(returnUti*100)/100 + " %";

		returnFin = ((finSharePrice / finGAV)-1)*100;
		returnFinText.text = Mathf.Round(returnFin*100)/100 + " %";

		returnTech = ((techSharePrice / techGAV)-1)*100;
		returnTechText.text = Mathf.Round(returnTech*100)/100 + " %";

		returnIndex = ((indexNAV / indexGAV)-1)*100;
		returnIndexText.text =  Mathf.Round(returnIndex*100)/100 + " %";

	}

	public void totalInvestedStock (){

		//totalStockInvestment = totalInvestUti + totalInvestFin + totalInvestTech;
		if (utiAmount > 0) {
			totalStockInvestment = utiGAV * utiAmount;
		}

		if (finAmount > 0) {
			totalStockInvestment = totalStockInvestment + finGAV * finAmount;
		}

		if (techAmount > 0) {
			totalStockInvestment = totalStockInvestment + techGAV*techAmount;
		}
			
	}

	public void totalReturnStock (){
		totalInvestedStock ();
		totalReturnAmountStocks = portfolioValue - totalStockInvestment;
	}

}

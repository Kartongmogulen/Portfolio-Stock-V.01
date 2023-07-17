
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sellStock : MonoBehaviour
//Script för när man väljer att köpa en aktie
{
	public GameObject playerScriptsGO;
	public GameObject playerGO;

	public int activeSector; //Kontrollera i scriptet chooseStockSector så sector-indexeringen är rätt när fler kategorier läggs till
	public int activeCompany;
	public int amountOrder;
	public float orderValue;
	public float moneyPlayer;
	public float stockPrice;
	public float playerStockCount;

	public GameObject stockGO;
	public chooseStockSector ChooseStockSector;
	//public GameObject PortfolioStock;

	public InputField inputAmountOrder;

	//Innan Steg 3.1

	public GameObject PanelStockSector;
	public GameObject BottomPanelGO;
	public InputField inputAmountIndex;

	public Text priceUtiText;
	public Text priceFinText;
	public Text priceTechText;
	public Text priceIndexText;

	//Vad kostar en aktie?
	public float priceUti;
	public float priceFin;
	public float priceTech;
	public float priceIndex;
	public float indexNAV;

	//Har jag några aktier att sälja?
	public GameObject playerPanel;
	public float numStockUti;
	public float numStockFin;
	public float numStockTech;
	public float numStockIndex;

	public float amountOrderIndex;
	public float indexShareSell;

	//Addera en till aktie till portföljen. Scriptet "portfolio"

	//Ta bort kostnaden för aktien av mina pengar. Funktion i scriptet "totalCash".

	void Awake()
	{
		ChooseStockSector = GetComponent<chooseStockSector> ();

	}

	public void sellStocks(){
		//Identifiera sektor
		activeSector = ChooseStockSector.activeSector;
		//moneyPlayer = playerPanel.GetComponent<totalCash> ().moneyNow;

		//Identifera vilket företag (nr)
		if (activeSector == 1) {
			activeCompany = stockGO.GetComponent<chooseUtiCompany> ().activeCompany;
			stockPrice = stockGO.GetComponent<chooseUtiCompany> ().activeCompanyPrice;
			playerStockCount = playerScriptsGO.GetComponent<portfolioStock> ().utiCompanySharesOwned [activeCompany];
		}

		if (activeSector == 2) {
			activeCompany = stockGO.GetComponent<chooseTechCompany> ().activeCompany;
			stockPrice = stockGO.GetComponent<chooseTechCompany> ().activeCompanyPrice;
			playerStockCount = playerScriptsGO.GetComponent<portfolioStock> ().techCompanySharesOwned [activeCompany];
		}

		//Identifiera antalet spelaren vill sälja
		amountOrder = int.Parse (inputAmountOrder.text);	

		orderValue = amountOrder * stockPrice;

		//Har spelaren tillräckligt med aktier
		if (amountOrder <= playerStockCount) {

			//Addera pengar
			moneyPlayer = playerScriptsGO.GetComponent<totalCash>().moneyNow;
			playerScriptsGO.GetComponent<totalCash> ().moneyNow = moneyPlayer + orderValue;
			playerScriptsGO.GetComponent<totalCash>().updateMoney();

			//Sub antalet aktier
			if (activeSector == 1) {
				playerScriptsGO.GetComponent<portfolioStock> ().sellUtiShares (amountOrder, activeCompany, orderValue);
	
			}

			if (activeSector == 2) {
				playerScriptsGO.GetComponent<portfolioStock> ().sellTechShares (amountOrder, activeCompany);

			}
			playerScriptsGO.GetComponent<portfolioStock>().valuePortfolio();//Uppdaterar värdet av portfölj
																			 
			//playerScriptsGO.GetComponent<portfolioStock>().GAVupdateSell();
		}
	}

		//_______________________________________________________________

	

	public void sellUtilitiesOne (){
		priceUti = PanelStockSector.GetComponent<priceChange>().utiStockPriceNow;
		priceUtiText.text = "Price: " + priceUti;
		numStockUti = playerPanel.GetComponent<portfolio>().utiAmount;

		if (numStockUti > 0) {
			playerPanel.GetComponent<portfolio>().sellUtiAmount (1);
			//playerPanel.GetComponent<totalCash>().sellStockUti (1);
			//playerPanel.GetComponent<portfolio>().GAV();
		}
	}

	public void sellUtilitiesTen (){
		priceUti = PanelStockSector.GetComponent<priceChange>().utiStockPriceNow;
		priceUtiText.text = "Price: " + priceUti;
		numStockUti = playerPanel.GetComponent<portfolio>().utiAmount;

		if (numStockUti >= 10) {
			playerPanel.GetComponent<portfolio>().sellUtiAmount (10);
			//playerPanel.GetComponent<totalCash>().sellStockUti (10);
			//playerPanel.GetComponent<portfolio>().GAV();
		}
	}

	public void sellUtilitiesHundred (){
		priceUti = PanelStockSector.GetComponent<priceChange>().utiStockPriceNow;
		priceUtiText.text = "Price: " + priceUti;
		numStockUti = playerPanel.GetComponent<portfolio>().utiAmount;

		if (numStockUti >= 100) {
			playerPanel.GetComponent<portfolio>().sellUtiAmount (100);
			//playerPanel.GetComponent<totalCash>().sellStockUti (100);
			//playerPanel.GetComponent<portfolio>().GAV();
		}
	}

	public void sellFinanceOne (){
		Debug.Log ("Sell Fin 1");
		priceFin = PanelStockSector.GetComponent<priceChange>().finStockPriceNow;
		priceFinText.text = "Price: " + priceFin;

		numStockFin = playerPanel.GetComponent<portfolio>().finAmount;

		if (numStockFin > 0) {
			playerPanel.GetComponent<portfolio>().sellFinAmount (1);
			//playerPanel.GetComponent<totalCash>().sellStockFin (1);
			//playerPanel.GetComponent<portfolio>().GAV();
		}
	}

	public void sellFinanceTen (){
		priceFin = PanelStockSector.GetComponent<priceChange>().finStockPriceNow;
		priceFinText.text = "Price: " + priceFin;
		numStockFin = playerPanel.GetComponent<portfolio>().finAmount;

		if (numStockFin >= 10) {
			playerPanel.GetComponent<portfolio>().sellFinAmount (10);
			//playerPanel.GetComponent<totalCash>().sellStockFin (10);
			//playerPanel.GetComponent<portfolio>().GAV();
		}
	}

	public void sellFinanceHundred (){
		priceFin = PanelStockSector.GetComponent<priceChange>().finStockPriceNow;
		priceFinText.text = "Price: " + priceFin;
		numStockFin = playerPanel.GetComponent<portfolio>().finAmount;

		if (numStockFin >= 100) {
			playerPanel.GetComponent<portfolio>().sellFinAmount (100);
			//playerPanel.GetComponent<totalCash>().sellStockFin (100);
			//playerPanel.GetComponent<portfolio>().GAV();
		}
	}

	public void sellTechOne (){
		priceTech = PanelStockSector.GetComponent<priceChange>().techStockPriceNow;
		priceTechText.text = "Price: " + priceTech;
		numStockTech = playerPanel.GetComponent<portfolio>().techAmount;

		if (numStockTech > 0) {
			playerPanel.GetComponent<portfolio>().sellTechAmount (1);
			//playerPanel.GetComponent<totalCash>().sellStockTech (1);
			//playerPanel.GetComponent<portfolio>().GAV();
		}
	}

	public void sellTechTen (){
		priceTech = PanelStockSector.GetComponent<priceChange>().techStockPriceNow;
		priceTechText.text = "Price: " + priceTech;
		numStockTech = playerPanel.GetComponent<portfolio>().techAmount;

		if (numStockTech >= 10) {
			playerPanel.GetComponent<portfolio>().sellTechAmount (10);
			//playerPanel.GetComponent<totalCash>().sellStockTech (10);
			//playerPanel.GetComponent<portfolio>().GAV();
		}
	}

	public void sellTechHundred (){
		priceTech = PanelStockSector.GetComponent<priceChange>().techStockPriceNow;
		priceTechText.text = "Price: " + priceTech;
		numStockTech = playerPanel.GetComponent<portfolio>().techAmount;

		if (numStockTech >= 100) {
			playerPanel.GetComponent<portfolio>().sellTechAmount (100);
			//playerPanel.GetComponent<totalCash>().sellStockTech (100);
			//playerPanel.GetComponent<portfolio>().GAV();
		}
	}

	public void sellIndex (){
		indexNAV= BottomPanelGO.GetComponent<indexFunds>().NAVIndexFund;

		amountOrderIndex = float.Parse (inputAmountIndex.text);	

		priceIndexText.text = "NAV: " + indexNAV;
		indexShareSell = amountOrderIndex/indexNAV;

		numStockIndex = playerPanel.GetComponent<portfolio>().indexAmount;

		if (numStockIndex > indexShareSell) {
			playerPanel.GetComponent<portfolio>().sellIndexAmount (indexShareSell, amountOrderIndex);
			//playerPanel.GetComponent<totalCash>().sellStockIndex	(amountOrderIndex);

		}
	}
}

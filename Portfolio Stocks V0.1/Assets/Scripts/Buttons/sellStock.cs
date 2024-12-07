
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sellStock : MonoBehaviour
//Script för när man väljer att köpa en aktie
{
	/*
	public GameObject playerScriptsGO;
	public GameObject playerGO;

	public activeSector_1850 ActiveSector_1850;
	public CityManager cityManager;
	public stockMarketManager_1850 StockMarketManager_1850;

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
		ChooseStockSector = GetComponent<chooseStockSector>();

	}

	public void sellStocks()
	{
		//Identifiera sektor
		activeSector = ChooseStockSector.activeSector;
		//moneyPlayer = playerPanel.GetComponent<totalCash> ().moneyNow;

		//Identifera vilket företag (nr)
		if (activeSector == 1)
		{
			activeCompany = stockGO.GetComponent<chooseUtiCompany>().activeCompany;
			stockPrice = stockGO.GetComponent<chooseUtiCompany>().activeCompanyPrice;
			playerStockCount = playerScriptsGO.GetComponent<portfolioStock>().utiCompanySharesOwned[activeCompany];
		}

		if (activeSector == 2)
		{
			activeCompany = stockGO.GetComponent<chooseTechCompany>().activeCompany;
			stockPrice = stockGO.GetComponent<chooseTechCompany>().activeCompanyPrice;
			playerStockCount = playerScriptsGO.GetComponent<portfolioStock>().techCompanySharesOwned[activeCompany];
		}

		//Identifiera antalet spelaren vill sälja
		amountOrder = int.Parse(inputAmountOrder.text);

		orderValue = amountOrder * stockPrice;

		//Har spelaren tillräckligt med aktier
		if (amountOrder <= playerStockCount)
		{

			//Addera pengar
			moneyPlayer = playerScriptsGO.GetComponent<totalCash>().moneyNow;
			playerScriptsGO.GetComponent<totalCash>().moneyNow = moneyPlayer + orderValue;
			playerScriptsGO.GetComponent<totalCash>().updateMoney();

			//Sub antalet aktier
			if (activeSector == 1)
			{
				//playerScriptsGO.GetComponent<portfolioStock>().sellUtiShares(amountOrder, activeCompany, orderValue);

			}

			if (activeSector == 2)
			{
				//playerScriptsGO.GetComponent<portfolioStock>().sellTechShares(amountOrder, activeCompany);

			}
			playerScriptsGO.GetComponent<portfolioStock>().valuePortfolio();//Uppdaterar värdet av portfölj

			//playerScriptsGO.GetComponent<portfolioStock>().GAVupdateSell();
		}
	}
	public void sellStocks_1850()
	{
		//Debug.Log("Sälj aktie");
		activeSector = ActiveSector_1850.getActiveSector();
		amountOrder = int.Parse(inputAmountOrder.text);

		if (activeSector == 0)
		{
			stockPrice = StockMarketManager_1850.StockPrefabListMines[cityManager.getActiveCity()].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListMines[cityManager.getActiveCity()].GetComponent<stock>().StockPrice.Count - 1];
			playerStockCount = playerScriptsGO.GetComponent<portfolioStock>().minesCompanySharesOwned[cityManager.getActiveCity()];
		}

		else if (activeSector == 1)
		{
			stockPrice = StockMarketManager_1850.StockPrefabListRailroad[cityManager.getActiveCity()].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListMines[cityManager.getActiveCity()].GetComponent<stock>().StockPrice.Count - 1];
			playerStockCount = playerScriptsGO.GetComponent<portfolioStock>().railroadCompanySharesOwned[cityManager.getActiveCity()];
		}

		else if (activeSector == 2 && StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<priceStock>() != null)
		{
			stockPrice = StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<priceStock>().StockPrice[StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<priceStock>().StockPrice.Count - 1];
			playerStockCount = playerScriptsGO.GetComponent<portfolioStock>().industriCompanySharesOwned[cityManager.getActiveCity()];
		}

		else if (activeSector == 2)
		{
			stockPrice = StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<stock>().StockPrice.Count - 1];
		}

		orderValue = amountOrder * stockPrice;

		//Har spelaren tillräckligt med aktier
		if (amountOrder <= playerStockCount)
		{
			Debug.Log("Spelaren har aktier");
			//Addera pengar
			playerGO.GetComponent<totalCash>().transactionMoney(orderValue);

			//Sub antalet aktier
			if (activeSector == 0)
			{
				playerScriptsGO.GetComponent<portfolioStock>().mineTotalInvestAmount[cityManager.getActiveCity()] -= orderValue;
				//playerScriptsGO.GetComponent<portfolioStock>().addMineShares(-amountOrder, cityManager.getActiveCity());

			}

			else if (activeSector == 1)
			{
				playerScriptsGO.GetComponent<portfolioStock>().railroadTotalInvestAmount[cityManager.getActiveCity()] -= orderValue;
				//playerScriptsGO.GetComponent<portfolioStock>().addRailroadShares(-amountOrder, cityManager.getActiveCity());

			}

			else if (activeSector == 2)
			{
				playerScriptsGO.GetComponent<portfolioStock>().industriTotalInvestAmount[cityManager.getActiveCity()] -= orderValue;
				//playerScriptsGO.GetComponent<portfolioStock>().addIndustriShares(-amountOrder, cityManager.getActiveCity());

			}
			playerScriptsGO.GetComponent<portfolioStock>().valuePortfolio();//Uppdaterar värdet av portfölj
		}
	}
	*/
}

	
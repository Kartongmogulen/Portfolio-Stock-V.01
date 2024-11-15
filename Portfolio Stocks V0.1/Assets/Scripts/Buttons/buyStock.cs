using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class buyStock : MonoBehaviour
//Script för när man väljer att köpa en aktie
{
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

	public GameObject stockGO;
	public chooseStockSector ChooseStockSector;
	//public GameObject PortfolioStock;

	public InputField inputAmountOrder;

	//Innan Steg 3.1
	public GameObject PanelStockSector;
	//public GameObject playerPanelGO;
	public GameObject BottomPanelGO;

	public Text priceUtiText;
	public Text priceFinText;
	public Text priceTechText;

	//Vad kostar en Utilities aktie?
	public float priceUti;

	//Vad kostar en Finance aktie?
	public float priceFin;

	//Vad kostar en Tech aktie?
	public float priceTech;

	//Vad kostar en Index aktie?
	public float indexNAV;
	public float amountOrderIndex;
	public float indexSharesAdd;

	//Har jag tillräckligt med pengar?
	public GameObject MainCanvas;
	public float moneyBeforeBuy;

	public InputField inputAmountIndex;

	//Addera en till aktie till portföljen. Scriptet "portfolio"

	//Ta bort kostnaden för aktien av mina pengar. Funktion i scriptet "totalCash".

	void Awake()
	{
		ChooseStockSector = GetComponent<chooseStockSector>();
		//PortfolioStock = stockGO.GetComponent<portfolioStock> ();

	}

	public void refactorTest(moneyManager MoneyManager)
	{
		///TEST REFACTOR
		MoneyManager.buyTransaction(100);

		Debug.Log("Pengar nu: " + MoneyManager.MoneyNow);

	}

	public void buyStocks()
	{
		//Identifiera sektor
		activeSector = ChooseStockSector.activeSector;

		//Identifera vilket företag (nr)
		if (activeSector == 1)
		{
			activeCompany = stockGO.GetComponent<chooseUtiCompany>().activeCompany;
			stockPrice = stockGO.GetComponent<chooseUtiCompany>().activeCompanyPrice;
		}

		if (activeSector == 2)
		{
			activeCompany = stockGO.GetComponent<chooseTechCompany>().activeCompany;
			stockPrice = stockGO.GetComponent<chooseTechCompany>().activeCompanyPrice;
		}

		if (activeSector == 3)
		{
			activeCompany = stockGO.GetComponent<chooseMaterialCompany>().activeCompany;
			stockPrice = stockGO.GetComponent<chooseMaterialCompany>().activeCompanyPrice;
		}

		//Identifiera antalet spelaren vill köpa
		amountOrder = int.Parse(inputAmountOrder.text);

		//Har spelaren tillräckligt med pengar?
		moneyPlayer = playerGO.GetComponent<totalCash>().moneyNow;

		orderValue = amountOrder * stockPrice;

		if (moneyPlayer >= orderValue)

		{
			//Subtrahera pengar
			playerGO.GetComponent<totalCash>().moneyNow = moneyPlayer - orderValue;
			playerGO.GetComponent<totalCash>().updateMoney();
			//moneyPlayer = playerPanelGO.GetComponent<totalCash>().moneyNow;


			//Addera antalet aktier
			if (activeSector == 1)
			{
				playerScriptsGO.GetComponent<portfolioStock>().utiTotalInvest[activeCompany] += orderValue;
				//playerScriptsGO.GetComponent<portfolioStock> ().addUtiShares (amountOrder, activeCompany);

			}

			if (activeSector == 2)
			{
				playerScriptsGO.GetComponent<portfolioStock>().techTotalInvest[activeCompany] += orderValue;
				//playerScriptsGO.GetComponent<portfolioStock> ().addTechShares (amountOrder, activeCompany);

			}

			if (activeSector == 3)
			{
				playerScriptsGO.GetComponent<portfolioStock>().materialsTotalInvest[activeCompany] += orderValue;
				//playerScriptsGO.GetComponent<portfolioStock> ().addMaterialShares (amountOrder, activeCompany);

			}

			//playerScriptsGO.GetComponent<portfolioStock>().GAVupdate();
			//playerPanelGO.GetComponent<totalCash>().updateMoney();
		}

		playerScriptsGO.GetComponent<portfolioStock>().valuePortfolio(); //Uppdaterar värdet av portfölj



	}

	public void buyStocks_1850()
	{
		activeSector = ActiveSector_1850.getActiveSector();

		//Identifiera antalet spelaren vill köpa

		amountOrder = int.Parse(inputAmountOrder.text);
		//Debug.Log("Amountorder: " + amountOrder);

		if (activeSector == 0)
		{
			stockPrice = StockMarketManager_1850.StockPrefabListMines[cityManager.getActiveCity()].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListMines[cityManager.getActiveCity()].GetComponent<stock>().StockPrice.Count - 1];
		}

		else if (activeSector == 1)
		{
			stockPrice = StockMarketManager_1850.StockPrefabListRailroad[cityManager.getActiveCity()].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListRailroad[cityManager.getActiveCity()].GetComponent<stock>().StockPrice.Count - 1];
		}

		else if (activeSector == 2 && StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<priceStock>() != null)
		{
			stockPrice = StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<priceStock>().StockPrice[StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<priceStock>().StockPrice.Count - 1];
		}

		else if (activeSector == 2)
		{
			stockPrice = StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<stock>().StockPrice.Count - 1];
		}
		//Debug.Log("Stockprice: " + stockPrice);

		//Har spelaren tillräckligt med pengar?
		moneyPlayer = playerGO.GetComponent<totalCash>().moneyNow;

		orderValue = amountOrder * stockPrice;
		//Debug.Log("Ordervalue: " + orderValue);

		if (moneyPlayer >= orderValue)

		{
			//Subtrahera pengar
			playerGO.GetComponent<totalCash>().transactionMoney(-orderValue);
			//playerGO.GetComponent<totalCash>().updateMoney();
			//moneyPlayer = playerPanelGO.GetComponent<totalCash>().moneyNow;

			//Addera antalet aktier
			if (activeSector == 0)
			{
				playerScriptsGO.GetComponent<portfolioStock>().mineTotalInvestAmount[cityManager.getActiveCity()] += orderValue;
				playerScriptsGO.GetComponent<portfolioStock>().addMineShares(amountOrder, cityManager.getActiveCity());

				//Uppdatera GAV
				playerScriptsGO.GetComponent<GAV>().minesGAV();
			}

			else if (activeSector == 1)
			{
				playerScriptsGO.GetComponent<portfolioStock>().railroadTotalInvestAmount[cityManager.getActiveCity()] += orderValue;
				playerScriptsGO.GetComponent<portfolioStock>().addRailroadShares(amountOrder, cityManager.getActiveCity());

			}

			else if (activeSector == 2)
			{
				Debug.Log("Active sector 2");
				playerScriptsGO.GetComponent<portfolioStock>().industriTotalInvestAmount[cityManager.getActiveCity()] += orderValue;
				playerScriptsGO.GetComponent<portfolioStock>().addIndustriShares(amountOrder, cityManager.getActiveCity());

			}

			playerScriptsGO.GetComponent<portfolioStock>().valuePortfolio(); //Uppdaterar värdet av portfölj

		}
	}

	public void buyStocks_1850_Refactor(moneyManager MoneyManager)
	{
		int activeSector = ActiveSector_1850.getActiveSector();
		int city = cityManager.getActiveCity();
		int amountOrder = int.Parse(inputAmountOrder.text);

		// Hämta aktiepriset
		float stockPrice = GetStockPrice(activeSector, city);

		// Kontrollera spelarens pengar
		float orderValue = amountOrder * stockPrice;

		if (MoneyManager.HasEnoughMoney(orderValue) == true)
		{
			// Genomför transaktionen
			MoneyManager.buyTransaction(orderValue);

			// Uppdatera aktier och investeringsdata
			UpdatePortfolio(activeSector, city, amountOrder, orderValue);
		}
		else
		{
			Debug.LogWarning("Not enough money to complete the transaction.");
		}

	}

	private float GetStockPrice(int sector, int city)
	{

		GameObject stockPrefab = sector switch
		{
			0 => StockMarketManager_1850.StockPrefabListMines[city],
			1 => StockMarketManager_1850.StockPrefabListRailroad[city],
			2 => StockMarketManager_1850.StockPrefabListIndustri[city],
			_ => throw new ArgumentException("Invalid sector.")
		};


		// Hantera olika typer av komponenter (stock vs priceStock)
		var stockComponent = stockPrefab.GetComponent<stock>();
		if (stockComponent != null)
		{
			int lastIndex = stockComponent.StockPrice.Count - 1;
			return stockComponent.StockPrice[lastIndex]; // Sista priset
		}

		var priceStockComponent = stockPrefab.GetComponent<priceStock>();
		if (priceStockComponent != null)
		{
			int lastIndex = stockComponent.StockPrice.Count - 1;
			return stockComponent.StockPrice[lastIndex]; // Sista prise
		}

		throw new Exception("Stock component not found for the selected sector.");
	}

	private void UpdatePortfolio(int sector, int city, int amountOrder, float orderValue)
	{
		var portfolio = playerScriptsGO.GetComponent<portfolioStock>();

		switch (sector)
		{
			case 0: // Gruvor
				portfolio.mineTotalInvestAmount[city] += orderValue;
				portfolio.addMineShares(amountOrder, city);
				playerScriptsGO.GetComponent<GAV>().minesGAV();
				break;

			case 1: // Järnvägar
				portfolio.railroadTotalInvestAmount[city] += orderValue;
				portfolio.addRailroadShares(amountOrder, city);
				break;

			case 2: // Industri
				portfolio.industriTotalInvestAmount[city] += orderValue;
				portfolio.addIndustriShares(amountOrder, city);
				break;

			default:
				throw new ArgumentException("Invalid sector.");
		}

		portfolio.valuePortfolio(); // Uppdatera portföljvärdet
	}
}


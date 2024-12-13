using System;
using UnityEngine;
using UnityEngine.UI;

public class stockTransaction : MonoBehaviour
{
	public activeSector_1850 ActiveSector_1850;
	public CityManager cityManager;
	public stockMarketManager_1850 StockMarketManager_1850;
	public InputField inputAmountOrder;
	public GameObject playerScriptsGO;

	[Header("Test")]
	public GameObject mineStockCompany;

	public void buyStocks_1850_Refactor(moneyManager MoneyManager)
	{
		int activeSector = ActiveSector_1850.getActiveSector();
		int city = cityManager.activeCity;
		int amountOrder = int.Parse(inputAmountOrder.text);

		// Hämta aktiepriset
		float stockPrice = GetStockPrice(activeSector, city);

		// Kontrollera spelarens pengar
		float orderValue = amountOrder * stockPrice;

		if (MoneyManager.HasEnoughMoney(orderValue) == true)
		{
			// Genomför transaktionen
			MoneyManager.buyTransaction(orderValue);
			GetComponent<PortfolioManager>().AddOrUpdateEntry(amountOrder, orderValue);
			//GetComponent<PortfolioManager>().UpdateMoneyDisplay(GetComponent<PortfolioManager>().GetTotalPortfolioValue());

			// Uppdatera aktier och investeringsdata
			UpdatePortfolio(activeSector, city, amountOrder, orderValue);
		}
		else
		{
			Debug.LogWarning("Not enough money to complete the transaction.");
		}

	}

	public void sellStocks_1850_Refactor(PortfolioManager portfolio)
	{
		int activeSector = ActiveSector_1850.getActiveSector();
		int city = cityManager.activeCity;
		float stockAmountPlayerHas;
		int amountOrder = int.Parse(inputAmountOrder.text);
		//var portfolio = playerScriptsGO.GetComponent<portfolioStock>();

		/*
		switch (activeSector)
		{
			case 0: // Gruvor
				stockAmountPlayerHas = portfolio.minesCompanySharesOwned[city];
				break;

			case 1: // Järnvägar
				stockAmountPlayerHas = portfolio.railroadCompanySharesOwned[city];
				break;

			case 2: // Industri
				stockAmountPlayerHas = portfolio.industriCompanySharesOwned[city];
				break;

			default:
				throw new ArgumentException("Invalid sector.");
		}
		*/

		//Debug.Log("Antal aktier spelaren har: " + stockAmountPlayerHas);
		//Debug.Log("Orderstorlek: " + amountOrder);
		//Om spelaren har tillräckligt med aktier utförs säljorder
		if (portfolio.getSharesAmount() >= amountOrder)
		{
			// Hämta aktiepriset
			float stockPrice = GetStockPrice(activeSector, city);
			float orderValue = amountOrder * stockPrice;
			// Genomför transaktionen
			GetComponent<moneyManager>().sellTransaction(orderValue);
			GetComponent<PortfolioManager>().AddOrUpdateEntry(-amountOrder, -orderValue);

			// Uppdatera aktier och investeringsdata
			UpdatePortfolio(activeSector, city, -amountOrder, -orderValue);
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
				//portfolio.addMineShares(amountOrder, city);
				playerScriptsGO.GetComponent<GAV>().minesGAV();
				break;

			case 1: // Järnvägar
				portfolio.railroadTotalInvestAmount[city] += orderValue;
				//portfolio.addRailroadShares(amountOrder, city);
				break;

			case 2: // Industri
				portfolio.industriTotalInvestAmount[city] += orderValue;
				//portfolio.addIndustriShares(amountOrder, city);
				break;

			default:
				throw new ArgumentException("Invalid sector.");
		}

		portfolio.valuePortfolio(); // Uppdatera portföljvärdet
	}

}


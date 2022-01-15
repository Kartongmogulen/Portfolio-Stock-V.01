using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class companyNumbersUpdate : MonoBehaviour
{
	public GameObject ScriptsStockGO;
	public GameObject StockMarketGO;
	public stockMarketManager StockMarketManager;

	public float newDividend;

	private void Start()
	{
		StockMarketManager = StockMarketGO.GetComponent<stockMarketManager>();
	}

	public void updateYearEnd()
	{
		updateDividends();
		updateEarnings();
	}

	public void updateDividends() //Script för att uppdatera utdelningen vid årets slut
	{

		for (int i = 0; i < StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++)
		{
			ScriptsStockGO.GetComponent<divPolicy>().endOfYearUpdate(StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i]);
		}

	}

	public void updateEarnings()
	{
		for (int i = 0; i < StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++)
		{
			ScriptsStockGO.GetComponent<earningsUpdate>().updateEarnings(StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i]);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class companyNumbersUpdate : MonoBehaviour
{
	public GameObject ScriptsStockGO;
	public GameObject StockMarketGO;
	public stockMarketManager StockMarketManager;
	public stockMarketManager_1850 StockMarketManager_1850;

	public float newDividend;

	private void Awake()
	{
		StockMarketManager = StockMarketGO.GetComponent<stockMarketManager>();
	}

	public void updateYearEnd()
	{
		updateDividends();
		updateEarnings();
		allocateCapital();
	}

	public void updateDividends() //Script för att uppdatera utdelningen vid årets slut
	{

		for (int i = 0; i < StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++)
		{
			//Spara utdelning för historik
			StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i].saveDividendHistory();

			//Uppdatera värden vid årets slut
			ScriptsStockGO.GetComponent<divPolicy>().endOfYearUpdate(StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i]);
		}

	}

	public void updateEarnings()
	{
		for (int i = 0; i < StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++)
		{
			ScriptsStockGO.GetComponent<earningsUpdate>().updateEarnings(StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i]);
		}

		for (int i = 0; i < StockMarketManager_1850.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++)
		{
			ScriptsStockGO.GetComponent<earningsUpdate>().updateEarnings(StockMarketManager_1850.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i]);
		}

		for (int i = 0; i < StockMarketManager_1850.StockPrefabListIndustri.Count; i++)
		{
			//Debug.Log("Loop UpdateEarnings");
			ScriptsStockGO.GetComponent<earningsUpdate>().earningsUpdate_Products(StockMarketManager_1850.StockPrefabListIndustri[i]);
		}

	}

	public void allocateCapital()
	{
		for (int i = 0; i < StockMarketManager_1850.StockPrefabListIndustri.Count; i++)
		{
			StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<managementPriorites>().allocateCapital();
		}
	}
}

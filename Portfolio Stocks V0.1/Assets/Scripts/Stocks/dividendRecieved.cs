using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dividendRecieved : MonoBehaviour
{
	//Utdelningar som erhållits
	/* Hämta spelarens portfölj
	 * Gå igenom portföljen för att få ut utdelnignen
	 */

	public GameObject StockMarketGO;
	public stockMarketManager StockMarketManager;
	public stockMarketManager_1850 StockMarketManager_1850;
	public GameObject playerScriptsGO;

	public portfolioStock PortfolioStock; 
	public utilitiesInfoStock UtiInfoStock;
	public techInfoStock TechInfoStock;

	public List<float> utiCompanySharesOwned;
	public List<float> utiCompanyDivPayout = new List<float>();
	public List<float> utiCompanyDivRecieved = new List<float> ();

	public List<float> techCompanySharesOwned;
	public List<float> techCompanyDivPayout;
	public List<float> techCompanyDivRecieved = new List<float> ();

	//1850
	public List<float> minesCompanySharesOwned;
	public List<float> minesCompanyDivPayout;
	public List<float> minesCompanyDivRecieved = new List<float>();

	public List<float> railroadCompanySharesOwned;
	public List<float> railroadCompanyDivPayout;
	public List<float> railroadCompanyDivRecieved = new List<float>();

	public List<float> industriCompanySharesOwned;
	public List<float> industriCompanyDivPayout;
	public List<float> industriCompanyDivRecieved = new List<float>();

	public List<float> divRecPerYear = new List<float> ();

	public float totalDivRecieved;
	public float incomeDivFromPortfolioNow;

	int year = 0; 
	
    void Awake()
    {
		PortfolioStock = playerScriptsGO.GetComponent<portfolioStock> ();
		//StockMarketManager = StockMarketGO.GetComponent<stockMarketManager>();
		//StockMarketManager_1850 = GetComponent<stockMarketManager_1850>();

		//SKAPAR STORLEK PÅ LISTA EFTER ANTALET BOLAG
		for (int i = 0; i < StockMarketManager.StockUtiList.Count; i++)
		{
			utiCompanySharesOwned.Add(0);
			utiCompanyDivPayout.Add(StockMarketManager.StockUtiList[i].divPayout);
			utiCompanyDivRecieved.Add(0);
		}

		//SKAPAR STORLEK PÅ LISTA EFTER ANTALET BOLAG
		for (int i = 0; i < StockMarketManager.StockTechList.Count; i++)
		{
			techCompanySharesOwned.Add(0);
			techCompanyDivPayout.Add(StockMarketManager.StockTechList[i].divPayout);
			techCompanyDivRecieved.Add(0);
		}

		for (int i = 0; i < StockMarketManager_1850.StockPrefabListMines.Count; i++)
		{
			minesCompanySharesOwned.Add(0);
			minesCompanyDivPayout.Add(StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().divPayout);
			minesCompanyDivRecieved.Add(0);
		}

		for(int i = 0; i < StockMarketManager_1850.StockPrefabListRailroad.Count; i++)
		{
			railroadCompanySharesOwned.Add(0);
			railroadCompanyDivPayout.Add(StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().divPayout);
			railroadCompanyDivRecieved.Add(0);
		}

		for (int i = 0; i < StockMarketManager_1850.StockPrefabListIndustri.Count; i++)
		{
			industriCompanySharesOwned.Add(0);
			industriCompanyDivPayout.Add(StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<divPolicyPrefab>().divPayoutPerShare);
			industriCompanyDivRecieved.Add(0);
		}

	}

	public void recievedDividends()
    {
		divRecPerYear.Add (0);
		//GÅR IGENOM SEKTOR FÖR SEKTOR

		//Gå igenom alla utilites-bolag
		for (int i = 0; i < StockMarketManager.StockUtiList.Count; i++) {
			utiCompanyDivPayout[i] = StockMarketManager.StockUtiList[i].GetComponent<stock>().divPayout;
			utiCompanySharesOwned[i] = PortfolioStock.utiCompanySharesOwned[i];
			utiCompanyDivRecieved[i] = utiCompanyDivPayout [i] * utiCompanySharesOwned [i];
			divRecPerYear[year] += utiCompanyDivRecieved[i];
		}

		//Gå igenom alla tech-bolag
		for (int i = 0; i < StockMarketManager.StockTechList.Count; i++)
		{
			techCompanyDivPayout[i] = StockMarketManager.StockTechList[i].GetComponent<stock>().divPayout;
			techCompanySharesOwned[i] = PortfolioStock.techCompanySharesOwned[i];
			techCompanyDivRecieved[i] = techCompanyDivPayout[i] * techCompanySharesOwned[i];
			divRecPerYear[year] += techCompanyDivRecieved[i];
		}

		//Gå igenom alla gruv-bolag
		for (int i = 0; i < StockMarketManager_1850.StockPrefabListMines.Count; i++)
		{
			//Debug.Log("Utdelningar Gruvor");
			minesCompanyDivPayout[i] = StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().divPayout;
			minesCompanySharesOwned[i] = PortfolioStock.minesCompanySharesOwned[i];
			minesCompanyDivRecieved[i] = minesCompanyDivPayout[i] * minesCompanySharesOwned[i];
			divRecPerYear[year] += minesCompanyDivRecieved[i];
		}

		//Gå igenom alla järnvägs-bolag
		for (int i = 0; i < StockMarketManager_1850.StockPrefabListRailroad.Count; i++)
		{
			//Debug.Log("Utdelningar Järnväg");
			railroadCompanyDivPayout[i] = StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().divPayout;
			railroadCompanySharesOwned[i] = PortfolioStock.railroadCompanySharesOwned[i];
			railroadCompanyDivRecieved[i] = railroadCompanyDivPayout[i] * railroadCompanySharesOwned[i];
			divRecPerYear[year] += railroadCompanyDivRecieved[i];
		}

		//Gå igenom alla Industri-bolag
		for (int i = 0; i < StockMarketManager_1850.StockPrefabListIndustri.Count; i++)
		{
			//Debug.Log("Utdelningar Industri");
			industriCompanyDivPayout[i] = StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<divPolicyPrefab>().divPayoutPerShare;
			industriCompanySharesOwned[i] = PortfolioStock.industriCompanySharesOwned[i];
			industriCompanyDivRecieved[i] = industriCompanyDivPayout[i] * industriCompanySharesOwned[i];
			divRecPerYear[year] += industriCompanyDivRecieved[i];
		}

		year++;
    }

	public float divIncomeFromPortfolioNow()
	{
		incomeDivFromPortfolioNow = 0;
		//Debug.Log(StockMarketManager.StockUtiList.Count);

		if (StockMarketManager != null)
		{
			for (int i = 0; i < StockMarketManager.StockUtiList.Count; i++)
			{
				utiCompanyDivPayout[i] = StockMarketManager.StockUtiList[i].GetComponent<stock>().divPayout;
				utiCompanySharesOwned[i] = PortfolioStock.utiCompanySharesOwned[i];
				utiCompanyDivRecieved[i] = utiCompanyDivPayout[i] * utiCompanySharesOwned[i];
				incomeDivFromPortfolioNow += utiCompanyDivRecieved[i];
			}

			//Debug.Log(StockMarketManager.StockTechList.Count);
			for (int i = 0; i < StockMarketManager.StockTechList.Count; i++)
			{
				techCompanyDivPayout[i] = StockMarketManager.StockTechList[i].GetComponent<stock>().divPayout;
				techCompanySharesOwned[i] = PortfolioStock.techCompanySharesOwned[i];
				techCompanyDivRecieved[i] = techCompanyDivPayout[i] * techCompanySharesOwned[i];
				incomeDivFromPortfolioNow += techCompanyDivRecieved[i];
			}
		}
		//Debug.Log(StockMarketManager.StockTechList.Count);
		
		for (int i = 0; i < StockMarketManager_1850.StockPrefabListMines.Count; i++)
		{
			minesCompanyDivPayout[i] = StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().divPayout;
			minesCompanySharesOwned[i] = PortfolioStock.minesCompanySharesOwned[i];
			minesCompanyDivRecieved[i] = minesCompanyDivPayout[i] * minesCompanySharesOwned[i];
			incomeDivFromPortfolioNow += minesCompanyDivRecieved[i];
		}

		for (int i = 0; i < StockMarketManager_1850.StockPrefabListRailroad.Count; i++)
		{
			railroadCompanyDivPayout[i] = StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().divPayout;
			railroadCompanySharesOwned[i] = PortfolioStock.railroadCompanySharesOwned[i];
			railroadCompanyDivRecieved[i] = railroadCompanyDivPayout[i] * railroadCompanySharesOwned[i];
			incomeDivFromPortfolioNow += railroadCompanyDivRecieved[i];
		}

		return incomeDivFromPortfolioNow;
	}
}

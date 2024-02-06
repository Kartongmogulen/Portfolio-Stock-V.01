using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GAV : MonoBehaviour
{
	//Beräkning av GAV, Genomsnittligt inköpspris
	public GameObject playerScriptsGO;
	public portfolioStock PortfolioStock;
	public stockMarketManager StockMarketManager;
	public stockMarketManager_1850 StockMarketManager_1850;
	public createListWithLength CreateListWithLength;
	public CityManager cityManager;
	public activeSector_1850 ActiveSector_1850;

	public Text companyGAVText;

	public List<float> utiCompanyGAVPlayer;
	public List<float> utiCompanySharesOwned;
	public List<float> utiTotalInvest;

	public List<float> techCompanyGAVPlayer;
	public List<float> techCompanySharesOwned;
	public List<float> techTotalInvest;

	//1850
	//public List<float> minesCompanyGAVPlayer;

	private void Awake()
	{
		PortfolioStock = playerScriptsGO.GetComponent<portfolioStock>();

		if(StockMarketManager != null)
		utiCompanyGAVPlayer = CreateListWithLength.listWithRightLengthFloat(StockMarketManager.StockPrefabUtiList.Count);

		if (StockMarketManager != null)
			techCompanyGAVPlayer = CreateListWithLength.listWithRightLengthFloat(StockMarketManager.StockTechList.Count);
		//minesCompanyGAVPlayer = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListMines.Count);
	}

	private void Update()
	{
		if (ActiveSector_1850.getActiveSector() == 0)
		{
			updateGAVText("Mines");
		}

		if (ActiveSector_1850.getActiveSector() == 1)
		{
			updateGAVText("Railroad");
		}

		if (ActiveSector_1850.getActiveSector() == 2)
		{
			updateGAVText("Industri");
		}
	}

	public float GAV_OwnedSharesAndInvestedCapital(float sharesOwned, float totalInvested)
	{
		if (sharesOwned == 0)
		{
			return 0;
		}
		else
		{
			return totalInvested / sharesOwned;
		}
	}

	public void updateGAVText(string sectorName)
	{
		if (sectorName == "Mines")
		companyGAVText.text = "GAV: " + Mathf.Round(PortfolioStock.minesCompanyGAV[cityManager.getActiveCity()]*100)/100;

		if (sectorName == "Railroad")
			companyGAVText.text = "GAV: " + Mathf.Round(PortfolioStock.railroadCompanyGAV[cityManager.getActiveCity()] * 100) / 100;

		if (sectorName == "Industri")
			companyGAVText.text = "GAV: " + Mathf.Round(PortfolioStock.industriCompanyGAV[cityManager.getActiveCity()] * 100) / 100;
	}

	public void minesGAV()
	{
		for (int i = 0; i < StockMarketManager_1850.StockPrefabListMines.Count; i++)
		{
			//Om inga andelar ägs sätts GAV till 0
			if (PortfolioStock.minesCompanySharesOwned[i] == 0)
			{
				PortfolioStock.minesCompanySharesOwned[i] = 0;
				PortfolioStock.mineTotalInvestAmount[i] = 0;
			}

			else
			{
				PortfolioStock.minesCompanyGAV[i] = PortfolioStock.mineTotalInvestAmount[i] / PortfolioStock.minesCompanySharesOwned[i];
			}
		}

		updateGAVText("Mines");
	}

	public void utiGAV()
	{
		utiCompanySharesOwned = PortfolioStock.utiCompanySharesOwned;
		utiTotalInvest = PortfolioStock.utiTotalInvest;

		for (int i = 0; i < utiCompanySharesOwned.Count; i++)
		{

			if (utiCompanySharesOwned[i] == 0)
			{
				utiCompanyGAVPlayer[i] = 0;
				PortfolioStock.utiTotalInvest[i] = 0;
			}
			else
			{
				utiCompanyGAVPlayer[i] = utiTotalInvest[i] / utiCompanySharesOwned[i];
			}
		}
		PortfolioStock.utiGAV = utiCompanyGAVPlayer;
	}

	public void techGAV()
	{
		techCompanySharesOwned = PortfolioStock.techCompanySharesOwned;
		techTotalInvest = PortfolioStock.techTotalInvest;

		for (int i = 0; i < techCompanySharesOwned.Count; i++)
		{

			if (techCompanySharesOwned[i] == 0)
			{
				techCompanyGAVPlayer[i] = 0;
				PortfolioStock.techTotalInvest[i] = 0;
			}
			else
			{
				techCompanyGAVPlayer[i] = techTotalInvest[i] / techCompanySharesOwned[i];
			}
		}
		PortfolioStock.techGAV = techCompanyGAVPlayer;
	}

	public void utiGAVSell()
	{
		for (int i = 0; i < utiCompanySharesOwned.Count; i++)
		{

			if (utiCompanySharesOwned[i] == 0)
			{
				utiCompanyGAVPlayer[i] = 0;
				PortfolioStock.utiTotalInvest[i] = 0;
			}
		}
	}

	public void techGAVSell()
	{
		for (int i = 0; i < techCompanySharesOwned.Count; i++)
		{
			if (techCompanySharesOwned[i] == 0)
			{
				techCompanyGAVPlayer[i] = 0;
				PortfolioStock.techTotalInvest[i] = 0;
			}
		}
	}
}
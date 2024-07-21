using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orderValue : MonoBehaviour
{
	public GameObject buttonGO;
	public GameObject stockGO;
	public InputField inputOrderAmount;
	public chooseStockSector ChooseStockSector;
	public buyStock BuyStock;
	public Text orderValueText;


	//1850
	public activeSector_1850 ActiveSector_1850;
	public CityManager cityManager;
	public stockMarketManager_1850 StockMarketManager_1850;
	public Text orderValueText_1850;
	public InputField inputOrderAmount_1850;

	public int activeCompany;
	public int activeSector;
	public int amountOrder;
	public float stockPrice;

	void Awake()
	{
		ChooseStockSector = buttonGO.GetComponent<chooseStockSector>();
		BuyStock = buttonGO.GetComponent<buyStock>();
	}

	private void Update()
	{
		onChangeInput_1850();
	}

	public void onChangeInput()
	{
		if (inputOrderAmount.text != "")
		{
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

			if (orderValueText.text == "")
			{
				amountOrder = 0;
			}
			else
				amountOrder = int.Parse(inputOrderAmount.text);

			orderValueText.text = "Value order: " + amountOrder * stockPrice;
		}
	}

	public void onChangeInput_1850()
	{
		if (inputOrderAmount_1850.text != "")
		{
			activeSector = ActiveSector_1850.getActiveSector();
			//Debug.Log("Get active sector: " + activeSector);

			//Identifera vilket företag (nr)
			if (activeSector == 0)
			{
				//activeCompany = StockMarketManager_1850.StockPrefabListMines[0];
				stockPrice = StockMarketManager_1850.StockPrefabListMines[cityManager.getActiveCity()].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListMines[0].GetComponent<stock>().StockPrice.Count-1];
			}

			if (activeSector == 1)
			{
				//activeCompany = StockMarketManager_1850.StockPrefabListMines[0];
				stockPrice = StockMarketManager_1850.StockPrefabListRailroad[cityManager.getActiveCity()].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListRailroad[0].GetComponent<stock>().StockPrice.Count - 1];
			}

			if (activeSector == 2 && StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<priceStock>() != null)
			{
				//activeCompany = StockMarketManager_1850.StockPrefabListMines[0];
				stockPrice = StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<priceStock>().StockPrice[StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<priceStock>().StockPrice.Count - 1];
			}
			else if (activeSector == 2)
			{
				stockPrice = StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListIndustri[0].GetComponent<stock>().StockPrice.Count - 1];
			}

			/*
			else if (orderValueText.text == "")
			{
				amountOrder = 0;
			}
			*/
			//else
				amountOrder = int.Parse(inputOrderAmount_1850.text);

			orderValueText_1850.text = "Value order: " + amountOrder * stockPrice;
		}
	}

}
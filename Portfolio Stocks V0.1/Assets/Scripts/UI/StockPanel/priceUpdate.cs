using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class priceUpdate : MonoBehaviour
{
    public Text priceText;
    public CityManager cityManager;
    public activeSector_1850 ActiveSector_1850;
    public stockMarketManager_1850 StockMarketManager_1850;

    [SerializeField] float stockPrice;

    private void Update()
    {
        updatePriceText_1850();
    }

    public void updatePriceText_1850()
    {
        if (ActiveSector_1850.getActiveSector() == 0)
        {
            {
                stockPrice = StockMarketManager_1850.StockPrefabListMines[cityManager.getActiveCity()].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListMines[0].GetComponent<stock>().StockPrice.Count - 1];
            }
        }

        else if (ActiveSector_1850.getActiveSector() == 1)
        {
            {
                stockPrice = StockMarketManager_1850.StockPrefabListRailroad[cityManager.getActiveCity()].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListMines[0].GetComponent<stock>().StockPrice.Count - 1];
            }
        }

        else if (ActiveSector_1850.getActiveSector() == 2)
        {
            {
                stockPrice = StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<priceStock>().StockPrice[StockMarketManager_1850.StockPrefabListIndustri[cityManager.getActiveCity()].GetComponent<priceStock>().StockPrice.Count - 1];
            }
        }

        priceText.text = "Price: " + stockPrice;
    }
}
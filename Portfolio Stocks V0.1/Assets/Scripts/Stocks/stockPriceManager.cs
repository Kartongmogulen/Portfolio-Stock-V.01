using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stockPriceManager : MonoBehaviour
{
    public GameObject ScriptsStockGO;
    public GameObject StockMarketGO;

    public stockMarketManager StockMarketManager;
    public stockMarketManager_1850 StockMarketManager_1850;

    public GameObject stockSector_1;

    public GameObject stockScript;
    public DCF dcfCalculation;

    public float priceNow;
    private void Awake()
    {
        StockMarketManager = StockMarketGO.GetComponent<stockMarketManager>(); 
    }

    public void Start()
    {
        //updateStockMarketPrice();
    }

    public void updateStockMarketPrice()
    {
        for (int i = 0; i < StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++) {
            priceNow = ScriptsStockGO.GetComponent<priceChange>().DCFbasedPriceTest(StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i]);
            StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i].StockPrice.Add(priceNow);
        }

        for (int i = 0; i < StockMarketManager_1850.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++)
        {
            //Debug.Log("Price manager: " + i);
            priceNow = ScriptsStockGO.GetComponent<priceChange>().DCFbasedPriceTest(StockMarketManager_1850.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i]);
            StockMarketManager_1850.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i].StockPrice.Add(priceNow);
        }

        for (int i = 0; i < StockMarketManager_1850.StockPrefabListIndustri.Count; i++)
        {
            //Debug.Log("Price manager: " + i);
            if (StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<incomeStatement>() != null)
            {
                priceNow = ScriptsStockGO.GetComponent<priceChange>().DCFbasedPrice_OneCompany_IncomeStatement(StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<incomeStatement>());
                StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().StockPrice.Add(priceNow);
            }
            else
            {
                priceNow = ScriptsStockGO.GetComponent<priceChange>().DCFbasedPriceTest(StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stock>());
                //StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stock>().StockPrice.Add(priceNow);
            }
                //Debug.Log("Pris nu: " + priceNow);
            //StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().StockPrice.Add(priceNow);
        }

    }

    public void priceUpdate_RevenueGrowth()
    {
        //Debug.Log("PriceUpdate_RevenueGrowth");
        for (int i = 0; i < StockMarketGO.GetComponent<stockMarketInventory>().masterList.Count; i++)
        {
            int priceNowTotalCompany = ScriptsStockGO.GetComponent<priceChange>().DCFbasedPrice_HistoricRevenueGrowth(StockMarketGO.GetComponent<stockMarketInventory>().masterList[i].GetComponent<incomeStatement>());
            //Debug.Log("PRIS: " + priceNowTotalCompany);
            //Debug.Log("Antal aktier: " + StockMarketGO.GetComponent<stockMarketInventory>().masterList[i].GetComponent<stockInformation>().getNumberOfShares());
            int priceNow = priceNowTotalCompany / StockMarketGO.GetComponent<stockMarketInventory>().masterList[i].GetComponent<stockInformation>().getNumberOfShares();
            StockMarketGO.GetComponent<stockMarketInventory>().masterList[i].GetComponent<priceStock>().StockPrice.Add(priceNow);
        }
    }
}

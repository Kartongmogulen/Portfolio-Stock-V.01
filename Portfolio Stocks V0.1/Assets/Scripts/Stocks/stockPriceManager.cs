using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stockPriceManager : MonoBehaviour
{
    public GameObject ScriptsStockGO;
    public GameObject StockMarketGO;

    public stockMarketManager StockMarketManager;
 
    public GameObject stockScript;
    public DCF dcfCalculation;

    public float priceNow;

    public List<float> StockPriceUtiOne;

    private void Start()
    {
        StockMarketManager = StockMarketGO.GetComponent<stockMarketManager>();
        updateStockMarketPrice();
    }

    public void updateStockMarketPrice()
    {
        for (int i = 0; i < StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++) { 
        priceNow = ScriptsStockGO.GetComponent<priceChange>().DCFbasedPriceTest(StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i]);
        StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i].StockPrice.Add(priceNow);
        }
    }

}

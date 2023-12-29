using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class allStocksComparisonLayout : MonoBehaviour
{
    public stockMarketInventory StockMarketInventory;
    public stockMarketManager_1850 StockMarketManager_1850;

    //Text
    public List<Text> nameStocksList;

    //P/E-tal nu
    public List<Text> PriceEarningsList;

    //P/E-tal nu
    public List<Slider> Trailing12MonthPrice;
    public trailing12MonthSliderPosition Trailing12MonthSliderPosition;

    public void updateAllText()
    {
        updateNameText();
        updatePriceEarningsText();
        updateTrailing12MonthPrice();
    }

    public void updateAllText_1850()
    {
        updateNameText_1850();
        updatePriceEarningsText_1850();
        //updateTrailing12MonthPrice();
    }

    public void updateNameText()
    {
        //Debug.Log(StockMarketInventory.Stock.Count);
        for (int i = 0;  i < StockMarketInventory.Stock.Count; i++)
        {
            nameStocksList[i].text = StockMarketInventory.Stock[i].nameOfCompany;
        }
    }

    public void updateNameText_1850()
    {
        //Debug.Log(StockMarketInventory.Stock.Count);
        for (int i = 0; i < StockMarketManager_1850.StockPrefabListMines.Count; i++)
        {
            nameStocksList[i].text = StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().nameOfCompany;
        }

        int intToStartFrom = StockMarketManager_1850.StockPrefabListMines.Count;
        Debug.Log(intToStartFrom);

        for (int i = intToStartFrom; i < intToStartFrom + StockMarketManager_1850.StockPrefabListRailroad.Count; i++)
        {
            Debug.Log("i: " + i);
            Debug.Log("intToStartFrom: " + intToStartFrom);
            nameStocksList[i].text = StockMarketManager_1850.StockPrefabListRailroad[i-intToStartFrom].GetComponent<stock>().nameOfCompany;
        }
    }

    public void updatePriceEarningsText()
    {
        for (int i = 0; i < StockMarketInventory.Stock.Count; i++)
        {
            PriceEarningsList[i].text = "" + Mathf.Round((StockMarketInventory.Stock[i].StockPrice[StockMarketInventory.Stock[i].StockPrice.Count-1]/ StockMarketInventory.Stock[i].EPSnow) * 100)/100;
        }
    }

    public void updatePriceEarningsText_1850()
    {
        for (int i = 0; i < StockMarketManager_1850.StockPrefabListMines.Count; i++)
        {
            float priceNow = StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice.Count - 1];
            float EPSNow = StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().EPSnow;
            Debug.Log("Pris: " + priceNow);
            Debug.Log("EPS nu: " + EPSNow);
            PriceEarningsList[i].text = "" + Mathf.Round(priceNow / EPSNow*100)/100;
        }
    }

    public void updateTrailing12MonthPrice()
    {
        
        for (int i = 0; i < StockMarketInventory.Stock.Count; i++)
        {
            Trailing12MonthPrice[i].value = Trailing12MonthSliderPosition.slidersRelativePoistionFromTwoValues(StockMarketInventory.Stock[i].StockPrice[StockMarketInventory.Stock[i].StockPrice.Count - 1], StockMarketInventory.Stock[i].trailingTwelweMonthLow, StockMarketInventory.Stock[i].trailingTwelweMonthHigh);
        }
    }

}

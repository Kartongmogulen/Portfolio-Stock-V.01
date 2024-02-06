using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class allStocksComparisonLayout : MonoBehaviour
{
    public stockMarketInventory StockMarketInventory;
    public stockMarketManager_1850 StockMarketManager_1850;

    public bool minesActive;
    public bool railroadActive;
    public bool industriActive;

    //Text
    public List<Text> nameStocksList;
    public List<Text> nameMinesList;
    public GameObject nameGO_Mines;
    public List<Text> nameRailRoadList;
    public GameObject nameGO_RailRoad;
    public List<Text> nameIndustriList;
    public GameObject nameGO_Industri;

    //P/E-tal nu
    public List<Text> PriceEarningsList;
    public List<Text> PriceEarningsListMines;
    public GameObject PriceEarningsGOMines;
    public List<Text> PriceEarningsListRailroad;
    public GameObject PriceEarningsGORailroad;
    public List<Text> PriceEarningsListIndustri;
    public GameObject PriceEarningsGOIndustri;

    //52week Interval
    public List<Slider> Trailing12MonthPrice;
    public trailing12MonthSliderPosition Trailing12MonthSliderPosition;

    public List<Slider> Trailing12MonthPrice_Mines;
    public GameObject week52IntervalGO_Mines;

    public List<Slider> Trailing12MonthPrice_Railroad;
    public GameObject week52IntervalGO_Railroad;

    public List<Slider> Trailing12MonthPrice_Índustri;
    public GameObject week52IntervalGO_Industri;

    private void Start ()
    {
        InvokeRepeating("updateAllText_1850", 0.5f, 0.1f);
        
    }

    public void updateAllText()
    {
        updateNameText();
        updatePriceEarningsText();
        updateTrailing12MonthPrice();
    }

    public void updateAllText_1850()
    {
        isPanelActive();
        updateNameText_1850();
        updatePriceEarningsText_1850();
        updateTrailing12MonthPrice_1850();
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

            
            for (int i = 0;i < StockMarketManager_1850.StockPrefabListRailroad.Count; i++)
            {
                //Debug.Log("i: " + i);
                //Debug.Log("intToStartFrom: " + intToStartFrom);
                nameRailRoadList[i].text = StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().nameOfCompany;
            }

        for (int i = 0; i < StockMarketManager_1850.StockPrefabListIndustri.Count; i++)
        {
            //Debug.Log("i: " + i);
            //Debug.Log("intToStartFrom: " + intToStartFrom);
            nameIndustriList[i].text = StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stockInformation>().nameCompany;
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
            PriceEarningsList[i].text = "" + Mathf.Round(priceNow / EPSNow*100)/100;
        }
        
            for (int i = 0; i < StockMarketManager_1850.StockPrefabListRailroad.Count; i++)
            {
                float priceNow = StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().StockPrice.Count - 1];
                float EPSNow = StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().EPSnow;
                //Debug.Log("Pris: " + priceNow);
                //Debug.Log("EPS nu: " + EPSNow);
                PriceEarningsListRailroad[i].text = "" + Mathf.Round(priceNow / EPSNow * 100) / 100;
                //PriceEarningsList[i].text = "" + Mathf.Round(priceNow / EPSNow * 100) / 100;
            }

        for (int i = 0; i < StockMarketManager_1850.StockPrefabListIndustri.Count; i++)
        {
            float priceNow = StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().StockPrice[StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().StockPrice.Count - 1];
            //float EPSNow = StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<incomeStatement>().EarningPerShareHistory[StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<incomeStatement>().EarningPerShareHistory.Count-1];

            float EPSNow = StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<incomeStatement>().getEarningsPerShareNow();
            //Debug.Log("Pris: " + priceNow);
            //Debug.Log("EPS nu: " + EPSNow);
            PriceEarningsListIndustri[i].text = "" + Mathf.Round(priceNow / EPSNow * 100) / 100;
            //PriceEarningsList[i].text = "" + Mathf.Round(priceNow / EPSNow * 100) / 100;
        }

    }

    public void updateTrailing12MonthPrice()
    {
        
        for (int i = 0; i < StockMarketInventory.Stock.Count; i++)
        {
            Trailing12MonthPrice[i].value = Trailing12MonthSliderPosition.slidersRelativePoistionFromTwoValues(StockMarketInventory.Stock[i].StockPrice[StockMarketInventory.Stock[i].StockPrice.Count - 1], StockMarketInventory.Stock[i].trailingTwelweMonthLow, StockMarketInventory.Stock[i].trailingTwelweMonthHigh);
        }
    }

    public void updateTrailing12MonthPrice_1850()
    {
        //Debug.Log("Trailing12Month_1850");
        float priceNow;
        float low52Week;
        float high52Week;

        for (int i = 0; i < StockMarketManager_1850.StockPrefabListMines.Count; i++)
        {
            priceNow = StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice.Count - 1];
            low52Week = StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().trailingTwelweMonthLow;
            high52Week = StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().trailingTwelweMonthHigh;
            //Debug.Log("Pris nu: " + priceNow);
            //Debug.Log("low52Week: " + low52Week);
            Trailing12MonthPrice_Mines[i].value = Trailing12MonthSliderPosition.slidersRelativePoistionFromTwoValues(priceNow,low52Week, high52Week);
        }

        for (int i = 0; i < StockMarketManager_1850.StockPrefabListRailroad.Count; i++)
        {
            priceNow = StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().StockPrice.Count - 1];
            low52Week = StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().trailingTwelweMonthLow;
            high52Week = StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().trailingTwelweMonthHigh;
            //Debug.Log("Pris nu: " + priceNow);
            //Debug.Log("low52Week: Railroad" + low52Week);
            Trailing12MonthPrice_Railroad[i].value = Trailing12MonthSliderPosition.slidersRelativePoistionFromTwoValues(priceNow, low52Week, high52Week);
        }

        
        for (int i = 0; i < StockMarketManager_1850.StockPrefabListIndustri.Count; i++)
        {
            priceNow = StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().StockPrice[StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().StockPrice.Count - 1];
            low52Week = StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().getTrailingTwelveMonthLow();
            high52Week = StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().getTrailingTwelveMonthHigh();
            //Debug.Log("Pris nu: " + priceNow);
            //Debug.Log("PriceNow: Industri" + priceNow);
            //Debug.Log("Low52: " + low52Week);
            //Debug.Log("High52: " + high52Week);
            Trailing12MonthPrice_Índustri[i].value = Trailing12MonthSliderPosition.slidersRelativePoistionFromTwoValues(priceNow, low52Week, high52Week);
        }
        
    }

    public void isPanelActive()
    {
        if (minesActive == true)
        {
            nameGO_Mines.SetActive(true);
            PriceEarningsGOMines.SetActive(true);
            week52IntervalGO_Mines.SetActive(true);
        }
        else
        {
            nameGO_Mines.SetActive(false);
            PriceEarningsGOMines.SetActive(false);
            week52IntervalGO_Mines.SetActive(false);
        }

        if (railroadActive == true)
        {
            nameGO_RailRoad.SetActive(true);
            PriceEarningsGORailroad.SetActive(true);
            week52IntervalGO_Railroad.SetActive(true);
        }
        else
        {
            nameGO_RailRoad.SetActive(false);
            PriceEarningsGORailroad.SetActive(false);
            week52IntervalGO_Railroad.SetActive(false);
        }

        if (industriActive == true)
        {
            nameGO_Industri.SetActive(true);
            PriceEarningsGOIndustri.SetActive(true);
            //week52IntervalGO_Industri.SetActive(true);
        }
        else
        {
            nameGO_Industri.SetActive(false);
            PriceEarningsGORailroad.SetActive(false);
            //week52IntervalGO_Railroad.SetActive(false);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volatilityCalculation : MonoBehaviour
{
    //public float totalVolatility;
    public stockMarketManager_1850 StockMarketManager_1850;
    public standardDeviationCalculation StandardDeviationCalculation;
    public averageCalculation AverageCalculation;

    public List<float> stockPrices;

    public List<priceStock> PriceStocksList;

    private void Start()
    {
        Invoke("last12Month",0.1f);
        
    }

    public float calculateVolatilty(List<float> stockPrices)
    {
        return StandardDeviationCalculation.calculateStandardDeviation(stockPrices);

        //return totalVolatility;
    }

    public void calculateVolatilty_StockAsInput(stock Stock)
    {
        Debug.Log("Volla: " + calculateVolatilty(Stock.StockPrice));
    }

    public void calculateVolatility_1850()
    {
        for (int i = 0; i < StockMarketManager_1850.StockPrefabListMines.Count; i++)
        {
            StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().volatilityAbs = calculateVolatilty(StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice);
        }
    }

    public void last12Month()
    {

        for (int i = 0; i < StockMarketManager_1850.StockPrefabListMines.Count; i++)
        {
            //stockPrices.Clear();
            for (int a = 0; a < 12; a++)
            {
                //Debug.Log("Loop2: " + a);
                stockPrices.Add(StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice.Count - 12 + a]);
            }
            //Debug.Log("Priser: " + stockPrices);
            StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().volatilityAbs = calculateVolatilty(stockPrices);
            StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().volatilityPercent = StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().volatilityAbs / AverageCalculation.listOfFloats(stockPrices);

            stockPrices.Clear();
        }

        for (int i = 0; i < StockMarketManager_1850.StockPrefabListRailroad.Count; i++)
        {
            //stockPrices.Clear();
            for (int a = 0; a < 12; a++)
            {
                //Debug.Log("Loop2: " + a);
                stockPrices.Add(StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().StockPrice.Count - 12 + a]);
            }
            //Debug.Log("Priser: " + stockPrices);
            StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().volatilityAbs = calculateVolatilty(stockPrices);
            StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().volatilityPercent = StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().volatilityAbs / AverageCalculation.listOfFloats(stockPrices);

            stockPrices.Clear();
        }

        for (int i = 0; i < StockMarketManager_1850.StockPrefabListIndustri.Count; i++)
        {
            //stockPrices.Clear();
            for (int a = 0; a < 12; a++)
            {
                //Debug.Log("Loop2: " + a);
                stockPrices.Add(StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stock>().StockPrice.Count - 12 + a]);
            }
            //Debug.Log("Priser: " + stockPrices);
            StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stock>().volatilityAbs = calculateVolatilty(stockPrices);
            StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stock>().volatilityPercent = StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stock>().volatilityAbs / AverageCalculation.listOfFloats(stockPrices);

            stockPrices.Clear();
        }

        //last12Month_Products(PriceStocksList); //KOMMENTERADE BORT FÖR ATT FUNKA VID V.5.2 UTAN NÅGRA BOLAG MED PRODUKTER
    }

    public void last12Month_Products(List<priceStock> ListStockPrices)
    {
        stockPrices.Clear();
        for (int i = 0; i < ListStockPrices.Count; i++)
        {

            for (int a = 0; a < 12; a++)
            {
                //Debug.Log("Loop2: " + a);
                stockPrices.Add(ListStockPrices[i].StockPrice[ListStockPrices[i].StockPrice.Count - 12 + a]);//StockPrice[StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice.Count - 12 + a]);
            }

            ListStockPrices[i].setVolatilityAbs(calculateVolatilty(stockPrices));
            ListStockPrices[i].setVolatilityPercent(calculateVolatilty(stockPrices), AverageCalculation.listOfFloats(stockPrices));
        }
    }

        public void last12Month_OneStock(stock Stock)
    {

        stockPrices.Clear();
        for (int a = 0; a < 12; a++)
        {
            //Debug.Log("Loop2: " + a);
            stockPrices.Add(Stock.StockPrice[Stock.StockPrice.Count - 12 + a]);
        }
        Stock.volatilityAbs = calculateVolatilty(stockPrices);
        Debug.Log("Name: " + Stock.name + " - " + Stock.volatilityAbs);
    }
}

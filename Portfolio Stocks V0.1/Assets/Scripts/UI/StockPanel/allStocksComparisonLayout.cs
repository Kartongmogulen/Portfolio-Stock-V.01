using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class allStocksComparisonLayout : MonoBehaviour
{
    public stockMarketInventory StockMarketInventory;

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

    public void updateNameText()
    {
        for (int i = 0;  i < StockMarketInventory.Stock.Count; i++)
        {
            nameStocksList[i].text = StockMarketInventory.Stock[i].nameOfCompany;
        }
    }

    public void updatePriceEarningsText()
    {
        for (int i = 0; i < StockMarketInventory.Stock.Count; i++)
        {
            PriceEarningsList[i].text = "" + Mathf.Round((StockMarketInventory.Stock[i].StockPrice[StockMarketInventory.Stock[i].StockPrice.Count-1]/ StockMarketInventory.Stock[i].EPSnow) * 100)/100;
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

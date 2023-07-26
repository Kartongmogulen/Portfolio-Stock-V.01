using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailing12MonthHighLowCalculation : MonoBehaviour
{
    //Beräknar högsta samt lägsta värdet senaste 12 månaderna

    public float valueHigh;
    public float valueLow;
    public int amountOfValuesToGet12Month; //Om det är månadsvärden ska det vara 12. Veckodata = 52;
    public List<float> last12Numbers;
    public List<float> allDataBeforeCleaning; //All data innan man rensat

    public stockMarketManager StockMarketManager;

   public void updateDataForStocks()
    {
        for (int i = 0; i < StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++)
        {
            //Hämta data
           allDataBeforeCleaning = StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i].StockPrice;
           last12Numbers = allDataBeforeCleaning.GetRange(allDataBeforeCleaning.Count - amountOfValuesToGet12Month, amountOfValuesToGet12Month);
           
            //Högsta värdet
           valueHigh = findHighestValue(last12Numbers);
           StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i].trailingTwelweMonthHigh = valueHigh;

            //Lägsta värdet
            valueLow = findLowestValue(last12Numbers);
            StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i].trailingTwelweMonthLow = valueLow;
        }
    }

    public float findHighestValue(List<float> values)
    {
        valueHigh = values[0];

        foreach (float number in values)
        {
            if (number > valueHigh)
            {
                valueHigh = number;
            }
        }
        return valueHigh;
    }

    public float findLowestValue(List<float> values)
    {
        valueLow = values[0];

        foreach (float number in values)
        {
            if (number < valueLow)
            {
                valueLow = number;
            }
        }
        return valueLow;
    }
}

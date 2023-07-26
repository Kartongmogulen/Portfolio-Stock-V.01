using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailing12MonthHighLowCalculation : MonoBehaviour
{
    //Ber�knar h�gsta samt l�gsta v�rdet senaste 12 m�naderna

    public float valueHigh;
    public float valueLow;
    public int amountOfValuesToGet12Month; //Om det �r m�nadsv�rden ska det vara 12. Veckodata = 52;
    public List<float> last12Numbers;
    public List<float> allDataBeforeCleaning; //All data innan man rensat

    public stockMarketManager StockMarketManager;

   public void updateDataForStocks()
    {
        for (int i = 0; i < StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++)
        {
            //H�mta data
           allDataBeforeCleaning = StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i].StockPrice;
           last12Numbers = allDataBeforeCleaning.GetRange(allDataBeforeCleaning.Count - amountOfValuesToGet12Month, amountOfValuesToGet12Month);
           
            //H�gsta v�rdet
           valueHigh = findHighestValue(last12Numbers);
           StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i].trailingTwelweMonthHigh = valueHigh;

            //L�gsta v�rdet
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

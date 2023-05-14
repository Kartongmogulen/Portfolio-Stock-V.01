using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compareStockReturn : MonoBehaviour
{
    /// <summary>
    /// J�mf�r vilken aktie som gett b�st avkastning
    /// </summary>

    public stockMarketManager StockMarketManager;
    public int highestReturnStockInt;
    public int highestReturnStockUtiInt;

    private void Start()
    {

        //Debug.Log(StockMarketManager.StockPrefabUtiList[0].GetComponent<stockSpecificCompany100>().returnOnInvestment[StockMarketManager.StockPrefabUtiList[0].GetComponent<stockSpecificCompany100>().returnOnInvestment.Count]);
    }

    public void highestReturn()
    {
        for (int i = 1; i < StockMarketManager.StockPrefabAllList.Count; i++)
        {
            Debug.Log("ForLoop");
            //Debug.Log(StockMarketManager.StockPrefabUtiList[i].GetComponent<stockSpecificCompany100>().returnOnInvestment[StockMarketManager.StockPrefabUtiList[i].GetComponent<stockSpecificCompany100>().returnOnInvestment.Count-1]);
            //StockMarketManager.StockPrefabUtiList[i].GetComponent<stockSpecificCompany100>().returnOnInvestment.Count]);

            if (StockMarketManager.StockPrefabAllList[i].GetComponent<stockSpecificCompany100>().returnOnInvestment[StockMarketManager.StockPrefabAllList[i].GetComponent<stockSpecificCompany100>().returnOnInvestment.Count - 1] > StockMarketManager.StockPrefabAllList[i - 1].GetComponent<stockSpecificCompany100>().returnOnInvestment[StockMarketManager.StockPrefabAllList[i - 1].GetComponent<stockSpecificCompany100>().returnOnInvestment.Count - 1])
            {
                highestReturnStockInt = i;

            }
            else
            {
                highestReturnStockInt = i - 1;
            }
            Debug.Log("B�st avkastning: " + highestReturnStockInt);
        }
    }

        public void highestReturnUti()
    {
        for (int i = 1; i < StockMarketManager.StockPrefabUtiList.Count; i++)
        {
            Debug.Log("ForLoop");
            //Debug.Log(StockMarketManager.StockPrefabUtiList[i].GetComponent<stockSpecificCompany100>().returnOnInvestment[StockMarketManager.StockPrefabUtiList[i].GetComponent<stockSpecificCompany100>().returnOnInvestment.Count-1]);
                //StockMarketManager.StockPrefabUtiList[i].GetComponent<stockSpecificCompany100>().returnOnInvestment.Count]);

            if (StockMarketManager.StockPrefabUtiList[i].GetComponent<stockSpecificCompany100>().returnOnInvestment[StockMarketManager.StockPrefabUtiList[i].GetComponent<stockSpecificCompany100>().returnOnInvestment.Count-1] > StockMarketManager.StockPrefabUtiList[i-1].GetComponent<stockSpecificCompany100>().returnOnInvestment[StockMarketManager.StockPrefabUtiList[i-1].GetComponent<stockSpecificCompany100>().returnOnInvestment.Count-1])
            {
                highestReturnStockUtiInt = i;
               
            }
            else
            {
                highestReturnStockUtiInt = i-1;
            }
            Debug.Log("B�st avkastning: " + highestReturnStockUtiInt);
        }
    }


}

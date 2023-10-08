using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataPlayerKnowFromStartManager : MonoBehaviour
{
    //Vilken data ska spelaren veta när spelet startar

    public bool earningPerShareknowAllHistoric;
    public bool E_P_SChangeYearOverYearKnowAllHistoric;
    public bool DividendChangeYearOverYearKnowAllHistoric;
    public bool PayoutRatioYearKnowAllHistoric;

    public stockMarketManager StockMarketManager;

    private void Start()
    {
        playerKnowEPSHistory();
        playerKnowEPSChangeHistory();
        playerKnowDividendChangeHistory();
        playerKnowPayoutRatioHistory();
    }

    public void playerKnowEPSHistory()
    {
        if (earningPerShareknowAllHistoric == true)
        {
            foreach (GameObject stockPrefab in StockMarketManager.StockPrefabAllList)
            {

                for (int i = 0; i < stockPrefab.GetComponent<stockDataPlayerKnow>().EPSdata.Count; i++)
                {
                    stockPrefab.GetComponent<stockDataPlayerKnow>().EPSdata[i] = true;
                }
                
            }
        }
    }

    public void playerKnowEPSChangeHistory()
    {
        if (E_P_SChangeYearOverYearKnowAllHistoric == true)
        {
            foreach (GameObject stockPrefab in StockMarketManager.StockPrefabAllList)
            {

                for (int i = 0; i < stockPrefab.GetComponent<stockDataPlayerKnow>().EPSYoYChangedata.Count; i++)
                {
                    stockPrefab.GetComponent<stockDataPlayerKnow>().EPSYoYChangedata[i] = true;
                }

            }
        }
    }

    public void playerKnowDividendChangeHistory()
    {
        if (DividendChangeYearOverYearKnowAllHistoric == true)
        {
            foreach (GameObject stockPrefab in StockMarketManager.StockPrefabAllList)
            {

                for (int i = 0; i < stockPrefab.GetComponent<stockDataPlayerKnow>().DividendYoYChangedata.Count; i++)
                {
                    stockPrefab.GetComponent<stockDataPlayerKnow>().DividendYoYChangedata[i] = true;
                }

            }
        }

    }

    public void playerKnowPayoutRatioHistory()
    {
        if (PayoutRatioYearKnowAllHistoric == true)
        {
            foreach (GameObject stockPrefab in StockMarketManager.StockPrefabAllList)
            {

                for (int i = 0; i < stockPrefab.GetComponent<stockDataPlayerKnow>().PayoutRatiodata.Count; i++)
                {
                    stockPrefab.GetComponent<stockDataPlayerKnow>().PayoutRatiodata[i] = true;
                }

            }
        }

    }

}

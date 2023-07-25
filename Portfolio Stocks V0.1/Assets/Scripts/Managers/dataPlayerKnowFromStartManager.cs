using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataPlayerKnowFromStartManager : MonoBehaviour
{
    //Vilken data ska spelaren veta när spelet startar

    public bool earningPerShareknowAllHistoric;
    public bool earningPerShareChangeYearOverYearKnowAllHistoric;

    public stockMarketManager StockMarketManager;

    private void Start()
    {
        playerKnowEPSHistory();
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
}

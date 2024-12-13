using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    public stockMarketInventory StockMarketInventory;

    public void yearEndCheck()
    {
        for (int i = 0; i < StockMarketInventory.masterList.Count; i++)
        {
            StockMarketInventory.masterList[i].GetComponent<fisherCompanyManager>().yearEnd();
        }
    }
}

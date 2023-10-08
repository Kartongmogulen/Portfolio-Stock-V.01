using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createHistoricDataStocks : MonoBehaviour
{
    public gamePlayScopeManager GamePlayScopeManager;
    public stockPriceManager StockPriceManager;
    public GameObject StockScriptGO;
    public GameObject EconomyScriptGO;

    private int numberOfYearsToCreateData;

    // Start is called before the first frame update
    void Start()
    {
        numberOfYearsToCreateData = GamePlayScopeManager.yearsToGetHistoricData;

        for (int i = 0; i<numberOfYearsToCreateData; i++)
        {
            createHistoricData();
        }
    }

    public void createHistoricData()
    {
        //Ska köras varje månad
        for (int i = 0; i < 12; i++)
        {
            StockPriceManager.updateStockMarketPrice();

            if (i >= 11)
            {
                StockScriptGO.GetComponent<companyNumbersUpdate>().updateYearEnd();
                EconomyScriptGO.GetComponent<economicClimate>().updateEcoClimate();
                EconomyScriptGO.GetComponent<eventAtDifferentEcoClimateManager>().valAvSektor();
            }
        }
    }
}

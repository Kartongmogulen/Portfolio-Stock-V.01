using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createHistoricData_Fisher : MonoBehaviour
{

    public gamePlayScopeManager GamePlayScopeManager;
    public catchFish CatchFish;
    public stockPriceManager StockPriceManager;
    public GameLoopManager gameLoopManager;
    
    [SerializeField] int numberOfYearsToCreateData;
    //[SerializeField] int numberOfIterationToCreateData;

    // Start is called before the first frame update
    void Start()
    {
        /*if (numberOfYearsToCreateData == 0)
        {
            numberOfYearsToCreateData = GamePlayScopeManager.yearsToGetHistoricData;
        }*/

        createHistoricData(numberOfYearsToCreateData*12);

        //Invoke("createHistoricData", 0.1f);

    }

    public void createHistoricData(int numberOfIterationToCreateData)
    {
        //Debug.Log("Skapa historisk data: 1");
        for (int i = 1; i < numberOfIterationToCreateData+1; i++) {
            //Debug.Log("Antal iterationer: " + i);
            //Ska köras varje månad
            //for (int a = 0; a < 12; i++)
            //{
            
                CatchFish.finishOneRound();

            if (i > 24)
            {
                StockPriceManager.priceUpdate_RevenueGrowth();
            }
            if (i % 12 == 0)
            {
                //Debug.Log("End of year");
                gameLoopManager.yearEndCheck();
            }

        }
    }
}


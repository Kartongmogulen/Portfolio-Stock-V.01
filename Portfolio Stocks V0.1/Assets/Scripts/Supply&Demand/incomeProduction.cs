using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incomeProduction : MonoBehaviour
{
    //Hanterar int�kter fr�n egen produktion
    //1. M�ngd produktion per behov
    //2. Pris per behov
    //3. Int�kter per behov
    //4. �ka spelarens pengar

    [SerializeField] productionPlayer ProductionPlayer;
    [SerializeField] SupplyDemandManager supplyDemandManager;
    [SerializeField] totalCash TotalCash;
    [SerializeField] float incomeTotal;
    [SerializeField] float incomeFood;
    [SerializeField] float incomeWater;
    [SerializeField] float incomeWood;

    public void incomeCalc()
    {
        Debug.Log("Int�kter fr�n egen produktion");
        foreach (NeedsPeople needs in supplyDemandManager.needsPeoplesList)
        {
            
            if (needs.NeedsName == needsName.Food)
            {
                incomeFood = ProductionPlayer.getFoodProduction() * needs.getprice();
                Debug.Log("Int�kter MAT: " + incomeFood);
            }

            if (needs.NeedsName == needsName.Water)
            {
                incomeWater = ProductionPlayer.getWaterProduction() * needs.getprice();
                Debug.Log("Int�kter VATTEN: " + incomeWater);
            }

            if (needs.NeedsName == needsName.Wood)
            {
                incomeWood = ProductionPlayer.getWoodProduction() * needs.getprice();
                Debug.Log("Int�kter TR�: " + incomeWood);
            }
        }

        incomeTotal = incomeFood + incomeWater + incomeWood;

        //�ka spelarens pengar
        TotalCash.transactionMoney(incomeTotal);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incomeProduction : MonoBehaviour
{
    //Hanterar intäkter från egen produktion
    //1. Mängd produktion per behov
    //2. Pris per behov
    //3. Intäkter per behov
    //4. Öka spelarens pengar

    [SerializeField] productionPlayer ProductionPlayer;
    [SerializeField] SupplyDemandManager supplyDemandManager;
    [SerializeField] totalCash TotalCash;
    [SerializeField] float incomeTotal;
    [SerializeField] float incomeFood;
    [SerializeField] float incomeWater;
    [SerializeField] float incomeWood;

    public void incomeCalc()
    {
        Debug.Log("Intäkter från egen produktion");
        foreach (NeedsPeople needs in supplyDemandManager.needsPeoplesList)
        {
            
            if (needs.NeedsName == needsName.Food)
            {
                incomeFood = ProductionPlayer.getFoodProduction() * needs.getprice();
                Debug.Log("Intäkter MAT: " + incomeFood);
            }

            if (needs.NeedsName == needsName.Water)
            {
                incomeWater = ProductionPlayer.getWaterProduction() * needs.getprice();
                Debug.Log("Intäkter VATTEN: " + incomeWater);
            }

            if (needs.NeedsName == needsName.Wood)
            {
                incomeWood = ProductionPlayer.getWoodProduction() * needs.getprice();
                Debug.Log("Intäkter TRÄ: " + incomeWood);
            }
        }

        incomeTotal = incomeFood + incomeWater + incomeWood;

        //Öka spelarens pengar
        TotalCash.transactionMoney(incomeTotal);
    }
    
}

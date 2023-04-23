using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earningsUpdate : MonoBehaviour
{
    public stock Stock;
    public sectorEffectFromEconomicClimateSO SectorEffectFromEconomic;
    public economicClimate EconomicClimate;

    public float newEPS;
    public float oldEPS;
    public float changeEPS;
    public float negativeEPSCalulationEPS; //Om EPS är negativ måste något värde sättas för att det negativa värdet ska kunna bli positivt

    float earningsMacro; //Hur EPSs påverkas utifrån den generella BNP utvecklingen

    public float EPSGrowthForPreviousYear;

    public void updateEarnings(stock Stock)
    {
        earningsMacro = earningsFromMacro(Stock);
        oldEPS = Stock.EPSnow;
        EPSGrowthForPreviousYear = Random.Range(Stock.EPSGrowthMin, Stock.EPSGrowthMax)/100;
        
        if (oldEPS > 0)
        {
            newEPS = Mathf.Round(oldEPS * (1 + EPSGrowthForPreviousYear + earningsMacro) * 100) / 100;
        }
        else
        {
            changeEPS = Mathf.Abs(negativeEPSCalulationEPS * (EPSGrowthForPreviousYear + earningsMacro));
            newEPS = Mathf.Round((oldEPS + changeEPS) * 100) / 100;
        }
        //newEPS = Mathf.Round(oldEPS + oldEPS * (EPSGrowthForPreviousYear + earningsMacro) * 100) / 100;
        Stock.EPSnow = newEPS;
        Stock.EPSHistory.Add(newEPS);
    }

    //Hur earnings påverkas utifrån den generella BNP utvecklingen
    public float earningsFromMacro(stock Stock)
    {
        if (Stock.SectorNameEnum == sectorNameEnum.Utilities)
        {
            earningsMacro = (EconomicClimate.yearlyBNPGrowthRate * SectorEffectFromEconomic.utilitesFactor)/(100*100);
        }

        if (Stock.SectorNameEnum == sectorNameEnum.Technology)
        {
            earningsMacro = (EconomicClimate.yearlyBNPGrowthRate * SectorEffectFromEconomic.technologyFactor) / (100 * 100);
        }

        return Mathf.Round(earningsMacro * 100)/ 100;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventsAffectSupplyDemand : MonoBehaviour
{
    //Hanterar h�ndelser som p�verkar Supply&Demand

    public SupplyDemandManager supplyDemandManager;
    private int index;
    [SerializeField] bool supplyAffectedByEvent; //Om falskt p�verkas Demand
    [SerializeField] float IfSupplyProbEventIsNegative;
    [SerializeField] float ifDemandProbEventIsNegative;
    [SerializeField] int procentuellPositivP�verkan;
    [SerializeField] int procentuellNegativP�verkan;


    public void Test(int iteration)
    {
        for (int i = 0; i < iteration; i++)
        {
            index = chooseNeedToAffect_Random();
            Debug.Log("" + supplyDemandManager.needsPeoplesList[index].name);
            supplyAffectedByEvent = supplyOrDemandAffected();
            Debug.Log("Supply p�verkad: " + supplyAffectedByEvent);
            affectNeed();
        }
    }

    public int chooseNeedToAffect_Random()
    {
        int i = Random.Range(0, supplyDemandManager.needsPeoplesList.Count);
        return i;
    }

    public bool supplyOrDemandAffected()
    {
        //Om sant p�verkas Supply
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }

    public void affectNeed()
    {
        //Ska behovet p�verkas negativt eller positivt

        //P�verkas positivt
        if (supplyAffectedByEvent == true)
        {
            if (Random.value >= IfSupplyProbEventIsNegative)
            {
                supplyDemandManager.needsPeoplesList[index].setSupply(supplyDemandManager.needsPeoplesList[index].getSupply() * procentuellPositivP�verkan / 100);
            }

            //P�verkas negativt
            else
            {
                supplyDemandManager.needsPeoplesList[index].setSupply(supplyDemandManager.needsPeoplesList[index].getSupply() * -procentuellNegativP�verkan / 100);
            }
        }

        else
        {
            //P�verkas positivt
            if (Random.value >= ifDemandProbEventIsNegative)
            {
                supplyDemandManager.needsPeoplesList[index].setDemand(supplyDemandManager.needsPeoplesList[index].getDemand() * procentuellPositivP�verkan / 100);
            }

            //P�verkas negativt
            else
            {
                supplyDemandManager.needsPeoplesList[index].setDemand(supplyDemandManager.needsPeoplesList[index].getDemand() * -procentuellNegativP�verkan / 100);
            }
        }
    }
}

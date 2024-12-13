using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventsAffectSupplyDemand : MonoBehaviour
{
    //Hanterar händelser som påverkar Supply&Demand

    public SupplyDemandManager supplyDemandManager;
    private int index;
    [SerializeField] bool supplyAffectedByEvent; //Om falskt påverkas Demand
    [SerializeField] float IfSupplyProbEventIsNegative;
    [SerializeField] float ifDemandProbEventIsNegative;
    [SerializeField] int procentuellPositivPåverkan;
    [SerializeField] int procentuellNegativPåverkan;


    public void Test(int iteration)
    {
        for (int i = 0; i < iteration; i++)
        {
            index = chooseNeedToAffect_Random();
            Debug.Log("" + supplyDemandManager.needsPeoplesList[index].name);
            supplyAffectedByEvent = supplyOrDemandAffected();
            Debug.Log("Supply påverkad: " + supplyAffectedByEvent);
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
        //Om sant påverkas Supply
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }

    public void affectNeed()
    {
        //Ska behovet påverkas negativt eller positivt

        //Påverkas positivt
        if (supplyAffectedByEvent == true)
        {
            if (Random.value >= IfSupplyProbEventIsNegative)
            {
                supplyDemandManager.needsPeoplesList[index].setSupply(supplyDemandManager.needsPeoplesList[index].getSupply() * procentuellPositivPåverkan / 100);
            }

            //Påverkas negativt
            else
            {
                supplyDemandManager.needsPeoplesList[index].setSupply(supplyDemandManager.needsPeoplesList[index].getSupply() * -procentuellNegativPåverkan / 100);
            }
        }

        else
        {
            //Påverkas positivt
            if (Random.value >= ifDemandProbEventIsNegative)
            {
                supplyDemandManager.needsPeoplesList[index].setDemand(supplyDemandManager.needsPeoplesList[index].getDemand() * procentuellPositivPåverkan / 100);
            }

            //Påverkas negativt
            else
            {
                supplyDemandManager.needsPeoplesList[index].setDemand(supplyDemandManager.needsPeoplesList[index].getDemand() * -procentuellNegativPåverkan / 100);
            }
        }
    }
}

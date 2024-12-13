using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NeedsPeopleManager", menuName = "Needs/Manager")]
public class SupplyDemandManager : ScriptableObject
{
    public List<NeedsPeople> needsPeoplesList;
    [SerializeField] int activeNeedID;
    
    [Header("Demand")]
    public List<int> demandStart;
    //public List<int> demandStartCopy; //Får värdena från demandStart och sedan raderas de när de blivit tagna
    public bool demandRandomStart;

    [Header("Supply")]
    public int supplyStartSameValue;

    [Header("Pricing")]
    public Price_SupplyDemand price_SupplyDemand;

    [Tooltip("Jämnviktspris")]
    [SerializeField] float equilibriumPrice;

    private void OnEnable()
    {
        resetDemand();
        setSupplyStart();
        setPrice();
        //Debug.Log("SupplyDemandManager");
    }

    public void setPrice()
    {
        for (int i = 0; i < needsPeoplesList.Count; i++)
        {

            float price = price_SupplyDemand.price(needsPeoplesList[i].getSupply(), needsPeoplesList[i].getDemand(), equilibriumPrice);
            needsPeoplesList[i].setPrice(price);

        }
    }


    public void setDemandStart()
    {
        
        if (demandRandomStart == true)
        {
            resetDemand();

            for (int i = 0; i < needsPeoplesList.Count; i++)
            {
                int randomInt = Random.Range(0, demandStart.Count);

                needsPeoplesList[i].setDemand(demandStart[randomInt]);

            }
        }
    }


    public void setSupplyStart()
    {
        Debug.Log("SetSupplyStart");
        resetSupply();

        for (int i = 0; i < needsPeoplesList.Count; i++)
        {
            
            needsPeoplesList[i].setSupply(supplyStartSameValue);

        }
    }

    public void resetDemand()
    {
        for (int i = 0; i < needsPeoplesList.Count; i++)
        {
            needsPeoplesList[i].resetDemand();
        }
    }

    public void resetSupply()
    {
        for (int i = 0; i < needsPeoplesList.Count; i++)
        {
            needsPeoplesList[i].resetSupply();

        }
    }

    public void setActiveNeedID(int id)
    {
        activeNeedID = id;
    }

    public int getActiveNeedID()
    {
        return activeNeedID;
    }
}

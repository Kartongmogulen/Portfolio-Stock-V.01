using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NeedsPeopleManager", menuName = "Needs/Manager")]
public class SupplyDemandManager : ScriptableObject
{
    public List<NeedsPeople> needsPeoplesList;
    
    [Header("Demand")]
    public List<int> demandStart;
    public bool demandRandomStart;

    [Header("Supply")]
    public int supplyStartSameValue;

    [Header("Pricing")]
    public Price_SupplyDemand price_SupplyDemand;
    [SerializeField] float startPrice;

    private void OnEnable()
    {
        setDemandStart();
        setSupplyStart();
        setPrice();
        Debug.Log("SupplyDemandManager");
    }

    public void setPrice()
    {
        for (int i = 0; i < needsPeoplesList.Count; i++)
        {

            float price = price_SupplyDemand.price(needsPeoplesList[i].getSupply(), needsPeoplesList[i].getDemand(), startPrice);
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

}

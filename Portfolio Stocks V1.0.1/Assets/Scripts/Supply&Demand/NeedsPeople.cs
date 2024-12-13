using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NeedsPeople", menuName = "Needs/Create New Need")]

public class NeedsPeople : ScriptableObject
{
   public string nameNeed;
   [SerializeField] int demandNow;
   [SerializeField] int supplyNow;
   [SerializeField] float priceNow;
    public needsName NeedsName;

    public void setPrice(float price)
    {
        priceNow = price;
    }

    public float getprice()
    {
        return priceNow;
    }

    public int getDemand()
    {
        return demandNow;
    }

    public int getSupply()
    {
        return supplyNow;
    }

    public void setDemand(int amount)
    {
        demandNow += amount;
    }

    public void setSupply(int amount)
    {
        supplyNow += amount;
    }

    public void resetDemand()
    {
        demandNow = 0;
    }

    public void resetSupply()
    {
        supplyNow = 0;
    }
}

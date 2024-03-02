using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fisherCompanyStats : MonoBehaviour
{
    [SerializeField] int employees;
    [SerializeField] int boats;
    [SerializeField] List<int> fishingRodAmount;

    [SerializeField] List<int> caughtFish;

    [SerializeField] sellFish SellFish;
    [SerializeField] boatStatManager BoatStatManager;
    [SerializeField] fishingRodManager FishingRodManager;

    [SerializeField] int money;

    private void Start()
    {
        SellFish = FindObjectOfType<sellFish>();
        BoatStatManager = FindObjectOfType<boatStatManager>();
        FishingRodManager = FindObjectOfType<fishingRodManager>();
    }

    public void buyBoat()
    {
        if (money >= BoatStatManager.getPrice())
        {
            boats++;
            money -= BoatStatManager.getPrice();
        }
    }

    public void buyFishingRoad(int level)
    {
        if (money >= FishingRodManager.getPrice(level))
        {
            fishingRodAmount[level]++;
            money -= FishingRodManager.getPrice(level);
        }
    }

    public int getEmployees()
    {
        return employees;
    }

    public int getBoatsAmount()
    {
        return boats;
    }

    public int getFishingRodAmount(int i)
    {
        return fishingRodAmount[i];
    }

    public void setCaughtFish(int fishID, int caughtAmount)
    {
        caughtFish[fishID] += caughtAmount;
    }

    public void sellFishAll()
    {
        for (int i = 0; i < caughtFish.Count; i++)
        {
            sellFishID(i);
        }
    }

    public void sellFishID(int fishID)
    {
        money += SellFish.sellFishForMoney(fishID, caughtFish[fishID]);

        //Minskar antalet fiskar
        caughtFish[fishID] -= caughtFish[fishID];

    }
}

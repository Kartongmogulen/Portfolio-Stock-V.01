using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockEPSData : MonoBehaviour, IUnlockStrategy
{

    /// <summary>
    /// Single Responsibility Principle (SRP): Låsa upp data rörande EPS
    /// Open/Closed Principle (OCP): Kan utöka med andra strategier
    /// Interface Segregation Principle (ISP): Använder interface för upplåsning
    /// Dependency Inversion Principle (DIP): 
    /// </summary>

    private actionPointsManager ActionPointsManager;
    private stockDataPlayerKnow StockDataPlayerKnow;
    [SerializeField ]private int cost;

    public void EPSUnlockStrategy(actionPointsManager apManager, stockDataPlayerKnow stockData, int cost)
    {
        ActionPointsManager = apManager;
        this.StockDataPlayerKnow = stockData;
        this.cost = cost;
    }

    //Kontrollerar om spelaren kan låsa upp data
    public bool CanUnlock(int yearOffset)
    {
        return ActionPointsManager.remainingAP >= cost && !StockDataPlayerKnow.EPSdata[yearOffset]; 
    }

    //Utför aktioner när data blir upplåst
    public void Unlock(int yearOffset)
    {
        if (!CanUnlock(yearOffset))
        {
            Debug.LogError($"Cannot unlock EPS for the specified yearOffset: {yearOffset}. Check prerequisites.");
            return;
        }

        StockDataPlayerKnow.EPSdata[yearOffset] = true;
        ActionPointsManager.actionPointSub(cost);
    }


   
}

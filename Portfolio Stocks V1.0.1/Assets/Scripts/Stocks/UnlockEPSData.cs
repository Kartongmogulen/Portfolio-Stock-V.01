using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockEPSData : MonoBehaviour, IUnlockStrategy
{

    /// <summary>
    /// Single Responsibility Principle (SRP): L�sa upp data r�rande EPS
    /// Open/Closed Principle (OCP): Kan ut�ka med andra strategier
    /// Interface Segregation Principle (ISP): Anv�nder interface f�r uppl�sning
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

    //Kontrollerar om spelaren kan l�sa upp data
    public bool CanUnlock(int yearOffset)
    {
        return ActionPointsManager.remainingAP >= cost && !StockDataPlayerKnow.EPSdata[yearOffset]; 
    }

    //Utf�r aktioner n�r data blir uppl�st
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

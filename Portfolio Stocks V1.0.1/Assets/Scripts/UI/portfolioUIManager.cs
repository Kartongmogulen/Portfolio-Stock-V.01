using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portfolioUIManager : MonoBehaviour
{
    //Vilken knapp är aktiv och vad ska visas i Portfölj-vy

    [SerializeField] bool stocksAndBonds;
    [SerializeField] bool stocksSector;
    public showShareAssets ShowShareAssets;
    public showStockSector ShowStockSector;
    public portfolioStock PortfolioStock;

    public void updateData()
    {
        if (stocksAndBonds == true)
            ShowShareAssets.infoPanelOne();

        else if (stocksSector == true)
        {
            PortfolioStock.showPortfolioData();
            ShowStockSector.infoPanelOne();
        }
    }

    public void updateData_1850()
    {
        if (stocksAndBonds == true)
            ShowShareAssets.infoPanelOne();

        else if (stocksSector == true)
        {
            //PortfolioStock.showPortfolioData_1850();
            ShowStockSector.infoPanelOne_1850();
        }
    }

    public void activeStocksAndBonds()
    {
        inactiveAll();

        stocksAndBonds = true;
        ShowShareAssets.infoPanelOne();
    }

    public void activeStockSectors()
    {
        inactiveAll();
        stocksSector = true;

    }

    public void inactiveAll()
    {
        stocksAndBonds = false;
        stocksSector = false;
    }
}

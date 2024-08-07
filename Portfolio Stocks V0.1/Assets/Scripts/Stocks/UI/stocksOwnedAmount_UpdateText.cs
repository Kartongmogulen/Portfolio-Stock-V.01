using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stocksOwnedAmount_UpdateText : MonoBehaviour
{
    public Text stockPanelOwnedText;
    public portfolioStock PortfolioStock;
    public activeSector_1850 ActiveSector_1850;
    public CityManager cityManager;



    // Update is called once per frame
    void Update()
    {
        updateText_1850();
    }

    public void updateText_1850()
    {
        if (ActiveSector_1850.getActiveSector() == 0)
        {
            stockPanelOwnedText.text = "Owned: " + "\n"+ PortfolioStock.minesCompanySharesOwned[cityManager.getActiveCity()];
        }

        else if (ActiveSector_1850.getActiveSector() == 1)
        {
            stockPanelOwnedText.text = "Owned: " + "\n" + PortfolioStock.railroadCompanySharesOwned[cityManager.getActiveCity()];
        }

        else if (ActiveSector_1850.getActiveSector() == 2)
        {
            stockPanelOwnedText.text = "Owned: " +"\n" + PortfolioStock.industriCompanySharesOwned[cityManager.getActiveCity()];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class stocksOwnedAmount_UpdateText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stockAmountOwnedText;
    public portfolioStock PortfolioStock;
    public activeSector_1850 ActiveSector_1850;
    public CityManager cityManager;



    // Update is called once per frame
    void Update()
    {
        //updateText_1850(PortfolioManager portfolio);
    }

    public void updateText_1850(PortfolioManager portfolio)
    {

        int sharesAmount = portfolio.getSharesAmount();
        //Debug.Log("Antal aktier: " + sharesAmount);
        stockAmountOwnedText.text = $"Owned: {sharesAmount}";

        /*
        if (ActiveSector_1850.getActiveSector() == 0)
        {
            stockAmountOwnedText.text = "Owned: " + "\n"+ PortfolioStock.minesCompanySharesOwned[cityManager.getActiveCity()];
        }

        else if (ActiveSector_1850.getActiveSector() == 1)
        {
            stockAmountOwnedText.text = "Owned: " + "\n" + PortfolioStock.railroadCompanySharesOwned[cityManager.getActiveCity()];
        }

        else if (ActiveSector_1850.getActiveSector() == 2)
        {
            stockAmountOwnedText.text = "Owned: " +"\n" + PortfolioStock.industriCompanySharesOwned[cityManager.getActiveCity()];
        }
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showStockInfo_1 : MonoBehaviour
{
    public Text cityNameText;
    public Text sectorNameText;
    public Text companyNameText;

    public CityManager cityManager;
    public activeSector_1850 ActiveSector_1850;
    public stockMarketManager_1850 StockMarketManager_1850;

    public void showDataBasic()
    {
        cityNameText.text = "City name: " + cityManager.nameCity[cityManager.getActiveCity()];

        //Sektor
        if (ActiveSector_1850.getActiveSector() == 0)
        {
            sectorNameText.text = "Sector: Mines";
            companyNameText.text = "Company: " + StockMarketManager_1850.StockPrefabListMines[cityManager.getActiveCity()].GetComponent<stock>().nameOfCompany;
        }

        if (ActiveSector_1850.getActiveSector() == 1)
        {
            sectorNameText.text = "Sector: Railroad";
        }
    }
}

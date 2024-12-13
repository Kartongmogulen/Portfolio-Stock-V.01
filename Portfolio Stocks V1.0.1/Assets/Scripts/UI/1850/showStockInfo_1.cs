using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showStockInfo_1 : MonoBehaviour
{
    public bool showCityName;
    public bool showCompanyName;
    public bool showSectorName;

    public Text cityNameText;
    public Text sectorNameText;
    public Text companyNameText;
    //public Text companyGAVText;

    public CityManager cityManager;
    public activeSector_1850 ActiveSector_1850;
    public stockMarketManager_1850 StockMarketManager_1850;
    public portfolioStock PortfolioStock;

    private void Start()
    {
        Invoke("showDataBasic", 0.1f);
    }

    public void showDataBasic()
    {
        if (showCityName == true)
        {
            cityNameText.text = "City name: " + cityManager.nameCity[cityManager.activeCity];
        }
        //Sektor
        if (ActiveSector_1850.getActiveSector() == 0)
        {
            if (showSectorName == true)
            {
                sectorNameText.text = "Sector: Mines";
            }
            if (showCompanyName == true)
            {
                companyNameText.text = "Company: " + StockMarketManager_1850.StockPrefabListMines[cityManager.activeCity].GetComponent<stock>().nameOfCompany;
            }

            
        }

        if (ActiveSector_1850.getActiveSector() == 1)
        {
            if (showSectorName == true)
            {
                sectorNameText.text = "Sector: Railroad";
            }

            if (showCompanyName == true)
            {
                companyNameText.text = "Company: " + StockMarketManager_1850.StockPrefabListRailroad[cityManager.activeCity].GetComponent<stock>().nameOfCompany;
            }
        }

        if (ActiveSector_1850.getActiveSector() == 2)
        {
            if (showSectorName == true)
            {
                sectorNameText.text = "Sector: Industri";
            }

            if (showCompanyName == true)
            {
                if (StockMarketManager_1850.StockPrefabListIndustri[cityManager.activeCity].GetComponent<stockInformation>() != null)
                    companyNameText.text = "Company: " + StockMarketManager_1850.StockPrefabListIndustri[cityManager.activeCity].GetComponent<stockInformation>().nameCompany;

                else
                    companyNameText.text = "Company: " + StockMarketManager_1850.StockPrefabListIndustri[cityManager.activeCity].GetComponent<stock>().nameOfCompany;

            }
        }
    }
}

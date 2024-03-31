using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class chooseCompany_1850 : MonoBehaviour
{
    public CityManager cityManager;
    public activeSector_1850 ActiveSector_1850;
    public stockMarketManager_1850 StockMarketManager_1850;
    public stocks_UnlockInfo_1850 StocksUnlockInfo;
    public dataPlayerKnowsButtonUnlock DataPlayerKnowsButtonUnlock;
    public ShowHistoricData showHistoricData;
    public List<GameObject> stockMarketSectorActive; //Listan med Prefabs över aktuell sektor
    public Text divYieldText;
    public Text divPayoutText;
    public Text divPayoutShareText;
    public Text divPolicyText;

    public Text EPSText;
    public Text PEtext;

    [SerializeField] int cityIndex;
    [SerializeField] int activeSector;
    [SerializeField] float divPayout;
    [SerializeField] float stockPrice;
    [SerializeField] float payoutRatioOnEPS;

    [SerializeField] bool divDataActive = true;
    [SerializeField] bool keyDataActive;

    private void Start()
    {
        Invoke("chooseCompany", 0.1f);
        //chooseCompany();
    }

    private void Update()
    {
        chooseCompany();
        //getCityAndSectorIndex();
    }

    public void chooseCompany()
    {
        getCityAndSectorIndex();

        if(divDataActive == true)
        {
            divDataUpdateText();
        }

        else if (keyDataActive == true)
        {
            keyDataPanel();
        }

        //showHistoricData.updateAllHistoricData(stockMarketSectorActive[cityIndex].GetComponent<stock>());
    }

    public void getCityAndSectorIndex()
    {
        cityIndex = cityManager.getActiveCity();
        activeSector = ActiveSector_1850.getActiveSector();

        if(activeSector == 0)
        {
            stockMarketSectorActive = StockMarketManager_1850.StockPrefabListMines;
            stockPrice = stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice[stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice.Count - 1];
            DataPlayerKnowsButtonUnlock.chooseStock(stockMarketSectorActive[cityIndex].GetComponent<stock>());
            
            showHistoricData.updateAllHistoricDataWithGameObject(stockMarketSectorActive[cityIndex]);

            //stocksUiScriptsGO.GetComponent<ShowHistoricData>().updateAllHistoricData(StockMarketManager_1850);
            //buttonsScriptsGO.GetComponent<dataPlayerKnowsButtonUnlock>().chooseStock(StockMarketManager.StockTechList[i]);
        }

        if (activeSector == 1)
        {
            stockMarketSectorActive = StockMarketManager_1850.StockPrefabListRailroad;
            stockPrice = stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice[stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice.Count - 1];
            DataPlayerKnowsButtonUnlock.chooseStock(stockMarketSectorActive[cityIndex].GetComponent<stock>());

            showHistoricData.updateAllHistoricDataWithGameObject(stockMarketSectorActive[cityIndex]);
        }

        if (activeSector == 2)
        {
            stockMarketSectorActive = StockMarketManager_1850.StockPrefabListIndustri;

            if (stockMarketSectorActive[cityIndex].GetComponent<priceStock>() != null)
            {
                stockPrice = stockMarketSectorActive[cityIndex].GetComponent<priceStock>().StockPrice[stockMarketSectorActive[cityIndex].GetComponent<priceStock>().StockPrice.Count - 1];
                DataPlayerKnowsButtonUnlock.chooseStock_Products(stockMarketSectorActive[cityIndex].GetComponent<incomeStatement>());
            }
            else
            {
                stockPrice = stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice[stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice.Count - 1];
                DataPlayerKnowsButtonUnlock.chooseStock(stockMarketSectorActive[cityIndex].GetComponent<stock>());
            }

            

            showHistoricData.updateEPSText_GO(stockMarketSectorActive[cityIndex]);
            showHistoricData.updateEPSChangeYearOverYearText_GO(stockMarketSectorActive[cityIndex]);
            showHistoricData.updateAllHistoricDataWithGameObject(stockMarketSectorActive[cityIndex]);
            
        }

        //stockPrice = stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice[stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice.Count - 1];
    }

    public void divDataUpdateText()
    {
     
        setAllBoolInactive();
        divDataActive = true;

        if (activeSector == 2 && stockMarketSectorActive[cityIndex].GetComponent<divPolicyPrefab>() != null)
        {
            
            divPayout = stockMarketSectorActive[cityIndex].GetComponent<divPolicyPrefab>().divPayoutPerShare;
            payoutRatioOnEPS = divPayout / stockMarketSectorActive[cityIndex].GetComponent<incomeStatement>().EarningPerShareHistory[stockMarketSectorActive[cityIndex].GetComponent<incomeStatement>().EarningPerShareHistory.Count - 1];


        }
        else
        {
            divPayout = stockMarketSectorActive[cityIndex].GetComponent<stock>().divPayout;
            payoutRatioOnEPS = divPayout / stockMarketSectorActive[cityIndex].GetComponent<stock>().EPSnow;

        }
        divYieldText.text = "Div. yield: " + Mathf.Round(divPayout / stockPrice * 10000) / 100 + "%";
        divPayoutText.text = "Annual dividend: " + Mathf.Round(divPayout * 100) / 100;

        
        divPayoutShareText.text = "Payout-ratio: " + Mathf.Round(payoutRatioOnEPS * 100) + "%";

        //Info spelaren måste låsa upp
        if (activeSector == 0 && StocksUnlockInfo.minesDivPolicyUnlocked[cityIndex] == 1)
        {
            divPolicyText.text = "Maximum payout ratio: " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyMaxPayouRatio + "% and aims to increase the dividend with " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyChangeDiv + "% per year.";
        }

        else if (activeSector == 1 && StocksUnlockInfo.railroadDivPolicyUnlocked[cityIndex] == 1)
        {
            divPolicyText.text = "Maximum payout ratio: " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyMaxPayouRatio + "% and aims to increase the dividend with " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyChangeDiv + "% per year.";
        }

        else if(activeSector == 2 && StocksUnlockInfo.industriDivPolicyUnlocked[cityIndex] == 1)
        {
            divPolicyText.text = "Maximum payout ratio: " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyMaxPayouRatio + "% and aims to increase the dividend with " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyChangeDiv + "% per year.";

            //divPolicyText.text = "Maximum payout ratio: " + stockMarketSectorActive[cityIndex].GetComponent<divPolicyPrefab>().divPolicyMaxPayouRatio + "% and aims to increase the dividend with " + stockMarketSectorActive[cityIndex].GetComponent<divPolicyPrefab>().divPolicyChangeDiv + "% per year.";

            if (stockMarketSectorActive[cityIndex].GetComponent<managementPriorites>() != null)
            divPolicyText.text = "Will pay out " + Mathf.Round(stockMarketSectorActive[cityIndex].GetComponent<managementPriorites>().dividendShareOfResult*10000)/100 + "% of the result";
        }

        else
        {
            divPolicyText.text = "Div.Policy: LOCKED. Cost (Time Points): " + StocksUnlockInfo.getCost_UnlockDivPolicy();
        }
    }

    public void keyDataPanel()
    {
        setAllBoolInactive();
        keyDataActive = true;

        //getCityAndSectorIndex();
        //Debug.Log("EPS: " + stockMarketSectorActive[cityIndex].GetComponent<stock>().EPSnow);

        if (activeSector == 0 || activeSector == 1 || stockMarketSectorActive[cityIndex].GetComponent<stock>() != null)
        {
            EPSText.text = "EPS: " + Mathf.Round(stockMarketSectorActive[cityIndex].GetComponent<stock>().EPSnow * 100) / 100;
            PEtext.text = "P/E: " + Mathf.Round((stockPrice / stockMarketSectorActive[cityIndex].GetComponent<stock>().EPSnow) * 10) / 10;
        }

        else if (activeSector == 2)
        {
            int length = stockMarketSectorActive[cityIndex].GetComponent<incomeStatement>().EarningPerShareHistory.Count;
            EPSText.text = "EPS: " + Mathf.Round(stockMarketSectorActive[cityIndex].GetComponent<incomeStatement>().EarningPerShareHistory[length-1] * 100) / 100;
            PEtext.text = "P/E: " + Mathf.Round((stockPrice / stockMarketSectorActive[cityIndex].GetComponent<incomeStatement>().EarningPerShareHistory[length - 1]) * 10) / 10;
        }
    }

    public void setAllBoolInactive()
    {
        divDataActive = false;
        keyDataActive = false;
    }
}

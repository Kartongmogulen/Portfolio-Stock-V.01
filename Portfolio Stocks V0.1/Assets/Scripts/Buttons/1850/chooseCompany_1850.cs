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

    [SerializeField] bool divDataActive = true;
    [SerializeField] bool keyDataActive;

    private float divPayoutShare;

    private void Start()
    {
        Invoke("chooseCompany", 0.1f);
        //chooseCompany();
    }

    private void Update()
    {
        chooseCompany();
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
    }

    public void getCityAndSectorIndex()
    {
        cityIndex = cityManager.getActiveCity();
        activeSector = ActiveSector_1850.getActiveSector();

        if(activeSector == 0)
        {
            stockMarketSectorActive = StockMarketManager_1850.StockPrefabListMines;
        }

        if (activeSector == 1)
        {
            stockMarketSectorActive = StockMarketManager_1850.StockPrefabListRailroad;
        }

        if (activeSector == 2)
        {
            stockMarketSectorActive = StockMarketManager_1850.StockPrefabListIndustri;
        }

        stockPrice = stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice[stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice.Count - 1];
    }

    public void divDataUpdateText()
    {
     
        setAllBoolInactive();
        divDataActive = true;

        divYieldText.text = "Div. yield: " + Mathf.Round((stockMarketSectorActive[cityIndex].GetComponent<stock>().divPayout) / stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice[stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice.Count - 1] * 10000) / 100 + "%";
        divPayoutText.text = "Annual dividend: " + Mathf.Round(stockMarketSectorActive[cityIndex].GetComponent<stock>().divPayout * 100) / 100;

        divPayoutShare = stockMarketSectorActive[cityIndex].GetComponent<stock>().divPayout / stockMarketSectorActive[cityIndex].GetComponent<stock>().EPSnow;
        divPayoutShareText.text = "Payout-ratio: " + Mathf.Round(divPayoutShare * 100) + "%";

        //Info spelaren måste låsa upp
        if (activeSector == 0 && StocksUnlockInfo.minesDivPolicyUnlocked[cityIndex] == 1)
        {
            divPolicyText.text = "Maximum payout ratio: " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyMaxPayouRatio + "% and aims to increase the dividend with " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyChangeDiv + "% per year.";
        }

        else if (activeSector == 1 && StocksUnlockInfo.railroadDivPolicyUnlocked[cityIndex] == 1)
        {
            divPolicyText.text = "Maximum payout ratio: " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyMaxPayouRatio + "% and aims to increase the dividend with " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyChangeDiv + "% per year.";
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
        EPSText.text = "EPS: " + Mathf.Round(stockMarketSectorActive[cityIndex].GetComponent<stock>().EPSnow * 100) / 100;
        PEtext.text = "P/E: " + Mathf.Round((stockPrice / stockMarketSectorActive[cityIndex].GetComponent<stock>().EPSnow) * 10) / 10;
    }

    public void setAllBoolInactive()
    {
        divDataActive = false;
        keyDataActive = false;
    }
}

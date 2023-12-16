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

    private float divPayoutShare;

    public void chooseCompany()
    {
        getCityAndSectorIndex();

        divYieldText.text = "Div. yield: " + Mathf.Round((stockMarketSectorActive[cityIndex].GetComponent<stock>().divPayout) / stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice[stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice.Count - 1] * 10000) / 100 + "%";
        divPayoutText.text = "Annual dividend: " + Mathf.Round(stockMarketSectorActive[cityIndex].GetComponent<stock>().divPayout * 100) / 100;
        
        divPayoutShare = stockMarketSectorActive[cityIndex].GetComponent<stock>().divPayout / stockMarketSectorActive[cityIndex].GetComponent<stock>().EPSnow;
        divPayoutShareText.text = "Div.Share: " + Mathf.Round(divPayoutShare * 100) + "%";

        //Info spelaren måste låsa upp
        if (StocksUnlockInfo.minesDivPolicyUnlocked[cityIndex] == 1)
        {
            divPolicyText.text = "Maximum payout ratio: " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyMaxPayouRatio + "% and aims to increase the dividend with " + stockMarketSectorActive[cityIndex].GetComponent<stock>().divPolicyChangeDiv + "% per year.";
        }
        else
        {
            divPolicyText.text = "Div.Policy: LOCKED. Cost (Time Points): " + StocksUnlockInfo.getCost_UnlockDivPolicy();
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

        stockPrice = stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice[stockMarketSectorActive[cityIndex].GetComponent<stock>().StockPrice.Count - 1];
    }

    public void keyDataPanel()
    {
        getCityAndSectorIndex();
        Debug.Log("EPS: " + stockMarketSectorActive[cityIndex].GetComponent<stock>().EPSnow);
        EPSText.text = "EPS: " + Mathf.Round(stockMarketSectorActive[cityIndex].GetComponent<stock>().EPSnow * 100) / 100;
        PEtext.text = "P/E: " + Mathf.Round((stockPrice / stockMarketSectorActive[cityIndex].GetComponent<stock>().EPSnow) * 10) / 10;
    }
}

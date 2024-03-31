using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHistoricData : MonoBehaviour
{
    public List<Text> yearsHeader;
    public List<Text> EPSText;
    public List<Text> EPSChangeYearOverYearText;
    public List<Text> DividendGrowthYoYText;
    public List<Text> PayoutRatioText;
    public endRoundButton EndRoundButton;
    public gamePlayScopeManager GamePlayScopeManager;
    public stockMarketManager StockMarketManager;

    private int yearNow;

    public int year;

    [SerializeField]
    private int startingYearToRevealData;//Första året spelaren kan se data

    private void Start()
    {
        startingYearToRevealData = GamePlayScopeManager.yearsToGetHistoricData - yearsHeader.Count;
    }

    public void updateAllHistoricData(stock Stock)
    {
        yearNow = EndRoundButton.year; //År i dagsläget
        updateYearText();

        updateEPSText(Stock);
        updateEPSChangeYearOverYearText(Stock);
    }

    public void updateAllHistoricDataWithGameObject(GameObject stockPrefab)
    {
        //Debug.Log("Visa historik med GO");
        //updateEPSText_GO(stockPrefab); //BLIR FEL OM MAN HAR OBJEKT SOM HAR KVAR "STOCK"
        updateDividendGrowthYoY(stockPrefab);
        updatePayoutRatioText(stockPrefab);
    }

    public void updateYearText()
    {


        //Debug.Log("Antal EPS-text: " + EPSText.Count);
        /*for (int i = 0; i  < yearsHeader.Count;i++)
        {
            yearsHeader[i].text = " " + (yearNow + EPSText.Count - (GamePlayScopeManager.yearsToGetHistoricData - i));
        }
        */

        //Debug.Log("År nu: " + yearNow);

        for (int i = 0; i < yearsHeader.Count; i++)
        {
            yearsHeader[i].text = " " + (yearNow  - i);
            //yearsHeader[i].text = " " + (yearNow + (GamePlayScopeManager.yearsToGetHistoricData - i));
        }
    }

    public void updateEPSText(stock Stock)
    {
        Debug.Log("UpdateEPSText: " + Stock.nameOfCompany);
        for (int i = 0; i < EPSText.Count; i++)
        {
            //Debug.Log("True or False: " + Stock.GetComponent<stockDataPlayerKnow>().EPSdata[Mathf.Abs(startingYearToRevealData + yearNow + i)] + " - " + Mathf.Abs(startingYearToRevealData + yearNow + i));
            //if (stockPrefab.GetComponent<stockDataPlayerKnow>().EPSdata[Mathf.Abs(yearNow + i)] == false)
            if(Stock.GetComponent<stockDataPlayerKnow>().EPSdata[Mathf.Abs(startingYearToRevealData + yearNow + i)] == true)
            {
                //Debug.Log(Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]);
                EPSText[i].text = " " + (Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]);
                //Debug.Log("EPS: " + Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]);

            }
            else
            {
                //EPSText[i].text = " " + (Stock.EPSHistory[(GamePlayScopeManager.yearsToGetHistoricData + yearNow + i - EPSText.Count)]);
                EPSText[i].text = "???";
            }
        }
    }

    public void updateEPSChangeYearOverYearText(stock Stock)
    {

        //KAN UPPSTÅ PROBLEM OM DET INTE FINNS TILLRÄCKLIGT MED HISTORISKA VÄRDEN
        //EPSChangeYearOverYearText[0].text = Mathf.Round((Stock.EPSHistory[(startingYearToRevealData + yearNow)] / Stock.EPSHistory[(startingYearToRevealData + yearNow - 1)] - 1) * 100) + " %";
        
        
        for (int i = 0; i < EPSChangeYearOverYearText.Count; i++)
        {
            //Debug.Log(Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]);
            //EPSChangeYearOverYearText[i].text = " " + Mathf.Round((Stock.EPSHistory[(startingYearToRevealData + yearNow + i)] / Stock.EPSHistory[(startingYearToRevealData + yearNow + i-1)] - 1) * 100) + " %";
            //Debug.Log(Mathf.Round((Stock.EPSHistory[(startingYearToRevealData + yearNow + i + 1)] / Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]) * 100));
            
            //if (stockPrefab.GetComponent<stockDataPlayerKnow>().EPSdata[Mathf.Abs(yearNow + i)] == false)
            if (Stock.GetComponent<stockDataPlayerKnow>().EPSYoYChangedata[Mathf.Abs(startingYearToRevealData + yearNow + i)] == true)
            {
                //Debug.Log(Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]);
                EPSChangeYearOverYearText[i].text = " " + Mathf.Round((Stock.EPSHistory[(startingYearToRevealData + yearNow + i)] / Stock.EPSHistory[(startingYearToRevealData + yearNow + i - 1)] - 1) * 100) + " %";

            }
            else
            {
                //EPSText[i].text = " " + (Stock.EPSHistory[(GamePlayScopeManager.yearsToGetHistoricData + yearNow + i - EPSText.Count)]);
                EPSChangeYearOverYearText[i].text = "???";
            }
            
        }
    }


    public void updateEPSText_GO(GameObject stockPrefab)
    {
        //Debug.Log("UpdateEPSText: " + Stock.nameOfCompany);
        for (int i = 0; i < EPSText.Count; i++)
        {
            //Debug.Log("True or False: " + stockPrefab.GetComponent<stockDataPlayerKnow>().EPSdata[Mathf.Abs(startingYearToRevealData + yearNow + i)] + " - " + Mathf.Abs(startingYearToRevealData + yearNow + i));
            //if (stockPrefab.GetComponent<stockDataPlayerKnow>().EPSdata[Mathf.Abs(yearNow + i)] == false)
            if (stockPrefab.GetComponent<stockDataPlayerKnow>().EPSdata[Mathf.Abs(startingYearToRevealData + yearNow + i)] == true)
            {
                //Debug.Log(Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]);
                if (stockPrefab.GetComponent<incomeStatement>() != null)
                {
                    EPSText[i].text = " " + Mathf.Round(((stockPrefab.GetComponent<incomeStatement>().EarningPerShareHistory[(startingYearToRevealData + yearNow + i)]) / 100) * 100);
                }

                /*else
                {
                    Debug.Log("EPS-text uppdatering Prefab");
                    EPSText[i].text = " " + Mathf.Round(((stockPrefab.GetComponent<stock>().EPSHistory  [(startingYearToRevealData + yearNow + i)] / 100) * 100));
                }*/
            }

            else
            {
                //EPSText[i].text = " " + (Stock.EPSHistory[(GamePlayScopeManager.yearsToGetHistoricData + yearNow + i - EPSText.Count)]);
                EPSText[i].text = "???";
            }
        }
    }

    public void updateEPSChangeYearOverYearText_GO(GameObject stockPrefab)
    {

        //KAN UPPSTÅ PROBLEM OM DET INTE FINNS TILLRÄCKLIGT MED HISTORISKA VÄRDEN
        //EPSChangeYearOverYearText[0].text = Mathf.Round((Stock.EPSHistory[(startingYearToRevealData + yearNow)] / Stock.EPSHistory[(startingYearToRevealData + yearNow - 1)] - 1) * 100) + " %";


        for (int i = 0; i < EPSChangeYearOverYearText.Count; i++)
        {
            //Debug.Log(Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]);
            //EPSChangeYearOverYearText[i].text = " " + Mathf.Round((Stock.EPSHistory[(startingYearToRevealData + yearNow + i)] / Stock.EPSHistory[(startingYearToRevealData + yearNow + i-1)] - 1) * 100) + " %";
            //Debug.Log(Mathf.Round((Stock.EPSHistory[(startingYearToRevealData + yearNow + i + 1)] / Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]) * 100));

            //if (stockPrefab.GetComponent<stockDataPlayerKnow>().EPSdata[Mathf.Abs(yearNow + i)] == false)
            if (stockPrefab.GetComponent<stockDataPlayerKnow>().EPSYoYChangedata[Mathf.Abs(startingYearToRevealData + yearNow + i)] == true)
            {
                //Debug.Log(Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]);
                EPSChangeYearOverYearText[i].text = " " + Mathf.Round((stockPrefab.GetComponent<incomeStatement>().EarningPerShareHistory[(startingYearToRevealData + yearNow + i)] / stockPrefab.GetComponent<incomeStatement>().EarningPerShareHistory[(startingYearToRevealData + yearNow + i - 1)] - 1) * 100) + " %";

            }
            else
            {
                //EPSText[i].text = " " + (Stock.EPSHistory[(GamePlayScopeManager.yearsToGetHistoricData + yearNow + i - EPSText.Count)]);
                EPSChangeYearOverYearText[i].text = "???";
            }

        }
    }

    public void updateDividendGrowthYoY(GameObject stockPrefab)
    {

        //KAN UPPSTÅ PROBLEM OM DET INTE FINNS TILLRÄCKLIGT MED HISTORISKA VÄRDEN
        //DividendGrowthYoYText[0].text = Mathf.Round((stockPrefab.GetComponent<dividendHistory>().dividendPaid[(startingYearToRevealData + yearNow)] / stockPrefab.GetComponent<dividendHistory>().dividendPaid[(startingYearToRevealData + yearNow - 1)] - 1) * 100) + " %";
        
        for (int i = 0; i < DividendGrowthYoYText.Count; i++)
        {
            DividendGrowthYoYText[i].text = "???";
            //EPSChangeYearOverYearText[i + 1].text = " " + Mathf.Round((Stock.EPSHistory[(startingYearToRevealData + yearNow + i + 1)] / Stock.EPSHistory[(startingYearToRevealData + yearNow + i)] - 1) * 100) + " %";
            //DividendGrowthYoYText[i + 1].text = Mathf.Round((stockPrefab.GetComponent<dividendHistory>().dividendPaid[(startingYearToRevealData + yearNow + i + 1)] / stockPrefab.GetComponent<dividendHistory>().dividendPaid[(startingYearToRevealData + yearNow + i)] - 1) * 100) + " %";
            //Debug.Log(DividendGrowthYoYText.Count);
            if (stockPrefab.GetComponent<stockDataPlayerKnow>().DividendYoYChangedata.Count > 1 && stockPrefab.GetComponent<stockDataPlayerKnow>().DividendYoYChangedata[Mathf.Abs(startingYearToRevealData + yearNow + i)] == true)
            {
                Debug.Log("1");
                DividendGrowthYoYText[i].text = Mathf.Round((stockPrefab.GetComponent<dividendHistory>().dividendPaid[(startingYearToRevealData + yearNow + i)] / stockPrefab.GetComponent<dividendHistory>().dividendPaid[(startingYearToRevealData + yearNow + i - 1)] - 1) * 10000)/100 + " %";
                //stockPrefab.GetComponent<stockDataPlayerKnow>().DividendYoYChangedata[(startingYearToRevealData + yearNow + i)] / GetComponent<stockDataPlayerKnow>().DividendYoYChangedata[(startingYearToRevealData + yearNow + i - 1)] - 1) * 100) + " %";

            }
            else
            {
                //Debug.Log("2");
                //EPSText[i].text = " " + (Stock.EPSHistory[(GamePlayScopeManager.yearsToGetHistoricData + yearNow + i - EPSText.Count)]);
                DividendGrowthYoYText[i].text = "???";
            }

        }
    }
        public void updatePayoutRatioText(GameObject stockPrefab)
        {

            for (int i = 0; i < PayoutRatioText.Count; i++)
            {

            //PayoutRatioText[i].text = " " + Mathf.Round((stockPrefab.GetComponent<dividendHistory>().dividendPaid[(startingYearToRevealData + yearNow + i )]/ (stockPrefab.GetComponent<stock>().EPSHistory[(startingYearToRevealData + yearNow + i)])*100));
            //Debug.Log(stockPrefab.GetComponent<dividendHistory>().dividendPaid[(startingYearToRevealData + yearNow + i)] / (stockPrefab.GetComponent<stock>().EPSHistory[(startingYearToRevealData + yearNow + i)]));
            
                //if (stockPrefab.GetComponent<stockDataPlayerKnow>().EPSdata[Mathf.Abs(yearNow + i)] == false)
                if (stockPrefab.GetComponent<stockDataPlayerKnow>().PayoutRatiodata[Mathf.Abs(startingYearToRevealData + yearNow + i)] == true && stockPrefab.GetComponent<stock>() != null)
                {
                    //Debug.Log(Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]);
                    PayoutRatioText[i].text = " " + Mathf.Round((stockPrefab.GetComponent<dividendHistory>().dividendPaid[(startingYearToRevealData + yearNow + i)] / (stockPrefab.GetComponent<stock>().EPSHistory[(startingYearToRevealData + yearNow + i)]) * 100));

                }

                else if(stockPrefab.GetComponent<stockDataPlayerKnow>().PayoutRatiodata[Mathf.Abs(startingYearToRevealData + yearNow + i)] == true)
                {
                //Debug.Log(Stock.EPSHistory[(startingYearToRevealData + yearNow + i)]);
                PayoutRatioText[i].text = " " + Mathf.Round((stockPrefab.GetComponent<dividendHistory>().dividendPaid[(startingYearToRevealData + yearNow + i)] / (stockPrefab.GetComponent<incomeStatement>().EarningPerShareHistory[(startingYearToRevealData + yearNow + i)]) * 100));

                }

            else
                {
                    //EPSText[i].text = " " + (Stock.EPSHistory[(GamePlayScopeManager.yearsToGetHistoricData + yearNow + i - EPSText.Count)]);
                    PayoutRatioText[i].text = "???";
                }
                
        }
    }

        public int getStartingYear()
    {
        return startingYearToRevealData;
    }

    public int getYearNow()
    {
        return yearNow;
    }

}

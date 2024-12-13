using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpeKvotSingelAsset : MonoBehaviour
{
    //Ber�knar Sharpekvot f�r en enskild tillg�ng t.ex en aktie eller r�ntepapper

    public stockMarketManager_1850 StockMarketManager_1850;
    public portfolioStock PortfolioStock;

    public int orderInStockList; //M�STE V�LJAS

    public stock Stock;
    public GameObject calculationTools;
    public bondMarketManager BondMarketManager;
    public GAV gav;



    public List<float> prices;
    //public List<float> pricesDeviationFromMean;
    //[SerializeField] float averagePrices;
    //[SerializeField] float sumPricesFromRange;
    //[SerializeField] float sumPriceDeviationFromMean;
    [SerializeField] float standardDeviation;
    //[SerializeField] float amountToTakeInCalcualtion; //Hur m�nga v�rden tidsserien ska inneh�lla
    
    [SerializeField] float sharpeKvot;
    [SerializeField] float returnAsset;
    [SerializeField] float riskFreeRate;


    private void Start()
    {
        Stock = GetComponent<stock>();
    }

    public void sharpeKvotCalc()
    {
        standardDeviation = calculationTools.GetComponent<standardDeviationCalculation>().calculateStandardDeviation(Stock.StockPrice);
        riskFreeRate = BondMarketManager.bondMarketListGO[BondMarketManager.bondMarketListGO.Count - 1].GetComponent<bondInfoPrefab>().rate;

        if (Stock.SectorNameEnum == sectorNameEnum.Utilities)
        {
            returnAsset = (Stock.StockPrice[Stock.StockPrice.Count - 1] / gav.utiCompanyGAVPlayer[orderInStockList]-1)*100;
            
            //sharpeKvot = (returnAsset - riskFreeRate) / standardDeviation;
        }

        if (Stock.SectorNameEnum == sectorNameEnum.Technology)
        {
            returnAsset = Stock.StockPrice[Stock.StockPrice.Count - 1] / gav.techCompanyGAVPlayer[orderInStockList] - 1;
            //Debug.Log("Avkastning: " + returnAsset);
            //Debug.Log("Riskfri r�nta: " + riskFreeRate);
            //Debug.Log("Std.avk: " + standardDeviation);
            //sharpeKvot = (returnAsset - riskFreeRate) / standardDeviation;
        }

        sharpeKvot = calculationTools.GetComponent<sharpeRatioCalculation>().sharpeRatio(riskFreeRate, returnAsset, standardDeviation);
    }

    public void calculateSharpeForSector()
    {
        for (int i = 0; i < StockMarketManager_1850.StockPrefabListMines.Count;i++)
        {
            standardDeviation = calculationTools.GetComponent<standardDeviationCalculation>().calculateStandardDeviation(StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice);
            riskFreeRate = BondMarketManager.bondMarketListGO[BondMarketManager.bondMarketListGO.Count - 1].GetComponent<bondInfoPrefab>().rate;
            returnAsset = (StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice[StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice.Count - 1] / PortfolioStock.minesCompanyGAV[i] - 1) * 100;
        }
    }

    
}

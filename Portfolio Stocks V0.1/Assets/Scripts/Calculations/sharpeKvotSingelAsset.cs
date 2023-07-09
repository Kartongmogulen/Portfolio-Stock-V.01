using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpeKvotSingelAsset : MonoBehaviour
{
    //Beräknar Sharpekvot för en enskild tillgång t.ex en aktie eller räntepapper

    public int orderInStockList; //MÅSTE VÄLJAS

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
    //[SerializeField] float amountToTakeInCalcualtion; //Hur många värden tidsserien ska innehålla
    
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
            //Debug.Log("Riskfri ränta: " + riskFreeRate);
            //Debug.Log("Std.avk: " + standardDeviation);
            //sharpeKvot = (returnAsset - riskFreeRate) / standardDeviation;
        }

        sharpeKvot = calculationTools.GetComponent<sharpeRatioCalculation>().sharpeRatio(riskFreeRate, returnAsset, standardDeviation);
    }

    
}

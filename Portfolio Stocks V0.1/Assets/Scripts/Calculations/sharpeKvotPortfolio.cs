using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpeKvotPortfolio : MonoBehaviour
{
    //Ber�knar sharpekvot f�r t.ex hela portf�ljen med olika tillg�ngslag
    //Input som kr�vs: Avkastning portf�lj, Riskfrir�nta, Sv�gning i portf�ljen
    [SerializeField] private float sharpeRatioPortfolio;
    [SerializeField] private float totalReturnAllPortfolioAmount;
    [SerializeField] private float totalReturnAllPortfolioPercent;
    [SerializeField] private float standardDeviationPortfolio;
    [SerializeField] private float riskFreeRate;
    [SerializeField] private float returnStockPortfolio;
    [SerializeField] private float totalInvestedStockPortfolio;
    [SerializeField] private float returnBondPortfolio;
    [SerializeField] private float totalInvestedBondPortfolio;
    public bondMarketManager BondMarketManager;
    public portfolioStock PortfolioStock;
    public bondsPortfolio BondsPortfolio;
    public totalCash TotalCash;

    private void Start()
    {
        //getRiskFreeRate();
    }

    public void getSharpeRatio()
    {
        getRiskFreeRate();
        totalReturnBondsAndStocks();
        standardDeviationPortfolio = GetComponent<standardDeviationCalculation>().calculateStandardDeviation(PortfolioStock.returnPortfolioEachTurn);
        sharpeRatioPortfolio = GetComponent<sharpeRatioCalculation>().sharpeRatio(riskFreeRate, totalReturnAllPortfolioPercent, standardDeviationPortfolio);
     
    }

    public void getRiskFreeRate()
    {
        riskFreeRate = BondMarketManager.bondMarketListGO[BondMarketManager.bondMarketListGO.Count - 1].GetComponent<bondInfoPrefab>().rate/100;
    }

    public void totalReturnBondsAndStocks()
    {
        totalReturnStockPortfolioGet();
        returnBondPortfolioGet();
        totalReturnAllPortfolioAmount = returnStockPortfolio + returnBondPortfolio;
        totalReturnAllPortfolioPercent = totalReturnAllPortfolioAmount / (totalInvestedStockPortfolio + totalInvestedBondPortfolio);
    }

    public void totalReturnStockPortfolioGet()
    {
        totalInvestedStockPortfolio = PortfolioStock.totalInvestAmountPortfolio;
        returnStockPortfolio = PortfolioStock.totalReturnPortfolioAmount;
    }

    public void returnBondPortfolioGet()
    {
        totalInvestedBondPortfolio = BondsPortfolio.totalBondsInvest;
        returnBondPortfolio = TotalCash.incomeBondsLifetime;
    }




   
}

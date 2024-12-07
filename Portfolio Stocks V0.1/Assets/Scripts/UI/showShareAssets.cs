using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showShareAssets : MonoBehaviour
{
    public playerPortfolioAllAssets PlayerPortfolioAllAssets;
    public portfolioStock PortfolioStock;
    public bondsPortfolio BondsPortfolio;
    public totalCash TotalCash;

    //Panel Ett
    public Text nameHeadline;
    public Text assetClassOne;
    public Text assetClassTwo;
    public Text assetClassThree;

    //Panel Två, Andelar
    public Text shareStocks;
    public Text shareBonds;

    //Panel Tre, Avkastning
    public Text returnStocks;
    public Text returnBonds;

    private float shareStockTotalPortfolio;
    private float shareBondsTotalPortfolio;

    private float returnStockPortfolio;
    private float returnBondsPortfolio;

    public void stockAndBondsSharePortfolio()
    {
        shareStockTotalPortfolio = PlayerPortfolioAllAssets.shareStockTotalPortfolio();
        //shareBondsTotalPortfolio = PlayerPortfolioAllAssets.shareBondsTotalPortfolio();
        //Debug.Log("Aktier andel av portfölj: " + shareStockTotalPortfolio);
    }

    public void infoPanelOne()
    {
        nameHeadline.text = " Asset class: ";
        assetClassOne.text = " Stocks: ";
        assetClassTwo.text = " Bonds: ";
        assetClassThree.text = "";

        infoSharePanelStocksVsBonds();
        //returnOnAsset();
        //returnStocks.text = " " + ;
    }

    public void infoSharePanelStocksVsBonds()
    {
        stockAndBondsSharePortfolio();
        shareStocks.text = "" + Mathf.Round(shareStockTotalPortfolio * 10000) / 100 + "%";
        shareBonds.text = "" + Mathf.Round(shareBondsTotalPortfolio * 10000) / 100 + "%";
    }

    public void returnOnAsset()
    {
        PortfolioStock.returnPortfolio();
        returnStockPortfolio = PortfolioStock.totalReturnPortfolioPercent;
        returnStocks.text = " " + Mathf.Round(returnStockPortfolio * 10000) / 100 + "%";

        returnBondsPortfolio = TotalCash.incomeBondsLifetime / BondsPortfolio.getTotalBondsInvestedLifetime();
        //Debug.Log("Intäkter från Räntor under livet: " + TotalCash.incomeBondsLifetime);
        //Debug.Log("Totalt investerat i Räntor under livet: " + BondsPortfolio.getTotalBondsInvestedLifetime());
        returnBonds.text = " " + Mathf.Round(returnBondsPortfolio * 10000) / 100 + "%";
    }


}

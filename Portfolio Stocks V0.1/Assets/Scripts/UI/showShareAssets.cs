using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showShareAssets : MonoBehaviour
{
    public playerPortfolioAllAssets PlayerPortfolioAllAssets;

    //Panel Ett
    public Text nameHeadline;
    public Text assetClassOne;
    public Text assetClassTwo;

    //Panel Två, Andelar
    public Text shareStocks;
    public Text shareBonds;

    private float shareStockTotalPortfolio;
    private float shareBondsTotalPortfolio;

    public void stockAndBondsSharePortfolio()
    {
        shareStockTotalPortfolio = PlayerPortfolioAllAssets.shareStockTotalPortfolio();
        shareBondsTotalPortfolio = PlayerPortfolioAllAssets.shareBondsTotalPortfolio();
        Debug.Log("Aktier andel av portfölj: " + shareStockTotalPortfolio);
    }

    public void infoPanelOne()
    {
        nameHeadline.text = " Asset class: ";
        assetClassOne.text = " Stocks: ";
        assetClassTwo.text = " Bonds: ";
    }

    public void infoSharePanelStocksVsBonds()
    {
        stockAndBondsSharePortfolio();
        shareStocks.text = "" + Mathf.Round(shareStockTotalPortfolio * 10000) / 100 + "%";
        shareBonds.text = "" + Mathf.Round(shareBondsTotalPortfolio * 10000) / 100 + "%";
    }



}

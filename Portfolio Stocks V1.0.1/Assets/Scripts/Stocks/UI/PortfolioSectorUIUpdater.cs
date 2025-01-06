using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class PortfolioSectorUIUpdater : MonoBehaviour
{
    [SerializeField] private Text minesReturnText;
    [SerializeField] private Text railroadReturnText;
    [SerializeField] private Text industryReturnText;

    [SerializeField] private Text shareOfStockPortfolioMines;
    [SerializeField] private Text shareOfStockPortfolioRailroad;
    [SerializeField] private Text shareOfStockPortfolioIndustry;

    private float mineTotalReturnPercent;
    private float railroadTotalReturnPercent;
    private float industryTotalReturnPercent;

    private float mineTotalValue;
    private float railroadTotalValue;
    private float industryTotalValue;

    public PortfolioManager portfolioManager;

    public void UpdateSectorDistribution()
    {
        mineTotalValue = portfolioManager.GetSectorValue(sectorNameEnum.Mine);
        //Debug.Log("Mines (värde): " + mineTotalValue);
        railroadTotalValue = portfolioManager.GetSectorValue(sectorNameEnum.Railroad);
        industryTotalValue = portfolioManager.GetSectorValue(sectorNameEnum.Industri);

        float totalValuePortfolio = mineTotalValue + railroadTotalValue + industryTotalValue;

        if (totalValuePortfolio == 0) return;

        float mineSharePortfolio = mineTotalValue / totalValuePortfolio;
        float railroadSharePortfolio = railroadTotalValue / totalValuePortfolio;
        float industrySharePortfolio = industryTotalValue / totalValuePortfolio;

        Debug.Log("Mines avkastning: " + mineTotalReturnPercent);
        minesReturnText.text = $" {Mathf.Round(mineTotalReturnPercent * 10000) / 100}%";
        railroadReturnText.text = $" {Mathf.Round(railroadTotalReturnPercent * 10000) / 100}%";
        industryReturnText.text = $" {Mathf.Round(industryTotalReturnPercent * 10000) / 100}%";

        shareOfStockPortfolioMines.text = $" {Mathf.Round(mineSharePortfolio * 100)}%";
        shareOfStockPortfolioRailroad.text = $" {Mathf.Round(railroadSharePortfolio * 100)}%";
        shareOfStockPortfolioIndustry.text = $" {Mathf.Round(industrySharePortfolio * 100)}%";
    }

}

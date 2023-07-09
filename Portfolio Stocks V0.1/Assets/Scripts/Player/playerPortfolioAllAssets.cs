using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPortfolioAllAssets : MonoBehaviour
{
    public bondsPortfolio BondsPortfolio;
    public portfolioStock PortfolioStock;

    public float stockShareTotalPortfolio;
    public float bondsShareTotalPortfolio;

    public float shareStockTotalPortfolio()
    {
        PortfolioStock.valuePortfolio();
        stockShareTotalPortfolio = PortfolioStock.totalValuePortfolio/(PortfolioStock.totalValuePortfolio+BondsPortfolio.totalBondsInvest);
        Debug.Log(stockShareTotalPortfolio);

        return stockShareTotalPortfolio;
    }

    public float shareBondsTotalPortfolio()
    {
        bondsShareTotalPortfolio = BondsPortfolio.totalBondsInvest / (PortfolioStock.totalValuePortfolio + BondsPortfolio.totalBondsInvest);
        return bondsShareTotalPortfolio;
    }
}

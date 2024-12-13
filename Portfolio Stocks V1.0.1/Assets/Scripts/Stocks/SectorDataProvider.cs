using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorDataProvider : MonoBehaviour
{
    [SerializeField] private stockMarketManager_1850 StockMarketManager;

    public List<GameObject> GetStockMarketSector(int sectorIndex)
    {
        return sectorIndex switch
        {
            0 => StockMarketManager.StockPrefabListMines,
            1 => StockMarketManager.StockPrefabListRailroad,
            2 => StockMarketManager.StockPrefabListIndustri,
            _ => new List<GameObject>()
        };
    }

    public float GetStockPrice(GameObject company)
    {
        return company.GetComponent<stock>()?.StockPrice[^1] ?? 0;
    }

    public float GetDividendPayout(GameObject company)
    {
        return company.GetComponent<stock>()?.DividendPerShare ?? 0;
    }

    public float GetPayoutRatioOnEPS(GameObject company)
    {
        var stockComponent = company.GetComponent<stock>();
        if (stockComponent == null) return 0;
        return stockComponent.DividendPerShare / stockComponent.EPSnow;
    }
}


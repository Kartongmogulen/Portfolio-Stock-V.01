using System.Collections.Generic;
using UnityEngine;

public interface ISectorDataProvider
{
    List<GameObject> GetStockMarketSector(int sectorIndex);
    float GetStockPrice(GameObject company);
    float GetDividendPayout(GameObject company);
    float GetPayoutRatioOnEPS(GameObject company);
}

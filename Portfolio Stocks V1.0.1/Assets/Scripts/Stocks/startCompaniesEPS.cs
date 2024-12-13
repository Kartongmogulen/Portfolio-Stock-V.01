using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCompaniesEPS : MonoBehaviour
{
    public stockMarketManager_1850 StockMarketManager_1850;

    //Mines
    public List<stock> MinesPrefab;
    public List<float> maxGrowthMines;
    public List<float> minGrowthMines;

    //Railroad
    //public List<stock> RailroadPrefab;
    public List<float> maxGrowthRailroad;
    public List<float> minGrowthRailroad;

    private void Awake()
    {
        //Mines
        foreach (stock prefab in MinesPrefab)
        {
           int indexMax = Random.Range(0, maxGrowthMines.Count - 1);
           prefab.EPSGrowthMax = maxGrowthMines[indexMax];
            maxGrowthMines.RemoveAt(indexMax);

            int indexMin = Random.Range(0, minGrowthMines.Count - 1);
            prefab.EPSGrowthMin = minGrowthMines[indexMin];
            minGrowthMines.RemoveAt(indexMin);
        }

        //Railroad
        foreach (GameObject prefab in StockMarketManager_1850.StockPrefabListRailroad)
        {
            int indexMax = Random.Range(0, maxGrowthRailroad.Count - 1);
            prefab.GetComponent<stock>().EPSGrowthMax = maxGrowthRailroad[indexMax];
            maxGrowthRailroad.RemoveAt(indexMax);

            int indexMin = Random.Range(0, minGrowthRailroad.Count - 1);
            prefab.GetComponent<stock>().EPSGrowthMin = minGrowthRailroad[indexMin];
            minGrowthRailroad.RemoveAt(indexMin);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCompaniesEPS : MonoBehaviour
{
    public List<stock> MinesPrefab;
    public List<float> maxGrowthMines;
    public List<float> minGrowthMines;

    private void Start()
    {
        foreach (stock prefab in MinesPrefab)
        {
           int indexMax = Random.Range(0, maxGrowthMines.Count - 1);
           prefab.EPSGrowthMax = maxGrowthMines[indexMax];
            maxGrowthMines.RemoveAt(indexMax);

            int indexMin = Random.Range(0, minGrowthMines.Count - 1);
            prefab.EPSGrowthMin = minGrowthMines[indexMin];
            minGrowthMines.RemoveAt(indexMin);
        }
    }
}

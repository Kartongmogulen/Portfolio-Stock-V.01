using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stockMarketInventory : MonoBehaviour
{

	public List<stock> Stock;
    //public List<priceStock> StockPrefab;

    public List<GameObject> masterList;
    public List<GameObject> minesList;

    // Start is called before the first frame update
    void Start()
    {

        skapaStartLista();

    }
   
    public void skapaStartLista()
    {
        for (int i = 0; i < masterList.Count; i++)
        {
            if (masterList[i].GetComponent<stock>().SectorNameEnum == sectorNameEnum.Mine)
            {
                minesList.Add(masterList[i]);
            }
        }
    }
}

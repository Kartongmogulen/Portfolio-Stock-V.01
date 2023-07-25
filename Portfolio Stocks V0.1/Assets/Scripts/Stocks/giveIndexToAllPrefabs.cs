using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveIndexToAllPrefabs : MonoBehaviour
{
    //Ge varje bolag ett eget index f�r att underl�tta n�r data ska h�mtas fr�n bolag

    public stockMarketManager StockMarketManager;

    private void Start()
    {
        giveIndex();
    }

    public void giveIndex()
    {
       for (int i = 0; i < StockMarketManager.StockPrefabAllList.Count; i++)
        {
            StockMarketManager.StockPrefabAllList[i].GetComponent<stock>().indexPrefabList = i; 
        }
            
    }
}

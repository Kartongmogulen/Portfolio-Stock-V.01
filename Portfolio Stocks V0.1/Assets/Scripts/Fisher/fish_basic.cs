using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_basic : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] List<int> probabilityByZoneLevel;  //Sannolikhet att fisken i zonen

    public int getProbabiltyByZoneLevel(int level)
    {
        return probabilityByZoneLevel[level];
    }

    public int getPrice()
    {
        return price;
    }
}

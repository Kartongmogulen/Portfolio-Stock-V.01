using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingRodStats : MonoBehaviour
{
    [SerializeField] List<int> probChanceToCatchFishType;
    //[SerializeField] int price;

    public int getProbChangeToCatchFishtype(int i)
    {
        return probChanceToCatchFishType[i];
    }
}

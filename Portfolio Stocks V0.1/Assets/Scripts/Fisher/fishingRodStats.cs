using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingRodStats : MonoBehaviour
{
    [SerializeField] List<int> probChanceToCatchFishType;
    [SerializeField] int probChangeToGetAFish; //F�r�ndring av slh att f� napp oavsett fiskezon
    //[SerializeField] int price;

    public int getProbChangeToCatchFishtype(int i)
    {
        return probChanceToCatchFishType[i];
    }

    public int getprobChangeToGetAFish()
    {
        return probChangeToGetAFish;
    }
}

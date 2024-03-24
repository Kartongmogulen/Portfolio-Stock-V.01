using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingRodStats : MonoBehaviour
{
    [SerializeField] List<int> probChanceToCatchFishType;
    [SerializeField] int probChangeToGetAFish; //Förändring av slh att få napp oavsett fiskezon
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

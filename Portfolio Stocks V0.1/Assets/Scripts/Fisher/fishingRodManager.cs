using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingRodManager : MonoBehaviour
{
    public List<fishingRodStats> FishingRods;
    [SerializeField] List<int> price;

    public int getPrice(int level)
    {
        return price[level];
    }
}

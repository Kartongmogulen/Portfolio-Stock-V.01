using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishzone : MonoBehaviour
{
    [SerializeField] List<int> probToCatchFish;

    public int getProbFishZone(int zone)
    {
        return probToCatchFish[zone];
    }
}

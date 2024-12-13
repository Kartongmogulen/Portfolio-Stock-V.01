using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishzone : MonoBehaviour
{
    [SerializeField] List<int> probToCatchFish;
    [SerializeField] List<bool> needBoat;
    [SerializeField] int zonesThatNeedBoat;

    private void Start()
    {
        zonesThatNeedBoat = getNumberOfZonesThatNeedBoat();
    }

    public int getProbFishZone(int zone)
    {
        return probToCatchFish[zone];
    }

    public int getNumberOfZones()
    {
        return (probToCatchFish.Count);
    }

    public int getNumberOfZonesThatNeedBoat()
    {
        int amount = 0;
        for(int i = 0; i < needBoat.Count; i++)
        {
            if (needBoat[i] == true)
            {
                amount++;
            }
        }

        return amount;
    }
}

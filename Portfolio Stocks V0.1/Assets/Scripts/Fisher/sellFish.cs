using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellFish : MonoBehaviour
{
    public fishManager FishManager;

    private void Start()
    {
        FishManager = FindObjectOfType<fishManager>();
    }

    public int sellFishForMoney(int fishID, int amount)
    {
        return amount * FishManager.typeOfFish[fishID].getPrice();
    }
}

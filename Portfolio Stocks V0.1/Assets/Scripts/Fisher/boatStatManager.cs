using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatStatManager : MonoBehaviour
{
    [SerializeField] int sizeBoat;//Antal anställda som får plats
    [SerializeField] int price;

    public int getPrice()
    {
        return price;
    }

    public int getBoatSize()
    {
        return sizeBoat;
    }
}

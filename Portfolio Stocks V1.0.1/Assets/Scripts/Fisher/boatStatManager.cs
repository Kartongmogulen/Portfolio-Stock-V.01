using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatStatManager : MonoBehaviour
{
    [SerializeField] int sizeBoat;//Antal anst�llda som f�r plats
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

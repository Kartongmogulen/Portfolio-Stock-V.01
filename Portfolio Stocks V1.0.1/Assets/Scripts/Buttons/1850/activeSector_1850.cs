using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeSector_1850 : MonoBehaviour
{
    [SerializeField] int activeSector;

    public void setActiveSector(int index)
    {
        activeSector = index;
    }

    public int getActiveSector()
    {
        return activeSector;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oilSupplyDemandManager : MonoBehaviour
{
    [SerializeField] int oilDemandGlobal; //Efterfrågan på olja
    [SerializeField] int oilDemandYearlyChange;
    [SerializeField] int oilSupplyGlobal; //Efterfrågan på olja
    [SerializeField] int oilSupplyYearlyChange;

    public void oilDemandChange(int demandChange)
    {
        oilDemandYearlyChange += demandChange;
    }
}

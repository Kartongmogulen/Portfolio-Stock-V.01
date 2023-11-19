using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oilSupplyDemandManager : MonoBehaviour
{
    [SerializeField] int oilDemandGlobal; //Efterfr�gan p� olja
    [SerializeField] int oilDemandYearlyChange;
    [SerializeField] int oilSupplyGlobal; //Efterfr�gan p� olja
    [SerializeField] int oilSupplyYearlyChange;

    public void oilDemandChange(int demandChange)
    {
        oilDemandYearlyChange += demandChange;
    }
}

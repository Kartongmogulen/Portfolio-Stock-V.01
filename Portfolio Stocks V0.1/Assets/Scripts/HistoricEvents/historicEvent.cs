using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class historicEvent : MonoBehaviour
{
    [SerializeField] string nameEvent;

    [TextArea(5, 20)]
    [SerializeField] string descpritionEvent;

    [Header("Olja")]
    public int OilCompaniesEarningsChange;
    //[SerializeField] float oilDemandChange;
    //[SerializeField] float oilSupplyChange;

    [Header("Stål")]
    public int MineCompaniesEarningsChange;
    //[SerializeField] float steelDemandChange;
    //[SerializeField] float steelSupplyChange;


    public string getEventName()
    {
        return nameEvent;
    }

    public string getEventDescription()
    {
        return descpritionEvent;
    }

    


}

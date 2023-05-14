using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataPlayerKnowsButtonUnlock : MonoBehaviour
{
    public ShowHistoricData showHistoricData;
    public stock activeCompany;
    public gamePlayScopeManager GamePlayScopeManager;

    public void chooseStock(stock Stock)
    {
        showHistoricData.updateAllHistoricData(Stock);

        activeCompany = Stock;
    }

    //Att-g�ra
    //1. H�mta Prefab f�r bolaget. G�rs i "chooseStock";
    public void unlockEPSyearX(int i)
    {

        if (activeCompany.GetComponent<stockDataPlayerKnow>().EPSdata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] == false)
        {
            activeCompany.GetComponent<stockDataPlayerKnow>().EPSdata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] = true;
        }
        
    }


}

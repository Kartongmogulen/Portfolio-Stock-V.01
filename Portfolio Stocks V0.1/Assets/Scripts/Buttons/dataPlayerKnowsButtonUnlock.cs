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

    //Att-göra
    //1. Hämta Prefab för bolaget. Görs i "chooseStock";
    public void unlockEPSyearX(int i)
    {

        if (activeCompany.GetComponent<stockDataPlayerKnow>().EPSdata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] == false)
        {
            activeCompany.GetComponent<stockDataPlayerKnow>().EPSdata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] = true;
        }
        
    }


}

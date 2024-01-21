using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataPlayerKnowsButtonUnlock : MonoBehaviour
{
    public ShowHistoricData showHistoricData;
    public stock activeCompany;
    public gamePlayScopeManager GamePlayScopeManager;
    public actionPointsManager ActionPointsManager;
    [SerializeField] int costToUnlock;

    public void chooseStock(stock Stock)
    {
        //Debug.Log("ChooseStock: " + Stock.nameOfCompany);
        showHistoricData.updateAllHistoricData(Stock);

        activeCompany = Stock;
    }

    //Att-göra
    //1. Hämta Prefab för bolaget. Görs i "chooseStock";
    public void unlockEPSyearX(int i)
    {
        Debug.Log(showHistoricData.getStartingYear());
        Debug.Log(showHistoricData.getYearNow());

        if (ActionPointsManager.remainingAP >= costToUnlock)
        {
            if (activeCompany.GetComponent<stockDataPlayerKnow>().EPSdata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] == false)
            {
                activeCompany.GetComponent<stockDataPlayerKnow>().EPSdata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] = true;
                ActionPointsManager.actionPointSub(costToUnlock);
            }
        }
    }

    public void unlockEPSChangeYoYyearX(int i)
    {
        
        if (ActionPointsManager.remainingAP >= costToUnlock)
        {
            if (activeCompany.GetComponent<stockDataPlayerKnow>().EPSYoYChangedata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] == false)
            {
                activeCompany.GetComponent<stockDataPlayerKnow>().EPSYoYChangedata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] = true;
                ActionPointsManager.actionPointSub(costToUnlock);
            }
        }
    }

    public void unlockDividendChangeYoYyearX(int i)
    {
        if (ActionPointsManager.remainingAP >= costToUnlock)
        {
            if (activeCompany.GetComponent<stockDataPlayerKnow>().DividendYoYChangedata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] == false)
            {
                activeCompany.GetComponent<stockDataPlayerKnow>().DividendYoYChangedata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] = true;
                ActionPointsManager.actionPointSub(costToUnlock);
            }
        }
    }

    public void unlockPayoutyearX(int i)
    {
        if (ActionPointsManager.remainingAP >= costToUnlock)
        {
            if (activeCompany.GetComponent<stockDataPlayerKnow>().PayoutRatiodata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] == false)
            {
                activeCompany.GetComponent<stockDataPlayerKnow>().PayoutRatiodata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] = true;
                ActionPointsManager.actionPointSub(costToUnlock);
            }
        }
    }
}

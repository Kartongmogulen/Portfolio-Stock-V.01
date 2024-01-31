using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataPlayerKnowsButtonUnlock : MonoBehaviour
{
    public ShowHistoricData showHistoricData;
    public stock activeCompany;
    public incomeStatement activeCompany_IncomeStatement;
    public gamePlayScopeManager GamePlayScopeManager;
    public actionPointsManager ActionPointsManager;
    public activeSector_1850 ActiveSector_1850;
    [SerializeField] int costToUnlock;

    public void chooseStock(stock Stock)
    {
        //Debug.Log("ChooseStock: " + Stock.nameOfCompany);
        showHistoricData.updateAllHistoricData(Stock);

        activeCompany = Stock;
    }

    public void chooseStock_Products(incomeStatement IncomeStatement)
    {
        activeCompany_IncomeStatement = IncomeStatement;
    }

    //Att-göra
    //1. Hämta Prefab för bolaget. Görs i "chooseStock";
    public void unlockEPSyearX(int i)
    {
        //Debug.Log(showHistoricData.getStartingYear());
        //Debug.Log(showHistoricData.getYearNow());

        if (ActiveSector_1850.getActiveSector() == 0 || ActiveSector_1850.getActiveSector() == 1)
        {
            if (ActionPointsManager.remainingAP >= costToUnlock)
            {
                if (activeCompany.GetComponent<stockDataPlayerKnow>().EPSdata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] == false)
                {
                    activeCompany.GetComponent<stockDataPlayerKnow>().EPSdata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] = true;
                    ActionPointsManager.actionPointSub(costToUnlock);
                }
            }
        }

        if (ActiveSector_1850.getActiveSector() == 2)
        {
            Debug.Log("Active sector: 2");
            unlockEPSyearX_Products(i);
        }
    }

    public void unlockEPSChangeYoYyearX(int i)
    {
        if (ActiveSector_1850.getActiveSector() == 0 || ActiveSector_1850.getActiveSector() == 1)
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

        if (ActiveSector_1850.getActiveSector() == 2)
        {
            Debug.Log("Active sector: 2");
            unlockEPSChangeYoYyearX_Products(i);
        }
    }

    public void unlockDividendChangeYoYyearX(int i)
    {

        if (ActiveSector_1850.getActiveSector() == 0 || ActiveSector_1850.getActiveSector() == 1)
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

        if (ActiveSector_1850.getActiveSector() == 2)
        {
            Debug.Log("Active sector: 2");
            unlockDividendChangeYoYyearX_Products(i);
        }
    }

    public void unlockPayoutyearX(int i)
    {
        if (ActiveSector_1850.getActiveSector() == 0 || ActiveSector_1850.getActiveSector() == 1)
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

        if (ActiveSector_1850.getActiveSector() == 2)
        {
            Debug.Log("Active sector: 2");
            unlockPayoutyearX_Products(i);
        }
    }
    //___________________________
    public void unlockEPSyearX_Products(int i)
    {
        Debug.Log("unlockEPSyearX_Products: " + i);

        if (ActionPointsManager.remainingAP >= costToUnlock)
        {
            if (activeCompany_IncomeStatement.GetComponent<stockDataPlayerKnow>().EPSdata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] == false)
            {
                activeCompany_IncomeStatement.GetComponent<stockDataPlayerKnow>().EPSdata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] = true;
                ActionPointsManager.actionPointSub(costToUnlock);
            }
        }
    }

    public void unlockEPSChangeYoYyearX_Products(int i)
    {
        Debug.Log("unlockEPSChangeYoYyearX_Products: " + i);

        if (ActionPointsManager.remainingAP >= costToUnlock)
        {
            if (activeCompany_IncomeStatement.GetComponent<stockDataPlayerKnow>().EPSYoYChangedata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] == false)
            {
                activeCompany_IncomeStatement.GetComponent<stockDataPlayerKnow>().EPSYoYChangedata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] = true;
                ActionPointsManager.actionPointSub(costToUnlock);
            }
        }
    }

    public void unlockDividendChangeYoYyearX_Products(int i)
    {
        Debug.Log("unlockEPSChangeYoYyearX_Products: " + i);

        if (ActionPointsManager.remainingAP >= costToUnlock)
        {
            if (activeCompany_IncomeStatement.GetComponent<stockDataPlayerKnow>().DividendYoYChangedata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] == false)
            {
                activeCompany_IncomeStatement.GetComponent<stockDataPlayerKnow>().DividendYoYChangedata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] = true;
                ActionPointsManager.actionPointSub(costToUnlock);
            }
        }
    }

    public void unlockPayoutyearX_Products(int i)
    {
        Debug.Log("unlockEPSChangeYoYyearX_Products: " + i);

        if (ActionPointsManager.remainingAP >= costToUnlock)
        {
            if (activeCompany_IncomeStatement.GetComponent<stockDataPlayerKnow>().PayoutRatiodata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] == false)
            {
                activeCompany_IncomeStatement.GetComponent<stockDataPlayerKnow>().PayoutRatiodata[showHistoricData.getStartingYear() + showHistoricData.getYearNow() + i] = true;
                ActionPointsManager.actionPointSub(costToUnlock);
            }
        }
    }
}

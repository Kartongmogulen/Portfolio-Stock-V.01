using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyManager : MonoBehaviour
{
    //Hanterar alla transaktioner spelaren genomför

    //==Starting values==
    public float moneyStart;
    public float incomeWorkPerMonth;

    //==COMPONENTS
    public totalCash TotalCash;
    public incomeWork IncomeWork;

    //==Data under spelets gång
    public float moneyNow;
    public float moneyTransactionOrder;

    private void Start()
    {
        TotalCash.moneyStart = moneyStart;
        TotalCash.updateStartingMoney();
        IncomeWork.incomeWorkPerMonth = incomeWorkPerMonth;
    }

    public float moneyTransaction(float startMoney, float moneyTransactionOrder){

        moneyNow = startMoney;
        moneyNow += moneyTransactionOrder;

        return moneyNow;

    }

    public bool enoughMoney(float money, float moneyTransaction)
    {
        if (money >= moneyTransaction)
        {
            return true;
        }
        else
            return false;
    }

   


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyManager : MonoBehaviour
{
    //Hanterar alla transaktioner spelaren genomf�r

    //==Starting values==


    //==COMPONENTS


    //==Data under spelets g�ng
    public float moneyNow;
    public float moneyTransactionOrder;

    public float moneyTransaction(float startMoney, float moneyTransactionOrder){

        moneyNow = startMoney;
        moneyNow += moneyTransactionOrder;

        return moneyNow;

    }


}

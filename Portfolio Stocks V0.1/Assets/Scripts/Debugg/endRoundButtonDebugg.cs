using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endRoundButtonDebugg : MonoBehaviour
{
    //Vad som ska köras för debugg då en runda avslutas

    public stockMarketInventory StockMarketInventory;
    public int companyAmount; //För test. Antal bolag att testa

    public void investInOnlyOneCompany()
    {

        for (int i = 0; i < companyAmount; i++)
        {
            StockMarketInventory.Stock[i].GetComponent<stockSpecificCompany100>().investCompany(i);
        }
        //StockMarketInventory.Stock[0].GetComponent<stockSpecificCompany100>().investCompany(0);
       // StockMarketInventory.Stock[1].GetComponent<stockSpecificCompany100>().investCompany(1);
    }

    public void recieveDividends()
    {
        for (int i = 0; i < companyAmount; i++)
        {
            StockMarketInventory.Stock[i].GetComponent<stockSpecificCompany100>().recieveDividens(i);
        }
    }

}

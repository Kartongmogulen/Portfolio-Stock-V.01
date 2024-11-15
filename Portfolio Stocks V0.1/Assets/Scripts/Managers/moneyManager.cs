using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public interface ITotalCash
    {
        float MoneyStart { get; set; }
        void UpdateStartingMoney();
    }

    public interface IIncomeWork
    {
        float IncomeWorkPerMonth { get; set; }
    }

public class moneyManager : MonoBehaviour, ITransaction
{
    [SerializeField] private float startingCapital;

    private ITotalCash totalCash;
    private IIncomeWork incomeWork;
    [SerializeField] public float MoneyNow { get; private set; }

    private void Awake()
    {
        MoneyNow = startingCapital;
        Debug.Log("MoneyStart: " + MoneyNow);
       
    }

    public moneyManager(ITotalCash totalCash, IIncomeWork incomeWork)
    {
        this.totalCash = totalCash;
        this.incomeWork = incomeWork;
    }

    public bool HasEnoughMoney(float transactionAmount)
    {
      
        return MoneyNow >= transactionAmount;
    }

    public void InitializeStartingValues(float moneyStart, float incomeWorkPerMonth)
    {
        totalCash.MoneyStart = moneyStart;
        totalCash.UpdateStartingMoney();
        incomeWork.IncomeWorkPerMonth = incomeWorkPerMonth;
    }

    public void buyTransaction(float amount)
    {
        MoneyNow -= amount;
        Debug.Log("MonyeNow: " + MoneyNow);
    }

    public void sellTransaction(float amount)
    {
        MoneyNow += amount;
    }
}


/* INNAN REFACTOR
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
*/

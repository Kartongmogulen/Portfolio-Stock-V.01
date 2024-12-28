using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface ITotalCash
    {
        float MoneyStart { get; set; }
        void UpdateStartingMoney();
    }


public class moneyManager : MonoBehaviour, ITransaction
{
    [SerializeField] private float startingCapital;
    [SerializeField] private float incomeWorkPerMonth; // Direkt hantering av lönen.

    private ITotalCash totalCash;
    private IMoneyVisualizer moneyVisualizer;

    [SerializeField] public float MoneyNow { get; private set; }

    private void Awake()
    {
        MoneyNow = startingCapital;
        //Debug.Log("MoneyStart: " + MoneyNow);

        moneyVisualizer = GetComponent<IMoneyVisualizer>();

        if (moneyVisualizer != null)
        {
            moneyVisualizer.UpdateMoneyDisplay(MoneyNow);
        }
        else
        {
            Debug.LogWarning("No money visualizer attached!");
        }

    }

    public moneyManager(ITotalCash totalCash)//, IIncomeWork incomeWork)
    {
        this.totalCash = totalCash;
        //this.incomeWork = incomeWork;
    }

    public bool HasEnoughMoney(float transactionAmount)
    {
      
        return MoneyNow >= transactionAmount;
    }

    public void InitializeStartingValues(float moneyStart, float incomeWorkPerMonth)
    {
        totalCash.MoneyStart = moneyStart;
        totalCash.UpdateStartingMoney();
        //incomeWork.IncomeWorkPerMonth = incomeWorkPerMonth;
    }

    public void buyTransaction(float amount)
    {
        MoneyNow -= amount;
        Debug.Log("MonyeNow: " + MoneyNow);
        moneyVisualizer?.UpdateMoneyDisplay(MoneyNow);

    }

    public void sellTransaction(float amount)
    {
        MoneyNow += amount;
        moneyVisualizer?.UpdateMoneyDisplay(MoneyNow);
    }

    public void AddIncome()
    {
        MoneyNow += incomeWorkPerMonth; // Lägg till lönen.
        moneyVisualizer?.UpdateMoneyDisplay(MoneyNow);
    }

    public void AddDividendIncome(float divIncome)
    {
        Debug.Log("Utdelning: " + divIncome);
        MoneyNow += divIncome;
        moneyVisualizer?.UpdateMoneyDisplay(MoneyNow);
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

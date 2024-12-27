using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DividendManager: MonoBehaviour
{
    [SerializeField]
    private PortfolioManager portfolioManager; // Referens till spelarens portf�lj

    [SerializeField]
    private Dictionary<GameObject, float> dividendsPaidThisYear = new Dictionary<GameObject, float>();
    
    [SerializeField]
    private float totalDividendsReceived;

    [SerializeField]
    public float totalDividendsReceivedThisYear { get; private set; }

    public stockPriceManager StockPriceManager;
    public timeManager TimeManager;

    public void UpdateAllDividendsEndOfYear()
    {
        //Debug.Log("UpdateAllDividendsEndOfYear");
        if (TimeManager.month == 1)
        {
            
            foreach (var company in StockPriceManager.Companies)
            {
                //Kontrollerar om bolaget inneh�ller scriptet "stock"
                if(company.GetComponent<stock>  ()!= null)
                company.GetComponent<stock>().UpdateDividendsEndOfYear();
            }
        }
    }


    /// <summary>
    /// Betalar ut utdelningar f�r alla f�retag i portf�ljen.
    /// </summary>
    public void PayDividends()
    {
        if (TimeManager.month == 1)
        {
            dividendsPaidThisYear.Clear();
           
            foreach (var entry in portfolioManager.GetPortfolioEntries())
            {
                if (entry.Company.TryGetComponent(out IDividendPayingCompany company))
                {
                    float dividend = company.DividendPerShare * entry.NumberOfShares;
                    totalDividendsReceived += dividend;
                    totalDividendsReceivedThisYear += dividend;
                    dividendsPaidThisYear[entry.Company] = dividend;
                }

                GetComponent<moneyManager>().AddDividendIncome(totalDividendsReceivedThisYear);
                totalDividendsReceivedThisYear = 0;
            }

            //Debug.Log($"Total dividends received this year: {totalDividendsReceivedThisYear}");
        }
    }

}

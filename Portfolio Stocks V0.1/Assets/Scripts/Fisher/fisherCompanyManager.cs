using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fisherCompanyManager : MonoBehaviour
{
    public incomeStatement IncomeStatement;
    public managementPriorites_FisherCompany ManagementPriorites_FisherCompany;
    public endRoundButton EndRoundButton;

    private void Awake()
    {
        IncomeStatement = GetComponent<incomeStatement>();
        ManagementPriorites_FisherCompany = GetComponent<managementPriorites_FisherCompany>();
        EndRoundButton = FindObjectOfType<endRoundButton>();
    }

    public void yearEnd()
    {
        if (EndRoundButton.month == 1)
        {
            //Data från året sparas
            addRevenue();

            //Årets resultat fördelas
            allocateCapital();
            investInNewEmployees();
            investInFishingRods();
            investInBoats();
            addCost();

            //Antar att alla pengar används
            resetMoney();
        }
    }

    public void addRevenue()
    {
        IncomeStatement.revenue_AddOwnAmount(GetComponent<fisherCompanyStats>().getMoney());
        IncomeStatement.EarningHistory.Add(GetComponent<fisherCompanyStats>().getMoney()); //ENDAST FÖR TEST INNAN KOSTNADER FINNS. SKA TAS BORT NÄR KOSTNADER IMPLEMENTERAS!
    }

    public void addCost()
    {
       int costToAdd = Mathf.RoundToInt(ManagementPriorites_FisherCompany.boatInvestAmount + ManagementPriorites_FisherCompany.fishingRodAmount + ManagementPriorites_FisherCompany.employeesHireAmount);
        IncomeStatement.cost_AddOwnAmount(costToAdd);
    }

    public void allocateCapital()
    {
        ManagementPriorites_FisherCompany.allocateCapital();
    }

    public void investInBoats()
    {
        GetComponent<fisherCompanyStats>().buyBoatsAmount(ManagementPriorites_FisherCompany.boatInvestAmount);
    }

    public void investInNewEmployees()
    {
        GetComponent<fisherCompanyStats>().employeesInvest(ManagementPriorites_FisherCompany.employeesHireAmount);
    }

    public void investInFishingRods()
    {
        GetComponent<fisherCompanyStats>().buyFishingRodAmount(ManagementPriorites_FisherCompany.fishingRodAmount,0);
    }

    public void resetMoney()
    {
        GetComponent<fisherCompanyStats>().resetMoney();
    }
}

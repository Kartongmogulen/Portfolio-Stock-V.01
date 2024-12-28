using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InvestmentData;

public class AIManager_CardMechanic : MonoBehaviour
{
    public List<InvestmentInstance> activeInvestments = new List<InvestmentInstance>();

    [Header("Key Figures")]
    public float investedCapitalTotal;
    public float returnTotal;
    public float depreciationTotal;

    public moneyManager MoneyManager;
    public InvestmentManager investmentManager;
    public actionPointsManager ActionPointsManager;
    public gamePlayScopeManager GamePlayScopeManager;
    public timeManager TimeManager;

    [Header("AI Behavior")]
    //[SerializeField] private float investmentFrequency = 5f; // Hur ofta AI g�r investeringar (i sekunder)
    [SerializeField] private float expectedValueThreshold;
    [SerializeField] private float stopInvestYearsBeforeGameEnds = 5; // Antal �r innan AI slutar investerar f�r att samla kapital

    private void Start()
    {
        ActionPointsManager = GetComponent<actionPointsManager>();
        GamePlayScopeManager = FindAnyObjectByType<gamePlayScopeManager>();
        TimeManager = FindObjectOfType<timeManager>();
        //StartCoroutine(AutoInvest());
        Invoke("investInProject", 0.1f);
    }

    /*
    private IEnumerator AutoInvest()
    {
        while (true)
        {
            yield return new WaitForSeconds(investmentFrequency);

            // V�lj ett projekt att investera i
            InvestmentInstance newInvestment = ChooseInvestment();

            if (newInvestment != null && MoneyManager.MoneyNow >= newInvestment.investmentType.cost)
            {
                AddInvestment(newInvestment);
                MoneyManager.buyTransaction(newInvestment.investmentType.cost);
                //aiCapital -= newInvestment.investmentType.cost;
            }

            UpdateInvestments();
        }
    }*/

        public void investInProject()
    {
        //Slutar investera n�r viss tid �terst�r av spelet f�r att samla kapital
        if (GamePlayScopeManager.yearsBeforeEndGameMaster >= TimeManager.year + stopInvestYearsBeforeGameEnds)
        {
            //Debug.Log(GamePlayScopeManager.yearsBeforeEndGameMaster >= TimeManager.year + stopInvestYearsBeforeGameEnds);
            while (ActionPointsManager.remainingAP > 0)
            {
                //Debug.Log("InvestInProject");

                InvestmentInstance project = investmentManager.ChooseRandomInvestment();

                //Debug.Log("Potentiell avkastning: " + project.potentialReturn);
                //Debug.Log("Gr�nsv�rde f�r att genomf�ra investering: " + expectedValueThreshold);
                if (project != null && project.investmentType.expectedValue > expectedValueThreshold)
                {
                    activeInvestments.Add(project);
                }
                ActionPointsManager.actionPointSub(1);
            }
        }
    }

    /*
    private InvestmentInstance ChooseInvestment()
    {
        // H�mta tillg�ngliga projekt fr�n InvestmentManager
        var investmentManager = FindObjectOfType<InvestmentManager>();
        List<InvestmentTypeData> possibleInvestments = investmentManager.possibleInvestments;

        // Filtrera och v�lj investering baserat p� AI-logik
        InvestmentInstance chosenInvestment = null;

        foreach (InvestmentTypeData project in possibleInvestments)
        {
            if (project.ROIpotential / project.cost >= riskTolerance)
            {
                chosenInvestment = project;
                break; // V�lj f�rsta l�mpliga projektet
            }
        }

        return chosenInvestment;
    }

    public void AddInvestment(InvestmentInstance investment)
    {
        activeInvestments.Add(investment);
        depreciationTotal += investment.investmentType.cost;
    }
    */
    public void UpdateInvestments()
    {
        for (int i = activeInvestments.Count - 1; i >= 0; i--)
        {
            activeInvestments[i].IncrementAge();

            if (activeInvestments[i].HasReachedEndOfLifetime())
            {
                CollectReturn(activeInvestments[i]);
                activeInvestments.RemoveAt(i);
            }
        }
    }

    public void CollectReturn(InvestmentInstance investment)
    {
        MoneyManager.sellTransaction(investment.potentialReturn + investment.investmentType.cost);
        returnTotal += investment.potentialReturn;
    }
    
    
}

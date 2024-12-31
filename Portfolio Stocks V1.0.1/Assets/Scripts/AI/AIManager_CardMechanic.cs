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

    [SerializeField] int succesfullInvestments;
    [SerializeField] int failedInvestments;
    [SerializeField] int skippedInvestments;

    public moneyManager MoneyManager;
    public InvestmentManager investmentManager;
    public actionPointsManager ActionPointsManager;
    public gamePlayScopeManager GamePlayScopeManager;
    public timeManager TimeManager;

    [Header("AI Behavior")]
    //[SerializeField] private float investmentFrequency = 5f; // Hur ofta AI gör investeringar (i sekunder)
    [SerializeField]
    private int newProjectsEachRound;
    [Tooltip("Lägsta väntevärde spelaren accepterar")]
    [SerializeField] private float expectedValueThreshold;
    [Tooltip("Lägsta sannolikheten att investeringen lyckas")]
    [SerializeField] private float riskTolerance;
    [SerializeField] private float stopInvestYearsBeforeGameEnds = 5; // Antal år innan AI slutar investerar för att samla kapital

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

            // Välj ett projekt att investera i
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
        //Slutar investera när viss tid återstår av spelet för att samla kapital
        if (GamePlayScopeManager.yearsBeforeEndGameMaster >= TimeManager.year + stopInvestYearsBeforeGameEnds)
        {
            //Debug.Log(GamePlayScopeManager.yearsBeforeEndGameMaster >= TimeManager.year + stopInvestYearsBeforeGameEnds);
            while (ActionPointsManager.remainingAP > 0)
            {
                //Debug.Log("InvestInProject");
                ActionPointsManager.actionPointSub(1);
                InvestmentInstance project = investmentManager.ChooseRandomInvestment();

                // Slumpa ett tal mellan 0 och 1 för att avgöra om investeringen lyckas
                float randomChance = Random.Range(0f, 1f);

                //Debug.Log("InvestInProject");
                if (project != null)
                {
                    if (MoneyManager.MoneyNow >= project.investmentType.cost)
                    {
                        //Debug.Log("Pengar och Projekt finns");
                        if (randomChance <= project.investmentType.successProbability)
                        {
                            if (project.investmentType.expectedValue > expectedValueThreshold)
                            {
                                //Debug.Log("" + project.investmentType.name + "Klarar väntevärdeskrav");
                                if (project.investmentType.successProbability >= riskTolerance)
                                {
                                    activeInvestments.Add(project);
                                    succesfullInvestments++;
                                }
                                else
                                {
                                    //Debug.Log("" + project.investmentType.name + "För riskfyllt projekt!");
                                    skippedInvestments++;
                                }
                            }
                            else
                            {
                                //Debug.Log("" + project.investmentType.name + "INTE tillräckligt lönsamt");
                            }
                        }

                        else
                        {
                            //Debug.Log("Pengar och Projekt finns INTE");
                            failedInvestments++;
                        }

                        investmentManager.removeProject();

                    }
                    
                }
                
            }

            investmentManager.addProjectsToAvailableList(newProjectsEachRound);

        }
    }

    /*
    private InvestmentInstance ChooseInvestment()
    {
        // Hämta tillgängliga projekt från InvestmentManager
        var investmentManager = FindObjectOfType<InvestmentManager>();
        List<InvestmentTypeData> possibleInvestments = investmentManager.possibleInvestments;

        // Filtrera och välj investering baserat på AI-logik
        InvestmentInstance chosenInvestment = null;

        foreach (InvestmentTypeData project in possibleInvestments)
        {
            if (project.ROIpotential / project.cost >= riskTolerance)
            {
                chosenInvestment = project;
                break; // Välj första lämpliga projektet
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

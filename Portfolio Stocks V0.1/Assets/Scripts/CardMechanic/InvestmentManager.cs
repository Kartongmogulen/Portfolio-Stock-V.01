using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InvestmentData;  // Se till att referera till InvestmentData

public class InvestmentManager : MonoBehaviour
{
    public bool fixedProjects;
    public bool randomProjects;
    [SerializeField] int numberOfProjectsStart;

    public List<InvestmentTypeData> availableInvestments;  // Lista �ver ScriptableObject-baserade investeringstyper
    public List<InvestmentTypeData> possibleInvestments;  // Lista �ver ScriptableObject-baserade investeringstyper som spelaren eventuellt kan f� v�lja av
    public List<InvestmentTypeData> investmentsLevelOne;  // Lista �ver ScriptableObject-baserade investeringstyper
    public List<InvestmentTypeData> investmentsLevelTwo;  // Lista �ver ScriptableObject-baserade investeringstyper
    public List<InvestmentTypeData> investmentsLevelThree;  // Lista �ver ScriptableObject-baserade investeringstyper
    //public List<InvestmentType> availableInvestments = new List<InvestmentType>();  // Lista �ver tillg�ngliga investeringstyper
    public PlayerManager playerManager; // Referens till PlayerManager
    public actionPointsManager ActionPointsManager;
    public InvestInfoUI investInfoUI;
    [SerializeField] int investmentIndex; //Aktuell investering
    public gamePlayScopeManager GamePlayScopeManager;



    void Start()
    {
        while (possibleInvestments.Count < numberOfProjectsStart)
        {
            Debug.Log("L�gg till projekt Start");
            addProjectsToAvailableList();
        }

        chooseProjectIndex(investmentIndex);

    }

    public void addProjectsToAvailableList()
    {
        if (fixedProjects == true)
        {
            foreach (InvestmentTypeData projects in investmentsLevelOne)
            {
                availableInvestments.Add(projects);
            }
        }

        else if (randomProjects == true)
        {

            //for (int i = 0; i < numberOfProjects; i++)
            //{
                int randomInt = Random.Range(0, investmentsLevelOne.Count);

                if (GamePlayScopeManager.Difficulty == gamePlayScopeManager.difficulty.Easy)
                {
                    if (investmentsLevelOne[randomInt].expectedAnnualReturnPercentage >= 5f)
                    {
                        availableInvestments.Add(investmentsLevelOne[randomInt]);
                        possibleInvestments.Add(investmentsLevelOne[randomInt]);
                    }
                    else
                    {
                        Debug.Log("F�r l�g f�rv�ntad ROI, nytt f�rs�k");

                    }
                }

                if (GamePlayScopeManager.Difficulty == gamePlayScopeManager.difficulty.Medium)
                {

                    availableInvestments.Add(investmentsLevelOne[randomInt]);
                    possibleInvestments.Add(investmentsLevelOne[randomInt]);
                }
                else
                {
                    Debug.Log("F�r l�g f�rv�ntad ROI");
                }
            }
        //}
    }

    public void addNewProjectsWhenPlayerLevelUp(int level)
    {
        if (level == 1)
        {
            foreach (InvestmentTypeData newProjects in investmentsLevelTwo)
            {
                possibleInvestments.Add(newProjects);
            }
        }

        else
        {
            Debug.Log("MAX LEVEL");
            return;
        }
    }

    public void chooseProjectIndex(int index)
    {
        if (availableInvestments.Count > 0)
        {
            investInfoUI.updateInvestInfo(availableInvestments[index], index);
        }
        else
        {
            investInfoUI.noMoreProjectsToChooseFrom();
        }
    }

    public void removeProject()
    {
        if (availableInvestments.Count > 0)
        {
            availableInvestments.RemoveAt(investmentIndex);
        }
    }

    public void investInProject()
    {
        if (availableInvestments.Count > 0)
        {
            InvestmentTypeData chosenInvestmentType = availableInvestments[investmentIndex];

            if (playerManager.playerCapitalGet() >= chosenInvestmentType.cost && ActionPointsManager.remainingAP > 0)
            {
                playerManager.investedCapital(chosenInvestmentType.cost); //Sparar totalt kapital som spelaren investerar. F�r statistik
                Debug.Log("Tillr�ckligt med kapital finns");
                playerManager.playerCapitalSet(-chosenInvestmentType.cost);
                ActionPointsManager.actionPointSub(1);

                // Slumpa ett tal mellan 0 och 1 f�r att avg�ra om investeringen lyckas
                float randomChance = Random.Range(0f, 1f);

                if (randomChance <= chosenInvestmentType.successProbability)
                {
                    // Om investeringen lyckas, skapa en ny individuell investering
                    InvestmentInstance newInvestment = new InvestmentInstance(chosenInvestmentType);
                    playerManager.AddInvestment(newInvestment); // L�gg till investeringen i spelarens aktiva investeringar

                    Debug.Log(chosenInvestmentType.name + " lyckades! Kostnad: " + chosenInvestmentType.cost +
                              ", Potentiell avkastning: " + newInvestment.potentialReturn);
                }
                else
                {
                    Debug.Log(chosenInvestmentType.name + " misslyckades.");
                }
            }
            else
            {
                Debug.Log("Inte tillr�ckligt med pengar");
            }
        }
        else
        {
            investInfoUI.noMoreProjectsToChooseFrom();
        }
    }

    
        public void ChooseRandomInvestment()
        {
            if (availableInvestments.Count > 0)
            {
                // V�lj ett slumpm�ssigt objekt fr�n listan
                int randomIndex = Random.Range(0, availableInvestments.Count);
                InvestmentTypeData chosenInvestmentType = availableInvestments[randomIndex];

                //Kontrollera om tillr�ckligt med kapital finns
                if (playerManager.playerCapitalGet() >= chosenInvestmentType.cost)
                {
                    Debug.Log("Tillr�ckligt med kapital finns");
                    playerManager.playerCapitalSet(-chosenInvestmentType.cost);
                    // Slumpa ett tal mellan 0 och 1 f�r att avg�ra om investeringen lyckas
                    float randomChance = Random.Range(0f, 1f);

                    if (randomChance <= chosenInvestmentType.successProbability)
                    {
                        // Om investeringen lyckas, skapa en ny individuell investering
                        InvestmentInstance newInvestment = new InvestmentInstance(chosenInvestmentType);
                        playerManager.AddInvestment(newInvestment); // L�gg till investeringen i spelarens aktiva investeringar

                        Debug.Log(chosenInvestmentType.name + " lyckades! Kostnad: " + chosenInvestmentType.cost +
                                  ", Potentiell avkastning: " + newInvestment.potentialReturn);
                    }
                    else
                    {
                        Debug.Log(chosenInvestmentType.name + " misslyckades.");
                    }
                }

                else
                {
                    Debug.Log("Inte tillr�ckligt med pengar");
                }
            }
            else
            {
                Debug.Log("Inga tillg�ngliga investeringar.");
            }
        }


    public void investmentIndexChange(int changeValue)
    {
        investmentIndex += changeValue;

        if (availableInvestments.Count == 0)
        {
            investInfoUI.noMoreProjectsToChooseFrom();
        }
        else
        {
            //Kontrollerar s� inte v�rdet passerar maxindex
            if (investmentIndex > availableInvestments.Count - 1)
            {
                investmentIndex = availableInvestments.Count - 1;
                investInfoUI.updateInvestInfo(availableInvestments[investmentIndex], investmentIndex);
            }

            //Kontrollerar s� inte v�rdet blir negativt
            else if (investmentIndex < 0)
            {
                investmentIndex = 0;
                //investInfoUI.noMoreProjectsToChooseFrom();
            }

            else
            {
                investInfoUI.updateInvestInfo(availableInvestments[investmentIndex], investmentIndex);
            }
        }
    }
}


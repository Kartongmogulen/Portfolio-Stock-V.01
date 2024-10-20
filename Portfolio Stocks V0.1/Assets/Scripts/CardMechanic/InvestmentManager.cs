using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InvestmentData;  // Se till att referera till InvestmentData

public class InvestmentManager : MonoBehaviour
{
    public bool fixedProjects;
    public bool randomProjects;
    [SerializeField] int numberOfProjectsStart;

    public List<InvestmentTypeData> availableInvestments;  // Lista över ScriptableObject-baserade investeringstyper
    public List<InvestmentTypeData> possibleInvestments;  // Lista över ScriptableObject-baserade investeringstyper som spelaren eventuellt kan få välja av
    public List<InvestmentTypeData> investmentsLevelOne;  // Lista över ScriptableObject-baserade investeringstyper
    public List<InvestmentTypeData> investmentsLevelTwo;  // Lista över ScriptableObject-baserade investeringstyper
    public List<InvestmentTypeData> investmentsLevelThree;  // Lista över ScriptableObject-baserade investeringstyper
    //public List<InvestmentType> availableInvestments = new List<InvestmentType>();  // Lista över tillgängliga investeringstyper
    public PlayerManager playerManager; // Referens till PlayerManager
    public actionPointsManager ActionPointsManager;
    public InvestInfoUI investInfoUI;
    [SerializeField] int investmentIndex; //Aktuell investering
    public gamePlayScopeManager GamePlayScopeManager;



    void Start()
    {
        while (possibleInvestments.Count < numberOfProjectsStart)
        {
            Debug.Log("Lägg till projekt Start");
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
                        Debug.Log("För låg förväntad ROI, nytt försök");

                    }
                }

                if (GamePlayScopeManager.Difficulty == gamePlayScopeManager.difficulty.Medium)
                {

                    availableInvestments.Add(investmentsLevelOne[randomInt]);
                    possibleInvestments.Add(investmentsLevelOne[randomInt]);
                }
                else
                {
                    Debug.Log("För låg förväntad ROI");
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
                playerManager.investedCapital(chosenInvestmentType.cost); //Sparar totalt kapital som spelaren investerar. För statistik
                Debug.Log("Tillräckligt med kapital finns");
                playerManager.playerCapitalSet(-chosenInvestmentType.cost);
                ActionPointsManager.actionPointSub(1);

                // Slumpa ett tal mellan 0 och 1 för att avgöra om investeringen lyckas
                float randomChance = Random.Range(0f, 1f);

                if (randomChance <= chosenInvestmentType.successProbability)
                {
                    // Om investeringen lyckas, skapa en ny individuell investering
                    InvestmentInstance newInvestment = new InvestmentInstance(chosenInvestmentType);
                    playerManager.AddInvestment(newInvestment); // Lägg till investeringen i spelarens aktiva investeringar

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
                Debug.Log("Inte tillräckligt med pengar");
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
                // Välj ett slumpmässigt objekt från listan
                int randomIndex = Random.Range(0, availableInvestments.Count);
                InvestmentTypeData chosenInvestmentType = availableInvestments[randomIndex];

                //Kontrollera om tillräckligt med kapital finns
                if (playerManager.playerCapitalGet() >= chosenInvestmentType.cost)
                {
                    Debug.Log("Tillräckligt med kapital finns");
                    playerManager.playerCapitalSet(-chosenInvestmentType.cost);
                    // Slumpa ett tal mellan 0 och 1 för att avgöra om investeringen lyckas
                    float randomChance = Random.Range(0f, 1f);

                    if (randomChance <= chosenInvestmentType.successProbability)
                    {
                        // Om investeringen lyckas, skapa en ny individuell investering
                        InvestmentInstance newInvestment = new InvestmentInstance(chosenInvestmentType);
                        playerManager.AddInvestment(newInvestment); // Lägg till investeringen i spelarens aktiva investeringar

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
                    Debug.Log("Inte tillräckligt med pengar");
                }
            }
            else
            {
                Debug.Log("Inga tillgängliga investeringar.");
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
            //Kontrollerar så inte värdet passerar maxindex
            if (investmentIndex > availableInvestments.Count - 1)
            {
                investmentIndex = availableInvestments.Count - 1;
                investInfoUI.updateInvestInfo(availableInvestments[investmentIndex], investmentIndex);
            }

            //Kontrollerar så inte värdet blir negativt
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


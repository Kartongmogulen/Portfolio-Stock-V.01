using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InvestmentData;  // Se till att referera till InvestmentData


public class PlayerManager : MonoBehaviour
{
    
    public List<InvestmentInstance> activeInvestments = new List<InvestmentInstance>(); // Lista över aktiva investeringar (individuella instanser)

    [Header("Key figures")]
    //public float investedCapitalTotal { get; private set; }
    public float investedCapitalTotal;
    //public float returnTotal { get; private set; }
    public float returnTotal;
    
    [Header("Player Level")]
    public Text playerLevelText;
    public int playerLevel { get; private set; }
    [SerializeField] int playerExpPointsInvested; //Antal poäng som investerats innan level upp
    [SerializeField] int levelUpCost;
    [SerializeField] int levelMax = 2;
    [SerializeField] int numberOfNewProjectsEachRoundValueStart;
    [SerializeField] int numberOfNewProjectsEachRound;// ValueStart;
    public int maxNumberOfAviableProjects { get; private set; }
    [SerializeField] int maxNumberOfAviableProjectsStart;

    //public int numberOfNewProjectsEachRoundValueNow { get; private set; }

    public moneyManager MoneyManager;
    public actionPointsManager ActionPointsManager;
    public InvestmentManager investmentManager;

    private void Start()
    {
        updateUI(false);
        
        ActionPointsManager = GetComponent<actionPointsManager>();
        investmentManager = GetComponent<InvestmentManager>();

        numberOfNewProjectsEachRound = numberOfNewProjectsEachRoundValueStart;
        maxNumberOfAviableProjects = maxNumberOfAviableProjectsStart; 
    }

    public int getNewProjectsToAvailiableList()
    {
        return numberOfNewProjectsEachRound;
    }

    public void updateUI(bool maxlevelReached)
    {
        if (maxlevelReached == false)
        playerLevelText.text = "Player level: " + playerLevel + " (Points to Level up: " + playerExpPointsInvested + "/" + levelUpCost +")";
        else
        {
            playerLevelText.text = "Player level: " + playerLevel + "(MAX)";
        }
    }

    // Funktion för att lägga till en ny investering till spelarens lista
    public void AddInvestment(InvestmentInstance investment)
    {
        activeInvestments.Add(investment);
        //depreciationTotal += investment.investmentType.cost;
        //Debug.Log("Ny investering tillagd: " + investment.investmentType.name + ", Potentiell avkastning: " + investment.potentialReturn);
    }

    // Funktion för att samla in avkastningen från en investering
    public void CollectReturn(InvestmentInstance investment)
    {
        //playerCapital += (investment.potentialReturn + investment.investmentType.cost);
        MoneyManager.sellTransaction(investment.potentialReturn);
        returnTotal += (investment.potentialReturn);
        //Debug.Log("Avkastning från " + investment.investmentType.name + " samlad in! Spelarens kapital: " + playerCapital);
        //updateMoneyText();
    }

    public void investedCapital(float amount)
    {
        investedCapitalTotal += amount;
    }

    // Funktion för att uppdatera investeringarnas ålder och ta bort gamla
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

        //Debug.Log("Aktiva investeringar uppdaterade. Kvarvarande: " + activeInvestments.Count);
    }

    public void levelUpPlayer()
    {
        if (playerLevel < levelMax)
        {
            playerLevel++;
            updateUI(false);
        }

        if (playerLevel == levelMax)
        {
            updateUI(true);
        }
    }

    public void investActionPointsToLevelUp()
    {
        int actionPointsLeft = ActionPointsManager.remainingAP;
        
        //Kontroll om spelaren uppnått MAX-level
        if (playerLevel < levelMax)
        {
            //Kontrollera om ActionPoints finns kvar
            if (actionPointsLeft > 0)
            {
                ActionPointsManager.actionPointSub(1);
                playerExpPointsInvested++;
            }

            //Lvl-up spelaren
            if (playerExpPointsInvested == levelUpCost)
            {
                levelUpPlayer();
                investmentManager.addNewProjectsWhenPlayerLevelUp(playerLevel);
                playerExpPointsInvested = 0;
            }
            updateUI(false);
        }
        
        if(playerLevel == levelMax)
        {
            updateUI(true);
        }
    }
}

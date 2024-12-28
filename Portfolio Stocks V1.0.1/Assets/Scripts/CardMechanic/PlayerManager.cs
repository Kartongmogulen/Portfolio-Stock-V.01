using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InvestmentData;  // Se till att referera till InvestmentData


public class PlayerManager : MonoBehaviour
{
    //[SerializeField] float playerCapitalStart;    
    //public float playerCapital { get; private set; }
    //public Text playerCapitalText;

    public List<InvestmentInstance> activeInvestments = new List<InvestmentInstance>(); // Lista över aktiva investeringar (individuella instanser)

    [Header("Key figures")]
    //public float investedCapitalTotal { get; private set; }
    public float investedCapitalTotal;
    //public float returnTotal { get; private set; }
    public float returnTotal;
    public float depreciationTotal;

    [Header("Player Level")]
    public Text playerLevelText;
    public int playerLevel { get; private set; }
    [SerializeField] int playerExpPointsInvested; //Antal poäng som investerats innan level upp
    [SerializeField] int levelUpCost;

    public moneyManager MoneyManager;

    private void Start()
    {
        updateUI();
    }

    public void updateUI()
    {
        playerLevelText.text = "Player level: " + playerLevel + " (Points to Level up: " + playerExpPointsInvested + "/" + levelUpCost +")";
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

    /*
    void updateMoneyText()
    {
        playerCapitalText.text = "Money: " + playerCapital;
    }
    

    public float playerCapitalGet()
    {
        return playerCapital;
    }

    public void playerCapitalSet(float transaction)
    {
        playerCapital += transaction;
        //updateMoneyText();
    }
    */
    public void levelUpPlayer()
    {
        playerLevel++;
        updateUI();
    }

    public void investActionPointsToLevelUp()
    {
        int actionPointsLeft = FindObjectOfType<actionPointsManager>().remainingAP;
       
        //Kontrollera om ActionPoints finns kvar
        if (actionPointsLeft > 0)
        {
            FindObjectOfType<actionPointsManager>().actionPointSub(1);
            playerExpPointsInvested++;
        }

        //Lvl-up spelaren
        if(playerExpPointsInvested == levelUpCost)
        {
            levelUpPlayer();
            FindObjectOfType<InvestmentManager>().addNewProjectsWhenPlayerLevelUp(playerLevel);
            playerExpPointsInvested = 0;
        }

        updateUI();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InvestmentData;  // Se till att referera till InvestmentData


public class PlayerManager : MonoBehaviour
{
    [SerializeField] float playerCapitalStart;    
    public float playerCapital { get; private set; }
    public Text playerCapitalText;

    public List<InvestmentInstance> activeInvestments = new List<InvestmentInstance>(); // Lista över aktiva investeringar (individuella instanser)

    [Header("Key figures")]
    [SerializeField] float investedCapitalTotal;
    [SerializeField] float returnTotal;

    [Header("Player Level")]
    public Text playerLevelText;
    public int playerLevel { get; private set; }
    [SerializeField] int playerExpPointsInvested; //Antal poäng som investerats innan level upp
    [SerializeField] int levelUpCost;

    private void Start()
    {
        playerCapital = playerCapitalStart;

        updateUI();
        updateMoneyText();
    }

    public void updateUI()
    {
        playerLevelText.text = "Player level: " + playerLevel + " (Points to Level up: " + playerExpPointsInvested + "/" + levelUpCost +")";
    }

    // Funktion för att lägga till en ny investering till spelarens lista
    public void AddInvestment(InvestmentInstance investment)
    {
        activeInvestments.Add(investment);
        Debug.Log("Ny investering tillagd: " + investment.investmentType.name + ", Potentiell avkastning: " + investment.potentialReturn);
    }

    // Funktion för att samla in avkastningen från en investering
    public void CollectReturn(InvestmentInstance investment)
    {
        playerCapital += (investment.potentialReturn + investment.investmentType.cost);
        returnTotal += (investment.potentialReturn);
        Debug.Log("Avkastning från " + investment.investmentType.name + " samlad in! Spelarens kapital: " + playerCapital);
        updateMoneyText();
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

        Debug.Log("Aktiva investeringar uppdaterade. Kvarvarande: " + activeInvestments.Count);
    }

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
        updateMoneyText();
    }

    public void levelUpPlayer()
    {
        playerLevel++;
        updateUI();
    }

    public void investActionPointsToLevelUp()
    {
        FindObjectOfType<actionPointsManager>().actionPointSub(1);
        playerExpPointsInvested++;

        if(playerExpPointsInvested == levelUpCost)
        {
            levelUpPlayer();
            FindObjectOfType<InvestmentManager>().addNewProjectsWhenPlayerLevelUp(playerLevel);
            playerExpPointsInvested = 0;
        }

        updateUI();
    }
}

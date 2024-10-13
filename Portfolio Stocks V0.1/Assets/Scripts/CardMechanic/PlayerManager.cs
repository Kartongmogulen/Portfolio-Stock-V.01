using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InvestmentData;  // Se till att referera till InvestmentData


public class PlayerManager : MonoBehaviour
{
        [SerializeField] float playerCapital = 0f; // Spelarens totala kapital
        public Text playerCapitalText;

        public List<InvestmentInstance> activeInvestments = new List<InvestmentInstance>(); // Lista �ver aktiva investeringar (individuella instanser)

    private void Start()
    {
        updateMoneyText();
    }

    // Funktion f�r att l�gga till en ny investering till spelarens lista
    public void AddInvestment(InvestmentInstance investment)
    {
        activeInvestments.Add(investment);
        Debug.Log("Ny investering tillagd: " + investment.investmentType.name + ", Potentiell avkastning: " + investment.potentialReturn);
    }

    // Funktion f�r att samla in avkastningen fr�n en investering
    public void CollectReturn(InvestmentInstance investment)
    {
        playerCapital += (investment.potentialReturn + investment.investmentType.cost);
        Debug.Log("Avkastning fr�n " + investment.investmentType.name + " samlad in! Spelarens kapital: " + playerCapital);
        updateMoneyText();
    }

    // Funktion f�r att uppdatera investeringarnas �lder och ta bort gamla
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
}

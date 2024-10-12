using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InvestmentData;  // Se till att referera till InvestmentData


public class PlayerManager : MonoBehaviour
{
        public float playerCapital = 0f; // Spelarens totala kapital
        public List<InvestmentInstance> activeInvestments = new List<InvestmentInstance>(); // Lista över aktiva investeringar (individuella instanser)

        // Funktion för att lägga till en ny investering till spelarens lista
        public void AddInvestment(InvestmentInstance investment)
    {
        activeInvestments.Add(investment);
        Debug.Log("Ny investering tillagd: " + investment.investmentType.name + ", Potentiell avkastning: " + investment.potentialReturn);
    }

    // Funktion för att samla in avkastningen från en investering
    public void CollectReturn(InvestmentInstance investment)
    {
        playerCapital += investment.potentialReturn;
        Debug.Log("Avkastning från " + investment.investmentType.name + " samlad in! Spelarens kapital: " + playerCapital);
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
}

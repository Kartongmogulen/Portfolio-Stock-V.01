using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInvestmentType", menuName = "Investment/InvestmentType")]
public class InvestmentTypeData : ScriptableObject
{
    public string investmentName;       // Namn på investeringen

    [Range(0.0f, 1.0f)]
    public float successProbability;    // Sannolikheten att investeringen lyckas (0-1)
    public int lifetime;                // Livslängd på investeringen i år
    public float cost;                  // Kostnaden för investeringen
    public float ROIpotential;      // Multiplikator för att beräkna avkastningen
    public float expectedValue;  // Väntevärdet av årlig avkastning
    
    public float annualReturn;     // Årlig avkastning
    public float annualReturnWithRisk;     // Årlig avkastning inkl misslyckande

    private void OnValidate()
    {
        // Beräkna procentuell förväntad årlig avkastning
        if (lifetime > 0) // Kontroll för att undvika division med 0
        {

            // Calculate potential outcomes
            float successOutcome = cost * ROIpotential;
            float failureOutcome = cost * (1 - successProbability);

            expectedValue = Mathf.Round(((successProbability * successOutcome) - failureOutcome) - cost);

            annualReturn = Mathf.Round((Mathf.Pow(ROIpotential, (1.0f / lifetime)) - 1) * 1000) / 1000;
        }
        else
        {
            expectedValue = 0;
        }

        CalculateAnnualReturnWithRisk();
    }

    public void CalculateAnnualReturnWithRisk()
    {
        if (lifetime <= 0)
        {
            Debug.LogError("Lifetime must be greater than 0!");
            annualReturnWithRisk = 0;
            return;
        }

        // Outcomes
        float successOutcome = Mathf.Pow(ROIpotential, 1.0f / lifetime) - 1; // Annualized return if successful
        Debug.Log("Succes Outcome: " + successOutcome);
        float failureOutcome = Mathf.Pow((1 - successProbability), 1.0f / lifetime) - 1; // Annualized return if failed
        Debug.Log("Failure Outcome: " + failureOutcome);
        // Expected annual return
        annualReturnWithRisk = successProbability * successOutcome +  failureOutcome;
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInvestmentType", menuName = "Investment/InvestmentType")]
public class InvestmentTypeData : ScriptableObject
{
    public string investmentName;       // Namn på investeringen
    public float successProbability;    // Sannolikheten att investeringen lyckas (0-1)
    public int lifetime;                // Livslängd på investeringen i år
    public float cost;                  // Kostnaden för investeringen
    public float ROIpotential;      // Multiplikator för att beräkna avkastningen
    public float expectedValue;  // Väntevärdet av årlig avkastning

    private void OnValidate()
    {
        // Beräkna procentuell förväntad årlig avkastning
        if (lifetime > 0) // Kontroll för att undvika division med 0
        {
            expectedValue = Mathf.Round((successProbability * ROIpotential *cost) - cost * (1-successProbability));
        }
        else
        {
            expectedValue = 0;
        }
    }
}




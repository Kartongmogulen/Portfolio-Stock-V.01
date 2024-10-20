using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInvestmentType", menuName = "Investment/InvestmentType")]
public class InvestmentTypeData : ScriptableObject
{
    public string investmentName;       // Namn p� investeringen
    public float successProbability;    // Sannolikheten att investeringen lyckas (0-1)
    public int lifetime;                // Livsl�ngd p� investeringen i �r
    public float cost;                  // Kostnaden f�r investeringen
    public float ROIpotential;      // Multiplikator f�r att ber�kna avkastningen
    public float expectedAnnualReturnPercentage;  // V�ntev�rdet av �rlig avkastning

    private void OnValidate()
    {
        // Ber�kna procentuell f�rv�ntad �rlig avkastning
        if (lifetime > 0) // Kontroll f�r att undvika division med 0
        {
            expectedAnnualReturnPercentage = (successProbability * ROIpotential / lifetime) * 100;
        }
        else
        {
            expectedAnnualReturnPercentage = 0;
        }
    }
}




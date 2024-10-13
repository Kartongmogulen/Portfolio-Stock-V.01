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
}


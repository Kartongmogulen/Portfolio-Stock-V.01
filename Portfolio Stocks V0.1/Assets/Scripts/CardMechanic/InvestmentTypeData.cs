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
}


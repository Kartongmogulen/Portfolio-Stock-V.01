using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvestmentData
{
    [System.Serializable]
    public class InvestmentType
    {
        public string name;                 // Namn p� investeringen
        public float successProbability;    // Sannolikheten att investeringen lyckas (0-1)
        public int lifetime;                // Livsl�ngd p� investeringen i �r
        public float cost;                  // Kostnaden f�r investeringen
        public float ROIpotential;      // Multiplikator f�r att ber�kna avkastningen

        public InvestmentType(string name, int cost, float successProbability, int lifetime, float ROIpotential)
        {
            this.name = name;
            this.successProbability = successProbability;
            this.lifetime = lifetime;
            this.cost = cost;
            this.ROIpotential = ROIpotential;
        }
    }

    [System.Serializable]
    public class InvestmentInstance
    {
        public InvestmentType investmentType;  // Typ av investering
        public int currentAge;                 // Nuvarande �lder p� investeringen
        public float potentialReturn;          // Potentiell avkastning om investeringen lyckas

        public InvestmentInstance(InvestmentType type)
        {
            this.investmentType = type;
            this.currentAge = 0;
            this.potentialReturn = type.cost * type.ROIpotential;
        }

        public void IncrementAge()
        {
            this.currentAge++;
        }

        public bool HasReachedEndOfLifetime()
        {
            return this.currentAge >= this.investmentType.lifetime;
        }
    }
}
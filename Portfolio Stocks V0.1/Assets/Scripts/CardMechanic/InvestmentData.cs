using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvestmentData
{
    [System.Serializable]
    public class InvestmentType
    {
        public string name;                 // Namn på investeringen
        public float successProbability;    // Sannolikheten att investeringen lyckas (0-1)
        public int lifetime;                // Livslängd på investeringen i år
        public float cost;                  // Kostnaden för investeringen
        public float ROIpotential;      // Multiplikator för att beräkna avkastningen

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
        public int currentAge;                 // Nuvarande ålder på investeringen
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

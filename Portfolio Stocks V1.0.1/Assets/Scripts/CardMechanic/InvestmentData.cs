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
        public float ROI;      // Multiplikator för att beräkna avkastningen

        public InvestmentType(string name, int cost, float successProbability, int lifetime, float ROIpotential)
        {
            this.name = name;
            this.successProbability = successProbability;
            this.lifetime = lifetime;
            this.cost = cost;
            this.ROI = ROIpotential;
        }
    }

    [System.Serializable]
    public class InvestmentInstance
    {
        //public InvestmentType investmentType;  // Typ av 
        public InvestmentTypeData investmentType;
        public int currentAge;                 // Nuvarande ålder på investeringen
        public float potentialReturn;          // Potentiell avkastning om investeringen lyckas
        public float expectedYearlyReturn;     // Årlig avkastning

        public InvestmentInstance(InvestmentTypeData type)
        {
            this.investmentType = type;
            this.currentAge = 0;
            this.potentialReturn = type.cost * type.ROI;
            this.expectedYearlyReturn = Mathf.Pow(type.successProbability * type.ROI, (1.0f /type.lifetime)) ;
            //Debug.Log("Investeringstyp: " + investmentType + " /Förväntad årlig avkast: " + expectedYearlyReturn);
            //Debug.Log("Livslängd: " + type.lifetime);
            //Debug.Log("Upphöjt i: " + (1.0f / type.lifetime));
            //Debug.Log("Årlig avkastning: " + expectedYearlyReturn);
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

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
        public float ROI;      // Multiplikator f�r att ber�kna avkastningen

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
        public int currentAge;                 // Nuvarande �lder p� investeringen
        public float potentialReturn;          // Potentiell avkastning om investeringen lyckas
        public float expectedYearlyReturn;     // �rlig avkastning

        public InvestmentInstance(InvestmentTypeData type)
        {
            this.investmentType = type;
            this.currentAge = 0;
            this.potentialReturn = type.cost * type.ROI;
            this.expectedYearlyReturn = Mathf.Pow(type.successProbability * type.ROI, (1.0f /type.lifetime)) ;
            //Debug.Log("Investeringstyp: " + investmentType + " /F�rv�ntad �rlig avkast: " + expectedYearlyReturn);
            //Debug.Log("Livsl�ngd: " + type.lifetime);
            //Debug.Log("Upph�jt i: " + (1.0f / type.lifetime));
            //Debug.Log("�rlig avkastning: " + expectedYearlyReturn);
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

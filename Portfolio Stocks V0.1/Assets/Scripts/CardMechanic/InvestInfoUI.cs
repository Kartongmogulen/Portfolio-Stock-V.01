using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InvestmentData;  // Se till att referera till InvestmentData

public class InvestInfoUI : MonoBehaviour
{
    public Text investmentIndexText;
    public Text nameText;                 // Namn p� investeringen
    public Text successProbabilityText;    // Sannolikheten att investeringen lyckas (0-1)
    public Text lifetimeText;                // Livsl�ngd p� investeringen i �r
    public Text costText;                  // Kostnaden f�r investeringen
    public Text ROIpotentialText;      // Multiplikator f�r att ber�kna avkastningen


    public void updateInvestInfo(InvestmentTypeData project, int index)
    {
        investmentIndexText.text = "" + index;

        nameText.text = project.name;
        successProbabilityText.text = "Prob to succed: " + project.successProbability*100 + "%";
        lifetimeText.text = "Lifetime: " + project.lifetime;
        costText.text = "Cost: " + project.cost;
        ROIpotentialText.text = "Potential return: " + project.ROIpotential * 100 + "%";

    }
}

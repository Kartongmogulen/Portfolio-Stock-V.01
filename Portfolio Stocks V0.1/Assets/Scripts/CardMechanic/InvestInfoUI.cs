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
    public InvestmentManager investmentManager;


    public void updateInvestInfo(InvestmentTypeData project, int index)
    {
        //Debug.Log("Index: " + index);    
        investmentIndexText.text = "" + (index+1) + "/" + investmentManager.availableInvestments.Count;

        nameText.text = project.investmentName;
        successProbabilityText.text = "Prob to succed: " + project.successProbability*100 + "%";
        lifetimeText.text = "Lifetime: " + project.lifetime;
        costText.text = "Cost: " + project.cost;
        ROIpotentialText.text = "Potential return: " + project.ROIpotential * 100 + "%";

    }
    
    public void noMoreProjectsToChooseFrom()
    {
        investmentIndexText.text = "0/0"; 

        nameText.text = "NO MORE PROJECTS";
        successProbabilityText.text = "NO MORE PROJECTS";
        lifetimeText.text = "NO MORE PROJECTS";
        costText.text = "NO MORE PROJECTS";
        ROIpotentialText.text = "NO MORE PROJECTS";
    }
}

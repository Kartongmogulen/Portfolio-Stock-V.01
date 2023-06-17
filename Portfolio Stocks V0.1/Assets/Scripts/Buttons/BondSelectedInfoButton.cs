using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BondSelectedInfoButton : MonoBehaviour
{
	public GameObject playerPanelGO;
	public bondMarketManager BondMarketManager;

	//STEP 2
	public Text durationText;
	public Text bondCostText;
	public Text bondRateText;
	public Text bondCFText;

	public float[] costBond; //Totalt kostnad
	public float[] rate;
	public float[] cashflow; 

	public float bondCost;

	public int lvlBond;

	public int activeBond; //Vilket räntepapper som är aktiverat

	public GameObject mainCanvasPanelGO;
	public GameObject researchPanelGO;

	public float rateIncrease;

	public void showBondInfo(int bondNumb)
	{
		activeBond = bondNumb;
		durationText.text = "Duration: " + BondMarketManager.bondMarketListGO[bondNumb].GetComponent<bondInfoPrefab>().duration + " (years)";
		bondCostText.text = "Cost: " + BondMarketManager.bondMarketListGO[bondNumb].GetComponent<bondInfoPrefab>().costBond;
		bondRateText.text = "Rate: " + BondMarketManager.bondMarketListGO[bondNumb].GetComponent<bondInfoPrefab>().rate + "%";
	}

	public void showInfoBondOne(int bondNum)
	{
		activeBond = 1;

		bondCost = costBond[bondNum];

		bondCostText.text = "Cost: " + bondCost;
		bondRateText.text = "Rate: " + rate[bondNum] + "%";

		cashflow[bondNum] = costBond[bondNum]*rate[bondNum]/100;
		bondCFText.text = "Cashflow/year: " + cashflow[bondNum];

	}

	// Increase rate on bonds when player lvl up
	public void lvlUpBondInterestRate()
	{


		lvlBond = playerPanelGO.GetComponent<playerStats>().lvlSkills[1];
		rateIncrease = researchPanelGO.GetComponent<research>().bondImproveIR;

		Debug.Log ("lvl bond");


		for (int i = 0; i<rate.Length; i++)
		{
			if (lvlBond == 1) {
				
				rate [i] = rate [i] + rateIncrease;

			}

			if (lvlBond == 2) {

				rate [i] = rate [i] + rateIncrease;

			}

			if (lvlBond == 3) {

				rate [i] = rate [i] + rateIncrease;

			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoRealEstateButton : MonoBehaviour
{

	public GameObject panelRealEstateGO;
	public GameObject panelStockGO;
	public GameObject bondPanel;

	//STEP 1
	public float downPaymentShare; //Amount of the cost that needs to get paid directly
	public float interestrateMortage; //Interest on mortage
	public float downPayment;
	public float mortgageCostYear; //Cost of interest
	//public float cashflowPerMonth //Net income from the real estate
	//public float numRE;

	public float[] costRE; //Totalt kostnad
	public float[] rent;
	public float[] cashflow; 

	public float activeRealEstate; //Vilken objekt som är aktivt 
	public float panelOnOff; //Om panelen är aktiverade eller inte

	public Text infoRealEstateText;
	public Text costRealEstateText;
	public Text downPaymentText;
	public Text mortgageText;
	public Text interestMortageText;
	public Text rentIncomeText;
	public Text cashflowText;

	//Step 3
	public int lvlRE;
	public float rentIncrease;
    
	public GameObject playerPanelGO;
	public GameObject researchPanelGO;

	public void activateRealEstateInfo () {

		if (panelOnOff == 0) {
		panelRealEstateGO.SetActive (true);
			panelOnOff++;}
			else {
				panelOnOff = 0;
			panelRealEstateGO.SetActive (false);
			}


		panelStockGO.SetActive (false);
		bondPanel.SetActive (false);

	}

	public void realEstateGlobalInfo (){


	}

	public void infoRealEstateOne (int numRE)

	{
		activeRealEstate = 1;
		downPayment = costRE[numRE]*downPaymentShare;

		costRealEstateText.text = "Cost: " + costRE[numRE]/1000 + "k";
		downPaymentText.text = "Down Payment: " + downPayment/1000 + "k";
		mortgageText.text = "Mortgage: " + costRE[numRE]*(1-downPaymentShare)/1000 + "k";
		interestMortageText.text = "Interest rate: " + interestrateMortage + "%";
		rentIncomeText.text = "Rent: " + rent[numRE]/1000 + "k";

		mortgageCostYear = (costRE[numRE]*(1-downPaymentShare))*interestrateMortage/100;
		cashflow[numRE] = rent[numRE]-mortgageCostYear/12;

		cashflowText.text = "Cashflow (M): " + Mathf.Round((cashflow[numRE]/1000)*100)/100 + "k";
	}

	public void infoRealEstateTwo (int numRE){

		activeRealEstate = 2;
		downPayment = costRE[numRE]*downPaymentShare;

		costRealEstateText.text = "Cost: " + costRE[numRE]/1000 + "k";
		downPaymentText.text = "Down Payment: " + downPayment/1000 + "k";
		mortgageText.text = "Mortgage: " + costRE[numRE]*(1-downPaymentShare)/1000 + "k";
	interestMortageText.text = "Interest rate: " + interestrateMortage + "%";
		rentIncomeText.text = "Rent: " + rent[numRE]/1000 + "k";

		mortgageCostYear = (costRE[numRE]*(1-downPaymentShare))*interestrateMortage/100;
		cashflow[numRE] = rent[numRE]-mortgageCostYear/12;

		cashflowText.text = "Cashflow (M): " + Mathf.Round((cashflow[numRE]/1000)*100)/100 + "k";
	}

	public void increaseRent()	{

		lvlRE = playerPanelGO.GetComponent<playerStats>().lvlSkills[2];
		rentIncrease = researchPanelGO.GetComponent<research>().REImproveRent;

		for (int i = 0; i<rent.Length; i++)
		{
			if (lvlRE == 1) {

				rent [i] = rent [i] + rentIncrease;

			}

			if (lvlRE == 2) {

				rent [i] = rent [i] + rentIncrease;

			}

			if (lvlRE == 3) {

				rent [i] = rent [i] + rentIncrease;

			}
		}
	}
}

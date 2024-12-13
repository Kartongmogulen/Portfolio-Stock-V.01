using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyRealEstate : MonoBehaviour
{
	public GameObject panelBottomPanel;
	public GameObject playerPanelGO;

	public Text cashflowRealEstateText;

	public float activeRealEstate; //Vilket objekt som är valt
	public float costRealEstate; //Hur mycket som krävs i handpenning för att få köpa
	public float moneyBefore; 

	public float cashFlowRealEstateNow;

	public float valueRE;

	public void buyRE(){

		activeRealEstate = panelBottomPanel.GetComponent<infoRealEstateButton>().activeRealEstate;
		costRealEstate = panelBottomPanel.GetComponent<infoRealEstateButton>().downPayment;
		//moneyBefore = playerPanelGO.GetComponent<totalCash>().moneyNow;

		if (costRealEstate<=moneyBefore && activeRealEstate==1 && playerPanelGO.GetComponent<realEstatePortfolio> ().realEstateOwned[0] == 0) {

			playerPanelGO.GetComponent<realEstatePortfolio>().realEstateOwned[0] = 1;
			//playerPanelGO.GetComponent<totalCash>().buyRealEstate(costRealEstate);
			playerPanelGO.GetComponent<realEstatePortfolio> ().investTotRealEstate (costRealEstate);
			cashFlowRealEstate();
		}

		if (costRealEstate<=moneyBefore && activeRealEstate==2 && playerPanelGO.GetComponent<realEstatePortfolio> ().realEstateOwned[1] == 0) {

			playerPanelGO.GetComponent<realEstatePortfolio>().realEstateOwned[1] = 1;
			//playerPanelGO.GetComponent<totalCash>().buyRealEstate(costRealEstate);
			playerPanelGO.GetComponent<realEstatePortfolio> ().investTotRealEstate (costRealEstate);
			cashFlowRealEstate();
		}


	}

	public void cashFlowRealEstate()
	{
		if (playerPanelGO.GetComponent<realEstatePortfolio>().realEstateOwned[0] == 1){
			cashFlowRealEstateNow = cashFlowRealEstateNow + panelBottomPanel.GetComponent<infoRealEstateButton>().cashflow[0];
		}

		cashflowRealEstateText.text = "Real Estate/Month: " + cashFlowRealEstateNow;
	}

	public void valueRealEstate()
	{
		valueRE = playerPanelGO.GetComponent<realEstatePortfolio>().realEstateOwned[0]*panelBottomPanel.GetComponent<infoRealEstateButton>().costRE[0];

	}
}

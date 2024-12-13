using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyBusiness : MonoBehaviour
{
	
	public float[] priceBusiness;
	public float totValueBusiness;
	public float cashflowActiveBus;
	public int activeBusiness; //Vilket företag som är aktiv
	public GameObject playerPanelGO;
	public float playerMoney;
	public int playerAlreadyOwn;
	public Text priceBusText;
	public Text cashflowText;
	public GameObject bottomPanelGO;

	public Text buyButtonText;

	void Awake (){
		businessValue ();
	}

	public void buttonBuy (){

		//playerMoney = playerPanelGO.GetComponent<totalCash>().moneyNow;
		playerAlreadyOwn = playerPanelGO.GetComponent<ownedBusiness>().playerBusiness[activeBusiness-1];

			if (playerMoney>=priceBusiness[activeBusiness-1] && playerAlreadyOwn!=1){
		
			//playerPanelGO.GetComponent<totalCash>().buyBusiness(priceBusiness[activeBusiness-1]);
			playerPanelGO.GetComponent<ownedBusiness>().addBusiness(activeBusiness);
			playerPanelGO.GetComponent<ownedBusiness>().totalInvest(priceBusiness[activeBusiness - 1]);
			playerPanelGO.GetComponent<ownedBusiness> ().valueOwnedBusiness ();

			buyButtonText.text = "Owned";

		}
	}

	public void activateBusiness1(){
		activeBusiness = 1;
		priceBusinessShow();
		cashflowBusiness(activeBusiness);

	}

	public void priceBusinessShow(){
		priceBusText.text = "Price: " + priceBusiness[activeBusiness-1];
	}

	public void cashflowBusiness(int activeBus){
		cashflowActiveBus = bottomPanelGO.GetComponent<busIncomeStatement>().cashflowBusiness[activeBus-1];
		cashflowText.text = "Cashflow/month: " + cashflowActiveBus;
	}

	public void businessValue(){


		foreach (float valueBusiness in priceBusiness) {

			totValueBusiness = totValueBusiness + valueBusiness;
	
		}

	}


}

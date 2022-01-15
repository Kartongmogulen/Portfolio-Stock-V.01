using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ownedBusiness : MonoBehaviour
{
	public int[] playerBusiness; //Business the player ownes
	public float totValueBusiness; //Vilket värde företaget har om man t.ex lvl upp den
	public float cashflowPlayer;
	public float totalInvestAmount;

	public GameObject bottomPanelGO;
	public GameObject businessPanelGO;

	void Awake (){

	
	}

	public void addBusiness(int business){

		playerBusiness[business-1] = 1;
	}

	//Script som justerar cashflow efter de företag spelaren äger
	public void playerCashflow(){

		if (playerBusiness[0]==1){

			cashflowPlayer = bottomPanelGO.GetComponent<busIncomeStatement>().cashflowBusiness[0];
		}
	}

	public void totalInvest(float cost){
		totalInvestAmount = totalInvestAmount + cost;
	}

	public void valueOwnedBusiness (){

		for (int i = 0; i < playerBusiness.Length; i++) {
			if (playerBusiness [i] == 1) {
				totValueBusiness = totValueBusiness + businessPanelGO.GetComponent<buyBusiness>().priceBusiness[i];

			}
		}
	}

}

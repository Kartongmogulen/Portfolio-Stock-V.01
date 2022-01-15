using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStockPortfolio : MonoBehaviour
{
	public GameObject portfolioPanelGO;
	public GameObject playerScriptsGO;
	//public GameObject sectorInfoPanelGO;

	public portfolioStock PortfolioStock;

	public int portfolioPanelStatus;

	void Awake(){
		PortfolioStock = playerScriptsGO.GetComponent<portfolioStock> ();
	}

	public void activatePortPanel(){

		if (portfolioPanelStatus == 0){

		portfolioPanelGO.SetActive (true);
		//sectorInfoPanelGO.SetActive (false);
		portfolioPanelStatus = 1;

		PortfolioStock.showPortfolioData ();
		}

		else {
			portfolioPanelGO.SetActive (false);
			//sectorInfoPanelGO.SetActive (false);
			portfolioPanelStatus = 0;

		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activatePanelButton : MonoBehaviour
{
	public GameObject buttonsScriptsGO;

	public GameObject panelBondsGO;
	public int bondsPanelActive;

	public GameObject panelBooksGO;
	public int booksPanelActive;

	public GameObject businessPanelGO;
	public int businessPanelActive;

	public GameObject indexPanelGO;
	public int indexPanelActive;

	public GameObject newsPanelGO;
	public int newsPanelActive;

	public GameObject playerStockPanelGO;
	public int playerStockPanelActive;

	public GameObject realEstatePanelGO;
	public int realEstatePanelActive;

	public GameObject sectorInfoPanelGO;
	public int sectorInfoPanelActive;

	public GameObject stockPanelGO;
	public int stockPanelActive;

	public GameObject windowGraphGO;
	public int windowGraphActive;

	public void activateBondsPanel (){

		if (bondsPanelActive == 0) {
			panelBondsGO.SetActive (true);
			bondsPanelActive = 1;

			inactiveBooksPanel ();
			inactiveBusinessPanel ();
			inactiveStockPanel ();
			inactiveRealEstatePanel ();

		} else {
			panelBondsGO.SetActive (false);
			bondsPanelActive = 0;
		}
	}

	public void activateBooksPanel (){

		if (booksPanelActive == 0) {
			panelBooksGO.SetActive (true);
			booksPanelActive = 1;

			inactiveBondsPanel ();
			inactiveBusinessPanel ();
			inactiveStockPanel ();
			inactiveRealEstatePanel ();

		} else {
			panelBooksGO.SetActive (false);
			booksPanelActive = 0;
		}
	}

		public void activeBusinessPanel (){
			if (businessPanelActive == 0) {
				businessPanelGO.SetActive (true);
				businessPanelActive = 1;

				inactiveBooksPanel ();

			} else {
				businessPanelGO.SetActive (false);
				businessPanelActive = 0;
			}
		}


	public void activeIndexPanel (){
		if (indexPanelActive == 0) {
			indexPanelGO.SetActive (true);
			indexPanelActive = 1;

			inactiveBooksPanel ();
			inactiveBusinessPanel ();

		} else {
			indexPanelGO.SetActive (false);
			indexPanelActive = 0;
		}
	}

	public void activeNewsPanel (){
		if (newsPanelActive == 0) {
			newsPanelGO.SetActive (true);
			newsPanelActive = 1;

			inactiveBooksPanel ();
			inactiveBusinessPanel ();

		} else {
			newsPanelGO.SetActive (false);
			newsPanelActive = 0;
		}
	}

	public void activatePortfolioPanel()
	{
		//playerStockPanelGO

		if (playerStockPanelActive == 0)
		{
			playerStockPanelGO.SetActive(true);
			playerStockPanelActive = 1;

			inactiveStockPanel();

		}
		else
		{
			playerStockPanelGO.SetActive(false);
			playerStockPanelActive = 0;

		}
	}

	public void activeRealEstatePanel(){

		if (realEstatePanelActive == 0) {
			realEstatePanelGO.SetActive (true);
			realEstatePanelActive = 1;

			inactiveBondsPanel ();
			inactiveBooksPanel ();
			inactiveBusinessPanel ();
			inactiveStockPanel ();

		} else {
			realEstatePanelGO.SetActive (false);
			realEstatePanelActive = 0;
		}
	}

	public void activeStockPanel(){

		if (stockPanelActive == 0) {
			stockPanelGO.SetActive (true);
			stockPanelActive = 1;

			//stockPanelGO.GetComponent<priceChange>().showInfoStock();
			//stockPanelGO.GetComponent<infoButton>().correctOnOff();

			inactivePlayerStockPanel();
			/*inactiveBondsPanel ();
			inactiveBooksPanel ();
			inactiveBusinessPanel ();
			inactiveRealEstatePanel ();
			inactiveSectorInfoPanel ();
			*/
		} else {
			stockPanelGO.SetActive (false);
			stockPanelActive = 0;
		}
	}

	public void activeWindowGraphPanel(){

		if (windowGraphActive == 0) {
			windowGraphGO.SetActive (true);
			windowGraphActive = 1;

			inactiveSectorInfoPanel ();

		} else {
			windowGraphGO.SetActive (false);
			windowGraphActive = 0;
		}
	}


	public void inactiveBondsPanel(){

		panelBondsGO.SetActive (false);
		bondsPanelActive = 0;
	}

		public void inactiveBooksPanel(){

			panelBooksGO.SetActive (false);
			booksPanelActive = 0;
		}

	public void inactiveBusinessPanel(){

		businessPanelGO.SetActive (false);
		businessPanelActive = 0;
	}

	public void inactivePlayerStockPanel()
	{

		playerStockPanelGO.SetActive(false);

		buttonsScriptsGO.GetComponent<playerStockPortfolio>().portfolioPanelStatus = 1;
		buttonsScriptsGO.GetComponent<playerStockPortfolio>().activatePortPanel();
		
		playerStockPanelActive = 0;
	}

	public void inactiveRealEstatePanel(){

		realEstatePanelGO.SetActive (false);
		realEstatePanelActive = 0;
	}

	public void inactiveSectorInfoPanel(){

		sectorInfoPanelGO.SetActive (false);
		sectorInfoPanelActive = 0;
	}

	public void inactiveStockPanel(){

		stockPanelGO.SetActive (false);
		stockPanelActive = 0;
	}
}


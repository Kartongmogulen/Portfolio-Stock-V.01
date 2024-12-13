using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoButtonStockMarket : MonoBehaviour
{
	public GameObject mainCanvasGO;
	public GameObject stockSectorPanel;
	public GameObject stockInfoPanel;
	public GameObject realEstatePanel;
	public GameObject bondPanel;

	public GameObject UtiPanelBuy;
	public GameObject UtiPanelSell;
	public GameObject FinPanelBuy;
	public GameObject FinPanelSell;
	public GameObject TechPanelBuy;
	public GameObject TechPanelSell;

	public float stockPanelOnOff;

	public void activateStockPanel ()
	{
		realEstatePanel.SetActive (false);
		bondPanel.SetActive (false);
		stockInfoPanel.SetActive (false);

		if (stockPanelOnOff==0){
		stockSectorPanel.SetActive (true);
		stockPanelOnOff=1;
		stockInfoPanel.SetActive (false);
		}

		else {
			stockSectorPanel.SetActive (false);
			stockPanelOnOff=0;
			stockInfoPanel.SetActive (false);
		}

		stockSectorPanel.GetComponent<priceChange>().showInfoStock();
		stockSectorPanel.GetComponent<infoButton>().correctOnOff();
	}

	public void activateUtiInfo()
	{
		stockInfoPanel.SetActive(true);
		stockSectorPanel.SetActive(false);

		UtiPanelBuy.SetActive(true);
		FinPanelBuy.SetActive(false);
		TechPanelBuy.SetActive(false);

		UtiPanelSell.SetActive(true);
		FinPanelSell.SetActive(false);
		TechPanelSell.SetActive(false);

		mainCanvasGO.GetComponent<infoStockSector>().infoUti();

	}

	public void activateFinInfo()
	{
		stockInfoPanel.SetActive(true);
		stockSectorPanel.SetActive(false);

		UtiPanelBuy.SetActive(false);
		FinPanelBuy.SetActive(true);
		TechPanelBuy.SetActive(false);

		UtiPanelSell.SetActive(false);
		FinPanelSell.SetActive(true);
		TechPanelSell.SetActive(false);

		mainCanvasGO.GetComponent<infoStockSector>().infoFin();

	}

	public void activateTechInfo(){
		stockInfoPanel.SetActive(true);
		stockSectorPanel.SetActive(false);

		UtiPanelSell.SetActive(false);
		FinPanelSell.SetActive(false);
		TechPanelBuy.SetActive(true);

		UtiPanelSell.SetActive(false);
		FinPanelSell.SetActive(false);
		TechPanelSell.SetActive(true);

		mainCanvasGO.GetComponent<infoStockSector>().infoTech();
	}

}

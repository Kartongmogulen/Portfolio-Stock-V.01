using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoButton : MonoBehaviour
{
	public GameObject MainCanvasGO;
	public GameObject stockSectorPanel;
	public GameObject InfoPanelStocksector;
	//public GameObject IndexInfoPanel;

	//public Text test;
	public int infoUtiOnOrOff;
	public int infoFinOnOrOff;
	public int infoTechOnOrOff;
	public int infoIndexOnOrOff;

	void Start () {

		infoUtiOnOrOff = 0; // 0 om den ska vara släckt och 1 när den är true
		MainCanvasGO.GetComponent<infoStockSector>().updatePE();
	}

	//Scriptet aktiverar en panel och visar info om aktien

	//Utdelning vid olika ekonomiska klimat

	//Script för Utilities
	public void showInfoUti(){

		MainCanvasGO.GetComponent<infoStockSector>().infoUti();

		if (infoUtiOnOrOff == 0){
			InfoPanelStocksector.SetActive (true);

			infoUtiOnOrOff ++;
			infoFinOnOrOff = 0;
			infoTechOnOrOff = 0;
			infoIndexOnOrOff = 0;
		}

		else {
			InfoPanelStocksector.SetActive (false);
			infoUtiOnOrOff --;
		}

		stockSectorPanel.SetActive(false);
	}

	public void correctOnOff () //Korrigera så att variable för av och på blir korrekt
	{
		infoUtiOnOrOff = 0;
		infoFinOnOrOff = 0;
		infoTechOnOrOff = 0;

	
	}

	//Script för Finance
	public void showInfoFin(){

		MainCanvasGO.GetComponent<infoStockSector>().infoFin();


		if (infoFinOnOrOff == 0){
			InfoPanelStocksector.SetActive (true);
			//IndexInfoPanel.SetActive (false);
			infoFinOnOrOff ++;

			infoUtiOnOrOff = 0;
			infoTechOnOrOff = 0;
			infoIndexOnOrOff = 0;
			//test.text = "On eller Off " + infoUtiOnOrOff;
		}

		else {
			InfoPanelStocksector.SetActive (false);
			infoFinOnOrOff --;
		}
	}

	//Script för Technology
	public void showInfoTech(){

		MainCanvasGO.GetComponent<infoStockSector>().infoTech();


		if (infoTechOnOrOff == 0){
			InfoPanelStocksector.SetActive (true);
			infoTechOnOrOff ++;

			infoUtiOnOrOff = 0;
			infoFinOnOrOff = 0;
			infoIndexOnOrOff = 0;
		}

		else {
			InfoPanelStocksector.SetActive (false);
			infoTechOnOrOff --;
		}

	}

	//Script för Index
	public void showInfoIndex(){

		//GetComponent<indexFund>().infoIndex();


		if (infoIndexOnOrOff == 0){
			InfoPanelStocksector.SetActive (false);
			//IndexInfoPanel.SetActive (true);
			infoIndexOnOrOff ++;

			infoUtiOnOrOff = 0;
			infoFinOnOrOff = 0;
			infoTechOnOrOff = 0;
			//test.text = "On eller Off " + infoUtiOnOrOff;
		}

		else {
			//IndexInfoPanel.SetActive (false);
			infoIndexOnOrOff --;
		}
	}
}


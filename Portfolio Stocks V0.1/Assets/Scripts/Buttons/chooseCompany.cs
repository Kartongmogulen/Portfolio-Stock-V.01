using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseCompany : MonoBehaviour
{
	public GameObject stockMarketGO;
	//public GameObject[] StockMarketInventory;

	public chooseStockSector ChooseStockSector;
	public GameObject ScriptsGO;
	public chooseUtiCompany ChooseUtiCompany;
	public chooseTechCompany ChooseTechCompany;

	public GameObject companyOneButton;
	public GameObject companyTwoButton;

	public int activeSector;
	public int activeCompany;

	//Kontrollerar vilken sektor som är aktiv och sedan vilket bolag inom sektorn som väljs

	void Awake(){
		ChooseStockSector = GetComponent<chooseStockSector>();
		ChooseUtiCompany = ScriptsGO.GetComponent<chooseUtiCompany>();
		ChooseTechCompany = ScriptsGO.GetComponent<chooseTechCompany>();

		//StockMarketInventory = stockMarketGO.GetComponent<stockMarketManager>().StockMarketInventory;
	}

	void Update(){

		if (activeCompany == 1) {
			chosenCompanyOne ();
		}
		if (activeCompany == 2) {
			chosenCompanyTwo ();
		}
	}

	public void chooseCompanyInt(int activeCompany)
	{
		activeSector = ChooseStockSector.activeSector;
		deactivateAll();
		companyOneButton.GetComponent<Image>().color = Color.green;

		if (activeSector == 1)
		{
			activeCompany = 3;
			ChooseUtiCompany.companyThree();

		}
	}

	public void chosenCompanyOne(){
		activeSector = ChooseStockSector.activeSector;
		deactivateAll ();
		companyOneButton.GetComponent<Image>().color = Color.green;

		if (activeSector == 1) {
			activeCompany = 1;
			ChooseUtiCompany.companyOne ();
			
		}

		if (activeSector == 2) {
			activeCompany = 1;
			ChooseTechCompany.companyOne ();
			
		}
		


	}

	public void chosenCompanyTwo(){
		activeSector = ChooseStockSector.activeSector;
		deactivateAll ();
		companyTwoButton.GetComponent<Image>().color = Color.green;


		if (activeSector == 1) {
			activeCompany = 2;
			ChooseUtiCompany.companyTwo ();
			
		}

		if (activeSector == 2) {
			activeCompany = 2;
			ChooseTechCompany.companyTwo ();
			
		}
	}

	public void deactivateAll() {
		companyOneButton.GetComponent<Image>().color = Color.white;
		companyTwoButton.GetComponent<Image>().color = Color.white;

	}

}

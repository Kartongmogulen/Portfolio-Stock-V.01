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
	public GameObject companyThreeButton;
	public GameObject companyFourButton;

	public int activeSector;
	[SerializeField] int activeCompany;

	//Kontrollerar vilken sektor som är aktiv och sedan vilket bolag inom sektorn som väljs

	void Awake() {
		ChooseStockSector = GetComponent<chooseStockSector>();
		ChooseUtiCompany = ScriptsGO.GetComponent<chooseUtiCompany>();
		ChooseTechCompany = ScriptsGO.GetComponent<chooseTechCompany>();

		//StockMarketInventory = stockMarketGO.GetComponent<stockMarketManager>().StockMarketInventory;
	}

	void Update() {
		//Debug.Log("Aktivt företag: " + activeCompany);
		
		if (activeCompany == 1) {
			chosenCompanyOne ();
			//Debug.Log("Företag 1");
		}
		if (activeCompany == 2) {
			chosenCompanyTwo ();
			//Debug.Log("Företag 2");
		}

		if (activeCompany == 3)
		{
			chosenCompanyThree();
			//Debug.Log("Företag 3");
		}

		if (activeCompany == 4)
		{
			chosenCompanyFour();
			//Debug.Log("Företag 3");
		}

	}

	public void chooseCompanyInt(int activeCompanyIndex)
	{
		activeSector = ChooseStockSector.activeSector;
		deactivateAll();
		//companyOneButton.GetComponent<Image>().color = Color.green;
		activeCompany = activeCompanyIndex;

		Debug.Log("Aktiv sektor: " + activeSector);
		if (activeSector == 1 && activeCompany == 3)
		{
			companyThreeButton.GetComponent<Image>().color = Color.green;
			ChooseUtiCompany.companyThree();

		}

		if (activeSector == 1 && activeCompany == 4)
		{
			companyFourButton.GetComponent<Image>().color = Color.green;
			ChooseUtiCompany.companyFour();

		}

		if (activeSector == 2 && activeCompany == 3)
		{
			companyThreeButton.GetComponent<Image>().color = Color.green;
			ChooseTechCompany.companyNumber(activeCompany-1);
		}

		if (activeSector == 2 && activeCompany == 4)
		{
			companyFourButton.GetComponent<Image>().color = Color.green;
			ChooseTechCompany.companyNumber(activeCompany - 1);
		}

	}

	public void chosenCompanyOne() {
		activeSector = ChooseStockSector.activeSector;
		deactivateAll();
		companyOneButton.GetComponent<Image>().color = Color.green;
		//Debug.Log(activeSector);
		//Debug.Log("Bolag: " + activeCompany);


		if (activeSector == 1) {
			activeCompany = 1;
			ChooseUtiCompany.companyOne();

		}

		if (activeSector == 2) {
			activeCompany = 1;
			ChooseTechCompany.companyOne();

		}


	}

	public void chosenCompanyTwo() {
		activeSector = ChooseStockSector.activeSector;
		deactivateAll();
		companyTwoButton.GetComponent<Image>().color = Color.green;


		if (activeSector == 1) {
			activeCompany = 2;
			ChooseUtiCompany.companyTwo();

		}

		if (activeSector == 2) {
			activeCompany = 2;
			ChooseTechCompany.companyTwo();

		}
	}

	public void chosenCompanyThree()
	{
		activeSector = ChooseStockSector.activeSector;
		deactivateAll();
		companyThreeButton.GetComponent<Image>().color = Color.green;
		

		if (activeSector == 1)
		{
			activeCompany = 3;
			ChooseUtiCompany.companyThree();
			Debug.Log("Aktivt företag: " + activeCompany);
		}

		if (activeSector == 2)
		{
			activeCompany = 3;
			ChooseTechCompany.companyThree();
			Debug.Log("Aktivt företag: " + activeCompany);
		}
	}

	public void chosenCompanyFour()
	{
		activeSector = ChooseStockSector.activeSector;
		deactivateAll();
		companyFourButton.GetComponent<Image>().color = Color.green;


		if (activeSector == 1)
		{
			activeCompany = 4;
			ChooseUtiCompany.companyFour();
			Debug.Log("Aktivt företag: " + activeCompany);
		}

		if (activeSector == 2)
		{
			activeCompany = 4;
			ChooseTechCompany.companyNumber(activeCompany-1);
			Debug.Log("Aktivt företag: " + activeCompany);
		}
	}

	public void deactivateAll() 
	{
		companyOneButton.GetComponent<Image>().color = Color.white;
		companyTwoButton.GetComponent<Image>().color = Color.white;
		companyThreeButton.GetComponent<Image>().color = Color.white;
		companyFourButton.GetComponent<Image>().color = Color.white;

	}

	public int getActiveCompany()
	{
		return activeCompany;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orderValue : MonoBehaviour
{
	public GameObject buttonGO;
	public GameObject stockGO;
	public InputField inputOrderAmount;
	public chooseStockSector ChooseStockSector;
	public buyStock BuyStock;
	public Text orderValueText;

	public int activeCompany;
	public int activeSector;
	public int amountOrder;
	public float stockPrice;

	void Awake() {
		ChooseStockSector = buttonGO.GetComponent<chooseStockSector>();
		BuyStock = buttonGO.GetComponent<buyStock>();
	}

	// Update is called once per frame
	public void onChangeInput()
	{

		if (inputOrderAmount.text != "")
		{
			activeSector = ChooseStockSector.activeSector;

			//Identifera vilket företag (nr)
			if (activeSector == 1)
			{
				activeCompany = stockGO.GetComponent<chooseUtiCompany>().activeCompany;
				stockPrice = stockGO.GetComponent<chooseUtiCompany>().activeCompanyPrice;

			}

			if (activeSector == 2)
			{
				activeCompany = stockGO.GetComponent<chooseTechCompany>().activeCompany;
				stockPrice = stockGO.GetComponent<chooseTechCompany>().activeCompanyPrice;
			}

			if (activeSector == 3)
			{
				activeCompany = stockGO.GetComponent<chooseMaterialCompany>().activeCompany;
				stockPrice = stockGO.GetComponent<chooseMaterialCompany>().activeCompanyPrice;
			}

			if (orderValueText.text == "")
			{
				amountOrder = 0;
				Debug.Log("Empty");
			}
			else
				amountOrder = int.Parse(inputOrderAmount.text);

			orderValueText.text = "Value order: " + amountOrder * stockPrice;
		}

	}

}
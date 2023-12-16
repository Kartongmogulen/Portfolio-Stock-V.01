using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseStockSector_1850 : MonoBehaviour
{
	bool mineSector;
	bool railroadSector;

	public int activeSector; //Vilken sektor spelaren har valt. Används av andra script vid t.ex köp.

	public GameObject mineSectorButton;
	public GameObject railroadSectorButton;


	private void Start()
	{
		mineSectorSelection();
	}
	public void deactivateAll()
	{
		mineSectorButton.GetComponent<Image>().color = Color.white;
		railroadSectorButton.GetComponent<Image>().color = Color.white;
		activeSector = 0;
	}

	public void mineSectorSelection()
	{
		deactivateAll();
		activeSector = 1;
		mineSectorButton.GetComponent<Image>().color = Color.green;
	}

	public void railroadSectorSelection()
	{
		deactivateAll();
		activeSector = 2;
		railroadSectorButton.GetComponent<Image>().color = Color.green;
	}

	public void materialSectorSelection()
	{
		deactivateAll();
		//companyPanelMaterial.SetActive (true);
		activeSector = 3;
	}

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseStockSector : MonoBehaviour
{
	bool utiSector;
	bool techSector;

	public int activeSector; //Vilken sektor spelaren har valt. Används av andra script vid t.ex köp.

	public GameObject utiSectorButton;
	public GameObject techSectorButton;


	private void Start()
	{
		utiSectorSelection();
	}
	public void deactivateAll() {
		utiSectorButton.GetComponent<Image>().color = Color.white;
		techSectorButton.GetComponent<Image>().color = Color.white;
		activeSector = 0;
	}

	public void utiSectorSelection(){
		deactivateAll ();
		activeSector = 1;
		utiSectorButton.GetComponent<Image>().color = Color.green;
	}

	public void techSectorSelection(){
		deactivateAll ();
		activeSector = 2;
		techSectorButton.GetComponent<Image>().color = Color.green;
	}

	public void materialSectorSelection(){
		deactivateAll ();
		//companyPanelMaterial.SetActive (true);
		activeSector = 3;
	}
		
		





}

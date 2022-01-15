using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PEG : MonoBehaviour
{
	//Beräkning av PEG-talet
    
	public float EPSNow;
	public float EPSxYearsAgo;
	public float EPSGrowth;
	public int year;
	public float price;

	public Text PEGtext;
	public GameObject MainCanvasGO;
	//public GameObject StockScriptGO;

	public void calculatePEG(){

		year = MainCanvasGO.GetComponent<infoStockSector> ().year;

		if (year >= 2) {
			EPSNow = MainCanvasGO.GetComponent<infoStockSector> ().utiEPSHist [year-1];
			EPSxYearsAgo = MainCanvasGO.GetComponent<infoStockSector> ().utiEPSHist [year - 2];

			EPSGrowth = (EPSNow / EPSxYearsAgo)*100;
		}

		price = MainCanvasGO.GetComponent<infoStockSector>().utiStockPrice;

		PEGtext.text = "PEG: " + Mathf.Round((price/EPSGrowth)*100)/100;

	}
}

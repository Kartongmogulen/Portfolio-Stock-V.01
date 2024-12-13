using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DCFButton : MonoBehaviour
{
	public float discountRate;

	public float playerViewMinUti;

	public float UtiDCF;

	public float EPSInput;
	public float EPSChangeMin;
	public float EPSChangeMax;
	public float valueDCFMinUti;
	public float valueDCFMaxUti;
	public int period;


	public Text UtiDCFText;

	public GameObject MainCanvasGO;
	public GameObject StockScriptGO;


	public void updateDCFforUti(){

		EPSInput = MainCanvasGO.GetComponent<infoStockSector>().utiEPSNow;
		EPSChangeMin = MainCanvasGO.GetComponent<infoStockSector>().utiEPSGrowthMin;
		EPSChangeMax = MainCanvasGO.GetComponent<infoStockSector>().utiEPSGrowthMax;

		StockScriptGO.GetComponent<DCF>().DCFCalculation(discountRate, EPSInput, EPSChangeMin, period);
		valueDCFMinUti = StockScriptGO.GetComponent<DCF> ().valueDCF;

		StockScriptGO.GetComponent<DCF>().DCFCalculation(discountRate, EPSInput, EPSChangeMax, period);
		valueDCFMaxUti = StockScriptGO.GetComponent<DCF> ().valueDCF;

		UtiDCFText.text = "DCF: " + Mathf.Round(valueDCFMinUti) + "-" + Mathf.Round(valueDCFMaxUti);
	}
}

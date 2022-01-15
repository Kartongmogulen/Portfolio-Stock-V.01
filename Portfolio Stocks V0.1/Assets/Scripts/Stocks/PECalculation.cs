using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PECalculation : MonoBehaviour
{
	public utilitiesInfoStock UtilitiesInfoStock;
	public float[] EPSGrowthMid;
	public float[] EPSUtiComp;
	public float earningsYield;

	//Script för att beräkna PE

	void Awake()
	{
		UtilitiesInfoStock = GetComponent<utilitiesInfoStock> ();

	}

	public void update()
	{
		EPSUtiComp [0] = UtilitiesInfoStock.EPSNow [0];
		EPSGrowthMid[0] = UtilitiesInfoStock.utiCompanyMaxEPSGrowth [0] - UtilitiesInfoStock.utiCompanyMinEPSGrowth [0];
		Debug.Log ("EPSGrowthMid: " + EPSGrowthMid);

		//earningsYield = 
	}
}

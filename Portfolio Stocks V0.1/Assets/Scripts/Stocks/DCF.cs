using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DCF : MonoBehaviour
{
	//Script to calcuate Discounted Cashflow from estimated EPS growth
	
	public float valueDCF;
	public float DR;
	public float EPSNow;
	public float EPSChange;

	public void DCFCalculation(float DiscountRate, float EPSInput, float EPSChange, int period)
    {
		valueDCF = 0; //Nollställer för varje körning
		EPSChange = EPSChange / 100;

		for (int i=1; i<period; i++){
			EPSNow = EPSInput * Mathf.Pow (1 + EPSChange, i); //Prognostiserad EPS i framtiden
			valueDCF = valueDCF + EPSNow/Mathf.Pow((1 + DiscountRate), i); //Diskonterat kassaflöde för perioden
		}
    }
}

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


    // Start is called before the first frame update
    void Start()
    {
		//DCFCalculation(DR, EPSNow, EPSChange, period);
    }
		
    // DCF-calculation for 5 years
	public void DCFCalculation(float DiscountRate, float EPSInput, float EPSChange, int period)
    {
		valueDCF = 0; //Nollställer för varje körning
		EPSChange = EPSChange / 100;

		if (EPSInput < 0) {
			EPSInput = EPSInput*(-Mathf.Pow (1 + EPSChange, 5));
		}

		for (int i=1; i<period; i++){
			EPSNow = EPSInput * Mathf.Pow (1 + EPSChange, i); //Prognostiserad EPS i framtiden

			valueDCF = valueDCF + EPSNow/Mathf.Pow((1 + DiscountRate), i); //Diskonterat kassaflöde för perioden
	
		}

    }
}

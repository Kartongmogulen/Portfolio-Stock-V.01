using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class utilitiesInfoStock : MonoBehaviour
{

	public int amountCompanies;
	public int costUnlockDivPolicy;
	public int costUnlockEPSGrowth;

	public float minEPSGrowth;
	public float maxEPSGrowth;
	public int spreadEPS; //Om det är liten eller stor spread på EPS;
	public List<float> EPSstart = new List<float> ();
	public List<float> EPSCompanyOne = new List<float> ();
	public List<float> EPSNow = new List<float> ();
	//public float[] EPSNow;

	public float startEPS;

	public List<float> divPayout = new List<float> (); //Utdelning för bolagen;
	public List<float> divPayoutShare = new List<float> (); //Vilken utdelningsandel bolaget har;

	public List<float> utiCompanyMinEPSGrowth = new List<float> ();
	public List<float> utiCompanyMaxEPSGrowth = new List<float> ();

	public List<float> dividendMaxPayout = new List<float> ();
	public List<float> dividendPayoutIncrease = new List<float> ();

	//Historiska priser
	public List<float> companyOnePriceHist = new List<float> ();
	public List<float> companyTwoPriceHist = new List<float> ();
	public List<float> companyThreePriceHist = new List<float> ();

	//Utdelningshistorik
	public List<float> oneCompanyDivHist = new List<float> ();
	public List<float> twoCompanyDivHist = new List<float> ();
	public List<float> threeCompanyDivHist = new List<float> ();

	//public GameObject economicClimateGO; 

	private int i = 0;
	//public int bnpYearBefore;

    void Awake()
    {
		utiCompanyPredetermined();

		/*for (int i = 0;  i < amountCompanies; i++){
		utiCreateCompany();
	    utiCompanyMinEPSGrowth.Add(minEPSGrowth);
		utiCompanyMaxEPSGrowth.Add(maxEPSGrowth);
		}*/
    }

	public void utiCompanyPredetermined(){

	//Bolag 1. Säker och stabil inkomst
		EPSNow.Add(startEPS);
		divPayout.Add(startEPS * 0.7f);
		divPayoutShare.Add(divPayout[0]/EPSNow[0]); //Utdelningsandel
		dividendMaxPayout.Add(80);
		dividendPayoutIncrease.Add(Random.Range(1,4));
		utiCompanyMinEPSGrowth.Add (Random.Range (0, 3));
		utiCompanyMaxEPSGrowth.Add (utiCompanyMinEPSGrowth[0] + 1);

	//Bolag 2. Mer fokus på tillväxt
		EPSNow.Add(startEPS);
		divPayout.Add(startEPS * 0.5f);
		divPayoutShare.Add(divPayout[1]/EPSNow[1]); //Utdelningsandel
		dividendMaxPayout.Add(70);
		dividendPayoutIncrease.Add(Random.Range(3,5));
		utiCompanyMinEPSGrowth.Add (Random.Range (2, 5));
		utiCompanyMaxEPSGrowth.Add (utiCompanyMinEPSGrowth[1] + 3);

	}

	public void utiCreateCompany ()
	{
		EPSNow.Add(startEPS);
		divPayout.Add(Mathf.RoundToInt(Random.Range (EPSNow[i]*0.4f, EPSNow[i]*0.8f))); //Vilken utdelning företaget börjar med
		divPayoutShare.Add(divPayout[i]/EPSNow[i]); //Utdelningsandel
		dividendMaxPayout.Add(Random.Range (Mathf.RoundToInt(divPayoutShare[i]*100), 80)); //Max utdelning företaget tänker betala ut
		dividendPayoutIncrease.Add(Random.Range(1,6)); //Vilken utdelningsökning bolaget planerar
		spreadEPS = Random.Range(0,2);

		if (spreadEPS == 0) {

			minEPSGrowth = Random.Range (0, 4);
			maxEPSGrowth = minEPSGrowth + 1f;

		}

		if (spreadEPS == 1) {

			minEPSGrowth = Random.Range (0, 4)-1f;
			maxEPSGrowth = minEPSGrowth + 3f;

		}

		i++;
	}

	public void updateDataMonthEnd()
	{

	}

		public void updateDataYearEnd()
		{

		//bnpYearBefore = economicClimateGO.GetComponent<EconomicClimate> ().yearlyBNPGrowthRate;
		
		oneCompanyDivHist.Add(divPayout[0]);
		twoCompanyDivHist.Add(divPayout[1]);
		//threeCompanyDivHist.Add(divPayout[2]);
	
		for (int i = 0; i < EPSNow.Count; i ++){
			EPSNow [i] = EPSNow [i] * (1+Mathf.Round(Random.Range (utiCompanyMinEPSGrowth[i], utiCompanyMaxEPSGrowth[i]))/100);
				
		}

		updateDividends ();
	}

	public void updateDividends(){

		for (int i = 0; i < amountCompanies; i++)
			if (divPayoutShare [i] * (1 + dividendPayoutIncrease [i] / 100) <= dividendMaxPayout [i]) { //Kontrollera så inte utdelningsandelen blir högre än högsta tillåtna
				divPayout[i] = divPayout[i]*(1 + dividendPayoutIncrease [i] / 100);
			}

	}
}


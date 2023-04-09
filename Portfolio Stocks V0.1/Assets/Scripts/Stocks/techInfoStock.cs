using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class techInfoStock : MonoBehaviour
{

	public int amountCompanies;
	public int costUnlockDivPolicy;
	public int costUnlockEPSGrowth;

	public float minEPSGrowth;
	public float maxEPSGrowth;
	public int spreadEPS; //Om det är liten eller stor spread på EPS;
	public float minEPSGrowthWithBNP;
	public float maxEPSGrowthWithBNP;

	public List<float> EPSstart = new List<float> ();
	public List<float> EPSCompanyOne = new List<float> ();
	public List<float> EPSNow = new List<float> ();

	public float startEPS;
	public float startEPSGrowthCompany; //Bolaget jag skapar själv som ej är lönsamt

	public List<float> divPayout = new List<float> (); //Utdelning för bolagen;
	public List<float> divPayoutShare = new List<float> (); //Vilken utdelningsandel bolaget har;

	public List<float> CompanyMinEPSGrowth = new List<float> ();
	public List<float> CompanyMaxEPSGrowth = new List<float> ();

	public List<float> BNPEffectOnEPS = new List<float> ();//Hur EPS påverkas av det globala klimatet
	public float effectBnpOnEPS;

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

	//EPS innan utdelning sker
	public List<float> EPSBeforePayingDividend = new List<float> ();//EPS innan företaget tänker börja dela ut vinsten
	public List<float> techPaysDividend = new List<float> ();

	public GameObject economicClimateGO; 

	private int i = 0;
	public int bnpYearBefore;

	void Awake()
	{

		CompanyPredetermined();

		/*for (int i = 0;  i < amountCompanies; i++){
			CreateCompany();
			CompanyMinEPSGrowth.Add(minEPSGrowth);
			CompanyMaxEPSGrowth.Add(maxEPSGrowth);
			Debug.Log ("minEPS: " + minEPSGrowth);

		}*/
	}

	public void CompanyPredetermined(){

		//Bolag 1. Lönsamt, Mindre tillväxt
		EPSNow.Add (startEPS);
		divPayout.Add (startEPS * 0.6f);
		divPayoutShare.Add (divPayout [0] / EPSNow [0]); //Utdelningsandel
		dividendMaxPayout.Add (80);
		dividendPayoutIncrease.Add (Random.Range (3, 8));
		CompanyMinEPSGrowth.Add (Random.Range (5, 10));
		CompanyMaxEPSGrowth.Add (CompanyMinEPSGrowth [0] + 3);
		BNPEffectOnEPS.Add(0.5f);

		if (dividendMaxPayout [0] > 0)
			techPaysDividend [0] = 1;

		//Bolag 2. EJ Lönsamt, Högre potential
		EPSNow.Add (startEPSGrowthCompany);
		divPayout.Add (startEPS * 0.0f);
		divPayoutShare.Add (divPayout [1] / EPSNow [1]); //Utdelningsandel
		dividendMaxPayout.Add (60);
		dividendPayoutIncrease.Add (Random.Range (8, 12));
		CompanyMinEPSGrowth.Add (Random.Range (8, 12));
		CompanyMaxEPSGrowth.Add (CompanyMinEPSGrowth [1] + 3);
		BNPEffectOnEPS.Add(1f);

	}

	public void CreateCompany ()
	{
		EPSNow.Add (startEPS);
		divPayout.Add(Mathf.RoundToInt(Random.Range (EPSNow[i]*0.0f, EPSNow[i]*0.0f))); //Vilken utdelning företaget börjar med
		divPayoutShare.Add(divPayout[i]/EPSNow[i]); //Utdelningsandel
		//dividendMaxPayout.Add(Random.Range (Mathf.RoundToInt(divPayoutShare[i]*100), 80)); //Max utdelning företaget tänker betala ut
		dividendPayoutIncrease.Add(Random.Range(5,10)); //Vilken utdelningsökning bolaget planerar

		spreadEPS = Random.Range(0,2);

		BNPEffectOnEPS.Add(effectBnpOnEPS);

		if (spreadEPS == 0) //"Låg" spread
		{

			minEPSGrowth = Random.Range (-2, 0);
			maxEPSGrowth = minEPSGrowth + 10f;

		}

		if (spreadEPS == 1) //"Hög" spread
		{

			minEPSGrowth = Random.Range (-5, 0);
			maxEPSGrowth = minEPSGrowth + 20f;

		}

		//Vilket EPS företag ska ha innan de börjar dela ut
		EPSBeforePayingDividend.Add(Random.Range (1,4)*100);

		i++;
	}

	public void updateDataMonthEnd()
	{

	}

	public void updateDataYearEnd()
	{
		bnpYearBefore = economicClimateGO.GetComponent<economicClimate> ().yearlyBNPGrowthRate;
		//Debug.Log ("BNP året innan: " + bnpYearBefore);

		oneCompanyDivHist.Add(divPayout[0]);
		//twoCompanyDivHist.Add(divPayout[1]);
		//threeCompanyDivHist.Add(divPayout[2]);

		EPSCompanyOne.Add (EPSNow [0]);

		for (int i = 0; i < EPSNow.Count; i ++){
			
			minEPSGrowthWithBNP = (CompanyMinEPSGrowth [i] + bnpYearBefore*BNPEffectOnEPS[i]);
			maxEPSGrowthWithBNP = (CompanyMaxEPSGrowth [i] + bnpYearBefore*BNPEffectOnEPS[i]);

			if (EPSNow [i]>0)
			EPSNow [i] = EPSNow [i] * (1+Mathf.Round(Random.Range (minEPSGrowthWithBNP, maxEPSGrowthWithBNP))/100);
			else 
				EPSNow [i] =	EPSNow [i] - startEPSGrowthCompany * (Mathf.Round(Random.Range (minEPSGrowthWithBNP, maxEPSGrowthWithBNP))/100);//Om EPS är negativ

			if (techPaysDividend [i] == 1) 
			{
				divPayout [i] = divPayout [i] * (1 + dividendPayoutIncrease [i]/100);
				divPayoutShare [i] = divPayout [i] / EPSNow [i];
			}


			/*
			if (EPSNow [i] >= EPSBeforePayingDividend [i] && techPaysDividend[i] == 0) {
				divPayout[i] = EPSNow [i]*0.1f;
				techPaysDividend [i] = 1;
				divPayoutShare [i] = divPayout [i] / EPSNow [i];
			}*/


		}
			
	}
}

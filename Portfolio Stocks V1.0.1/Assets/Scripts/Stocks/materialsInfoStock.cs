using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class materialsInfoStock : MonoBehaviour
{
	//Startvariabler som måste bestämmas
	public int amountCompanies; 
	public float startEPS;

	//Annat
	public int minGlobalAffectBNP; //Hur global BNP påverkar bolaget, minimalt
	public int maxGlobalAffectBNP; //Hur global BNP påverkar bolaget, minimalt

	public float minEPSGrowth;
	public float maxEPSGrowth;
	public int spreadEPS; //Om det är liten eller stor spread på EPS;
	public float minEPSGrowthWithBNP;
	public float maxEPSGrowthWithBNP;


	public List<float> EPSstart = new List<float> ();
	public List<float> EPSCompanyOne = new List<float> ();
	public List<float> EPSNow = new List<float> ();

	public List<float> divPayout = new List<float> (); //Utdelning för bolagen;
	public List<float> divPayoutShare = new List<float> (); //Vilken utdelningsandel bolaget har;

	public List<float> CompanyMinEPSGrowth = new List<float> ();
	public List<float> CompanyMaxEPSGrowth = new List<float> ();

	public List<float> BNPEffectOnEPS = new List<float> ();//Hur EPS påverkas av det globala klimatet

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

	public GameObject economicClimateGO; 

	private int i = 0;
	public int bnpYearBefore;

	void Awake()
	{

		for (int i = 0;  i < amountCompanies; i++){
			CreateCompany();
			CompanyMinEPSGrowth.Add(minEPSGrowth);
			CompanyMaxEPSGrowth.Add(maxEPSGrowth);

		}
	}

	public void CreateCompany ()
	{
		EPSNow.Add(startEPS);
		divPayout.Add(Mathf.RoundToInt(Random.Range (EPSNow[i]*0.2f, EPSNow[i]*0.6f))); //Vilken utdelning företaget börjar med
		divPayoutShare.Add(divPayout[i]/EPSNow[i]); //Utdelningsandel
		dividendMaxPayout.Add(Random.Range (Mathf.RoundToInt(divPayoutShare[i]*100), 80)); //Max utdelning företaget tänker betala ut
		dividendPayoutIncrease.Add(Random.Range(3,8)); //Vilken utdelningsökning bolaget planerar
		spreadEPS = Random.Range(0,2);
		//BNPEffectOnEPS.Add(Random.Range(1,3));
		BNPEffectOnEPS.Add(1);

		if (spreadEPS == 0) {

			minEPSGrowth = Random.Range (0, 4);
			maxEPSGrowth = minEPSGrowth + 3f;

		}

		if (spreadEPS == 1) {

			minEPSGrowth = Random.Range (0, 4)-2f;
			maxEPSGrowth = minEPSGrowth + 5f;

		}

		i++;
	}

	public void updateDataMonthEnd()
	{

	}

	public void updateDataYearEnd()
	{

		bnpYearBefore = economicClimateGO.GetComponent<economicClimate> ().yearlyBNPGrowthRate;

		oneCompanyDivHist.Add(divPayout[0]);
		twoCompanyDivHist.Add(divPayout[1]);
		threeCompanyDivHist.Add(divPayout[2]);

		for (int i = 0; i < EPSNow.Count; i ++){
			minEPSGrowthWithBNP = (CompanyMinEPSGrowth [i] + bnpYearBefore*BNPEffectOnEPS[i]);
			maxEPSGrowthWithBNP = (CompanyMaxEPSGrowth [i] + bnpYearBefore*BNPEffectOnEPS[i]);

			EPSNow [i] = EPSNow [i] * (1+Mathf.Round(Random.Range (minEPSGrowthWithBNP, maxEPSGrowthWithBNP))/100);

		}
	}
}

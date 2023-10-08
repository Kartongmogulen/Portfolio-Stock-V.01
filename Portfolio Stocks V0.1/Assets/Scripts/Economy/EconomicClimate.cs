using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class economicClimate : MonoBehaviour
{
	//Script för att bestämma konjunkturcykel
	public GameObject scriptsCalculationGO;
	public gamePlayScopeManager GamePlayScopeManager;
	public recessionOrExpanssionEnum RecessionOrExpanssionEnum;

	//Globalt
	public float totalBNPBefore;
	public float totalBNPAfter;
	public List<float> totalBNPlist = new List<float>();
	public float normalizedPlayerStartBNP; //Normaliserar startvärdet så historisk värde ej inkluderas.
	

	[Header("Högkonjunktur")]
	public int[] constantIntervallExpansion; //Olika fasta värden på expansionsfas
	[Tooltip("Ökning(%/år)")]
	public int[] growthRateYearExpanssion;

	[Header("Lågkonjunktur")]
	public int[] constantIntervallRecession; //Olika fasta värden på expansionsfas
	public int[] growthRateYearRecession;

	public Text ecoClimateText;
	public Text lengthCykelText;
	public Text BNPText;

	int probExpansionShort; //Slh för expansion 
	int probExpansionMediumStart; //Slh för expansion 
	int probExpansionMedium; //Slh för expansion 
	int probExpansionLong; //Slh för expansion 

	public int probDepression;//Slh för recenssion
	public int expOrRec; //Om det är expansion eller recenssion

	public int a;
	public int lengthCykelProb;
	public int lengthCykelYears;
	public int lengthCykelYearsCount;
	public int yearlyBNPGrowthRate;
	public int recOrDep;

	public int i;

	public List<recessionOrExpanssionEnum> recenssionOrExpanssion;

	void Start()
	{
		probExpansionMedium = probExpansionMediumStart + probExpansionShort;

		//updateEcoClimate ();
		//lengthPeriod();
		lengthPeriodThreeConstant();
		//yearlyGrowthRate();
		updateEcoClimate();
		StartCoroutine(normalizeStartingBNP());
	}

	IEnumerator normalizeStartingBNP()
	{
		yield return new WaitForSeconds(0.05f);
		normalizedPlayerStartBNP = scriptsCalculationGO.GetComponent<normalizeValue>().normalizeOneValue(totalBNPlist[GamePlayScopeManager.yearsToGetHistoricData - 1], totalBNPlist[0]);
	}

	public void updateEcoClimate() {
		//Debug.Log("Uppdatering ekonomiskt klimat: 1");
		recenssionOrExpanssion.Add(RecessionOrExpanssionEnum);
		yearlyGrowthRate();
		globalBNPChanger(yearlyBNPGrowthRate);

		lengthCykelYearsCount++;
		if (lengthCykelYearsCount >= lengthCykelYears) {
			lengthCykelYearsCount = 0;
			Debug.Log("Uppdatering ekonomiskt klimat: 2");
			if (RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Expanssion)
			{
				RecessionOrExpanssionEnum = recessionOrExpanssionEnum.Rececssion;
				Debug.Log("Uppdatering ekonomiskt klimat: Byt till Recenssion");
			}

			else if (RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Rececssion)
			{
				RecessionOrExpanssionEnum = recessionOrExpanssionEnum.Expanssion;
				//Debug.Log("Uppdatering ekonomiskt klimat: Byt till Expanssion");
			}

			//lengthPeriod();
			lengthPeriodThreeConstant();
			/*if (expOrRec == 0) {
				expOrRec = 1;
				lengthCykelYearsCount = 0;
				Debug.Log("ExpLrRec: " + expOrRec);
				lengthPeriod();
			}
			else {
				expOrRec = 0;
				lengthCykelYearsCount = 0;
				Debug.Log("ExpLrRec: " + expOrRec);
				lengthPeriod();
			}
			*/

		}

	}

	//3 Fasta längder på konjunkturcykel
	public void lengthPeriodThreeConstant()
	{
		if (RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Expanssion)
		lengthCykelYears = constantIntervallExpansion[Random.Range(0, constantIntervallExpansion.Length)];
		else
		{
			lengthCykelYears = constantIntervallRecession[Random.Range(0, constantIntervallRecession.Length)];
		}
	}

	public void lengthPeriod(){

		if (expOrRec == 0) {

			lengthCykelYears = constantIntervallExpansion[Random.Range(0, constantIntervallExpansion.Length)];
			Debug.Log("Längd högkonjunktur: " + lengthCykelYears);

			/*
			lengthCykelProb = Random.Range (0, 10); //Slumpar om perioden ska vara kort, medium eller lång

			//Beslutar längden på konjunkturcykeln
			if (lengthCykelProb <= probExpansionShort)
				lengthCykelText.text = "Short";
			else if (lengthCykelProb <= probExpansionMedium)
				lengthCykelText.text = "Medium";
			else {
				lengthCykelText.text = "Long";

			}

			if (lengthCykelText.text == "Short") {
				lengthCykelYears = Random.Range (0, 3);
				}
			if (lengthCykelText.text == "Medium") {
				lengthCykelYears = Random.Range (4, 9);
			}
			if (lengthCykelText.text == "Long") {
				lengthCykelYears = Random.Range (10, 20);
			}
		*/
			ecoClimateText.text = "Expanssion";

		}

		if (expOrRec == 1) {

			lengthCykelYears = Random.Range (0, 3); //Slumpar om perioden ska vara kort, medium eller lång
			recOrDep = Random.Range (0,100);
			ecoClimateText.text = "Recenssion/Depression";
		}

		//yearlyGrowthRate ();
	}

	//Hur mycket BNP förändras per år
	public void yearlyGrowthRate(){
		
		if (RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Expanssion) 
		{
			yearlyBNPGrowthRate = growthRateYearExpanssion[Random.Range(0, growthRateYearExpanssion.Length)];
		}

		if (RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Rececssion)
		{
			yearlyBNPGrowthRate = growthRateYearRecession[Random.Range(0, growthRateYearRecession.Length)];
		}
		//Debug.Log("BNP-förändring: " + yearlyBNPGrowthRate);

		/*
		//Hur mycket BNP ökar per år
		if (expOrRec == 0) {
			if (lengthCykelText.text == "Short") {
				yearlyBNPGrowthRate = Random.Range (2, 8);
			}

			if (lengthCykelText.text == "Medium") {
				yearlyBNPGrowthRate = Random.Range (3, 6);
			}

			if (lengthCykelText.text == "Long") {
				yearlyBNPGrowthRate = Random.Range (2, 5);
			}
		} else {
			if (recOrDep <= probDepression) {
				yearlyBNPGrowthRate = Random.Range (-10, -2);
			}
			else yearlyBNPGrowthRate = Random.Range (-2, 1);
		}
		*/
	}

	public void globalBNPChanger(int changeBNP){
		//Debug.Log ("BNP Change  " + changeBNP);
		totalBNPlist.Add (totalBNPBefore);
		totalBNPAfter = Mathf.RoundToInt(totalBNPBefore * (100 + changeBNP)/100);
		totalBNPBefore = totalBNPAfter;

		BNPText.text = "BNP: " + totalBNPAfter;

	}
}

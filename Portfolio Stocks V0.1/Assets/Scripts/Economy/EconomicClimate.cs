using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomicClimate : MonoBehaviour
{
	//Script för att bestämma konjunkturcykel



	public float totalBNPBefore;
	public float totalBNPAfter;
	public List <float> totalBNPlist = new List<float>();

	public int probExpansionShort; //Slh för expansion 
	public int probExpansionMediumStart; //Slh för expansion 
	public int probExpansionMedium; //Slh för expansion 
	public int probExpansionLong; //Slh för expansion 

	public int probDepression;//Slh för recenssion
	public int expOrRec; //Om det är expansion eller recenssion

	public Text ecoClimateText;
	public Text lengthCykelText;
	public Text BNPText;

	public int a;
	public int lengthCykelProb;
	public int lengthCykelYears;
	public int lengthCykelYearsCount;
	public int yearlyBNPGrowthRate;
	public int recOrDep;

	public int i;

	void Start()
	{
		probExpansionMedium = probExpansionMediumStart + probExpansionShort;

		//updateEcoClimate ();
		lengthPeriod();
		yearlyGrowthRate();
}

	public void updateEcoClimate(){

		yearlyGrowthRate ();
		globalBNPChanger (yearlyBNPGrowthRate);

		lengthCykelYearsCount++;
		if (lengthCykelYearsCount >= lengthCykelYears) {
			if (expOrRec == 0){
				expOrRec = 1;
				lengthCykelYearsCount = 0;
				Debug.Log ("ExpLrRec: " + expOrRec);
				lengthPeriod();
		}
			else {
				expOrRec = 0;
				lengthCykelYearsCount = 0;
				Debug.Log ("ExpLrRec: " + expOrRec);
				lengthPeriod();
				}

			}

		}

	public void lengthPeriod(){

		if (expOrRec == 0) {

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
		
			ecoClimateText.text = "Expanssion";

		}

		if (expOrRec == 1) {

			lengthCykelYears = Random.Range (0, 3); //Slumpar om perioden ska vara kort, medium eller lång
			recOrDep = Random.Range (0,100);
			ecoClimateText.text = "Recenssion/Depression";
		}

		//yearlyGrowthRate ();
	}

	public void yearlyGrowthRate(){
		i++;
		Debug.Log ("Antal ggr yearlyGrowth körs: " + i);

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
	}

	public void globalBNPChanger(int changeBNP){
		//Debug.Log ("BNP Change  " + changeBNP);
		totalBNPlist.Add (totalBNPBefore);
		totalBNPAfter = Mathf.RoundToInt(totalBNPBefore * (100 + changeBNP)/100);
		totalBNPBefore = totalBNPAfter;

		BNPText.text = "BNP: " + totalBNPAfter;

	}
}

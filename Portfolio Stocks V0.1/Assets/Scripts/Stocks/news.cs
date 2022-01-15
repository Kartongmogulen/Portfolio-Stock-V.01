using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using System;

public class news : MonoBehaviour
{

	//Nyheter som påverkar bolaget
	//Köper ny del som ökar EPS (engångsbelopp alt EPS tillväxt)
	//Ny VD = +/- EPS; Ökad "spread" på EPS
	//Försenade projekt = Lägre EPS för X antal år.
	//Rykten: Uppköp av annat bolag => Ökad förväntat av EPS.

	//public float[] probNewCEOUti; //Sannolikhet för ny VD för varje bolag inom Uti;
	//public float[] probDelayedProjectUti; //Sannolikhet förseningar projekt varje bolag inom Uti;
	//public float[] probRumorPurchaseUti; //Sannolikhet förseningar projekt varje bolag inom Uti;

	public float[] probPurchaseUti; //Sannolikhet för förvärv
	public string[] utiPurshase; //Text vad händelsen innebär
	public float boostEPS; //Engångs ökning av EPS

	public float probGrowthChange;
	public float increaseGrowthEPS; //Ökning av EPS-tillväxt
	public float minEPSGrowthNow;
	public float maxEPSGrowthNow;
	public float minEPSGrowthAfter;
	public float maxEPSGrowthAfter;
	public string[] utiEPSGrowthChange; //Text vad händelsen innebär


	public float probVolChange;
	public float volChange;
	public float utiVolBefore;
	public float utiVolAfter;
	public string[] utiVolText;


	public float EPSNow;

	public float randomFloat;
	public int i;

	public GameObject MainCanvasGO;
	public TMP_Text newsTextOne;
	public TMP_Text newsTextTwo;
	public TMP_Text newsTextThree;

	public void randomNews () //Simulera om nyheten infaller

	{
		i = 0;
		Debug.Log ("I: " + i);
		utiPurshase [0] = "Uppköp leder till ökning av total EPS med: ";
		utiPurshase [1] = "Avyttring leder till minskning av total EPS med: ";

		utiEPSGrowthChange [0] = "Ändrad estimerad tillväxt";

		utiVolText [0] = "Volatility increases to: ";
		utiVolText [1] = "Volatility decreases to: ";

		foreach (float item in probPurchaseUti) {

			randomFloat = Random.Range (0f, 1f);

			if (item >= randomFloat){

				changeEPS (i);

			}
			i++;

		}

		//MÅSTE ÄNDRAS (SE OVAN) OM DET LÄGGS TILL FLER ALTERNATIV
		i = 0;

		randomFloat = Random.Range (0f, 1f);
		if (randomFloat <= probVolChange) {
			changeVolatility (i);	
		}

		randomFloat = Random.Range (0f, 1f);
		if (randomFloat <= probGrowthChange) {
			growthEPSchange (i);	
		}

		Debug.Log ("I: " + i);
	}

	void changeEPS(int i){

		//Ökning av total EPS
		if (i == 0) {

			EPSNow = MainCanvasGO.GetComponent<infoStockSector> ().utiEPSNow; //EPS innan ändring

			newsTextOne.text = utiPurshase [i] + Mathf.Round((boostEPS * EPSNow)*100)/100;

			MainCanvasGO.GetComponent<infoStockSector> ().utiEPSNow = EPSNow+boostEPS*EPSNow; //EPS efter nyheten
		}

		if (i == 1) {

			EPSNow = MainCanvasGO.GetComponent<infoStockSector> ().utiEPSNow; //EPS innan ändring

			newsTextOne.text = utiPurshase [i] + Mathf.Round((-boostEPS * EPSNow)*100)/100;

			MainCanvasGO.GetComponent<infoStockSector> ().utiEPSNow = EPSNow-boostEPS*EPSNow; //EPS efter nyheten
		}
	}

	void growthEPSchange (int i){


		if (i == 0) {

			minEPSGrowthNow = MainCanvasGO.GetComponent<infoStockSector> ().utiEPSGrowthMin; //EPS innan ändring
			maxEPSGrowthNow = MainCanvasGO.GetComponent<infoStockSector> ().utiEPSGrowthMax; //EPS innan ändring

			randomFloat = Random.Range (0f, 1f);

			if	(randomFloat<0.5){

				MainCanvasGO.GetComponent<infoStockSector> ().utiEPSGrowthMin--;
				MainCanvasGO.GetComponent<infoStockSector> ().utiEPSGrowthMax--;

				minEPSGrowthAfter = MainCanvasGO.GetComponent<infoStockSector> ().utiEPSGrowthMin;
				maxEPSGrowthAfter = MainCanvasGO.GetComponent<infoStockSector> ().utiEPSGrowthMax;

				newsTextTwo.text = utiEPSGrowthChange [i] + "(minskning): " + minEPSGrowthAfter + "-" + maxEPSGrowthAfter + " %";
			}


			if	(randomFloat>=0.5){

				MainCanvasGO.GetComponent<infoStockSector> ().utiEPSGrowthMin++;
				MainCanvasGO.GetComponent<infoStockSector> ().utiEPSGrowthMax++;

				minEPSGrowthAfter = MainCanvasGO.GetComponent<infoStockSector> ().utiEPSGrowthMin;
				maxEPSGrowthAfter = MainCanvasGO.GetComponent<infoStockSector> ().utiEPSGrowthMax;

				newsTextTwo.text = utiEPSGrowthChange [i] + "(ökning): " + minEPSGrowthAfter + "-" + maxEPSGrowthAfter + " %";
			}

		
			}
				
		}

	void changeVolatility(int i){

		randomFloat = Random.Range (0f, 1f);

		if	(randomFloat<0.5){

			utiVolBefore = MainCanvasGO.GetComponent<infoStockSector> ().volatilityUti;
			MainCanvasGO.GetComponent<infoStockSector> ().changeVolatility (0, volChange);

			utiVolAfter = MainCanvasGO.GetComponent<infoStockSector> ().volatilityUti;

			newsTextThree.text = utiVolText [0] + utiVolAfter*100 + " from " + utiVolBefore*100 + " %";
		}

		if	(randomFloat>=0.5){
			
			utiVolBefore = MainCanvasGO.GetComponent<infoStockSector> ().volatilityUti;
			MainCanvasGO.GetComponent<infoStockSector> ().changeVolatility (0, -volChange);

			utiVolAfter = MainCanvasGO.GetComponent<infoStockSector> ().volatilityUti;

			newsTextThree.text = utiVolText [1] + utiVolAfter*100 + " from " + utiVolBefore*100 + " %";
		}

	}


}

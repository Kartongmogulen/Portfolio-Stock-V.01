using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yearsDivIncrease : MonoBehaviour
{
	public GameObject MainCanvasGO;

	public int year;
	public List<float> utiCompanyYearsIncreaseDiv = new List<float> ();
	//Antal år företaget höjt utdelningen

	void Start ()
	{

	}


	public void updateDivYearStreak(){
	
		year = MainCanvasGO.GetComponent<endRoundButton> ().year;

		//for (int i = 0; i < 3; i++) {

		//if ()


	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStatsStocks : MonoBehaviour
{
	//Script för vilka skills spelaren har inom Stocks
	public float playerIntervalViewStart; //Vad spelaren har för interval vid start
	public float playerIntervalView; //Vad spelaren har för intervall beroende på lvl

	void Start () {

		playerIntervalViewStart = Random.Range (0.0f,1.0f);
		intervalPlayerViewEPS(playerIntervalViewStart);
	
	}

	public void intervalPlayerViewEPS(float playerIntervalViewNow){



		if (playerIntervalViewNow <= 0.5f){


			playerIntervalView = -1;

		}
		if (playerIntervalViewNow > 0.5f)
		{
				playerIntervalView = 1;

		}
			
	}
		

}

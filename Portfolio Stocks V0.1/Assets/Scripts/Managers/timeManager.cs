using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
	public int year;
	public int month;
	public Text roundText;
	[Tooltip("Antal månader som ska simuleras vid varje aktivering")]
	public int multiMonthSim;

	// SIMULERING 12 MÅNADER
	public bool stop12MonthSim = false;
	public int countMultiMonthSim;

	public historicEventManager HistoricEventManager;

	public void endTurn() //Uppdaterar tid samt texten för vilken aktuell tid det är
	{

		//timePointsLeftText.GetComponent<Text>().enabled = false;

		//month = month + 10;
		month++;//Add 1 to the month;

		if (month > 12)
		{
			year++;
			month = 1;
			//HistoricEventManager.newEventHappened();
		}
		
	}

	//Om varje runda representerar 1 år
	public void endTurnYearlyRounds()
	{
		year++;
	}

	public void updateUI()
	{
		roundText.text = "Y: " + year + " M: " + month;
	}
}

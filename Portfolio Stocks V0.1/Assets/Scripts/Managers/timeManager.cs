using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeManager : MonoBehaviour
{
	public int year;
	public int month;
	[Tooltip("Antal m�nader som ska simuleras vid varje aktivering")]
	public int multiMonthSim;

	// SIMULERING 12 M�NADER
	public bool stop12MonthSim = false;
	public int countMultiMonthSim;

	public historicEventManager HistoricEventManager;

	public void endTurn() //Uppdaterar tid samt texten f�r vilken aktuell tid det �r
	{

		//timePointsLeftText.GetComponent<Text>().enabled = false;

		//month = month + 10;
		month++;//Add 1 to the month;

		if (month > 12)
		{
			year++;
			month = 1;
			HistoricEventManager.newEventHappened();
		}
		
	}
}

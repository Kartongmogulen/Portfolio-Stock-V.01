using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timeManager : MonoBehaviour
{
	[SerializeField] public int year { get; private set; }
	public int month;
	//public Text roundText;
	public TextMeshProUGUI roundText_TMP;
	[Tooltip("Antal månader som ska simuleras vid varje aktivering")]
	public int multiMonthSim;

	// SIMULERING 12 MÅNADER
	public bool stop12MonthSim = false;
	public int countMultiMonthSim;

	public historicEventManager HistoricEventManager;
	public gamePlayScopeManager GamePlayScopeManager;
	public gameEnd GameEnd;

	private void Start()
	{
		GameEnd = FindAnyObjectByType<gameEnd>();

		if (roundText_TMP != null)
		{
			updateUI();
		}
	}
	public void endTurn() //Uppdaterar tid samt texten för vilken aktuell tid det är
	{

		//timePointsLeftText.GetComponent<Text>().enabled = false;

		//month = month + 10;
		month++;//Add 1 to the month;

		//Debug.Log("Spelets läng i år: " + GamePlayScopeManager.yearsBeforeEndGameMaster);
		if (month > 12)
		{
			year++;
			month = 1;
			//HistoricEventManager.newEventHappened();

			if (year == GamePlayScopeManager.yearsBeforeEndGameMaster)
			{
				endGame();
			}
			
			Debug.Log("Year: " + year);
		}
		updateUI();

		

		//Debug.Log("Runda slut: Y: " + year + " M: " + month);

	}

	//Om varje runda representerar 1 år
	public void endTurnYearlyRounds()
	{
		year++;

		handleYearEndRounds();

		if (year == GamePlayScopeManager.yearsBeforeEndGameMaster)
		{
			endGame();
		}
	}

	public void updateUI()
	{
		roundText_TMP.text = "Y: " + year + " M: " + month;
	}

	public void handleYearEndRounds()
	{
		FindAnyObjectByType<yearEnd_AI>().incrementAgeProject();
	}

	public void endGame()
	{
		//Debug.Log("Game ended");
		GameEnd.endOfGame();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yearEnd_AI : MonoBehaviour
{
    //Hanterar vad som sker d� �ret �r slut f�r 
    //public endRoundButton EndRoundButton;
    public opponentsManager OpponentsManager;
    public timeManager TimeManager;

    private void Start()
    {
        TimeManager = FindAnyObjectByType<timeManager>();
    }

    public void checkIfYearHaveEnded()
    {
        if (TimeManager.month == 1)
        {
            incomeFromProjects();
        }
    }

    public void incomeFromProjects()
    {
        for (int i = 0; i < OpponentsManager.opponentsList.Count; i++)
        {
            if(OpponentsManager.opponentsList[i].GetComponent<incomeProduction>() != null)
            OpponentsManager.opponentsList[i].GetComponent<incomeProduction>().incomeCalc();
        }
    }

    public void incrementAgeProject()
    {

        Debug.Log("Uppdatera �lder av projekt");
        for (int i = 0; i < OpponentsManager.opponentsList.Count; i++)
        {
            if (OpponentsManager.opponentsList[i].GetComponent<AIManager_CardMechanic>() != null)
                OpponentsManager.opponentsList[i].GetComponent<AIManager_CardMechanic>().UpdateInvestments();
        }
    }
}

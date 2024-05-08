using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yearEnd_AI : MonoBehaviour
{
    //Hanterar vad som sker då året är slut för 
    public endRoundButton EndRoundButton;
    public opponentsManager OpponentsManager;

    public void checkIfYearHaveEnded()
    {
        if (EndRoundButton.month == 1)
        {
            incomeFromProjects();
        }
    }

    public void incomeFromProjects()
    {
        for (int i = 0; i < OpponentsManager.opponentsList.Count; i++)
        {
            OpponentsManager.opponentsList[i].GetComponent<incomeProduction>().incomeCalc();
        }
    }
}

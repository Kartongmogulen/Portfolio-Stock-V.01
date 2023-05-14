using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stockDataPlayerKnow : MonoBehaviour
{
    public List<bool> EPSdata = new List<bool>(); //Vilken data spelaren känner till om EPS

    public gamePlayScopeManager GamePlayScopeManager;
    public endRoundButton EndRoundButton;
    public ShowHistoricData showHistoricData;

    [SerializeField]
    private int startingYearToRevealData;//Första året spelaren kan se data


    private void Start()
    {
        startingYearToRevealData = GamePlayScopeManager.yearsToGetHistoricData - showHistoricData.yearsHeader.Count;

        for (int i = 0; i<(GamePlayScopeManager.yearsToGetHistoricData + GamePlayScopeManager.yearsBeforeEndGameMaster); i++)
        {
            EPSdata.Add(false);
        }
    }

    //Check if player have unlocked data
    public void PlayerAlreadyKnowData(int year)
    {
        if(EPSdata[Mathf.Abs(startingYearToRevealData + EndRoundButton.year + year)] == false)
        {
            EPSdata[Mathf.Abs(startingYearToRevealData + EndRoundButton.year + year)] = true;
        }
    }
}

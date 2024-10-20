using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePlayScopeManager : MonoBehaviour
{
    public enum difficulty
    {
        Easy,
        Medium
    }

    public difficulty Difficulty;
    //Omfattning av spelet t.ex antal år
    public int yearsBeforeEndGameMaster;
    [Tooltip("Hur många år som ska simuleras innan Spelaren får börja investera för att få historisk data")]
    public int yearsToGetHistoricData;

 

}

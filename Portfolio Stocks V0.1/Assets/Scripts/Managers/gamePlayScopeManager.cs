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
    //Omfattning av spelet t.ex antal �r
    public int yearsBeforeEndGameMaster;
    [Tooltip("Hur m�nga �r som ska simuleras innan Spelaren f�r b�rja investera f�r att f� historisk data")]
    public int yearsToGetHistoricData;

 

}

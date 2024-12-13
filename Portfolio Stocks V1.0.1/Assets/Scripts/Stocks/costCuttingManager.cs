using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class costCuttingManager : MonoBehaviour
{
    public int lvlNow;

    [SerializeField] float ExpericeneNow; //Nuvarande Xp innan lvl upp
    [SerializeField] List<float> experienceToLvlUp;

    //Intervall hur mycket XP som erh�lls f�r varje krona
    [SerializeField] float minXPFromEachMoney;
    [SerializeField] float maxXPFromEachMoney;

    public void investeringInCostCutting(float moneyInvested)
    {
        //Om MAX-level �r uppn�dd
        if (lvlNow == experienceToLvlUp.Count)
        {
            return;
        }
        float randomInt = Random.Range(minXPFromEachMoney, maxXPFromEachMoney);
        //Debug.Log("RandomInt:" + randomInt);
        ExpericeneNow += moneyInvested * randomInt;
        if (ExpericeneNow >= experienceToLvlUp[lvlNow])
        {
            lvlNow++;
        }
    }
}


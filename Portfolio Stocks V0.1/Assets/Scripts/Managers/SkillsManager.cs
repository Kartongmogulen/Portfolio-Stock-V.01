using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsManager : MonoBehaviour
{
    //Hanterar vilka skills splaren kan utveckla
    [Header("More Points to Invest")]
    public int costToUnlockMorePoints;
    public int pointsInvestedNowMoreActionPoints;
    public int addedPointsWhenUnlocked;

    [Header("Unlock New Companies")]
    public int costToUnlockNewCompany;

    public actionPointsManager ActionPointsManager;
    public Text pointsInvestedAndLeftToUnlockText;

    public pointsLeftToUnlock PointsLeftToUnlock;

    public void investInMorePointsToInvest()
    {
        if (ActionPointsManager.remainingAP > 0)
        {
            pointsInvestedNowMoreActionPoints++;
            ActionPointsManager.actionPointSub(1);
            PointsLeftToUnlock.updateText();
        }
    }

}

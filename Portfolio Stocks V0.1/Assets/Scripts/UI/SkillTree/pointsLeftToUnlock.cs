using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsLeftToUnlock : MonoBehaviour
{
    public SkillsManager skillsManager;
   
    public Text pointsInvestedAndLeftToUnlockText;

    public string pointsInvestedAndLeftToUnlockString;

    public void updateText()
    {
        pointsInvestedAndLeftToUnlockText.text = "" + skillsManager.pointsInvestedNowMoreActionPoints + "/" + skillsManager.costToUnlockMorePoints;
    }
}

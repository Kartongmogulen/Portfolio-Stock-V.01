using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsLeftToUnlock : MonoBehaviour
{
    public SkillsManager skillsManager;
   
    public Text pointsInvestedAndLeftToUnlockText;
    public Text unlockNewCompanyText;

    //public string pointsInvestedAndLeftToUnlockString;

    public void getMoreActionPoints()
    {
        if (skillsManager.timePointsLvlNow < skillsManager.costToUnlockMorePoints.Count)
        pointsInvestedAndLeftToUnlockText.text = "" + skillsManager.pointsInvestedNowMoreActionPoints + "/" + skillsManager.costToUnlockMorePoints[skillsManager.timePointsLvlNow];
        else
        {
            pointsInvestedAndLeftToUnlockText.text = "Max lvl reached";
        }
    }

    public void unlockNewCompany()
    {
        if (skillsManager.getLevelUnlockNewCompany() < skillsManager.maxLevelUnlockNewCompany)
            unlockNewCompanyText.text = "" + skillsManager.getExperienceUnlockNewCompany() + "/" + skillsManager.costToUnlockNewCompany;
        else
        {
            unlockNewCompanyText.text = "Max lvl reached";
        }
    }

}

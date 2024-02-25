using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsLeftToUnlock : MonoBehaviour
{
    public SkillsManager skillsManager;
   
    public Text pointsInvestedAndLeftToUnlockText;
    public Text skillNrTwo_Text;
    public Text skillNrThree_Text;

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
            skillNrTwo_Text.text = "" + skillsManager.getExperienceUnlockNewCompany() + "/" + skillsManager.costToUnlockNewCompany;
        else
        {
            skillNrTwo_Text.text = "Max lvl reached";
        }
    }

    public void unlockNewCity()
    {
        if (skillsManager.getLevelUnlockNewCity() < skillsManager.maxLevelUnlockNewCity)
            skillNrTwo_Text.text = "" + skillsManager.getExperienceUnlockNewCity() + "/" + skillsManager.costToUnlockNewCity;
        else
        {
            skillNrTwo_Text.text = "Max lvl reached";
        }
    }

    public void unlockSkill(SkillsPlayer skill)
    {
        if (skill.getCurrentLevel() < skill.maxLevel)
        {
            skillNrThree_Text.text = "" + skill.getCurrentExperience() + "/" + skill.costToUnlockNextLvl[skill.getCurrentLevel()];
        }

        else
        {
            skillNrThree_Text.text = "Max lvl reached";
        }
        
    }

    /*
    public void unlockTool_ComparisonPanel()
    {
        
        if (skillsManager.skillsPlayersList[0].GetComponent<SkillsPlayer>().getCurrentLevel() < skillsManager.skillsPlayersList[0].GetComponent<SkillsPlayer>().maxLevel)
            skillNrThree_Text.text = "" + skillsManager.getExperienceUnlockNewCity() + "/" + skillsManager.costToUnlockNewCity;
        else
        {
            skillNrThree_Text.text = "Max lvl reached";
        }
    }
    */

}

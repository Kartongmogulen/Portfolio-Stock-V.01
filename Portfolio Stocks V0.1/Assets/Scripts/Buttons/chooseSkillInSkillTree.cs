using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class chooseSkillInSkillTree : MonoBehaviour
{
    public descriptionTextSkillTree DescriptionTextSkillTree;
    public SkillsManager skillsManager;

    public void morePointsToInvestButton()
    {
        if (skillsManager.timePointsLvlNow < skillsManager.costToUnlockMorePoints.Count)
            DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.morePointsToInvest + "\n You get " + skillsManager.addedPointsWhenUnlocked[skillsManager.timePointsLvlNow] + " more TimePoints";
    }

    public void unlockNewCompany()
    {
        DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.unlockNewCompnay + "\n You get one new company to invest in";
    }

   
}

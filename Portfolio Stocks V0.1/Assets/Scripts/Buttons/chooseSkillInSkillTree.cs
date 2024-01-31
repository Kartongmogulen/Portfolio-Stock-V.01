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
        DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.unlockNewCompany + "\n You get one new company to invest in";
    }

    public void unlockNewCity()
    {
        DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.unlockNewCompany + "\n You get one new city to invest in";
    }

    public void unlockTool_ComparisonPanel()
    {
        DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.unlockTool_ComparisonPanel + "\n You unlock new Tool: Compare multiple stocks";
    }
}

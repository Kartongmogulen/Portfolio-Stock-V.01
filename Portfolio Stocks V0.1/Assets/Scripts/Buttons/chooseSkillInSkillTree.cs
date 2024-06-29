using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class chooseSkillInSkillTree : MonoBehaviour
{
    public descriptionTextSkillTree DescriptionTextSkillTree;
    public SkillsManager skillsManager;

    public void morePointsToInvestButton()
    {
        //  if (skillsManager.timePointsLvlNow < skillsManager.costToUnlockMorePoints.Count)
        //DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.morePointsToInvest + "\n You get " + skillsManager.addedPointsWhenUnlocked[skillsManager.timePointsLvlNow] + " more TimePoints";
        DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.morePointsToInvest + "\n You get "+ skillsManager.skillsPlayersList[0].getPointsIncreaseLevelUp() + " more TimePoints";
    }

    public void unlockNewCompany()
    {
        DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.unlockNewCompany + "\n You get one new company to invest in";
    }

    public void unlockNewCity()
    {
        DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.unlockNewCity + "\n You get one new city to invest in";
    }

    public void unlockTool_ComparisonPanel()
    {
        DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.unlockTool_ComparisonPanel + "\n You unlock new Tool: Compare multiple stocks";
    }

    public void events_SectorOrCompanyAffected()
    {
        DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.unlockTool_ComparisonPanel + "\n See if event is affecting a whole Sector or the specific company";
    }
    public void events_PosOrNegEffect()
    {
        DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.unlockTool_ComparisonPanel + "\n See if event is positive or negative for the EPS";
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseSkillInSkillTree : MonoBehaviour
{
    public descriptionTextSkillTree DescriptionTextSkillTree;
    public SkillsManager skillsManager;

    public void morePointsToInvestButton()
    {
        DescriptionTextSkillTree.descpritionText.text = DescriptionTextSkillTree.morePointsToInvest + ". You get " + skillsManager.addedPointsWhenUnlocked +" more TimePoints";
    }
}

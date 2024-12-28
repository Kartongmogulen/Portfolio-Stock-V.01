using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actionPointsManager : MonoBehaviour
{
    //Hanterar allt som kräver Action Points

    public int startAP;
    public int baseAP; //Spelarens nuvarande AP vid ny runda
    public int remainingAP;

    public Text actionPointsText;

    public actionPointsLeft_AutoUse ActionPointsLeft_AutoUse;
    public SkillsManager skillsManager;

  void Start()
    {
        remainingAP = startAP;
        baseAP = startAP;

        if(actionPointsText != null)
        actionPointsText.text = " AP: " + remainingAP;
    }

    public void checkIfPointsRemain()
    {
        int remaningAPInterim = remainingAP;
        if (remainingAP > 0)
        {
            //Debug.Log("Active Skill: " + skillsManager.getActiveSkill());
            //Sätter activeSkill till samma som vald
            skillsManager.setActiveSkill(ActionPointsLeft_AutoUse.getSavedIndex());
            //Debug.Log("Active Skill: " + skillsManager.getActiveSkill());
        }

        //while(remainingAP > 0)
        for (int i = 0; remaningAPInterim >= i; i++)
        {
           
            skillsManager.addExperienceGeneralSkill();
            //Debug.Log("Active Skill: " + skillsManager.getActiveSkill());

        }
        
        /*for (int i = 0; remainingAP >= i; i++)
        {
            //remainingAP--;
            skillsManager.addExperienceGeneralSkill();
            Debug.Log("Active Skill: " + skillsManager.getActiveSkill() + "-" + i);
        }*/

    }

    public void actionPointSub(int amountAP)
    {

        if (remainingAP >= amountAP)
        {
            remainingAP -= amountAP;
        }
        updateAP();
    }

    public void endRound()
    {
        if (skillsManager != null)
        {
            checkIfPointsRemain();
        }
        remainingAP = baseAP;
        updateAP();
    }

    public void updateAP()
    {
        if(actionPointsText != null)
        actionPointsText.text = "AP: " + remainingAP;
    }

    

}

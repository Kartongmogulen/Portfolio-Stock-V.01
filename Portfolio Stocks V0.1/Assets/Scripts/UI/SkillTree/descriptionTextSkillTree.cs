using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class descriptionTextSkillTree : MonoBehaviour
{
    public Text descpritionText;

    public string morePointsToInvest = " You get more effective with your time.";
    public string unlockNewCompnay;

    public void updateTextUnlockNewCompany()
    {
        descpritionText.text = "" + unlockNewCompnay;
    }
}

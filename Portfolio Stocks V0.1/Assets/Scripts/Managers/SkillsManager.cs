using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsManager : MonoBehaviour
{
    //Hanterar vilka skills splaren kan utveckla
    [Header("More Points to Invest")]
    public int timePointsLvlNow;
    public List <int> costToUnlockMorePoints;
    public int pointsInvestedNowMoreActionPoints;
    public List <int> addedPointsWhenUnlocked;

    [Header("Unlock New Companies")]
    [SerializeField] private int levelUnlockNewCompany;
    public int costToUnlockNewCompany;
    [SerializeField] private int experienceUnlockNewCompany;
    public int maxLevelUnlockNewCompany;
    public stocksPlayerKnow StocksPlayerKnow;

    //public GameObject companyThreeButton;
    //public GameObject companyFourButton;


    public actionPointsManager ActionPointsManager;
    public Text pointsInvestedAndLeftToUnlockText;

    public pointsLeftToUnlock PointsLeftToUnlock;
    public chooseSkillInSkillTree ChooseSkillInSkill;

    private void Start()
    {
        maxLevelUnlockNewCompany = StocksPlayerKnow.getUnknownCompianesLeft();
    }

    public void addExperienceInMorePointsToInvest()
    {
        if (ActionPointsManager.remainingAP > 0)
        {
            //�r max level uppn�d
            if (timePointsLvlNow < costToUnlockMorePoints.Count)
            {
                pointsInvestedNowMoreActionPoints++;
                ActionPointsManager.actionPointSub(1);

                //Har tillr�ckligt med po�ng investerats
                if (pointsInvestedNowMoreActionPoints == costToUnlockMorePoints[timePointsLvlNow])
                {
                    timePointsLvlNow++; // �kar lvl
                    ActionPointsManager.baseAP += addedPointsWhenUnlocked[timePointsLvlNow - 1];
                    pointsInvestedNowMoreActionPoints = 0;
                }
            }

        }
            PointsLeftToUnlock.getMoreActionPoints();
            ChooseSkillInSkill.morePointsToInvestButton();
    }

    public void addExperienceUnlockNewCompany()
    {
        //Finns det po�ng kvar att anv�nda
        if (ActionPointsManager.remainingAP > 0)
        {
            //�r max level uppn�d
            if (levelUnlockNewCompany < maxLevelUnlockNewCompany)
            {

                experienceUnlockNewCompany++;
                ActionPointsManager.actionPointSub(1);

                //G�r spelaren upp en level?
                if (experienceUnlockNewCompany == costToUnlockNewCompany)
                {
                    levelUnlockNewCompany++; // �kar lvl
                    StocksPlayerKnow.unlockNewCompany();
                    
                    //Nollst�ller experince d� det �r samma po�ng som kr�vs oavsett nuvarande level
                    experienceUnlockNewCompany = 0;
                    //activateButtonForNewCompany();
                }
            }
            PointsLeftToUnlock.unlockNewCompany();
            ChooseSkillInSkill.unlockNewCompany();
        }
    }

    public int getLevelUnlockNewCompany()
    {
        return levelUnlockNewCompany;
    }

    public int getExperienceUnlockNewCompany()
    {
        return experienceUnlockNewCompany;
    }
}

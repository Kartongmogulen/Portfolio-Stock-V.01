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

    [Header("Unlock New City")]
    [SerializeField] private int levelUnlockNewCity;
    public int costToUnlockNewCity;
    [SerializeField] private int experienceUnlockNewCity;
    public int maxLevelUnlockNewCity;
    public CityManager cityManager;

    [Header("Unlock Tools")]
    [SerializeField] private int levelUnlockTool_ComparisonPanel;
    public int costToUnlock_ComparisonPanel;
    [SerializeField] private int experienceUnlock_ComparisonPanel;
    public int maxLevelUnlock_ComparisonPanel;
    public GameObject CompareMultipleStocksButtonGO;
   
    public List<SkillsPlayer> skillsPlayersList;
    public List<GameObject> buttonsSkills;
  
    //public GameObject companyThreeButton;
    //public GameObject companyFourButton;


    public actionPointsManager ActionPointsManager;
    public Text pointsInvestedAndLeftToUnlockText;

    public pointsLeftToUnlock PointsLeftToUnlock;
    public chooseSkillInSkillTree ChooseSkillInSkill;

    private void Start()
    {
        maxLevelUnlockNewCompany = StocksPlayerKnow.getUnknownCompianesLeft();
        //Debug.Log("Antal st�der: " + cityManager.avaibleCities.Count);
        maxLevelUnlockNewCity = cityManager.avaibleCities.Count - cityManager.getActiveCity()-1;

        if (buttonsSkills.Count != 0)
        {
            //Debug.Log("ButtonsSkill");
            buttonsSkills[0].GetComponentInChildren<Text>().text = skillsPlayersList[0].GetComponent<SkillsPlayer>().getDescription();
        }
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

    public void addExperienceUnlockNewCity()
    {
        //Finns det po�ng kvar att anv�nda
        if (ActionPointsManager.remainingAP > 0)
        {
            //�r max level uppn�d
            if (levelUnlockNewCity < maxLevelUnlockNewCity)
            {

                experienceUnlockNewCity++;
                ActionPointsManager.actionPointSub(1);

                //G�r spelaren upp en level?
                if (experienceUnlockNewCity == costToUnlockNewCity)
                {
                    levelUp_UnlockNewCity();
                }
            }
            PointsLeftToUnlock.unlockNewCity();
            ChooseSkillInSkill.unlockNewCity();
            //Debug.Log("XP city: " + experienceUnlockNewCity);
        }
    }

    public void levelUp_UnlockNewCity()
    {
        levelUnlockNewCity++; // �kar lvl
        cityManager.activateNextCity();

        //Nollst�ller experince d� det �r samma po�ng som kr�vs oavsett nuvarande level
        experienceUnlockNewCity = 0;
        //activateButtonForNewCompany();
    }

    public void addExperienceUnlockTool_ComparisonPanel(int expPoints)
    {
        //Finns det po�ng kvar att anv�nda
        if (ActionPointsManager.remainingAP > 0)
        {
            //�r max level uppn�d
            //if (levelUnlockTool_ComparisonPanel < maxLevelUnlock_ComparisonPanel)
            if (skillsPlayersList[0].GetComponent<SkillsPlayer>().getCurrentLevel() < skillsPlayersList[0].GetComponent<SkillsPlayer>().maxLevel)
            {

                //experienceUnlock_ComparisonPanel++;
                int newExperience = skillsPlayersList[0].GetComponent<SkillsPlayer>().setCurrentExperience(expPoints);
                ActionPointsManager.actionPointSub(1);

                //G�r spelaren upp en level?
                //if (experienceUnlock_ComparisonPanel == costToUnlock_ComparisonPanel)
                if(newExperience == skillsPlayersList[0].GetComponent<SkillsPlayer>().costToUnlockNextLvl[skillsPlayersList[0].GetComponent<SkillsPlayer>().getCurrentLevel()])
                {
                    // �kar lvl
                    //levelUnlockTool_ComparisonPanel++; 
                    skillsPlayersList[0].GetComponent<SkillsPlayer>().setCurrentLevel_AddOne();

                    //GENOMF�R VAD SOM H�NDER VID LVLUPP
                    CompareMultipleStocksButtonGO.SetActive(true);
                    //buttonsSkills[0].SetActive(true);

                    //Nollst�ller experince d� det �r samma po�ng som kr�vs oavsett nuvarande level
                    //experienceUnlock_ComparisonPanel = 0;
                    skillsPlayersList[0].GetComponent<SkillsPlayer>().setCurrentExperienceToZero();
                    //activateButtonForNewCompany();
                }
            }
            PointsLeftToUnlock.unlockSkill(skillsPlayersList[0]);
            ChooseSkillInSkill.unlockTool_ComparisonPanel();
            //Debug.Log("XP city: " + experienceUnlockNewCity);
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

    public int getLevelUnlockNewCity()
    {
        return levelUnlockNewCity;
    }

    public int getExperienceUnlockNewCity()
    {
        return experienceUnlockNewCity;
    }
}

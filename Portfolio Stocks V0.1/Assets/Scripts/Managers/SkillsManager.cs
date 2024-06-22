using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsManager : MonoBehaviour
{
    [SerializeField] int activeSkill;
    [Header("Skills Avalible")]
    [SerializeField] bool MoreActionPoints_Available;
    [SerializeField] bool Tools_ComparisonPanel_Available;
    [SerializeField] bool Events_AffectEarningsSectorOrCompany_Available;

    //Hanterar vilka skills splaren kan utveckla
    [Header("More Points to Invest")]
    /*public int timePointsLvlNow;
    public List <int> costToUnlockMorePoints;
    public int pointsInvestedNowMoreActionPoints;
    public List <int> addedPointsWhenUnlocked;
     */
    public GameObject moreActionPointsButton;
   

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

    [Header("Events")]
    [SerializeField] Text sectorOrCompanyText;
    [SerializeField] Text posOrNegativeText;

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

        skillsActiveDuringGamePlay();
    }

    //Start om "Events" �r aktiverade och GameMode �r p�
    public void eventsGameModeOn()
    {
        sectorOrCompanyText.text = "???";
        posOrNegativeText.text = "???";
    }

    //Vilka Skills ska spelaren ha tillg�ng till under spelet
    public void skillsActiveDuringGamePlay()
    {
       
        if(MoreActionPoints_Available == true)
        {
            moreActionPointsButton.SetActive(true);
        }
        else
        {
            moreActionPointsButton.SetActive(false);
        }

        if (Tools_ComparisonPanel_Available == true)
        {
            buttonsSkills[0].SetActive(true);
        }
        else
        {
            buttonsSkills[0].SetActive(false);
        }

        if (Events_AffectEarningsSectorOrCompany_Available == true)
        {
            buttonsSkills[1].SetActive(true);
            buttonsSkills[2].SetActive(true);
        }
        else
        {
            buttonsSkills[1].SetActive(false);
            buttonsSkills[2].SetActive(false);
        }


            
    }

    public void setActiveSkill(int index)
    {
        activeSkill = index;
    }

    //Har en lista med Skills d�r input best�mmer vilken som ska g�lla. D�rmed slipper jag skapa en knapp f�r varje skill
    public void addExperienceGeneralSkill()
    {
        Debug.Log("Active skill: " + activeSkill);
        if (activeSkill == 0)
        {
            addExperienceActionPointsIncrease(1);
        }

        if (activeSkill == 1)
        {
            addExperienceUnlockTool_ComparisonPanel(1);
        }

        else if (activeSkill == 2)
        {
            addExperienceUnlockEvents_SectorOrCompany(1);
        }

        else if (activeSkill == 3)
        {
            addExperienceUnlockEvents_PosOrNeg(1);
        }
    }

    /*
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
    */

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
            //PointsLeftToUnlock.unlockNewCompany();
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
            //PointsLeftToUnlock.unlockNewCity();
            ChooseSkillInSkill.unlockNewCity();
            //Debug.Log("XP city: " + experienceUnlockNewCity);
        }
    }

    public void levelUp_UnlockNewCity()
    {

        //Kontrollera om alla st�der redan �r uppl�sta
        if (levelUnlockNewCity != maxLevelUnlockNewCity)
        {
            levelUnlockNewCity++; // �kar lvl
            cityManager.activateNextCity();

            //Nollst�ller experince d� det �r samma po�ng som kr�vs oavsett nuvarande level
            experienceUnlockNewCity = 0;
            //activateButtonForNewCompany();
        }

        else
        {
            Debug.Log("Alla st�der �r uppl�sta!");
        }
    }

    public void addExperienceActionPointsIncrease(int expPoints)
    {
        int index = 0;
        //Finns det po�ng kvar att anv�nda
        if (ActionPointsManager.remainingAP > 0)
        {
            //�r max level uppn�d
            //if (levelUnlockTool_ComparisonPanel < maxLevelUnlock_ComparisonPanel)
            if (skillsPlayersList[index].GetComponent<SkillsPlayer>().getCurrentLevel() < skillsPlayersList[index].GetComponent<SkillsPlayer>().maxLevel)
            {

                //experienceUnlock_ComparisonPanel++;
                int newExperience = skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentExperience(expPoints);
                ActionPointsManager.actionPointSub(1);

                //G�r spelaren upp en level?
                //if (experienceUnlock_ComparisonPanel == costToUnlock_ComparisonPanel)
                if (newExperience == skillsPlayersList[index].GetComponent<SkillsPlayer>().costToUnlockNextLvl[skillsPlayersList[index].GetComponent<SkillsPlayer>().getCurrentLevel()])
                {
                    Debug.Log("Lvl up: More ActionPoints");
                    // �kar lvl
                    //levelUnlockTool_ComparisonPanel++; 
                    skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentLevel_AddOne();

                    //GENOMF�R VAD SOM H�NDER VID LVLUPP
                    ActionPointsManager.baseAP += skillsPlayersList[index].getPointsIncreaseLevelUp();

                    //Nollst�ller experince d� det �r samma po�ng som kr�vs oavsett nuvarande level
                    //experienceUnlock_ComparisonPanel = 0;
                    skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentExperienceToZero();
                    //activateButtonForNewCompany();
                }
            }
            PointsLeftToUnlock.unlockSkill(skillsPlayersList[index]);
            ChooseSkillInSkill.morePointsToInvestButton();
            //Debug.Log("XP city: " + experienceUnlockNewCity);
        }
    }

    public void addExperienceUnlockTool_ComparisonPanel(int expPoints)
    {
        int index = 1;
        //Finns det po�ng kvar att anv�nda
        if (ActionPointsManager.remainingAP > 0)
        {
            //�r max level uppn�d
            //if (levelUnlockTool_ComparisonPanel < maxLevelUnlock_ComparisonPanel)
            if (skillsPlayersList[index].GetComponent<SkillsPlayer>().getCurrentLevel() < skillsPlayersList[index].GetComponent<SkillsPlayer>().maxLevel)
            {

                //experienceUnlock_ComparisonPanel++;
                int newExperience = skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentExperience(expPoints);
                ActionPointsManager.actionPointSub(1);

                //G�r spelaren upp en level?
                //if (experienceUnlock_ComparisonPanel == costToUnlock_ComparisonPanel)
                if(newExperience == skillsPlayersList[index].GetComponent<SkillsPlayer>().costToUnlockNextLvl[skillsPlayersList[index].GetComponent<SkillsPlayer>().getCurrentLevel()])
                {
                    // �kar lvl
                    //levelUnlockTool_ComparisonPanel++; 
                    skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentLevel_AddOne();

                    //GENOMF�R VAD SOM H�NDER VID LVLUPP
                    CompareMultipleStocksButtonGO.SetActive(true);
                    //buttonsSkills[0].SetActive(true);

                    //Nollst�ller experince d� det �r samma po�ng som kr�vs oavsett nuvarande level
                    //experienceUnlock_ComparisonPanel = 0;
                    skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentExperienceToZero();
                    //activateButtonForNewCompany();
                }
            }
            PointsLeftToUnlock.unlockSkill(skillsPlayersList[index]);
            ChooseSkillInSkill.unlockTool_ComparisonPanel();
            //Debug.Log("XP city: " + experienceUnlockNewCity);
        }
    }

    public void addExperienceUnlockEvents_SectorOrCompany(int expPoints)
    {
        Debug.Log("Add Experience_SectorOrCompany");
        int index = 2; //UPPDATERAS VID NY SKILL
        //Finns det po�ng kvar att anv�nda. Beh�lls vid ny skill!
        if (ActionPointsManager.remainingAP > 0)
        {
            //�r max level uppn�d
            //if (levelUnlockTool_ComparisonPanel < maxLevelUnlock_ComparisonPanel). UPPDATERA INDEX VID NY SKILL
            if (skillsPlayersList[index].GetComponent<SkillsPlayer>().getCurrentLevel() < skillsPlayersList[index].GetComponent<SkillsPlayer>().maxLevel)
            {

                //experienceUnlock_ComparisonPanel++;
                int newExperience = skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentExperience(expPoints);
                ActionPointsManager.actionPointSub(1);

                //G�r spelaren upp en level?
                //if (experienceUnlock_ComparisonPanel == costToUnlock_ComparisonPanel)
                if (newExperience == skillsPlayersList[index].GetComponent<SkillsPlayer>().costToUnlockNextLvl[skillsPlayersList[index].GetComponent<SkillsPlayer>().getCurrentLevel()])
                {
                    // �kar lvl
                    //levelUnlockTool_ComparisonPanel++; 
                    skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentLevel_AddOne();

                    //GENOMF�R VAD SOM H�NDER VID LVLUPP
                    skillsPlayersList[index].actionLevelUp();

                    //Nollst�ller experince d� det �r samma po�ng som kr�vs oavsett nuvarande level
                    //experienceUnlock_ComparisonPanel = 0;
                    skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentExperienceToZero();
                    //activateButtonForNewCompany();
                }
            }
            PointsLeftToUnlock.unlockSkill(skillsPlayersList[index]);
            //ChooseSkillInSkill.unlockTool_ComparisonPanel();
            //Debug.Log("XP city: " + experienceUnlockNewCity);
        }
    }

    public void addExperienceUnlockEvents_PosOrNeg(int expPoints)
    {
        Debug.Log("Add Experience_PosOrNeg");
        int index = 3; //UPPDATERAS VID NY SKILL
        //Finns det po�ng kvar att anv�nda. Beh�lls vid ny skill!
        if (ActionPointsManager.remainingAP > 0)
        {
            //�r max level uppn�d
            //if (levelUnlockTool_ComparisonPanel < maxLevelUnlock_ComparisonPanel). UPPDATERA INDEX VID NY SKILL
            if (skillsPlayersList[index].GetComponent<SkillsPlayer>().getCurrentLevel() < skillsPlayersList[index].GetComponent<SkillsPlayer>().maxLevel)
            {

                //experienceUnlock_ComparisonPanel++;
                int newExperience = skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentExperience(expPoints);
                ActionPointsManager.actionPointSub(1);

                //G�r spelaren upp en level?
                //if (experienceUnlock_ComparisonPanel == costToUnlock_ComparisonPanel)
                if (newExperience == skillsPlayersList[index].GetComponent<SkillsPlayer>().costToUnlockNextLvl[skillsPlayersList[index].GetComponent<SkillsPlayer>().getCurrentLevel()])
                {
                    // �kar lvl
                    //levelUnlockTool_ComparisonPanel++; 
                    skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentLevel_AddOne();

                    //GENOMF�R VAD SOM H�NDER VID LVLUPP
                    skillsPlayersList[index].actionLevelUp();

                    //Nollst�ller experince d� det �r samma po�ng som kr�vs oavsett nuvarande level
                    //experienceUnlock_ComparisonPanel = 0;
                    skillsPlayersList[index].GetComponent<SkillsPlayer>().setCurrentExperienceToZero();
                    //activateButtonForNewCompany();
                }
            }
            PointsLeftToUnlock.unlockSkill(skillsPlayersList[index]);
            //ChooseSkillInSkill.unlockTool_ComparisonPanel();
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

    public void setSkillActive_Events_AffectEarningsSectorOrCompany(bool aktiv)
    {
        //Debug.Log("Activate Events Skills");
        if (aktiv == true)
        {
            Events_AffectEarningsSectorOrCompany_Available = true;
        }
        else
        {
            Events_AffectEarningsSectorOrCompany_Available = false;
        }

        //F�rs�krar mig om att de aktiveras oavsett i vilken ordning scripten k�rs
        skillsActiveDuringGamePlay();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsPlayer : MonoBehaviour
{
    //Prefab för olika förmågor

    [SerializeField] string descpritionText;
    [SerializeField] private int levelCurrentSkill;
    public List<int> costToUnlockNextLvl; //Antal experience som krävs för att gå upp en level
    [SerializeField] private int experienceCurrentSkill; //Underpoäng av "levelCurrentSkill"
    public int maxLevel;
    [SerializeField] GameObject activateWhenLvlUp;
    [SerializeField] int pointsIncreaseLvlUp;

    private void Start()
    {
        maxLevel = costToUnlockNextLvl.Count;
    }

    public void actionLevelUp()
    {
        activateWhenLvlUp.SetActive(true);
    }

    public int getPointsIncreaseLevelUp()
    {
        return pointsIncreaseLvlUp;
    }

    public string getDescription()
    {
        return descpritionText;
    }

    public int getCurrentLevel()
    {
        return levelCurrentSkill;
    }

    public int setCurrentLevel_AddOne()
    {
        levelCurrentSkill++;
        return levelCurrentSkill;
    }

    public int getCurrentExperience()
    {
        return experienceCurrentSkill;
    }

    public int setCurrentExperience(int addedXP)
    {
        return experienceCurrentSkill += addedXP;
    }

    public void setCurrentExperienceToZero()
    {
        experienceCurrentSkill = 0;
    }
}

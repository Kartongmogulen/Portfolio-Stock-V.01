using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    //Hanterar m�l som spelaren ska uppn� t.ex X kr i utdelning
    [SerializeField] List<float> dividendIncome;
    [SerializeField] int dividendIncomeLevel;
    public dividendRecieved DividendRecieved;
    public string dividendQuestCompletedText;
    public string dividendQuestCompletedText_Bonus;

    public GameObject completedQuest_Panel;
    public Text completedQuest_Text;
    public Text completedQuest_BonusText;

    public CityManager cityManager;
    public SkillsManager skillsManager;

    private void Start()
    {
        skillsManager = FindObjectOfType<SkillsManager>();
    }

    public void checkIfObjectiveIsCompleted()
    {
        dividendIncomeObjective();
    }

    public void dividendIncomeObjective()
    {
        //�r MAX-level uppn�dd
        if(dividendIncomeLevel == dividendIncome.Count)
        {
            return;
        }

        if (dividendIncome[dividendIncomeLevel] < DividendRecieved.divIncomeFromPortfolioNow())
        {
            
            Debug.Log("Dividend objetive completed!");
            int availibleCities =  cityManager.getNumberOfAvailbleCities();
            questCompleted_ShowUI(dividendQuestCompletedText);
            completedQuest_BonusText.text = dividendQuestCompletedText_Bonus + cityManager.nameCity[availibleCities];
            //cityManager.activateNextCity();
            skillsManager.levelUp_UnlockNewCity();

            if (dividendIncomeLevel < dividendIncome.Count)
            {
                dividendIncomeLevel++;
            }
        }
    }

    public void questCompleted_ShowUI(string descriptionQuset)
    {
        //1. Panel aktiveras
        completedQuest_Panel.SetActive(true);

        //2. Text med vad som uppn�tts
        completedQuest_Text.text = descriptionQuset;

        //3. Text med Bonus. FUNKTION F�R TYP AV UPPDRAG
        

        //4. Knapp f�r att inaktivera Panel
        //Annat script. OnOffGameobjectTool

    }

}
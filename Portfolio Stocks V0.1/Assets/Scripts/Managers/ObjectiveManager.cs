using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    //Hanterar mål som spelaren ska uppnå t.ex X kr i utdelning
    [SerializeField] List<float> dividendIncome;
    [SerializeField] int dividendIncomeLevel;
    public dividendRecieved DividendRecieved;
    public string dividendQuestCompletedText;
    public string dividendQuestCompletedText_Bonus;

    public GameObject completedQuest_Panel;
    public Text completedQuest_Text;
    public Text completedQuest_BonusText;

    public CityManager cityManager;

    private void Update()
    {
        InvokeRepeating("checkIfObjectiveIsCompleted",1.0f,1.0f);
    }

    public void checkIfObjectiveIsCompleted()
    {
        dividendIncomeObjective();
    }

    public void dividendIncomeObjective()
    {
        if (dividendIncome[dividendIncomeLevel] < DividendRecieved.divIncomeFromPortfolioNow())
        {
            
            Debug.Log("Dividend objetive completed!");
            int availibleCities =  cityManager.getNumberOfAvailbleCities();
            questCompleted_ShowUI(dividendQuestCompletedText);
            completedQuest_BonusText.text = dividendQuestCompletedText_Bonus + cityManager.nameCity[availibleCities];
            cityManager.activateNextCity();

            if (dividendIncomeLevel< dividendIncome.Count-1)
            {
                dividendIncomeLevel++;
            }
        }
    }

    public void questCompleted_ShowUI(string descriptionQuset)
    {
        //1. Panel aktiveras
        completedQuest_Panel.SetActive(true);

        //2. Text med vad som uppnåtts
        completedQuest_Text.text = descriptionQuset;

        //3. Text med Bonus. FUNKTION FÖR TYP AV UPPDRAG
        

        //4. Knapp för att inaktivera Panel
        //Annat script. OnOffGameobjectTool

    }

}

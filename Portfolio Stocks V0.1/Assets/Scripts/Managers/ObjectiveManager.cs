using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    //Hanterar mål som spelaren ska uppnå t.ex X kr i utdelning

    //Viss nivå av utdelning
    [Header("Dividends")]
    [SerializeField] List<float> dividendIncome;
    [SerializeField] int dividendIncomeLevel;
    public dividendRecieved DividendRecieved;
    public string dividendQuestCompletedText;
    public string dividendQuestCompletedText_Bonus;

    //Viss nivå av totalt kapital
    [Header("CapitalAmount")]
    [SerializeField] List<float> capitalAmountTimesStartingMoney;
    [SerializeField] int capitalAmountLevel;
    [SerializeField] float startingMoney; //Spar hur mycket pengar man har vi start
    public string capitalAmountQuestCompletedText;
    public string capitalAmountQuestCompletedText_Bonus;

    [Header("ReturnPortfolio")]
    [SerializeField] List<float> returnOnPortfolioMilestones;
    [SerializeField] int returnOnPortfolioPercentLevel;
    public string returnOnPortfolioQuestCompletedText;
    public string returnOnPortfolioQuestCompletedText_Bonus;

    public GameObject completedQuest_Panel;
    public Text completedQuest_Text;
    public Text completedQuest_BonusText;

    public CityManager cityManager;
    public SkillsManager skillsManager;
    public portfolioStock PortfolioStock;
    public List<Text> progessText;

    private void Start()
    {
        skillsManager = FindObjectOfType<SkillsManager>();
        PortfolioStock = FindObjectOfType<portfolioStock>();
        startingMoney = GetComponent<moneyManager>().moneyStart;
        updateProgessText();
    }

    public void checkIfObjectiveIsCompleted()
    {
        Debug.Log("Kolla om några mål uppnås");
        dividendIncomeObjective();
        checkCapitalGoalsFromStartingMoney();
        checkReturnOnPortfolio();
        updateProgessText();
    }

    public void dividendIncomeObjective()
    {
        //Är MAX-level uppnådd
        if(dividendIncomeLevel == dividendIncome.Count)
        {
            return;
        }

        if (dividendIncome[dividendIncomeLevel] < DividendRecieved.divIncomeFromPortfolioNow())
        {
            
            //Debug.Log("Dividend objetive completed!");
            int availibleCities =  cityManager.getNumberOfAvailbleCities();
            Debug.Log("Tillgängliga städer: " + availibleCities);

            //Kontrollera om alla städer redan är upplåsta
            if (availibleCities == cityManager.getCitiesMaxAvaible())
            {
                Debug.Log("Alla städer redan upplåsta!!!");
            }
            else
            {
                questCompleted_ShowUI(dividendQuestCompletedText);
                completedQuest_BonusText.text = dividendQuestCompletedText_Bonus + cityManager.nameCity[availibleCities];
                //cityManager.activateNextCity();
                skillsManager.levelUp_UnlockNewCity();
            }

            if (dividendIncomeLevel < dividendIncome.Count)
            {
                dividendIncomeLevel++;
            }
        }
    }

    public void checkCapitalGoalsFromStartingMoney()
    {
        //Debug.Log("Kollar om kapital är X ggr större än startkapital");
        //Är MAX-level uppnådd
        if (capitalAmountLevel == capitalAmountTimesStartingMoney.Count)
        {
            return;
        }

        //Spelarens kapital (Likvider + Aktieportfölj)
        float capitalPlayer = GetComponent<moneyManager>().moneyNow + PortfolioStock.totalValuePortfolio;
        //Debug.Log("Spelarens totala kapital: " + capitalPlayer);

        if ((startingMoney  + capitalAmountTimesStartingMoney[capitalAmountLevel] * startingMoney) < capitalPlayer)
        {
            int availibleCities = cityManager.getNumberOfAvailbleCities();
            questCompleted_ShowUI(capitalAmountQuestCompletedText);
            completedQuest_BonusText.text = capitalAmountQuestCompletedText_Bonus + cityManager.nameCity[availibleCities];
            skillsManager.levelUp_UnlockNewCity();

            if (capitalAmountLevel < capitalAmountTimesStartingMoney.Count)
            {
                capitalAmountLevel++;
            }
        }
    }

    public void checkReturnOnPortfolio()
    {
        //Debug.Log("Kollar avkastning i portföljen");
        //Är MAX-level uppnådd
        if (returnOnPortfolioPercentLevel == returnOnPortfolioMilestones.Count)
        {
            return;
        }

        if (returnOnPortfolioMilestones[returnOnPortfolioPercentLevel] < PortfolioStock.totalReturnPortfolioPercent)
        {
            //Debug.Log("Avkastningen på portfölj har nått en milstolpe");
            int availibleCities = cityManager.getNumberOfAvailbleCities();
            questCompleted_ShowUI(returnOnPortfolioQuestCompletedText);
            completedQuest_BonusText.text = returnOnPortfolioQuestCompletedText_Bonus + cityManager.nameCity[availibleCities];
            skillsManager.levelUp_UnlockNewCity();
            returnOnPortfolioPercentLevel++;
        }
    }

    public void updateProgessText()
    {
        progessText[0].text = "Dividend income lvl: " + dividendIncomeLevel +"/" + dividendIncome.Count;
        progessText[1].text = "Capital Amount lvl: " + capitalAmountLevel + "/" + capitalAmountTimesStartingMoney.Count;
        progessText[2].text = "Return Portfolio lvl: " + returnOnPortfolioPercentLevel + "/" + returnOnPortfolioMilestones.Count;
    }

    public void questCompleted_ShowUI(string descriptionQuset)
    {
        Debug.Log("Quest completed!");
        //1. Panel aktiveras
        completedQuest_Panel.SetActive(true);

        //2. Text med vad som uppnåtts
        completedQuest_Text.text = descriptionQuset;

        //3. Text med Bonus. FUNKTION FÖR TYP AV UPPDRAG
        

        //4. Knapp för att inaktivera Panel
        //Annat script. OnOffGameobjectTool

    }

    public float getDividendIncomeNeededToLvlUp()
    {
        if (dividendIncomeLevel < dividendIncome.Count)
            return dividendIncome[dividendIncomeLevel];
        else return 0; 
    }

    public float getCapitalNeededToLvlUp()
    {
        if (capitalAmountLevel < capitalAmountTimesStartingMoney.Count)
            return (capitalAmountTimesStartingMoney[capitalAmountLevel]*startingMoney + startingMoney);
        else return 0;
    }

    public float getReturnPortfolio()
    {
        if (returnOnPortfolioPercentLevel < returnOnPortfolioMilestones.Count)
            return (returnOnPortfolioMilestones[returnOnPortfolioPercentLevel]);
        else return 0;
    }

}

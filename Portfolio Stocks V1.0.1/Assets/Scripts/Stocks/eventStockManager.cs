using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStockManager : MonoBehaviour
{
    //[SerializeField] int frequency; //Hur ofta en händelse inträffar
    /*
    [SerializeField] enum frequency { None, OncePerYear, Quarterly, Monthly };
    [SerializeField] frequency Frequency;
    */
    public EventFrequencyManager eventFrequencyManager;

    [SerializeField] bool positiveEvent;
    [SerializeField] float epsGrowthChange;
    //[SerializeField] float epsChangeTempEventTEST;
    [SerializeField] int tempEffectDuration;

    [SerializeField] [Range(0,100)]int sectorEventProb; //Slh att det är sektorn som drabbas annars bolag
    [SerializeField] [Range(0, 100)] int permanentEffectProb; //Slh att påverkan är permanent annars temporär
    [SerializeField] bool permanentAffect;
    [SerializeField] List<bool> permanentEffectHistory;
    [SerializeField] List<bool> positiveEffectHistory;
    [SerializeField] bool sectorAffected;
    [SerializeField] int choosenCompanyIndex;
    [SerializeField] List<sectorNameEnum> sectorAffectedList;
    [SerializeField] List<string> companyAffectedList;

    //[SerializeField] int positiveProbability; // Sannolikheten för en positiv händelse (0 till 100)

    [SerializeField] economicClimate EconomicClimate;
    [SerializeField] stockMarketInventory StockMarketInventory;
    [SerializeField] createButton CreateButton;
    [SerializeField] GameObject EventPanel; //Sätts av och på då ny knapp skapas för att få in rätt data på knappen
    [SerializeField] GameObject alertPlayerWhenEventOccur;

    //---TEMPORÄRA EFFEKTER---
    [Header("Temporary Effects")]
    [Tooltip("List of active temporary effects affecting stocks.")]
    // Temporär lista för effekter
    [SerializeField] private List<TemporaryEffect> activeEffects = new List<TemporaryEffect>();
    // Ger åtkomst till aktiva effekter för inspektorn
    public List<TemporaryEffect> GetActiveEffects() => activeEffects;

    private void Start()
    {
        //doesEventOccur(1);//FÖR TEST!!!
    }

    public void doesEventOccur(int month)
    {
        //Debug.Log("Does Event Occur (Månad): " + month);
        if(eventFrequencyManager.ShouldEventOccur(month) == true )
        {
            //Debug.Log("Händelse inträffar 1 ggr per år i januari");
            //TA BORT KOMMENTARER EFTER TEST
            positiveOrNegativeEvent();
            permanentOrOneTimeEffect();
            sectorOrCompanyEvent();

            //TEST
            //positiveEvent = true;
            //whichCompanyIsAffected();

            //Skapa knapp samt panelen måste vara aktiv för att rätt data ska hamna på knappen
            EventPanel.SetActive(true);
            CreateButton.buttonSpawn();
            EventPanel.SetActive(false);
            alertPlayerWhenEventOccur.SetActive(true);
            

            if (permanentAffect == true)
            {
                applyPermanentEffect();
            }
            else
            {
                ApplyEffect();
            }

            Invoke("UpdateEffects", 0.1f);
            //resetValues();
        }
    }

    
    //Sker en positiv eller negativ händelse
    public void positiveOrNegativeEvent()
    {
       if (EconomicClimate.RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Expanssion)
        {
            Debug.Log("Positiv händelse!");
            positiveEvent = true;
        }

        if (EconomicClimate.RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Rececssion)
        {
            Debug.Log("Negativ händelse!");
            positiveEvent = false;
        }

        positiveEffectHistory.Add(positiveEvent);
    }

    //Är påverkan permanent eller endast temporär
    public void permanentOrOneTimeEffect()
    {
        int random = Random.Range(0, 100);
        if (random <= permanentEffectProb)
        {
            Debug.Log("Permanent effekt: " + random);
            permanentAffect = true;

        }
        else
        {
            Debug.Log("Temporär effekt: " + random);
            permanentAffect = false;
        }

        permanentEffectHistory.Add(permanentAffect);
    }


    public void sectorOrCompanyEvent()
    {
        int random = Random.Range(0, 100);
        if(random <= sectorEventProb)
        {
            //Debug.Log("Sektorn drabbas: " + random);
            whichSectorIsAffected();
            sectorAffected = true;
        }
        else
        {
            //Debug.Log("Bolag drabbas: " + random);
            whichCompanyIsAffected();
            sectorAffected = false;
        }

        
    }

    public void whichCompanyIsAffected()
    {
        int numberOfCompanies = StockMarketInventory.masterList.Count;
        choosenCompanyIndex = Random.Range(0, numberOfCompanies);
        //choosenCompanyIndex = 0; //TEST
        //Debug.Log("Antal bolag: " + numberOfCompanies);
        sectorAffectedList.Add(StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().SectorNameEnum);
        companyAffectedList.Add(StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().nameOfCompany);

        
        var companyToAffect = StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>();
        float epsAmountToChange = (epsGrowthChange / 100) * companyToAffect.EPSnow;
        Debug.Log("EPS påverkan: " + epsAmountToChange);

        if (positiveEvent == true)
        {
            companyToAffect.updateEPS(epsAmountToChange + companyToAffect.EPSnow);
        }
        else
        {
            companyToAffect.updateEPS(-(epsAmountToChange + companyToAffect.EPSnow));
        }
        
    }

    public void whichSectorIsAffected()
    {

        //Slumpar ett bolag och hämtar sektorn
        int numberOfCompanies = StockMarketInventory.masterList.Count;
        int choosenCompanyIndex = Random.Range(0, numberOfCompanies);
        //Debug.Log("Sektor som påverkas: " + StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().SectorNameEnum);
        sectorAffectedList.Add(StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().SectorNameEnum);
        companyAffectedList.Add("Sector");

        /*
        int numberOfSectors = 1; //Finns alltid minst en sektor

        Debug.Log("Antal bolag att gå igenom: " + StockMarketInventory.masterList.Count);
        for (int i = 1; i < StockMarketInventory.masterList.Count; i++)
        {
            Debug.Log(StockMarketInventory.masterList[i].GetComponent<stock>().nameOfCompany);
            if (StockMarketInventory.masterList[i-1].GetComponent<stock>().SectorNameEnum != StockMarketInventory.masterList[i].GetComponent<stock>().SectorNameEnum)

            {
                numberOfSectors++;
            }
        }
        Debug.Log("Antal sektorer: " + numberOfSectors);
        */

    }

   
    public void applyPermanentEffect()
    {
        //Sektor drabbas POSITIVT
        if (sectorAffected == true && positiveEvent == true)
        {
           
            //Går igenom lista med aktier
            for (int i = 0; i < StockMarketInventory.masterList.Count; i++)
            {
                //Debug.Log("Sektorn påverkas PERMANENT: " + i);
                //Om aktien ingår i sektorn som påverkas
                if (StockMarketInventory.masterList[i].GetComponent<stock>().SectorNameEnum == sectorAffectedList[sectorAffectedList.Count - 1])
                {
                    Debug.Log("Permanent påverkan på sektor med: " + epsGrowthChange + "% på EPS");
                    StockMarketInventory.masterList[i].GetComponent<stock>().adjustEPSGrowth(true, epsGrowthChange);
                }
            }
        }

        //Sektor drabbas NEGATIVT
        else if (sectorAffected == true && positiveEvent == false)
        {

            //Går igenom lista med aktier
            for (int i = 0; i < StockMarketInventory.masterList.Count; i++)
            {
                //Debug.Log("Sektorn påverkas PERMANENT: " + i);
                //Om aktien ingår i sektorn som påverkas
                if (StockMarketInventory.masterList[i].GetComponent<stock>().SectorNameEnum == sectorAffectedList[sectorAffectedList.Count - 1])
                {
                    StockMarketInventory.masterList[i].GetComponent<stock>().adjustEPSGrowth(false, -epsGrowthChange);
                }
            }
        }
        //Enskild bolag påverkas
        else
        {
            if (positiveEvent == true)
            {
                StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().adjustEPSGrowth(true, epsGrowthChange);
            }
            else
            {
                StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().adjustEPSGrowth(false, -epsGrowthChange);
            }
        }
    }

    public void resetValues()
    {
        permanentAffect = false;
        sectorAffected = false;
    }

    //TEMPORÄR EFFEKT
    public void ApplyEffect()
    {
        var companyToAffect = StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>();
        Debug.Log("Bolag som påverkas: " + companyToAffect.nameOfCompany);
        activeEffects.Add(new TemporaryEffect(companyToAffect, epsGrowthChange, positiveEvent, tempEffectDuration));

        float valueToEffectEPS = (epsGrowthChange / 100) * companyToAffect.EPSnow;
        Debug.Log("Inför temporär effekt på EPS med: " + valueToEffectEPS);
        companyToAffect.updateEPS(positiveEvent ? valueToEffectEPS + companyToAffect.EPSnow : -valueToEffectEPS + companyToAffect.EPSnow);


    }

    public void UpdateEffects()
    {
        //Debug.Log("Update Effects");
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {

            if (activeEffects[i].Tick())
            {
                activeEffects.RemoveAt(i); // Ta bort effekten om den har gått ut
            }
        }

    }

    //HÄMTA/SKICKA DATA
    public sectorNameEnum getSectorAffected(int index)
    {
        return sectorAffectedList[index];
    }

    public string getCompanyAffected(int index)
    {
        return companyAffectedList[index];
    }

    public string getPositiveOrNegativeAffect(int index)
    {
        if (positiveEffectHistory[index] == true)
            return "Positive";
        else
        {
            return "Negative";
        }
    }


}

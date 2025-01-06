using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStockManager : MonoBehaviour
{
    //[SerializeField] int frequency; //Hur ofta en h�ndelse intr�ffar
    /*
    [SerializeField] enum frequency { None, OncePerYear, Quarterly, Monthly };
    [SerializeField] frequency Frequency;
    */
    public EventFrequencyManager eventFrequencyManager;

    [SerializeField] bool positiveEvent;
    [SerializeField] float epsGrowthChange;
    //[SerializeField] float epsChangeTempEventTEST;
    [SerializeField] int tempEffectDuration;

    [SerializeField] [Range(0,100)]int sectorEventProb; //Slh att det �r sektorn som drabbas annars bolag
    [SerializeField] [Range(0, 100)] int permanentEffectProb; //Slh att p�verkan �r permanent annars tempor�r
    [SerializeField] bool permanentAffect;
    [SerializeField] List<bool> permanentEffectHistory;
    [SerializeField] List<bool> positiveEffectHistory;
    [SerializeField] bool sectorAffected;
    [SerializeField] int choosenCompanyIndex;
    [SerializeField] List<sectorNameEnum> sectorAffectedList;
    [SerializeField] List<string> companyAffectedList;

    //[SerializeField] int positiveProbability; // Sannolikheten f�r en positiv h�ndelse (0 till 100)

    [SerializeField] economicClimate EconomicClimate;
    [SerializeField] stockMarketInventory StockMarketInventory;
    [SerializeField] createButton CreateButton;
    [SerializeField] GameObject EventPanel; //S�tts av och p� d� ny knapp skapas f�r att f� in r�tt data p� knappen
    [SerializeField] GameObject alertPlayerWhenEventOccur;

    //---TEMPOR�RA EFFEKTER---
    [Header("Temporary Effects")]
    [Tooltip("List of active temporary effects affecting stocks.")]
    // Tempor�r lista f�r effekter
    [SerializeField] private List<TemporaryEffect> activeEffects = new List<TemporaryEffect>();
    // Ger �tkomst till aktiva effekter f�r inspektorn
    public List<TemporaryEffect> GetActiveEffects() => activeEffects;

    private void Start()
    {
        //doesEventOccur(1);//F�R TEST!!!
    }

    public void doesEventOccur(int month)
    {
        //Debug.Log("Does Event Occur (M�nad): " + month);
        if(eventFrequencyManager.ShouldEventOccur(month) == true )
        {
            //Debug.Log("H�ndelse intr�ffar 1 ggr per �r i januari");
            //TA BORT KOMMENTARER EFTER TEST
            positiveOrNegativeEvent();
            permanentOrOneTimeEffect();
            sectorOrCompanyEvent();

            //TEST
            //positiveEvent = true;
            //whichCompanyIsAffected();

            //Skapa knapp samt panelen m�ste vara aktiv f�r att r�tt data ska hamna p� knappen
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

    
    //Sker en positiv eller negativ h�ndelse
    public void positiveOrNegativeEvent()
    {
       if (EconomicClimate.RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Expanssion)
        {
            Debug.Log("Positiv h�ndelse!");
            positiveEvent = true;
        }

        if (EconomicClimate.RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Rececssion)
        {
            Debug.Log("Negativ h�ndelse!");
            positiveEvent = false;
        }

        positiveEffectHistory.Add(positiveEvent);
    }

    //�r p�verkan permanent eller endast tempor�r
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
            Debug.Log("Tempor�r effekt: " + random);
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
        Debug.Log("EPS p�verkan: " + epsAmountToChange);

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

        //Slumpar ett bolag och h�mtar sektorn
        int numberOfCompanies = StockMarketInventory.masterList.Count;
        int choosenCompanyIndex = Random.Range(0, numberOfCompanies);
        //Debug.Log("Sektor som p�verkas: " + StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().SectorNameEnum);
        sectorAffectedList.Add(StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().SectorNameEnum);
        companyAffectedList.Add("Sector");

        /*
        int numberOfSectors = 1; //Finns alltid minst en sektor

        Debug.Log("Antal bolag att g� igenom: " + StockMarketInventory.masterList.Count);
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
           
            //G�r igenom lista med aktier
            for (int i = 0; i < StockMarketInventory.masterList.Count; i++)
            {
                //Debug.Log("Sektorn p�verkas PERMANENT: " + i);
                //Om aktien ing�r i sektorn som p�verkas
                if (StockMarketInventory.masterList[i].GetComponent<stock>().SectorNameEnum == sectorAffectedList[sectorAffectedList.Count - 1])
                {
                    Debug.Log("Permanent p�verkan p� sektor med: " + epsGrowthChange + "% p� EPS");
                    StockMarketInventory.masterList[i].GetComponent<stock>().adjustEPSGrowth(true, epsGrowthChange);
                }
            }
        }

        //Sektor drabbas NEGATIVT
        else if (sectorAffected == true && positiveEvent == false)
        {

            //G�r igenom lista med aktier
            for (int i = 0; i < StockMarketInventory.masterList.Count; i++)
            {
                //Debug.Log("Sektorn p�verkas PERMANENT: " + i);
                //Om aktien ing�r i sektorn som p�verkas
                if (StockMarketInventory.masterList[i].GetComponent<stock>().SectorNameEnum == sectorAffectedList[sectorAffectedList.Count - 1])
                {
                    StockMarketInventory.masterList[i].GetComponent<stock>().adjustEPSGrowth(false, -epsGrowthChange);
                }
            }
        }
        //Enskild bolag p�verkas
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

    //TEMPOR�R EFFEKT
    public void ApplyEffect()
    {
        var companyToAffect = StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>();
        Debug.Log("Bolag som p�verkas: " + companyToAffect.nameOfCompany);
        activeEffects.Add(new TemporaryEffect(companyToAffect, epsGrowthChange, positiveEvent, tempEffectDuration));

        float valueToEffectEPS = (epsGrowthChange / 100) * companyToAffect.EPSnow;
        Debug.Log("Inf�r tempor�r effekt p� EPS med: " + valueToEffectEPS);
        companyToAffect.updateEPS(positiveEvent ? valueToEffectEPS + companyToAffect.EPSnow : -valueToEffectEPS + companyToAffect.EPSnow);


    }

    public void UpdateEffects()
    {
        //Debug.Log("Update Effects");
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {

            if (activeEffects[i].Tick())
            {
                activeEffects.RemoveAt(i); // Ta bort effekten om den har g�tt ut
            }
        }

    }

    //H�MTA/SKICKA DATA
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

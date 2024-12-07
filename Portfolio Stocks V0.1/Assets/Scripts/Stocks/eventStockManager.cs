using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventStockManager : MonoBehaviour
{
    //[SerializeField] int frequency; //Hur ofta en h�ndelse intr�ffar
    [SerializeField] enum frequency { None, OncePerYear, Quarterly, Monthly };
    [SerializeField] frequency Frequency;

    [SerializeField] bool positiveEvent;
    [SerializeField] float epsGrowthChange;

    [SerializeField] int sectorEventProb; //Slh att det �r sektorn som drabbas annars bolag
    [SerializeField] int permanentEffectProb; //Slh att p�verkan �r permanent annars tempor�r
    [SerializeField] bool permanentAffect;
    [SerializeField] List<bool> permanentAffectHistory;
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
        if (permanentAffectHistory[index] == true)
        return "Positive";
        else
        {
            return "Negative";
        }
    }

    public void doesEventOccur(int month)
    {
        //Debug.Log("Does Event Occur (M�nad): " + month);
        if(Frequency == frequency.OncePerYear && month == 1 )
        {
            //Debug.Log("H�ndelse intr�ffar 1 ggr per �r i januari");
            positiveOrNegativeEvent();
            permanentOrOneTimeEffect();
            sectorOrCompanyEvent();

            //Skapa knapp samt panelen m�ste vara aktiv f�r att r�tt data ska hamna p� knappen
            EventPanel.SetActive(true);
            CreateButton.buttonSpawn();
            EventPanel.SetActive(false);
            alertPlayerWhenEventOccur.SetActive(true);

            if (permanentAffect == true)
        {
            applyPermanentEffect();
        }

        //resetValues();
        }
    }

    //Sker en positiv eller negativ h�ndelse
    public void positiveOrNegativeEvent()
    {
       if (EconomicClimate.RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Expanssion)
        {
            //Debug.Log("Positiv h�ndelse!");
            positiveEvent = true;
        }

        if (EconomicClimate.RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Rececssion)
        {
            //Debug.Log("Negativ h�ndelse!");
            positiveEvent = false;
        }

        permanentAffectHistory.Add(positiveEvent);
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
        //Debug.Log("Antal bolag: " + numberOfCompanies);
        sectorAffectedList.Add(StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().SectorNameEnum);
        companyAffectedList.Add(StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().nameOfCompany);
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

    //�r p�verkan permanent eller endast tempor�r
    public void permanentOrOneTimeEffect()
    {
        int random = Random.Range(0, 100);
        if (random <= permanentEffectProb)
        {
            //Debug.Log("Permanent effekt: " + random);
            permanentAffect = true;

        }
        else
        {
            //Debug.Log("Tempor�r effekt: " + random);
            permanentAffect = false;
        }
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

    
}

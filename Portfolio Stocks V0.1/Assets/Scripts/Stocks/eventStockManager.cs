using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventStockManager : MonoBehaviour
{
    //[SerializeField] int frequency; //Hur ofta en h�ndelse intr�ffar
    [SerializeField] enum frequency { None, OncePerYear, Quarterly, Montlhy };
    [SerializeField] frequency Frequency;

    [SerializeField] bool positiveEvent;
    [SerializeField] float epsGrowthChange;

    [SerializeField] int sectorEventProb; //Slh att det �r sektorn som drabbas annars bolag
    [SerializeField] int permanentEffectProb; //Slh att p�verkan �r permanent annars tempor�r
    [SerializeField] bool permanentAffect;
    [SerializeField] bool sectorAffected;
    [SerializeField] List<sectorNameEnum> sectorAffectedList;

    //[SerializeField] int positiveProbability; // Sannolikheten f�r en positiv h�ndelse (0 till 100)

    [SerializeField] economicClimate EconomicClimate;
    [SerializeField] stockMarketInventory StockMarketInventory;
  

    public void doesEventOccur(int month)
    {
        //Debug.Log("M�nad: " + month);
        if(Frequency == frequency.OncePerYear && month == 1 )
        {
            //Debug.Log("H�ndelse intr�ffar 1 ggr per �r i januari");
            positiveOrNegativeEvent();
            permanentOrOneTimeEffect();
            sectorOrCompanyEvent();

        if (permanentAffect == true)
        {
            applyPermanentEffect();
        }

        resetValues();
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

        
    }

    public void sectorOrCompanyEvent()
    {
        int random = Random.Range(0, 100);
        if(random <= sectorEventProb)
        {
            Debug.Log("Sektorn drabbas: " + random);
            whichSectorIsAffected();
            sectorAffected = true;
        }
        else
        {
            Debug.Log("Bolag drabbas: " + random);
            whichCompanyIsAffected();
            sectorAffected = false;
        }

        
    }

    public void whichCompanyIsAffected()
    {
        int numberOfCompanies = StockMarketInventory.masterList.Count;
        Debug.Log("Antal bolag: " + numberOfCompanies);
    }

    public void whichSectorIsAffected()
    {

        //Slumpar ett bolag och h�mtar sektorn
        int numberOfCompanies = StockMarketInventory.masterList.Count;
        int choosenCompanyIndex = Random.Range(0, numberOfCompanies);
        Debug.Log("Sektor som p�verkas: " + StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().SectorNameEnum);
        sectorAffectedList.Add(StockMarketInventory.masterList[choosenCompanyIndex].GetComponent<stock>().SectorNameEnum);

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
            Debug.Log("Permanent effekt: " + random);
            permanentAffect = true;

        }
        else
        {
            Debug.Log("Tempor�r effekt: " + random);
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
                Debug.Log("Sektorn p�verkas PERMANENT: " + i);
                //Om aktien ing�r i sektorn som p�verkas
                if (StockMarketInventory.masterList[i].GetComponent<stock>().SectorNameEnum == sectorAffectedList[sectorAffectedList.Count - 1])
                {
                    StockMarketInventory.masterList[i].GetComponent<stock>().adjustEPSGrowth(true, epsGrowthChange);
                }
            }
        }

        //Sektor drabbas NEGATIVT
        if (sectorAffected == true && positiveEvent == false)
        {

            //G�r igenom lista med aktier
            for (int i = 0; i < StockMarketInventory.masterList.Count; i++)
            {
                Debug.Log("Sektorn p�verkas PERMANENT: " + i);
                //Om aktien ing�r i sektorn som p�verkas
                if (StockMarketInventory.masterList[i].GetComponent<stock>().SectorNameEnum == sectorAffectedList[sectorAffectedList.Count - 1])
                {
                    StockMarketInventory.masterList[i].GetComponent<stock>().adjustEPSGrowth(false, -epsGrowthChange);
                }
            }
        }
        //Enskild bolag p�verkas
    }

    public void resetValues()
    {
        permanentAffect = false;
        sectorAffected = false;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchFish : MonoBehaviour
{
    public fishManager FishManager;
    public fishzone Fishzone;
    public boatStatManager BoatStatManager;
    public fishingRodManager FishingRodManager;

    [SerializeField] List<fisherCompanyStats> FisherCompanyStats;

    [SerializeField] List<int> employeesPerZone;
    [SerializeField] List<int> fishingRods_WhichZoneToUseThem_levelOne;
    [SerializeField] List<int> caughtFishPerZone;
    [SerializeField] List<int> caughtFishBySpecies;

    [SerializeField] List<int> caughtFishPerZone_FishOne;
    [SerializeField] List<int> caughtFishPerZone_FishTwo;

    [SerializeField] int totalFishProb; //Totala "sannolikhets"po�ng f�r alla fiskar i zonen. Anv�nds f�r att sedan ber�kna vilken fisk som f�ngas

    private void Start()
    {
        FishManager = FindObjectOfType<fishManager>();
        Fishzone = FindObjectOfType<fishzone>();
        BoatStatManager = FindObjectOfType<boatStatManager>();
        FishingRodManager = FindObjectOfType<fishingRodManager>();
    }

    public void fishingPerRoundAllCompanies()
    {
        for (int i = 0; i < FisherCompanyStats.Count; i++)
        {
            goFishingPerRound(FisherCompanyStats[i]);
        }
    }

    public void goFishingPerRound(fisherCompanyStats company)
    {
        //Var skickar bolaget sina anst�llda f�r att fiska
        employeesPerZone[1] = whereToFish(company);
        employeesPerZone[0] = company.getEmployees() - employeesPerZone[1];

        //Var anv�nds fiskesp�n
        whichZoneToUseFishingRods(company);

        //Hur m�nga fiskar per zon
        howManyFishGetCaughtPerZone(company, 0);
        howManyFishGetCaughtPerZone(company, 1);

        //Vilken fisk f�ngas
        resetValues();
        whichFishGetCaught(0, company);
        whichFishGetCaught(1, company);
        //whichFishGetCaught(0, 1, company);
        //whichFishGetCaught(0, 2, company);

        //whichFishGetCaught(1, company);
        //whichFishGetCaught(1, 1, company);
        //whichFishGetCaught(1, 2, company);

        //Data till f�retaget
        company.setCaughtFish(0, caughtFishBySpecies[0]);
        company.setCaughtFish(1, caughtFishBySpecies[1]);
        company.setCaughtFish(2, caughtFishBySpecies[2]);

    }

    public int whereToFish(fisherCompanyStats company)
    {
        //Antal som �ker ut till zon 2
        int employeesOnBoat = company.getBoatsAmount() * BoatStatManager.getBoatSize();
        return employeesOnBoat;
    }

    public void howManyFishGetCaughtPerZone(fisherCompanyStats company, int zone)
    {
        //Nollst�ller data
        caughtFishPerZone[zone] = 0;

        //Antal f�ngade fiskar per zon
        for (int i = 0; i < employeesPerZone[zone] - 1; i++)
        {
            int randomInt = Random.Range(0, 100);
            //Debug.Log("RandomInt: " + randomInt);
            if(randomInt< Fishzone.getProbFishZone(zone))
            {
                caughtFishPerZone[zone]++;
            }
        }

        //Debug.Log("F�ngade fiskar zone 1: " + caughtFishPerZone[0]);
    }

    //Vilken zon ska fiskep�n av olika level anv�ndas
    public void whichZoneToUseFishingRods(fisherCompanyStats company)
    {
        //L�gg att p� h�gsta zonen
        fishingRods_WhichZoneToUseThem_levelOne[1] = company.getFishingRodAmount(0);
    }

    public void whichFishGetCaught(int zone, fisherCompanyStats company)//, int fishingRodLevel)
    {
        //Debug.Log("F�ngade fiskar lvl 0: " + caughtFishBySpecies[0] + " i zon " + zone);
        //Debug.Log("Antal fiskar lvl 1: " + caughtFishBySpecies[1]);
        //normalizeWhichFishGetCaughtInZone(zone, 0);

        //Fiskesp�n anv�nds vid h�gst zon
       
        if (zone == Fishzone.getNumberOfZones() - 1)
        {
            //Debug.Log("Fiskezon: " + (Fishzone.getNumberOfZones() - 1));
            normalizeWhichFishGetCaughtInZone(zone, 1);

            Debug.Log("Gr�ns f�r att f�nga fisk lvl 0: " + FishManager.typeOfFish[0].getProbabiltyByZoneLevel(Fishzone.getNumberOfZones() - 1));
            Debug.Log("Gr�ns f�r att f�nga fisk lvl 1: " + (FishManager.typeOfFish[0].getProbabiltyByZoneLevel(Fishzone.getNumberOfZones() - 1) + FishManager.typeOfFish[1].getProbabiltyByZoneLevel(Fishzone.getNumberOfZones() - 1)));

            //Antal fiskar som f�ngats i zonen
            for (int i = 0; i < company.getFishingRodAmount(0); i++)
            {
                //Har alla fiskar i zonen blivit identifierade
                if (totalFishCaught() == caughtFishPerZone[zone])
                {
                    Debug.Log("Antalet fiskar f�ngade: " + caughtFishPerZone[zone]);
                    return;
                }

                else
                {
                    int randomInt = Random.Range(0, totalFishProb);
                    Debug.Log("RandomInt: " + randomInt);
                   
                    if (randomInt < FishManager.typeOfFish[0].getProbabiltyByZoneLevel(Fishzone.getNumberOfZones() - 1))
                    {
                        caughtFishBySpecies[0]++;
                        //Debug.Log("Fisk nr 0: " + caughtFishBySpecies[0]);
                    }
                    else if (randomInt < (FishManager.typeOfFish[0].getProbabiltyByZoneLevel(Fishzone.getNumberOfZones() - 1) + FishManager.typeOfFish[1].getProbabiltyByZoneLevel(Fishzone.getNumberOfZones() - 1)))
                    {
                        caughtFishBySpecies[1]++;
                        //Debug.Log("Fisk nr 1: " + caughtFishBySpecies[1]);
                    }

                    else
                    {
                        caughtFishBySpecies[2]++;
                        //Debug.Log("Fisk nr 2: " + caughtFishBySpecies[2]);
                    }
                }
                Debug.Log("Antal iterationer i fiskesp�-loop: " + i);
            }

            Debug.Log("Antal fiskar efter fiskesp�n: " + (caughtFishBySpecies[0] + caughtFishBySpecies[1] + caughtFishBySpecies[2]));

            //Debug.Log("Antal fiskar lvl 1: " + caughtFishBySpecies[1]);
            //
            if (totalFishCaught() < caughtFishPerZone[zone])
            {
                Debug.Log("Fler fiskar ska f�ngas!: " + (caughtFishPerZone[zone] - company.getFishingRodAmount(0)));

                for (int i = 0; i < (caughtFishPerZone[zone] - company.getFishingRodAmount(0)); i++)
                {
                    //Har alla fiskar i zonen blivit identifierade
                    if (totalFishCaught() == caughtFishPerZone[zone])
                    {
                        return;
                    }

                    else
                    {
                        int randomInt = Random.Range(0, totalFishProb);
                        //Debug.Log("RandomInt: " + randomInt);
                        if (randomInt < FishManager.typeOfFish[0].getProbabiltyByZoneLevel(Fishzone.getNumberOfZones() - 1))
                        {
                            caughtFishBySpecies[0]++;
                        }
                        else if (randomInt < FishManager.typeOfFish[0].getProbabiltyByZoneLevel(Fishzone.getNumberOfZones() - 1) + FishManager.typeOfFish[1].getProbabiltyByZoneLevel(Fishzone.getNumberOfZones() - 1))
                        {
                            caughtFishBySpecies[1]++;
                        }

                        else
                        {
                            caughtFishBySpecies[2]++;
                        }
                    }
                }
            }
            //Debug.Log("Antal fiskar lvl 1: " + caughtFishBySpecies[1]);
        }
       

        if (zone == 0)
        {
            //Debug.Log("Antal f�ngade inf�r zon 0: " + totalFishCaught());
            //Debug.Log("Zon 0");
            normalizeWhichFishGetCaughtInZone(zone, 0);

            for (int i = 0; i < caughtFishPerZone[zone]; i++)
            {
                //Har alla fiskar i zonen blivit identifierade
                if (totalFishCaught() == caughtFishPerZone[zone])
                {
                    return;
                }
                else
                {
                    int randomInt = Random.Range(0, totalFishProb);
                    //Debug.Log("Antal loopar: " + i);
                    if (randomInt < FishManager.typeOfFish[0].getProbabiltyByZoneLevel(zone))
                    {
                        caughtFishBySpecies[0]++;
                    }
                    else if (randomInt < FishManager.typeOfFish[0].getProbabiltyByZoneLevel(zone) + FishManager.typeOfFish[1].getProbabiltyByZoneLevel(zone))
                    {
                        caughtFishBySpecies[1]++;
                    }

                    else
                    {
                        caughtFishBySpecies[2]++;
                    }
                }
            }
        }
        //Debug.Log("Antal fiskar lvl 1: " + (caughtFishBySpecies[1]));
    }

    public int totalFishCaught()
    {
        int caughtSoFar = 0;

        for (int i = 0; i < caughtFishBySpecies.Count; i++)
        {
            caughtSoFar += caughtFishBySpecies[i];
        }

        //Debug.Log("Totalt f�ngade fiskar: " + caughtSoFar);
        return caughtSoFar;
    }

    public void normalizeWhichFishGetCaughtInZone(int zone, int fishRodLevel)
    {
        totalFishProb = 0;
        for (int i = 0; i < FishManager.typeOfFish.Count; i++)
        {
            if (fishRodLevel == 0)
            {
                totalFishProb += FishManager.typeOfFish[i].getProbabiltyByZoneLevel(zone);
                //Debug.Log("TotalFishProb: " + totalFishProb);
            }

            else if (fishRodLevel == 1)
            {
                totalFishProb += (FishManager.typeOfFish[i].getProbabiltyByZoneLevel(zone) + FishingRodManager.FishingRods[0].getProbChangeToCatchFishtype(i));
            }
        }
        //Debug.Log("TotalFishProb: " + totalFishProb);
    }

    public void resetValues()
    {
        for (int i = 0; i < caughtFishBySpecies.Count; i++)
        {
            caughtFishBySpecies[i] = 0;
        }
    }


}

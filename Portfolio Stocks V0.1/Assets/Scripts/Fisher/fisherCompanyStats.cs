using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fisherCompanyStats : MonoBehaviour
{
    [SerializeField] int employees;
    [SerializeField] int boats;
    [SerializeField] List<int> fishingRodAmount;

    [SerializeField] List<int> employeesPerZone;
    [SerializeField] List<int> caughtFishBySpecie;
    [SerializeField] List<int> caughtFishByZone;

    [SerializeField] sellFish SellFish;
    [SerializeField] boatStatManager BoatStatManager;
    [SerializeField] fishingRodManager FishingRodManager;
    public employeeStatManager EmployeeStatManager;
    [SerializeField] fishzone Fishzone;
    [SerializeField] fishManager FishManager;

    [SerializeField] int money;

    private void Awake()
    {
        SellFish = FindObjectOfType<sellFish>();
        BoatStatManager = FindObjectOfType<boatStatManager>();
        FishingRodManager = FindObjectOfType<fishingRodManager>();
        EmployeeStatManager = FindObjectOfType<employeeStatManager>();
        Fishzone = FindObjectOfType<fishzone>();
        FishManager = FindObjectOfType<fishManager>();

        //Skapar r�tt l�ngd p� listor
        for (int i = 0; i < Fishzone.getNumberOfZones(); i++) 
        {
            employeesPerZone.Add(0);
            caughtFishByZone.Add(0);


        }

        for (int i = 0; i < FishManager.typeOfFish.Count; i++)
        {
            caughtFishBySpecie.Add(0);
        }

    }

    public List<int> getEmployeesPerZone()
    {
        return employeesPerZone;
    }

    public void addCaughtFishByZone(int zone)
    {
        caughtFishByZone[zone]++;
    }

    public int getCaughtFishByZone(int zone)
    {
        return caughtFishByZone[zone];
    }

    public void addCaughtFishBySpecies(int ID)
    {
        caughtFishBySpecie[ID]++;
    }

    public void whereToFish()
    {
        int whereToFish = 0;
        int whereToFishWithBoat = 0;

        //Nollst�ller innan ny prioritet
        for (int i = 0; i < employeesPerZone.Count; i++)
        {
            employeesPerZone[i] = 0;
        }

        //Kontrollerar om f�retaget har n�gon b�t
        if (boats > 0)
        {
            whereToFishWithBoat = Random.Range(Fishzone.getNumberOfZones() - Fishzone.getNumberOfZonesThatNeedBoat(), Fishzone.getNumberOfZones());
            //Debug.Log("Zon att fiska som kr�ver b�t: " + whereToFish);

            //Antal anst�lla som tar b�t
            if (employees >= boats * BoatStatManager.getBoatSize())
            {
               int employeesOnBoats = boats * BoatStatManager.getBoatSize();
               Debug.Log("Anst�llda p� b�t: " + employeesOnBoats);
               employeesPerZone[whereToFishWithBoat] = employeesOnBoats;
            }

            if(boats * BoatStatManager.getBoatSize() >= employees)
            {
                int employeesOnBoats = employees;
                Debug.Log("Anst�llda p� b�t (Fler b�tplatser �n anst�llda): " + employeesOnBoats);
                employeesPerZone[whereToFishWithBoat] = employeesOnBoats;
            }
        }

        whereToFish = Random.Range(0, Fishzone.getNumberOfZones()-Fishzone.getNumberOfZonesThatNeedBoat());
        Debug.Log("Zon att fiska som INTE kr�ver b�t: " + whereToFish);
        employeesPerZone[whereToFish] = employees - employeesPerZone[whereToFishWithBoat];

    }

    public void employeesInvest(float amountToInvest)
    {
        Debug.Log("Pengar f�r nyanst�llningar: " + amountToInvest);
        int numberToHire = Mathf.RoundToInt(amountToInvest) / EmployeeStatManager.getPriceToHire();
        //Debug.Log("Antal anst�llda: " + numberToHire);
        employees += numberToHire;
    }

    public void buyBoat()
    {
        if (money >= BoatStatManager.getPrice())
        {
            boats++;
            money -= BoatStatManager.getPrice();
        }
    }

    public void buyBoatsAmount(float amountToInvest)
    {
        //Debug.Log("Antal investeringar i b�tar: " + amountToInvest);
        if (amountToInvest >= BoatStatManager.getPrice())
        {
            //Antal fiskep�n bolaget har r�d med
            int numberNewBoats = Mathf.RoundToInt(amountToInvest) / BoatStatManager.getPrice();
            //Debug.Log("Nya b�tar: " + numberNewBoats);
            boats += numberNewBoats;
        }
    }

    public void buyFishingRoad(int level)
    {
        if (money >= FishingRodManager.getPrice(level))
        {
            fishingRodAmount[level]++;
            money -= FishingRodManager.getPrice(level);
        }
    }

    public void buyFishingRodAmount (float amountToInvest, int level)
    {
        //Debug.Log("Antal investeringar i Fiskesp�n: " + amountToInvest);
        if (amountToInvest >= FishingRodManager.getPrice(level))
        {
            //Antal fiskep�n bolaget har r�d med
            int numberNewRods = Mathf.RoundToInt(amountToInvest) / FishingRodManager.getPrice(level);
            //Debug.Log("Nya sp�n: " + numberNewRods);
            fishingRodAmount[level] += numberNewRods;
        }
    }

    public int getEmployees()
    {
        return employees;
    }

    public int getBoatsAmount()
    {
        return boats;
    }

    public int getFishingRodAmount(int i)
    {
        return fishingRodAmount[i];
    }

    public void setCaughtFish(int fishID, int caughtAmount)
    {
        caughtFishBySpecie[fishID] += caughtAmount;
    }

    public void sellFishAll()
    {
        for (int i = 0; i < caughtFishBySpecie.Count; i++)
        {
            sellFishID(i);
        }
    }

    public void sellFishID(int fishID)
    {
        money += SellFish.sellFishForMoney(fishID, caughtFishBySpecie[fishID]);

        //Minskar antalet fiskar
        caughtFishBySpecie[fishID] -= caughtFishBySpecie[fishID];

    }

    public int getMoney()
    {
        return money;
    }

    public void resetMoney()
    {
        money = 0;
    }
}

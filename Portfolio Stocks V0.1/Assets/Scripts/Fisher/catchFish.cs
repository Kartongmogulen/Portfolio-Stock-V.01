using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchFish : MonoBehaviour
{
    public fishManager FishManager;
    public fishzone Fishzone;

    [SerializeField] float modifierCatchFish;

    private void Start()
    {
        FishManager = FindObjectOfType<fishManager>();
        Fishzone = FindObjectOfType<fishzone>();
    }

    public void howManyFishGetCaught(fisherCompanyStats company)
    {
        int caughtFish = 0;

        for (int i = 0; i < company.getEmployees(); i++)
        {
            int randomInt = Random.Range(0, 100);
                if(randomInt< FishManager.typeOfFish[0].GetComponent<fish_basic>().getProbabiltyByZoneLevel(0))
            {
                caughtFish++;
            }
        }

        Debug.Log("Fångade fiskar: " + caughtFish);
    }

    public void numberOfThrows(int number)
    {

    }

    public void simOneThrow(int fishzone)
    {
        //Får napp eller inte
        int catchFishInt = Random.Range(0, 100);
        
        if (catchFishInt < Fishzone.getProbFishZone(fishzone))
        {
            Debug.Log("DU FICK NAPP!");
        }
        else
        {
            Debug.Log("INGEN FISK NAPPADE");
        }

        /*//Total "sannolikhetspoäng"
        int totalProbForAllFish = 0;

        for (int i = 0; i < FishManager.typeOfFish.Count - 1; i++)
        {
            totalProbForAllFish += FishManager.typeOfFish[i].GetComponent<fish_basic>().getProbabiltyByZoneLevel(fishzone);
        }

        int totalCalculationPoints = Mathf.RoundToInt(totalProbForAllFish * modifierCatchFish);
        Debug.Log("TotalCalculationPoints: " + totalCalculationPoints);
        */

    }

}

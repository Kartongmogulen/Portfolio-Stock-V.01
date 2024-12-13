using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityManager : MonoBehaviour
{
    public List<bool> avaibleCities;

    public List<string> nameCity;
    public List<Text> nameCityText;
    public List<Button> chooseCity;
    public List<cityInfo> CityInfoList;
    [SerializeField] public int activeCity {get; private set; }

    public List<GameObject> stockPanelButtons;

    private void Start()
    {
        checkAvailbleCities();
        nameCityText[0].text = nameCity[0];

        giveIndex(CityInfoList);


    }

    public void checkAvailbleCities()
    {
        for (int i = 0; i < stockPanelButtons.Count; i++)
        {
            if (avaibleCities[i] == true)
            {
                stockPanelButtons[i].SetActive(true);
            }
            else
            {
                stockPanelButtons[i].SetActive(false);
            }
        }
    }

    public void giveIndex(List<cityInfo> listOfCities)
    {
       for (int i = 0; i < listOfCities.Count; i++)
        {
            listOfCities[i].cityIndex = i;
            //Debug.Log("Index: " + listOfCities[i].cityIndex);
        }

    }

    public void setActiveCity(int cityIndex)
    {
        activeCity = cityIndex;
    }

    /*
    public int getActiveCity()
    {
        return activeCity;
    }
    */

    public int getNumberOfAvailbleCities()
    {
        int availbleCitiesCount = 0;

        for (int i = 0; i < avaibleCities.Count-1; i++)
        {
            if (avaibleCities[i] == true)
            {
                availbleCitiesCount++;
            }
        }

        return availbleCitiesCount;
    }

    public void activateNextCity()
    {
        int availbleCitiesCount = getNumberOfAvailbleCities();
        avaibleCities[availbleCitiesCount] = true;
        checkAvailbleCities();
    }

    public int getCitiesMaxAvaible()
    {
        return CityInfoList.Count;
    }

}

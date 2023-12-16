using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityManager : MonoBehaviour
{
    public List<string> nameCity;
    public List<Text> nameCityText;
    public List<Button> chooseCity;
    public List<cityInfo> CityInfoList;
    [SerializeField] int activeCity;

    private void Start()
    {
        nameCityText[0].text = nameCity[0];

        giveIndex(CityInfoList);


    }

    public void giveIndex(List<cityInfo> listOfCities)
    {
       for (int i = 0; i < listOfCities.Count; i++)
        {
            listOfCities[i].cityIndex = i;
            Debug.Log("Index: " + listOfCities[i].cityIndex);
        }

    }

    public void setActiveCity(int cityIndex)
    {
        activeCity = cityIndex;
    }

    public int getActiveCity()
    {
        return activeCity;
    }

}

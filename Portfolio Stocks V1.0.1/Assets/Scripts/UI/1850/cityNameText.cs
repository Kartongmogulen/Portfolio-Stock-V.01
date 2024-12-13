using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cityNameText : MonoBehaviour
{
    public Text nameText;
    public CityManager cityManager;

    public void updateTextWithCityName()
    {
        nameText.text = "City name: " + cityManager.nameCity[cityManager.activeCity];
    }

    public void updateOnlyTextWithName()
    {
        nameText.text = "" + cityManager.nameCity[cityManager.activeCity];
    }

    public string getCityName(int i)
    {
        return cityManager.nameCity[i];
    }
}

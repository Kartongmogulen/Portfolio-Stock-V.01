using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouseOverUI_City_WorldMap : MonoBehaviour
{
    //public bool mouseOverObject;
    public GameObject cityInfoPanel;
    public CityManager cityManager;
    //public cityInfo CityInfo;
    //public Button Test;

    public Text cityNameText;

    private void Start()
    {
        //cityManager = GameObject.FindObjectOfType<CityManager>();
    }

    /*
    private void Update()
    {
        isMouseOverUI();
        if (mouseOverObject == true)
        {
            cityInfoPanel.SetActive(true);
            showUIInfo();
        }
        else
            cityInfoPanel.SetActive(false);

    }

    private bool isMouseOverUI()
    {
        

        if (EventSystem.current.IsPointerOverGameObject() == true)
        {
            mouseOverObject = true;
        }
        else
            mouseOverObject = false;

        return mouseOverObject;
    }
    */

    public void CityInfoPanelActive()
    {
        cityInfoPanel.SetActive(true);
    }

    public void CityInfoPanelInActive()
    {
        cityInfoPanel.SetActive(false);
    }

    public void showUIInfo(int index)
    {
        //int index = CityInfo.cityIndex;
        //Debug.Log(index);
        cityNameText.text = "Cityname: " + cityManager.nameCity[index];
    }
}

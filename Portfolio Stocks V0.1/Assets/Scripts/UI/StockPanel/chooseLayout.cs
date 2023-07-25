using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class chooseLayout : MonoBehaviour
{
    //Vilken layout som ska visas då man väljer aktier att köpa

    public Button individualStocksButton;
    public Button allStocksComparisonButton;

    public GameObject SectorPanelGO;
    public GameObject CompanySelectionPanelGO;
    public GameObject CompanyInfoPanelGO;
    public GameObject CompareStocksPanelGO;

    private void Start()
    {
        activeIndividualStockLayout();
    }
    public void inactiveAllOther()
    {
        inactiveIndividualStockLayout();
        inactiveAllStocksComparison();

        individualStocksButton.GetComponent<Image>().color = Color.white;
        allStocksComparisonButton.GetComponent<Image>().color = Color.white;
    }


    public void activeIndividualStockLayout()
    {
        inactiveAllOther();

        SectorPanelGO.SetActive(true);
        CompanySelectionPanelGO.SetActive(true);
        CompanyInfoPanelGO.SetActive(true);
        individualStocksButton.GetComponent<Image>().color = Color.green;
    }

    public void inactiveIndividualStockLayout()
    {
    SectorPanelGO.SetActive(false);
    CompanySelectionPanelGO.SetActive(false);
    CompanyInfoPanelGO.SetActive(false);
    }

    public void activeAllStocksComparison()
    {
        inactiveAllOther();

        CompareStocksPanelGO.SetActive(true);
        allStocksComparisonButton.GetComponent<Image>().color = Color.green;
    }

    public void inactiveAllStocksComparison()
    {
        CompareStocksPanelGO.SetActive(false);
    }
   
}

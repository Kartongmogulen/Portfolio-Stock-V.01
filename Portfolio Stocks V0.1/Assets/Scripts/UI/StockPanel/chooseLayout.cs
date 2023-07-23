using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseLayout : MonoBehaviour
{
    //Vilken layout som ska visas då man väljer aktier att köpa

    public GameObject SectorPanelGO;
    public GameObject CompanySelectionPanelGO;
    public GameObject CompanyInfoPanelGO;

    public void inactiveIndividualStockLayout()
    {
    SectorPanelGO.SetActive(false);
    CompanySelectionPanelGO.SetActive(false);
    CompanyInfoPanelGO.SetActive(false);
    }

    public void activeIndividualStockLayout()
    {
        SectorPanelGO.SetActive(true);
        CompanySelectionPanelGO.SetActive(true);
        CompanyInfoPanelGO.SetActive(true);
    }
}

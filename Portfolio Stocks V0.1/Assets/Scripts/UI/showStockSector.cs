using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showStockSector : MonoBehaviour
{
    //Panel Ett
    public Text nameHeadline;
    public Text utitiliesName;
    public Text technologyName;

    public Text sectorName1850_1;
    public Text sectorName1850_2;
    public Text sectorName1850_3;

    public void infoPanelOne()
    {
        nameHeadline.text = " Sector: ";
        utitiliesName.text = " Uti: ";
        technologyName.text = " Tech: ";

    }

    public void infoPanelOne_1850()
    {
        nameHeadline.text = " Sector: ";
        sectorName1850_1.text = " Mines: ";
        sectorName1850_2.text = " Railroad: ";
        sectorName1850_3.text = " Industri: ";
    }
}

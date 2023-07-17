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

    public void infoPanelOne()
    {
        nameHeadline.text = " Sector: ";
        utitiliesName.text = " Uti: ";
        technologyName.text = " Tech: ";

    }
}

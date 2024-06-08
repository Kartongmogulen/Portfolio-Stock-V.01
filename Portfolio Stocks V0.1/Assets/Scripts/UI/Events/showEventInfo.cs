using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showEventInfo : MonoBehaviour
{
    public eventStockManager EventStockManager;
    public Text sectorAffectedText;
    public Text companyAffectedText;
    public Text eventPosOrNegText;
    public int index;

    public void updateUI()
    {
        sectorAffectedText.text = "Sector affected: " + EventStockManager.getSectorAffected(index);
        companyAffectedText.text = "Company affected: " + EventStockManager.getCompanyAffected(index);
        eventPosOrNegText.text = "Event effect on EPS: " + EventStockManager.getPositiveOrNegativeAffect(index);
        Debug.Log("Index: " + index);
    }
    
}

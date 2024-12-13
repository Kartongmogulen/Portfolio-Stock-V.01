using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showEventInfo : MonoBehaviour
{
    public eventStockManager EventStockManager;
    [SerializeField] SkillsManager skillsManager;
    public Text sectorAffectedText;
    public Text companyAffectedText;
    public Text eventPosOrNegText;
    public int index;

    public void updateUI()
    {
        sectorAffectedText.text = "Sector affected: " + EventStockManager.getSectorAffected(index);

        Debug.Log("Level: " + skillsManager.skillsPlayersList[3].name + "   " + skillsManager.skillsPlayersList[3].getCurrentLevel());
        if (skillsManager.skillsPlayersList[3].getCurrentLevel() > 0)
        {
            companyAffectedText.text = "Company affected: " + EventStockManager.getCompanyAffected(index);
        }
        if (skillsManager.skillsPlayersList[4].getCurrentLevel() > 0)
        {
            eventPosOrNegText.text = "Event effect on EPS: " + EventStockManager.getPositiveOrNegativeAffect(index);
        }
        Debug.Log("Index: " + index);
    }
    
}

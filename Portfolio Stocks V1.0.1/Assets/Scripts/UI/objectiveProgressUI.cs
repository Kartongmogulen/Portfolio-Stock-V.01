using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectiveProgressUI : MonoBehaviour
{
    [SerializeField] List<Text> progressTextList;
    [SerializeField] int activeIndex;
    [SerializeField] ObjectiveManager objectiveManager;

    // Start is called before the first frame update
    void Start()
    {
        progressTextList[activeIndex].text = "Hej";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setActiveIndex(int index)
    {
        activeIndex = index;

        if(index == 0)
        {
            if (objectiveManager.getDividendIncomeNeededToLvlUp() != 0)
                progressTextList[0].text = "Dividend Income needed to lvl up: " + objectiveManager.getDividendIncomeNeededToLvlUp();
            else
                maxLevelReached();
        }

        if (index == 1)
        {
            if(objectiveManager.getCapitalNeededToLvlUp() != 0)
            progressTextList[0].text = "Total Capital needed to lvl up: " + objectiveManager.getCapitalNeededToLvlUp();
            else
                maxLevelReached();
        }

        if (index == 2)
        {
            if (objectiveManager.getReturnPortfolio() != 0)
              progressTextList[0].text = "Return on Portfolio needed to lvl up: " + objectiveManager.getReturnPortfolio()+"%";

            else
                maxLevelReached();
        }
    }

    public void maxLevelReached()
    {
        progressTextList[0].text = "MAX level reached!";
    }
}

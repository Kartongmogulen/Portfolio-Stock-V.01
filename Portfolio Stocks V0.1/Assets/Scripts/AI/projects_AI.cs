using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projects_AI : MonoBehaviour
{
    //Spelare som endast investerar i produktion

    [SerializeField] float moneyNow;
    [SerializeField] bool foodInvest;
   
    public moneyManager MoneyManager;
    public NeedsPeople needsPeopleManager;
    [SerializeField] projectsManager ProjectsManager;
    [SerializeField] projectsUI ProjectsUI;
    [SerializeField] endRoundButton EndRoundButton;

    private void Start()
    {
        moneyNow = MoneyManager.moneyStart;
        GetComponent<totalCash>().setMoneyNoTextUpdate(moneyNow);
    }

    public void buyProduction()
    {
        if (foodInvest == true)
        {
            //Väljer Food-projekt
            ProjectsUI.updateUIFromProject(ProjectsManager.getProject(0));

            //Adderar produktion om pengar finns
            while (GetComponent<totalCash>().moneyNow >= ProjectsManager.getProject(0).getPrice())
            //for(int i = 0; i < 5; i++)
            {
                GetComponent<productionPlayer>().addProduction();
            }
        }
    }

}

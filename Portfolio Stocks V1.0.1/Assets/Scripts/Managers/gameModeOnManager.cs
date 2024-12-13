using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameModeOnManager : MonoBehaviour
{
    //När spelet ska spelas "skarpt"

    public bool economicClimateEffectEPS; //Om aktiv påverkas EPS utifrån globalt ekonomiskt klimat

    public bool settlerOn;

    public bool startingYear_1850;

    public bool historicEventsOn;

    [SerializeField] bool eventsAffectingSectorsAndCompaniesOn;

    public GameObject stockPanelGO;
    public GameObject portfolioPlayerGO;
    public GameObject portfolioChooseCategoriPanelGO;
    public GameObject bondsPanelGO;

    public GameObject testButtonPanelGO;
    
    [Header("Settler")]
    public GameObject SettlerGO;
    public GameObject SettlerScriptsGO;
    public GameObject historicEventsGO;
    public GameObject imageStartGO;

    [Header("Scripts")]
    public SkillsManager skillsManager;

    private void Start()
    {
        inactivateGameObjectsAtStart();

        if (settlerOn == true)
        {
            settlerModeActive();
        }
        else
        {
            SettlerScriptsGO.SetActive(false);
        }

        if(historicEventsOn == true)
        {
            historicEventsActive();
        }

        //Events
        
        if (eventsAffectingSectorsAndCompaniesOn == true)
        {
            skillsManager.setSkillActive_Events_AffectEarningsSectorOrCompany(true);
            skillsManager.eventsGameModeOn();
        }
    }

    public void inactivateGameObjectsAtStart()
    {
        stockPanelGO.SetActive(false);

        if (portfolioPlayerGO != null)
        {
            portfolioPlayerGO.SetActive(false);
        }

        if (portfolioChooseCategoriPanelGO != null)
        {
            portfolioChooseCategoriPanelGO.SetActive(false);
        }

        if (bondsPanelGO != null)
        {
            bondsPanelGO.SetActive(false);
        }
        SettlerGO.SetActive(false);
        historicEventsGO.SetActive(false);
        testButtonPanelGO.SetActive(false);
        imageStartGO.SetActive(false);
    }

    public void settlerModeActive()
    {
        SettlerGO.SetActive(true);
        imageStartGO.SetActive(true);

    }

    public void historicEventsActive()
    {
        historicEventsGO.SetActive(true);
    }
}

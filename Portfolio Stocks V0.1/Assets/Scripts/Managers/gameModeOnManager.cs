using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameModeOnManager : MonoBehaviour
{
    //När spelet ska spelas "skarpt"

    public bool settlerOn;

    public bool startingYear_1850;

    public bool historicEventsOn;

    public GameObject stockPanelGO;
    public GameObject portfolioPlayerGO;
    public GameObject portfolioChooseCategoriPanelGO;
    public GameObject bondsPanelGO;

    public GameObject testButtonPanelGO;
    
    //Settler
    public GameObject SettlerGO;

    public GameObject historicEventsGO;

    private void Start()
    {
        inactivateGameObjectsAtStart();

        if (settlerOn == true)
        {
            settlerModeActive();
        }

        if(historicEventsOn == true)
        {
            historicEventsActive();
        }
    }

    public void inactivateGameObjectsAtStart()
    {
        stockPanelGO.SetActive(false);
        portfolioPlayerGO.SetActive(false);
        portfolioChooseCategoriPanelGO.SetActive(false);
        bondsPanelGO.SetActive(false);
        SettlerGO.SetActive(false);
        historicEventsGO.SetActive(false);
        testButtonPanelGO.SetActive(false);
    }

    public void settlerModeActive()
    {
        SettlerGO.SetActive(true);
    }

    public void historicEventsActive()
    {
        historicEventsGO.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameModeOnManager : MonoBehaviour
{
    //När spelet ska spelas "skarpt"

    public bool settlerOn;

    public bool startingYear_1850;

    public GameObject stockPanelGO;
    public GameObject portfolioPlayerGO;
    public GameObject portfolioChooseCategoriPanelGO;
    public GameObject bondsPanelGO;
    public GameObject SettlerGO;

    private void Start()
    {
        inactivateGameObjectsAtStart();

        if (settlerOn == true)
        {
            settlerModeActive();
        }
    }

    public void inactivateGameObjectsAtStart()
    {
        stockPanelGO.SetActive(false);
        portfolioPlayerGO.SetActive(false);
        portfolioChooseCategoriPanelGO.SetActive(false);
        bondsPanelGO.SetActive(false);
        SettlerGO.SetActive(false);
    }

    public void settlerModeActive()
    {
        SettlerGO.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameModeOnManager : MonoBehaviour
{
    //När spelet ska spelas "skarpt"

    public GameObject stockPanelGO;
    public GameObject portfolioPlayerGO;
    public GameObject portfolioChooseCategoriPanelGO;
    public GameObject bondsPanelGO;

    private void Start()
    {
        inactivateGameObjectsAtStart();
    }

    public void inactivateGameObjectsAtStart()
    {
        stockPanelGO.SetActive(false);
        portfolioPlayerGO.SetActive(false);
        portfolioChooseCategoriPanelGO.SetActive(false);
        bondsPanelGO.SetActive(false);
    }
}

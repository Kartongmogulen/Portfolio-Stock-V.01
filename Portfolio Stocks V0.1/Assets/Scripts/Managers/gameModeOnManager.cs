using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameModeOnManager : MonoBehaviour
{
    //När spelet ska spelas "skarpt"

    public GameObject stockPanelGO;

    private void Start()
    {
        inactivateGameObjectsAtStart();
    }

    public void inactivateGameObjectsAtStart()
    {
        stockPanelGO.SetActive(false);
    }
}

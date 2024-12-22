using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endGame : MonoBehaviour
{
    public GameObject gameEndPanelGO;

    public gamePlayScopeManager GamePlayScopeManager;
    public TMP_Text returnProjects;
    public TMP_Text returnPercentProjects;
    public PlayerManager playerManager;

    public void gameEnd()
    {
        gameEndPanelGO.SetActive(true);

        if (returnProjects != null)
        {
            returnProjects.text = "Return Capital: " + playerManager.returnTotal;
        }

        if (returnPercentProjects != null)
        {
            returnPercentProjects.text = "Return Capital: " + Mathf.Round(((playerManager.returnTotal + playerManager.depreciationTotal) / playerManager.investedCapitalTotal - 1) * 100) + "%";
        }
    }
}

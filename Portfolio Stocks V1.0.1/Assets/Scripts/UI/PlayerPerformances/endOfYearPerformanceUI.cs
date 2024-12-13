using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class endOfYearPerformanceUI : MonoBehaviour
{
    public GameObject endOfYearPanelGO;
    public GameObject PlayerScriptsGO;
    public Text returnTotalStocksText;

    public void activeEndOfYearPanel()
    {
        endOfYearPanelGO.SetActive(true);
        //Debug.Log(PlayerScriptsGO.GetComponent<portfolioStock>().returnPortfolioEachTurn[PlayerScriptsGO.GetComponent<portfolioStock>().returnPortfolioEachTurn.Count - 1]);
        returnTotalStocksText.text = "Total return, Stocks: " + Mathf.Round((PlayerScriptsGO.GetComponent<portfolioStock>().returnPortfolioEachTurn[PlayerScriptsGO.GetComponent<portfolioStock>().returnPortfolioEachTurn.Count-1])*100) + "%";
    }

    public void inactiveEndOfYearPanel()
    {
        endOfYearPanelGO.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialBoxText;
    [SerializeField] List<string> tutorialArrayTexts;
    [SerializeField] int indexTutorial;
    [SerializeField] int indexTutorialSimulering; //För att simulera fram x-antal steg. Ska vara 0 vid färdig produkt
    [SerializeField] List<GameObject> tutorialGOList;
    [SerializeField] List<int> indexActivateGO;
    [SerializeField] int indexGOList;
    [SerializeField] Button stocksButton;
    [SerializeField] GameObject stockPanel;

    [Header("Checkpoints")]
    [SerializeField] bool activateStockPanel;
    [SerializeField] bool dividendPolicyUnlock;


    public void Start()
    {
        syncTutorialWhenNotStartingFromBeginning();
        tutorialBoxText.text = tutorialArrayTexts[indexTutorial];
    }

    public void nextIndex()
    {
        if (indexTutorial < 15)
        {
            checkIfStockPanelActivated();
            indexTutorial++;
        }

        else if(activateStockPanel == true && indexTutorial < 19)
        {
            Debug.Log("StockPanelActive: " + indexTutorial);
            indexTutorial++;
           
        }    

        updateText();
        activateGO();
    }

    public void updateText()
    {
        tutorialBoxText.text = tutorialArrayTexts[indexTutorial];
    }

    public void activateGO()
    {
        foreach (int i in indexActivateGO)
        {
            //Debug.Log("i: " + i);
            if (i == indexTutorial)
            {
                tutorialGOList[indexGOList].SetActive(true);
                indexGOList++;
            }
        }
    }

    public void checkIfStockPanelActivated()
    {
        if (stockPanel.activeSelf == true)
        {
            indexTutorial++;
            activateStockPanel = true;
            stocksButton.interactable = false;//Inaktiverar för att ej kunna bläddra med Stocks-knappen
        }
    }

    public void checkIfDividendPolicyUnlocked()
    {
        if (stockPanel.activeSelf == true)
        {
            indexTutorial++;
        }
    }

    public void completeDividendPolicyUnlock()
    {

    }

    public void syncTutorialWhenNotStartingFromBeginning()
    {
        for(int i = 0; i < indexTutorialSimulering; i++)
        {
            Debug.Log("Iteration: " + i);
            nextIndex();
        }
    }

}

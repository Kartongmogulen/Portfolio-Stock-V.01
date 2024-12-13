using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialBoxText;
    [SerializeField] List<string> tutorialArrayTexts;
    [SerializeField] int indexTutorial;
    [SerializeField] int indexTutorialSimulering; //För att simulera fram x-antal steg. Ska vara 0 vid färdig produkt
    [SerializeField] List<GameObject> tutorialGOList;
    [SerializeField] List<int> indexActivateGO;
    [SerializeField] int indexGOList;
   
    [SerializeField] GameObject stockPanel;
   
    [SerializeField] List<bool> checkpointsCompletedList;
    [SerializeField] int completedCheckpointsInt;

    [Header("Checkpoints")]
    [SerializeField] bool activateStockPanel;
    [SerializeField] bool dividendPolicyUnlock;

    [Header("Buttons")]
    [SerializeField] Button nextButton;
    [SerializeField] Button stocksButton;
    [SerializeField] Button divPolicyButton;
    [SerializeField] Button skillTreeButton;

    public void Start()
    {
        syncTutorialWhenNotStartingFromBeginning(); //Går igenom stegen till det index man vill ha. Bra vid test
        tutorialBoxText.text = tutorialArrayTexts[indexTutorial];
    }

    public void nextIndex()
    {
        if (indexTutorial < 14)
        {
            checkIfStockPanelActivated();
            indexTutorial++;
            //activateGO();
        }

        else if(checkpointsCompletedList[0] == true && indexTutorial < 18)
        {
            indexTutorial++;
            Debug.Log("Checkpoint: 1 avklarad");
            //activateGO();

        }

        else if (checkpointsCompletedList[1] == true && indexTutorial < 25)
        {
            indexTutorial++;
            Debug.Log("Checkpoint: 2 avklarad");
            //checkIfDividendPolicyUnlocked();

        }

       

        if(checkpointsCompletedList[1] == true && indexTutorial == 22)
        {
            skillTreeTutorial();
            //indexTutorial++;
        }

        if(checkpointsCompletedList[1] == true && indexTutorial == 23)
        {
            eventsTutorial();
        }

        if (indexTutorial == tutorialArrayTexts.Count)
        {
            endOfTutorial();
        }

        else if (indexTutorial > tutorialArrayTexts.Count)
        {
            backToMainMeny();
        }

        updateText();
        activateGO();
        nextButtonStatus();
    }

    public void updateText()
    {
        tutorialBoxText.text = tutorialArrayTexts[indexTutorial];
    }

    //Styr status på NextButton
    public void nextButtonStatus()
    {
        
        if (indexTutorial == 14)
        {
            nextButton.interactable = false;
        }

        else
        {
            nextButton.interactable = true;
        }
    }

    public void completedCheckpoints()
    {
        checkpointsCompletedList[completedCheckpointsInt] = true;
        Debug.Log("Checkpoint Completed");

        indexTutorial++;
        updateText();

        checkIfStockPanelActivated();
        nextButtonStatus();

    }

    public void activateStockPanelInfoButtons()
    {
        
            //indexGOList++;
            tutorialGOList[5].SetActive(true);
            tutorialGOList[6].SetActive(true);
            tutorialGOList[7].SetActive(true);
            
        //Så korrekt index sätts
        //indexGOList = 8;

    }

    public void activateBuySellPanel()
    {
        tutorialGOList[5].SetActive(false);
        tutorialGOList[8].SetActive(true);
        tutorialGOList[9].SetActive(true);
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

            if(indexTutorial == indexActivateGO[5])
            {
                //Debug.Log("Aktivera aktiepanel med infoknappar");
                activateStockPanelInfoButtons();
            }

            if (indexTutorial == indexActivateGO[6])
            {
                activateBuySellPanel();
            }

        }
    }

    public void checkIfStockPanelActivated()
    {
        if (stockPanel.activeSelf == true)
        {
            //indexTutorial++;
            activateStockPanel = true;
            stocksButton.interactable = false;//Inaktiverar för att ej kunna bläddra med Stocks-knappen
        }
    }

    public void checkIfDividendPolicyUnlocked()
    {
        if (activateStockPanel == true)
        {
            if (dividendPolicyUnlock == false)
            {
                indexTutorial++;
            }

            dividendPolicyUnlock = true;
            divPolicyButton.interactable = false;
            
        }
    }

    public void completeDividendPolicyUnlock()
    {
        dividendPolicyUnlock = true;
        divPolicyButton.interactable = false;
        checkpointsCompletedList[1] = true;
        //indexTutorial++;
    }

    //Simulerar fram till annan punkt
    public void syncTutorialWhenNotStartingFromBeginning()
    {
        //Aktiverar handlingar som spelaren behöver genomföra
        if(indexTutorialSimulering > 13)
        {
            checkpointsCompletedList[0] = true;
        }

        if (indexTutorialSimulering > 17)
        {
            checkpointsCompletedList[1] = true;
        }

        for (int i = 0; i < indexTutorialSimulering; i++)
        {
            Debug.Log("Iteration: " + i);
            nextIndex();
        }
    }

    public void skillTreeTutorial()
    {
        Debug.Log("SkillTree Tutorial");

        stockPanel.SetActive(false);
        tutorialGOList[9].SetActive(false);

        //skillTreeButton.interactable(false);
        tutorialGOList[10].SetActive(true);
        tutorialGOList[11].SetActive(true);

    }

    public void eventsTutorial()
    {
        skillTreeButton.interactable = false;

        tutorialGOList[12].SetActive(true);
        tutorialGOList[11].GetComponent<Transform>().position += new Vector3(0, 65, 0);
    }

    public void endOfTutorial()
    {
        tutorialBoxText.text = "Now you are ready to enjoy the life of investing!";
        nextButton.GetComponentInChildren<Text>().text = "To main meny";
        indexTutorial++;
    }

    public void backToMainMeny()
    {
        Debug.Log("Back to Mainmeny");
        SceneManager.LoadScene(0);
    }

}

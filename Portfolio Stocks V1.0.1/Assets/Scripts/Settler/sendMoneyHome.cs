using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sendMoneyHome : MonoBehaviour
{
    [SerializeField] string introText;
    [SerializeField] string moneyNeededText;
    [SerializeField] string startSeendingMoneyText;
    [SerializeField] string sendMoneyText;
    [SerializeField] string effectOnFamilyNoMoneyText;
    [SerializeField] int moneyNeededPerYear;
    [SerializeField] int startSendingMoneyTimepoint;

    public Text textStartingLetter;
    public Text textOne;

    public GameObject infoPanel;
    public GameObject sendMoneyButton;
    //public totalCash TotalCash;
    public moneyManager MoneyManager;
    public familyStatusManager FamilyStatusManager;


    private void Start()
    {
        textStartingLetter.text = "" + introText + "\n" + moneyNeededText + moneyNeededPerYear + "\n" + startSeendingMoneyText + startSendingMoneyTimepoint;
        sendMoneyButton.SetActive(false);

        textOne.text = sendMoneyText + " " + moneyNeededPerYear + "\n" + effectOnFamilyNoMoneyText + "-" + FamilyStatusManager.getFamilyStatusChange();

    }

    public void timeForPlayerToSendMoney(int yearNow)
    {
        //Debug.Log("�r: " + yearNow);
        //Debug.Log("B�rja skicka pengar (�r): " + startSendingMoneyTimepoint);

        if (yearNow >= startSendingMoneyTimepoint)
        {
            //Debug.Log("Send money!");
            textOne.text = sendMoneyText + " " + moneyNeededPerYear + "\n" + effectOnFamilyNoMoneyText + "-" + FamilyStatusManager.getFamilyStatusChange();
            infoPanel.SetActive(true);
            sendMoneyButton.SetActive(true);
           
        }

    }

    public void sendMoney()
    {

        int amountToSend = moneyNeededPerYear;

        //Om spelaren har tillr�ckligt med pengar skickas detta till familjen
        if (MoneyManager.MoneyNow >= amountToSend)
        {
            Debug.Log("Tillr�ckligt med pengar");
            MoneyManager.buyTransaction(amountToSend);
            FamilyStatusManager.updateFamilyHealth();

            infoPanel.SetActive(false);
        }
    }


}

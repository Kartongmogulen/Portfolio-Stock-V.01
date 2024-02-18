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

    public Text textOne;

    public GameObject infoPanel;
    public GameObject sendMoneyButton;
    public totalCash TotalCash;
    public familyStatusManager FamilyStatusManager;


    private void Start()
    {
        textOne.text = "" + introText + "\n" + moneyNeededText + moneyNeededPerYear + "\n" + startSeendingMoneyText + startSendingMoneyTimepoint;
        sendMoneyButton.SetActive(false);
    }

    public void timeForPlayerToSendMoney(int yearNow)
    {
        //Debug.Log("År: " + yearNow);
        Debug.Log("Börja skicka pengar (år): " + startSendingMoneyTimepoint);

        if (yearNow >= startSendingMoneyTimepoint)
        {
            Debug.Log("Send money!");
            textOne.text = sendMoneyText + " " + moneyNeededPerYear + "\n" + effectOnFamilyNoMoneyText + "-" + FamilyStatusManager.getFamilyStatusChange();
            infoPanel.SetActive(true);
            sendMoneyButton.SetActive(true);
           
        }

    }

    public void sendMoney()
    {

        int amountToSend = moneyNeededPerYear;

        //Om spelaren har tillräckligt med pengar skickas detta till familjen
        if (TotalCash.moneyNow >= amountToSend)
        {
            Debug.Log("Tillräckligt med pengar");
            TotalCash.transactionMoney(-amountToSend);
            FamilyStatusManager.updateFamilyHealth();

            infoPanel.SetActive(false);
        }
    }


}

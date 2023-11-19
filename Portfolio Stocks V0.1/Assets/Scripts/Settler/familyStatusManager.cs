using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class familyStatusManager : MonoBehaviour
{
    //Hanterar hur famljens hälsa/livssituation påverkas av pengarna som skickas.
    [SerializeField] int familyHealthStart;
    [SerializeField] int familyHealthNow;
    [SerializeField] int familyHealthChange;
    public bool moneySendThisTurn = true;
    public endRoundButton EndRoundButton;
    public GameObject sendMoneyButton;

    public Text familyHealthText;

    private void Start()
    {
        familyHealthNow = familyHealthStart;
        familyHealthText.text = "Family Health: " + familyHealthNow;
    }

    public void updateFamilyHealth()
    {
        familyHealthNow += familyHealthChange;
        Debug.Log("Familj hälsa: " + familyHealthNow);
        
        if(familyHealthNow > familyHealthStart)
        {
            familyHealthNow = familyHealthStart;
        }

        moneySendThisTurn = true;
        familyHealthText.text = "Family Health: " + familyHealthNow;
    }

    public void didPlayerSendMoneyToFamily()
    {
        if (moneySendThisTurn != true && EndRoundButton.month == 2)
        {
            familyHealthNow -= familyHealthChange;
            sendMoneyButton.SetActive(false);
        }

        //Nollställer 
        moneySendThisTurn = false;  
       familyHealthText.text = "Family Health: " + familyHealthNow;
        isFamilyDead();
    }

    public void isFamilyDead()
    {
        if (familyHealthNow <= 0)
        {
            familyHealthText.text = "Family is dead!!!";
        }
    }

    public int getFamilyStatusChange()
    {
        return familyHealthChange;
    }
}

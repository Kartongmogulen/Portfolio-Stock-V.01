using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actionPointsManager : MonoBehaviour
{
    //Hanterar allt som kräver Action Points

    public int startAP;
    public int baseAP; //Spelarens nyvarande AP vid ny runda
    public int remainingAP;

    public Text actionPointsText;

  void Start()
    {
        remainingAP = startAP;
        baseAP = startAP;
        actionPointsText.text = "AP: " + remainingAP;
    }

    public void actionPointSub(int amountAP)
    {

        if (remainingAP >= amountAP)
        {
            remainingAP -= amountAP;
        }
        updateAP();
    }

    public void endRound()
    {
        remainingAP = baseAP;
        updateAP();
    }

    public void updateAP()
    {
        actionPointsText.text = "AP: " + remainingAP;
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHistoricData : MonoBehaviour
{
    public List<Text> yearsHeader;
    public List<Text> EPSText;
    public endRoundButton EndRoundButton;
    public gamePlayScopeManager GamePlayScopeManager;

    private int yearNow;

    public void updateAllHistoricData(stock Stock)
    {
        yearNow = EndRoundButton.year; //År i dagsläget
        updateYearText();
        updateEPSText(Stock);
    }

    public void updateYearText()
    {
        for (int i = 0; i  < yearsHeader.Count;i++)
        {
            yearsHeader[i].text = " " + (yearNow + EPSText.Count - (GamePlayScopeManager.yearsToGetHistoricData - i));
        }
    }

    public void updateEPSText(stock Stock)
    {
        for (int i = 0; i < EPSText.Count; i++)
        {
            EPSText[i].text = " " + (Stock.EPSHistory[(GamePlayScopeManager.yearsToGetHistoricData + yearNow + i - EPSText.Count)]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class DividendUIUpdater : MonoBehaviour
{
    [SerializeField] private Text divYieldText;
    [SerializeField] private Text divPayoutText;
    [SerializeField] private Text divPayoutShareText;

    public void UpdateDividendUI(float dividendYield, float annualDividend, float payoutRatio)
    {
        divYieldText.text = $"Div. Yield: {Mathf.Round(dividendYield * 10000)/100}%";
        divPayoutText.text = $"Annual dividend: {Mathf.Round(annualDividend * 100) / 100}";
        divPayoutShareText.text = $"Payout-ratio: {Mathf.Round(payoutRatio * 100)}%";
    }
}

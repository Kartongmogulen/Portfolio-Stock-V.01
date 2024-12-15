using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class KeyDataUiUpdater : MonoBehaviour
{
    [SerializeField] private Text priceEarningsText;
    [SerializeField] private Text earningsPerShareText;
    
    public void UpdateKeyDataUI(float priceEarnings, float earningsPerShare)
    {
        priceEarningsText.text = $"P/E: {Mathf.Round(priceEarnings * 100) / 100}";
        earningsPerShareText.text = $"EPS: {Mathf.Round(earningsPerShare * 100) / 100}";
    }
}

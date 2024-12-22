using UnityEngine;
using TMPro;

public class PortfolioValueVisualizer : MonoBehaviour, IMoneyVisualizer, IPercentVisualizer
{
    [SerializeField] TMP_Text portfolioValueText;
    [SerializeField] TMP_Text portfolioReturnText;

    public void percentWithDecimals(float value)
    {
        if (portfolioReturnText != null)
        {
            portfolioReturnText.text = $"Portfolio Return: {value:0.00}%";
        }
        else
        {
            Debug.LogWarning("Portfolio return text is not assigned.");
        }
    }

    public void UpdateMoneyDisplay(float currentMoney)
    {
        if (portfolioValueText != null)
        {
            portfolioValueText.text = $"Total Portfolio Value: ${currentMoney:0.00}";
        }
        else
        {
            Debug.LogWarning("Portfolio value text is not assigned.");
        }
    }



}

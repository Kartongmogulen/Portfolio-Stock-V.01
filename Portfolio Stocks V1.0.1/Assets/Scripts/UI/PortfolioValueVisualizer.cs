using UnityEngine;
using TMPro;

public class PortfolioValueVisualizer : MonoBehaviour, IMoneyVisualizer
{
    [SerializeField] TMP_Text portfolioValueText;

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

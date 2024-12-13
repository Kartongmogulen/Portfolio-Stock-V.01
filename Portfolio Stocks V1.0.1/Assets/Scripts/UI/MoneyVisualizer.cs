using UnityEngine;
using TMPro;

public class MoneyVisualizer : MonoBehaviour, IMoneyVisualizer
{
    [SerializeField] private TextMeshProUGUI moneyText; // Referens till en TextMeshPro-komponent

    public void UpdateMoneyDisplay(float currentMoney)
    {
        moneyText.text = $"Money: ${currentMoney:F2}"; // Uppdatera texten med nuvarande pengar
    }
}

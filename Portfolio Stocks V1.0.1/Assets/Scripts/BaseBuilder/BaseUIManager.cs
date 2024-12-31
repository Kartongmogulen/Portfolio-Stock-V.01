using UnityEngine;
using TMPro;

public class BaseUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI houseUpgradeText; // Koppla ett Text-element h�r
    private BaseUpgradeManager upgradeManager;

    private void Start()
    {
        // H�mta BaseUpgradeManager fr�n GameManager
        upgradeManager = GetComponent<BaseUpgradeManager>();
        Invoke("UpdateUI",0.1f);
    }

    public void UpdateUI()
    {
        if (houseUpgradeText != null && upgradeManager != null)
        {
            int level = upgradeManager.GetUpgradeLevel("House");
            houseUpgradeText.text = $"House Level: {level}";
        }
    }
}


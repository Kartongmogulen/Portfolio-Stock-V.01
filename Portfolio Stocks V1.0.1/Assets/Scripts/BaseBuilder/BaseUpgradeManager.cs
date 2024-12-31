using System;
using UnityEngine;
using System.Collections.Generic;

public class BaseUpgradeManager : MonoBehaviour
{
    [SerializeField] private List<IUpgrade> _upgrades = new List<IUpgrade>();

    private void Start()
    {
        AddUpgrade(new HouseUpgrade(GetComponent<actionPointsManager>()));
    }

    public void AddUpgrade(IUpgrade upgrade)
    {
        _upgrades.Add(upgrade);
    }

    public void Upgrade(string upgradeType)
    {
        Debug.Log("Upgrade: " + upgradeType);
        var upgrade = _upgrades.Find(u => u.UpgradeType.Equals(upgradeType, StringComparison.OrdinalIgnoreCase));
        if (upgrade != null)
        {
            upgrade.ApplyUpgrade();
        }
        else
        {
            Console.WriteLine($"Upgrade of type {upgradeType} not found.");
        }

    }

    public int GetUpgradeLevel(string upgradeType)
    {
       
        var upgrade = _upgrades.Find(u => u.UpgradeType.Equals(upgradeType, StringComparison.OrdinalIgnoreCase));
        if (upgrade != null)
        {
            return upgrade._level;  // Hämta och returnera leveln för uppgraderingen
        }
        else
        {
            Console.WriteLine($"Upgrade of type {upgradeType} not found.");
            return -1; // Returnera ett ogiltigt värde om uppgraderingen inte finns
        }
    }

}

using System;
using UnityEngine;
using System.Collections.Generic;

public class BaseUpgradeManager : MonoBehaviour
{
    [SerializeField] private List<IUpgrade> _upgrades = new List<IUpgrade>();

    [SerializeField] private Transform houseLocation;
    [SerializeField] private GameObject[] housePrefabs;

    [SerializeField] private actionPointsManager ActionPointsManager;

    private void Start()
    {
        ActionPointsManager = GetComponent<actionPointsManager>();
        InitializeUpgrades();
    }

    private void InitializeUpgrades()
    {
        // Skapa och lägg till HouseUpgrade
        var houseUpgrade = new HouseUpgrade(ActionPointsManager, houseLocation, housePrefabs);
        _upgrades.Add(houseUpgrade);
        houseUpgrade.Initialize(); // Initiera med första prefaben
        //Upgrade("House");

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

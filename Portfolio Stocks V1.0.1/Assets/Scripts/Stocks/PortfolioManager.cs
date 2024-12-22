using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class PortfolioManager : MonoBehaviour, IMoneyVisualizer
{
    [SerializeField]
    private List<PortfolioEntry> portfolioEntries = new List<PortfolioEntry>();

    public activeSector_1850 ActiveSector_1850;
    public CityManager cityManager;
    public stockMarketManager_1850 StockMarketManager_1850;
    public InputField inputAmountOrder;
    
    [Header("UI")]
    private PortfolioValueVisualizer valueVisualizer;

    private void Awake()
    {
        valueVisualizer = GetComponent<PortfolioValueVisualizer>();

        if (valueVisualizer != null)
        {
            UpdatePortfolioValue();
        }
        else
        {
            Debug.LogWarning("No PortfolioValueVisualizer attached!");
        }
    }
        /// <summary>
        /// Uppdaterar det totala värdet på portföljen och skickar det till visualiseraren.
        /// </summary>
    public void UpdatePortfolioValue()
        {
            float totalValue = GetTotalPortfolioValue();
            valueVisualizer?.UpdateMoneyDisplay(totalValue);

        float totalReturn = (GetTotalUnrealizedReturn()/GetTotalValueInvested())*100;
            Debug.Log("Orealiserad avkastning: " + totalReturn);
            valueVisualizer?.percentWithDecimals(totalReturn);
        }

    /// <summary>
    /// Lägger till eller uppdaterar en post i portföljen baserat på företaget.
    /// </summary>
    /// <param name="company">Företaget (GameObject).</param>
    /// <param name="numberOfShares">Antalet aktier att lägga till eller ändra.</param>
    /// <param name="investmentValue">Det totala investeringsvärdet att uppdatera.</param>
    public void AddOrUpdateEntry(int numberOfShares, float investmentValue)
    {
        GameObject company = findCompany();//Hitta Gameobject för bolaget

        var existingEntry = portfolioEntries.Find(entry => entry.Company == company);

        if (existingEntry != null)
        {
            existingEntry.NumberOfShares += numberOfShares;
            existingEntry.InvestmentValue += investmentValue;

            if (existingEntry.NumberOfShares == 0)
            {
                portfolioEntries.Remove(existingEntry);
            }
        }
        else if (numberOfShares > 0)
        {
            portfolioEntries.Add(new PortfolioEntry
            {
                Company = company,
                NumberOfShares = numberOfShares,
                InvestmentValue = investmentValue
            });
        }

    }

    public void UpdateMoneyDisplay(float value)
    {
        valueVisualizer?.UpdateMoneyDisplay(value);
    }

    public int getSharesAmount()
    {
        GameObject company = findCompany();//Hitta Gameobject för bolaget

        var existingEntry = portfolioEntries.Find(entry => entry.Company == company);

        return existingEntry != null ? existingEntry.NumberOfShares : 0;
        //return existingEntry.NumberOfShares;
    }

    public GameObject findCompany()
    {
        int sector = ActiveSector_1850.getActiveSector();
        int city = cityManager.activeCity;

        GameObject stockPrefab = sector switch
        {
            0 => StockMarketManager_1850.StockPrefabListMines[city],
            1 => StockMarketManager_1850.StockPrefabListRailroad[city],
            2 => StockMarketManager_1850.StockPrefabListIndustri[city],
            _ => throw new ArgumentException("Invalid sector.")
        };

        return stockPrefab;
    }

    /// <summary>
    /// Hämtar orealiserad avkastning för ett företag.
    /// </summary>
    /// <param name="company">Företaget (GameObject).</param>
    /// <returns>Orealiserad avkastning som en float.</returns>
    public float GetUnrealizedReturn(GameObject company)
    {
        //Debug.Log("Avkastning bolag Script: " + company.name);
        var entry = portfolioEntries.Find(e => e.Company == company);

        if (entry != null && company.TryGetComponent(out ICompany companyScript))
        {
            //Debug.Log("Bolag: " + company.name);
            return (companyScript.StockPrice * entry.NumberOfShares) - entry.InvestmentValue;
        }

        else if (entry != null && company.TryGetComponent(out stock Stock))
        {
            //Debug.Log("Bolag: " + company.name);
            return (Stock.CurrentPrice * entry.NumberOfShares) - entry.InvestmentValue;
        }

        return 0f;
    }

    /// <summary>
    /// Hämtar hela portföljen.
    /// </summary>
    /// <returns>Lista över alla poster i portföljen.</returns>
    public List<PortfolioEntry> GetPortfolioEntries()
    {
        return new List<PortfolioEntry>(portfolioEntries);
    }

    /// <summary>
    /// Beräknar det totala värdet av spelarens portfölj.
    /// </summary>
    /// <returns>Totalt värde som float.</returns>
    public float GetTotalPortfolioValue()
    {
        float totalValue = 0f;

        foreach (var entry in portfolioEntries)
        {
            //Debug.Log("Söker aktier");
            if (entry.Company.TryGetComponent(out stock companyScript))// FUNKAR EJ FÖR INDUSTRIS FÖR TILLFÄLLET
            {
                //Debug.Log("Hittat matchande aktie");
                totalValue += companyScript.CurrentPrice * entry.NumberOfShares;
            }
        }

        return totalValue;
    }

    public float GetTotalValueInvested()
    {
        float totalValue = 0f;

        foreach (var entry in portfolioEntries)
        {
            //Debug.Log("Söker aktier");
            //if (entry.Company.TryGetComponent(out stock companyScript))// FUNKAR EJ FÖR INDUSTRIS FÖR TILLFÄLLET
            //{
            //Debug.Log("Hittat matchande aktie");
            totalValue += entry.InvestmentValue; // * entry.NumberOfShares;
            //}
        }

        return totalValue;
    }

    public float GetSectorValue(sectorNameEnum sectorName)
    {
        float valueSector = 0f;

        foreach (var entry in portfolioEntries)
        {
            Debug.Log("Söker aktier");
            if (entry.Company.TryGetComponent(out stock companyScript))// FUNKAR EJ FÖR INDUSTRIS FÖR TILLFÄLLET
            {
                Debug.Log("Hittat matchande aktie");
                if (companyScript.SectorNameEnum == sectorName)
                {
                    valueSector += companyScript.CurrentPrice * entry.NumberOfShares;
                }
            }
        }

        return valueSector;
    }

    /// <summary>
    /// Beräknar total orealiserad avkastning för hela portföljen.
    /// </summary>
    /// <returns>Totalt orealiserad avkastning som float.</returns>
    public float GetTotalUnrealizedReturn()
    {
        float totalUnrealizedReturn = 0f;

        foreach (var entry in portfolioEntries)
        {
            totalUnrealizedReturn += GetUnrealizedReturn(entry.Company);
            Debug.Log("Orealiserad avkastning: ForLoop " + totalUnrealizedReturn);
        }

        return totalUnrealizedReturn;
    }
}

/// <summary>
/// En enskild post i spelarens portfölj.
/// </summary>
[System.Serializable]
public class PortfolioEntry
{
    public GameObject Company;        // Företaget som aktien gäller
    public int NumberOfShares;        // Antalet aktier spelaren äger i företaget
    public float InvestmentValue;    // Det totala beloppet spelaren investerat i företaget
}

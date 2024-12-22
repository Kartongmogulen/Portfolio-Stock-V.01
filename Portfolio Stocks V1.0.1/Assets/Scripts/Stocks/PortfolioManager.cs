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
        /// Uppdaterar det totala v�rdet p� portf�ljen och skickar det till visualiseraren.
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
    /// L�gger till eller uppdaterar en post i portf�ljen baserat p� f�retaget.
    /// </summary>
    /// <param name="company">F�retaget (GameObject).</param>
    /// <param name="numberOfShares">Antalet aktier att l�gga till eller �ndra.</param>
    /// <param name="investmentValue">Det totala investeringsv�rdet att uppdatera.</param>
    public void AddOrUpdateEntry(int numberOfShares, float investmentValue)
    {
        GameObject company = findCompany();//Hitta Gameobject f�r bolaget

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
        GameObject company = findCompany();//Hitta Gameobject f�r bolaget

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
    /// H�mtar orealiserad avkastning f�r ett f�retag.
    /// </summary>
    /// <param name="company">F�retaget (GameObject).</param>
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
    /// H�mtar hela portf�ljen.
    /// </summary>
    /// <returns>Lista �ver alla poster i portf�ljen.</returns>
    public List<PortfolioEntry> GetPortfolioEntries()
    {
        return new List<PortfolioEntry>(portfolioEntries);
    }

    /// <summary>
    /// Ber�knar det totala v�rdet av spelarens portf�lj.
    /// </summary>
    /// <returns>Totalt v�rde som float.</returns>
    public float GetTotalPortfolioValue()
    {
        float totalValue = 0f;

        foreach (var entry in portfolioEntries)
        {
            //Debug.Log("S�ker aktier");
            if (entry.Company.TryGetComponent(out stock companyScript))// FUNKAR EJ F�R INDUSTRIS F�R TILLF�LLET
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
            //Debug.Log("S�ker aktier");
            //if (entry.Company.TryGetComponent(out stock companyScript))// FUNKAR EJ F�R INDUSTRIS F�R TILLF�LLET
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
            Debug.Log("S�ker aktier");
            if (entry.Company.TryGetComponent(out stock companyScript))// FUNKAR EJ F�R INDUSTRIS F�R TILLF�LLET
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
    /// Ber�knar total orealiserad avkastning f�r hela portf�ljen.
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
/// En enskild post i spelarens portf�lj.
/// </summary>
[System.Serializable]
public class PortfolioEntry
{
    public GameObject Company;        // F�retaget som aktien g�ller
    public int NumberOfShares;        // Antalet aktier spelaren �ger i f�retaget
    public float InvestmentValue;    // Det totala beloppet spelaren investerat i f�retaget
}

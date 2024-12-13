using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SectorStocks : MonoBehaviour
{
    [SerializeField]
    private string sectorName; // Namnet på sektorn, exempelvis "Utilities" eller "Technology"

    [SerializeField]
    private List<GameObject> companies = new List<GameObject>(); // Lista med GameObjects som representerar företag

    public string SectorName => sectorName;

    public List<ICompany> Companies
    {
        get
        {
            return companies
                .Select(companyGO => companyGO.GetComponent<ICompany>())
                .Where(company => company != null)
                .ToList();
        }
    }

    /// <summary>
    /// Beräknar det totala värdet av alla företag i denna sektor.
    /// </summary>
    /// <returns>Det totala värdet.</returns>
    public float CalculateTotalSectorValue()
    {
        return Companies.Sum(company => company.StockPrice * company.NumberOfShares);
    }

    /// <summary>
    /// Lägger till ett företag till sektorn (genom GameObject).
    /// </summary>
    /// <param name="company">GameObject som innehåller ett företagsskript.</param>
    public void AddCompany(GameObject company)
    {
        if (company != null && company.GetComponent<ICompany>() != null)
        {
            companies.Add(company);
        }
        else
        {
            Debug.LogWarning("GameObjectet saknar ett ICompany-kompatibelt skript och kan inte läggas till.");
        }
    }

    /// <summary>
    /// Tar bort ett företag från sektorn.
    /// </summary>
    /// <param name="company">GameObject som ska tas bort.</param>
    public void RemoveCompany(GameObject company)
    {
        if (companies.Contains(company))
        {
            companies.Remove(company);
        }
    }
}
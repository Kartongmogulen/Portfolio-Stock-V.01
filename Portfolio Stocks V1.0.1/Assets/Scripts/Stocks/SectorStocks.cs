using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SectorStocks : MonoBehaviour
{
    [SerializeField]
    private string sectorName; // Namnet p� sektorn, exempelvis "Utilities" eller "Technology"

    [SerializeField]
    private List<GameObject> companies = new List<GameObject>(); // Lista med GameObjects som representerar f�retag

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
    /// Ber�knar det totala v�rdet av alla f�retag i denna sektor.
    /// </summary>
    /// <returns>Det totala v�rdet.</returns>
    public float CalculateTotalSectorValue()
    {
        return Companies.Sum(company => company.StockPrice * company.NumberOfShares);
    }

    /// <summary>
    /// L�gger till ett f�retag till sektorn (genom GameObject).
    /// </summary>
    /// <param name="company">GameObject som inneh�ller ett f�retagsskript.</param>
    public void AddCompany(GameObject company)
    {
        if (company != null && company.GetComponent<ICompany>() != null)
        {
            companies.Add(company);
        }
        else
        {
            Debug.LogWarning("GameObjectet saknar ett ICompany-kompatibelt skript och kan inte l�ggas till.");
        }
    }

    /// <summary>
    /// Tar bort ett f�retag fr�n sektorn.
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
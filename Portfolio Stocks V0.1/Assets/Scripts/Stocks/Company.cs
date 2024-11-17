using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class Company : MonoBehaviour, ICompany
    {

    [Header("Company Settings")]
    [Tooltip("Det nuvarande aktiepriset för företaget.")]
    [SerializeField]
    private float stockPrice; // Standardvärde som kan justeras i inspektorn.

    [Tooltip("Antalet tillgängliga aktier för företaget.")]
    [SerializeField]
    private int numberOfShares = 1000; // Standardvärde som kan justeras i inspektorn.

    /// <summary>
    /// Företagets aktiepris. Kan endast läsas från andra klasser.
    /// </summary>
    public float StockPrice => stockPrice;

    /// <summary>
    /// Antalet tillgängliga aktier. Kan endast läsas från andra klasser.
    /// </summary>
    public int NumberOfShares => numberOfShares;

    [Tooltip("Företagets namn.")]
    [SerializeField]
    private string companyName = "Example Company";

    public string CompanyName => companyName;

    [Tooltip("Företagets sektor.")]
    [SerializeField]
    private sectorNameEnum companySector;

    public sectorNameEnum CompanySector => companySector;
}


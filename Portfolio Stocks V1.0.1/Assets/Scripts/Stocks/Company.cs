using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class Company : MonoBehaviour, ICompany
    {

    [Header("Company Settings")]
    [Tooltip("Det nuvarande aktiepriset f�r f�retaget.")]
    [SerializeField]
    private float stockPrice; // Standardv�rde som kan justeras i inspektorn.

    [Tooltip("Antalet tillg�ngliga aktier f�r f�retaget.")]
    [SerializeField]
    private int numberOfShares = 1000; // Standardv�rde som kan justeras i inspektorn.

    /// <summary>
    /// F�retagets aktiepris. Kan endast l�sas fr�n andra klasser.
    /// </summary>
    public float StockPrice => stockPrice;

    /// <summary>
    /// Antalet tillg�ngliga aktier. Kan endast l�sas fr�n andra klasser.
    /// </summary>
    public int NumberOfShares => numberOfShares;

    [Tooltip("F�retagets namn.")]
    [SerializeField]
    private string companyName = "Example Company";

    public string CompanyName => companyName;

    [Tooltip("F�retagets sektor.")]
    [SerializeField]
    private sectorNameEnum companySector;

    public sectorNameEnum CompanySector => companySector;
}


using UnityEngine;


/// <summary>
/// Interfacet abstraherar bort implementationen av utdelningar.
/// Vilket inneb�r att klasser med olika implementationer av DividendPerShare kan hanteras p� samma s�tt. 
/// Detta g�r det enklare att l�gga till nya typer av bolag som implementerar utdelningar utan att beh�va �ndra befintlig kod.
/// Exempel:
/// 1.Ett industribolag kanske ber�knar utdelningar baserat p� vinster.
/// 2.Ett fastighetsbolag kanske ber�knar utdelningar baserat p� hyresint�kter.
/// Med ett interface beh�ver du bara s�kerst�lla att dessa klasser implementerar IDividendPayingCompany och kan hanteras genom enhetlig kod.
/// </summary>
public interface IDividendPayingCompany
{
    float DividendPerShare { get; set; }
    void UpdateDividendsEndOfYear();
}

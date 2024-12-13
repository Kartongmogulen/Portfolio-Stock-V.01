using UnityEngine;


/// <summary>
/// Interfacet abstraherar bort implementationen av utdelningar.
/// Vilket innebär att klasser med olika implementationer av DividendPerShare kan hanteras på samma sätt. 
/// Detta gör det enklare att lägga till nya typer av bolag som implementerar utdelningar utan att behöva ändra befintlig kod.
/// Exempel:
/// 1.Ett industribolag kanske beräknar utdelningar baserat på vinster.
/// 2.Ett fastighetsbolag kanske beräknar utdelningar baserat på hyresintäkter.
/// Med ett interface behöver du bara säkerställa att dessa klasser implementerar IDividendPayingCompany och kan hanteras genom enhetlig kod.
/// </summary>
public interface IDividendPayingCompany
{
    float DividendPerShare { get; set; }
    void UpdateDividendsEndOfYear();
}

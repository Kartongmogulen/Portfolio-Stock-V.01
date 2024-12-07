using UnityEngine;

public interface IDividendPayingCompany
{
    float DividendPerShare { get; set; }
    void UpdateDividendsEndOfYear();
}

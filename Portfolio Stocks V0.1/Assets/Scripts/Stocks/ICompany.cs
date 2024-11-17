public interface ICompany
{
    /// <summary>
    /// F�retagets aktiepris.
    /// </summary>
    float StockPrice { get; }

    /// <summary>
    /// Antalet aktier som finns tillg�ngliga.
    /// </summary>
    int NumberOfShares { get; }
}

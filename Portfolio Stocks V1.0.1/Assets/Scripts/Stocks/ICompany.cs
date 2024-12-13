public interface ICompany
{
    /// <summary>
    /// Företagets aktiepris.
    /// </summary>
    float StockPrice { get; }

    /// <summary>
    /// Antalet aktier som finns tillgängliga.
    /// </summary>
    int NumberOfShares { get; }
}

public interface ISector
{
    float TotalInvestedAmount { get; }
    float TotalValue { get; }
    float UnrealizedProfit { get; }
    void AddShares(int companyIndex, int shares);
    void ResetValuesIfAllSharesSold();
}
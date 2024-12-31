using UnityEngine;


public class HouseUpgrade: IUpgrade
{
    public string UpgradeType => "House";

    public int _level { get; private set; } = 1;
    private readonly actionPointsManager _actionPointsManager;

    public HouseUpgrade(actionPointsManager ActionPointsManager)
    {
        _actionPointsManager = ActionPointsManager;
    }
    public void ApplyUpgrade()
    {
        _level++;
        _actionPointsManager.changeBaseActionPoints(4); // Öka action points med 10 för varje uppgradering
        Debug.Log($"House upgraded to level {_level}.");
    }

}

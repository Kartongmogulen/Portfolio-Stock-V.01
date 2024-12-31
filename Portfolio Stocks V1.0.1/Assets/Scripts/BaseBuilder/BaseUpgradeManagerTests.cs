using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BaseUpgradeManagerTests
{
    public void CanAddAndUpgradeHouse()
    {
        // Arrange
        var upgradeManager = new BaseUpgradeManager();
        //var houseUpgrade = new HouseUpgrade();

        // Act
        //upgradeManager.AddUpgrade(houseUpgrade);
        upgradeManager.Upgrade("House");

        // Assert
        //Assert.AreEqual(2, houseUpgrade._level, "House level should be 2 after one upgrade.");
    }

    [Test]
    public void UpgradeFailsForUnknownType()
    {
        // Arrange
        var upgradeManager = new BaseUpgradeManager();

        // Act & Assert
        Assert.DoesNotThrow(() => upgradeManager.Upgrade("Unknown"), "Upgrading unknown type should not throw.");
    }
}

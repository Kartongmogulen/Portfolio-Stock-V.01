using UnityEngine;

public class PlayerBase:MonoBehaviour
{
    [SerializeField] private string playerName; // Synligt i Inspector
    //[SerializeField] private BaseUpgradeManager baseUpgradeManager;
    //public BaseUpgradeManager baseUpgradeManager { get; private set; }

    //KOMPONENTEN ADDERAS I "GAMEMANAGER"
    private void Awake()
    {/*
        baseUpgradeManager = new BaseUpgradeManager();

        baseUpgradeManager.AddUpgrade(new HouseUpgrade());
        Debug.Log("House Level: " + baseUpgradeManager.GetUpgradeLevel("House"));
        //baseUpgradeManager.Upgrade("House");

        /*if (upgradeManager == null)
        {
            //upgradeManager = gameObject.AddComponent<BaseUpgradeManager>();
        }*/
        
    }
}

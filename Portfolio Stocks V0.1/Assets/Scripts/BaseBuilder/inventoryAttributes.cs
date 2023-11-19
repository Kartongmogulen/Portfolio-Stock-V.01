using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryAttributes : MonoBehaviour
{
    [SerializeField] string NameInventory;
    [SerializeField] int lvl;
    [SerializeField] List<int> cost;
    [SerializeField] List<int> actionPointsIncrease;
    public Sprite picture;

    public string getNameInventory()
    {
        return NameInventory;
    }

    public int getCost()
    {
        return cost[lvl];
    }

    public int getActionPointsIncrease()
    {
        return actionPointsIncrease[lvl];
    }

    public int getCurrentLvl()
    {
        return lvl;
    }

    public void lvlUpAsset()
    {
        Debug.Log("LvlUpAsset");
        lvl++;
    }

    public int levelCountOnAsset()
    {
        return cost.Count;
    }

}

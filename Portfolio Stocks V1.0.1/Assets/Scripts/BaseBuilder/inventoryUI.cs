using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI : MonoBehaviour
{
    public Text currentLvlText;
    public Text descriptionText;
    public Text costText;

    public void displayInventoryAsset(inventoryAttributes InventoryAttributes)
    {
        if (InventoryAttributes.getCurrentLvl() == InventoryAttributes.levelCountOnAsset())
        {
            assetMaxLvlRearched();
        }
        else
        {
            currentLvlText.text = "Current lvl: " + InventoryAttributes.getCurrentLvl();
            descriptionText.text = "Increase Actionpoints: " + InventoryAttributes.getActionPointsIncrease();
            costText.text = "Cost: " + InventoryAttributes.getCost();
        }
        
    }

    public void updateTextFromChoosenAsset(GameObject assetGO)
    {
        
            currentLvlText.text = "Current lvl: " + assetGO.GetComponent<inventoryAttributes>().getCurrentLvl();
            descriptionText.text = "Increase Actionpoints: " + assetGO.GetComponent<inventoryAttributes>().getActionPointsIncrease();
            costText.text = "Cost: " + assetGO.GetComponent<inventoryAttributes>().getCost();
   
    }

    public void assetMaxLvlRearched()
    {
        currentLvlText.text = "Current lvl: MAX";
        descriptionText.text = "Current lvl: MAX";
        costText.text = "Current lvl: MAX";
    }
}

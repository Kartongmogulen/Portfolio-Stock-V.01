using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryButtonManager : MonoBehaviour
{
    public List<GameObject> chooseAssetButtons;
    public Button lvlUpButton;
    [SerializeField] int activeAssetInt;
    public inventoryUI InventoryUI;
    public actionPointsManager ActionPointsManager;
    public totalCash TotalCash;

    public void activeAsset(int assetInt)
    {
        Debug.Log("Du valde: " + assetInt);
        activeAssetInt = assetInt;
        //lvlUpButton.onClick.AddListener(chooseAssetButtons[assetInt].GetComponent<inventoryAttributes>().lvlUpAsset());
        if (chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().levelCountOnAsset() == chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().getCurrentLvl())
        {
            InventoryUI.assetMaxLvlRearched();//Uppdatera text
        }
    }

    public void upgradeAsset()
    {
        //Är Asset fullt uppgraderad??
        if(chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().levelCountOnAsset() == chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().getCurrentLvl())
        {
            InventoryUI.assetMaxLvlRearched();//Uppdatera text
        }
        else { 
        {
                //Har spelaren tillräckligt med pengar
                if (TotalCash.moneyNow >= chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().getCost())
                {

                    //Betalar för uppgradering
                    TotalCash.transactionMoney(-chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().getCost());

                    ActionPointsManager.baseAP += chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().getActionPointsIncrease();

                    if (chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().levelCountOnAsset() == chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().getCurrentLvl())
                    {
                        InventoryUI.assetMaxLvlRearched();//Uppdatera text

                    }
                    else
                    {
                        chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().lvlUpAsset();
                        
                        //Uppdaterar text
                        if (chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().levelCountOnAsset() == chooseAssetButtons[activeAssetInt].GetComponent<inventoryAttributes>().getCurrentLvl())
                        {
                            InventoryUI.assetMaxLvlRearched();
                        }
                        else
                        {
                            InventoryUI.updateTextFromChoosenAsset(chooseAssetButtons[activeAssetInt]);//Uppdatera text
                        }
                    }
                }

            }
            
        }
        
    }
}

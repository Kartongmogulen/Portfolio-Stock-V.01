using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyDemandUI : MonoBehaviour
{
    public SupplyDemandManager supplyDemandManager;

    public List<Text> needNameTextList;
    public List<Text> needPriceTextList;
    public List<Text> needSupplyTextList;
    public List<Text> needDemandTextList;

    public List<Text> buttonNeedTextList;

    public void OnEnable()
    {
        needNameTextUpdate(buttonNeedTextList);
    }

    public void needAllUpdate()
    {
        needNameTextUpdate(needNameTextList);
        supplyDemandManager.setPrice();
        needPriceTextUpdate();
        needSupplyTextUpdate();
        needDemandTextUpdate();
        
    }

    public void needNameTextUpdate(List<Text> textlista)
    {
        for (int i = 0; i < supplyDemandManager.needsPeoplesList.Count; i++)
        {
            textlista[i].text = "" + supplyDemandManager.needsPeoplesList[i].NeedsName;
        }
    }

    public void needPriceTextUpdate()
    {
        for (int i = 0; i < supplyDemandManager.needsPeoplesList.Count; i++)
        {
            needPriceTextList[i].text = "" + supplyDemandManager.needsPeoplesList[i].getprice();
        }
    }

    public void needSupplyTextUpdate()
    {
        for (int i = 0; i < supplyDemandManager.needsPeoplesList.Count; i++)
        {
            needSupplyTextList[i].text = "" + supplyDemandManager.needsPeoplesList[i].getSupply();
        }
    }

    public void needDemandTextUpdate()
    {
        for (int i = 0; i < supplyDemandManager.needsPeoplesList.Count; i++)
        {
            needDemandTextList[i].text = "" + supplyDemandManager.needsPeoplesList[i].getDemand();
        }
    }
}

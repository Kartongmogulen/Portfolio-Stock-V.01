using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UpdateAssetInfoText : MonoBehaviour
{
    [SerializeField] List<Text> textToUpdateList;
    [SerializeField] List<string> textStartList;
    public stockMarketInventory StockMarketInventory;

    public void assetInfoUpdate(int companyID)
    {
        textToUpdateList[0].text = "" + textStartList[0] +""+ StockMarketInventory.masterList[companyID].GetComponent<fisherCompanyStats>().getEmployees();
        textToUpdateList[1].text = "" + textStartList[1] + "" + StockMarketInventory.masterList[companyID].GetComponent<fisherCompanyStats>().getFishingRodAmount(0);
        textToUpdateList[2].text = "" + textStartList[2] + "" + StockMarketInventory.masterList[companyID].GetComponent<fisherCompanyStats>().getBoatsAmount();
    }

    public void employees_Amount()
    {
        for (int i = 0; i < textStartList.Count; i++)
        {
            textToUpdateList[i].text = "" + textStartList[i] + StockMarketInventory.masterList[i].GetComponent<fisherCompanyStats>().getEmployees();
        }
    }

    public void rods_Amount()
    {
        for (int i = 0; i < textStartList.Count; i++)
        {
            textToUpdateList[i].text = "" + textStartList[i] + StockMarketInventory.masterList[i].GetComponent<fisherCompanyStats>().getFishingRodAmount(0);
        }
    }
}

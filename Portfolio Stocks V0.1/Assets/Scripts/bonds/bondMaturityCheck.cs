using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bondMaturityCheck : MonoBehaviour
{
    // Kontrollerar om räntepappret har uppnått slutdatum
    public bondsPortfolio BondsPortfolio;
    public totalCash TotalCash;
    public bondMarketManager BondMarketManager;
    public GameObject bondsScriptsGO;

    [SerializeField] private float amountBonds;
    [SerializeField] private float valueBonds;

    public void checkIfMaturePassed()
    {
        
        checkOneYearBonds();
        checkFiveYearBonds(1);
    }

    public void checkOneYearBonds()
    {
        if (BondsPortfolio.bondsOwned1Year.Count-1 < 12 * BondMarketManager.bondMarketListGO[0].GetComponent<bondInfoPrefab>().duration)
        {
            //Debug.Log("12 mån har ej passerat");
            return; 
        }
        else
        {
            bondsScriptsGO.GetComponent<bondsCollectCoupon>().CollectCoupon();
            BondsPortfolio.removeBondsFromListWhenMature(0);
            /*
            amountBonds = BondsPortfolio.bondsOwned1Year[BondsPortfolio.bondsOwned1Year.Count - 13];
            valueBonds = amountBonds * BondMarketManager.bondMarketListGO[0].GetComponent<bondInfoPrefab>().costBond;

            BondsPortfolio.removeBondsFromListWhenMature(0);
            TotalCash.sellBonds(valueBonds);
            //BondsPortfolio.bondsOwned1Year[BondsPortfolio.bondsOwned1Year.Count-12]
            */
        }
    }

    public void checkFiveYearBonds(int bondInt)
    {
        if (BondsPortfolio.bondsOwned5Year.Count - 1 < 12 * BondMarketManager.bondMarketListGO[bondInt].GetComponent<bondInfoPrefab>().duration)
        {
            //Debug.Log("60 mån har ej passerat");
            return;
        }

        else
        {
            //Debug.Log("60 mån HAR passerat");
            amountBonds = BondsPortfolio.bondsOwned5Year[BondsPortfolio.bondsOwned5Year.Count - Mathf.RoundToInt(12 * BondMarketManager.bondMarketListGO[bondInt].GetComponent<bondInfoPrefab>().duration + 1)];
            //Debug.Log("Antal Långa räntor: " + amountBonds);
            valueBonds = amountBonds * BondMarketManager.bondMarketListGO[bondInt].GetComponent<bondInfoPrefab>().costBond;
            //Debug.Log("Värde Långa räntor: " + valueBonds);
            //TotalCash.incomeBonds(valueBonds * BondMarketManager.bondMarketListGO[bondInt].GetComponent<bondInfoPrefab>().rate / 100);
            BondsPortfolio.removeBondsFromListWhenMature(bondInt);
            TotalCash.sellBonds(valueBonds);
        }
    }


}

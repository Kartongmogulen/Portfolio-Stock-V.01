using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bondsCollectCoupon : MonoBehaviour
{
    //Adderar pengar till spelaren då ränta erhålls
    public totalCash TotalCash;
    public bondsPortfolio BondsPortfolio;
    public bondMarketManager BondMarketManager;

    [SerializeField] private float amountBonds;
    [SerializeField] private float valueBonds;

    //Hanteras idag i TotalCash-script
    public void CollectCoupon()
    {
        //Debug.Log("Collect Coupon: " + BondsPortfolio.bondsOwned1Year.Count);
        if (BondsPortfolio.bondsOwned1Year.Count - 1 == 12) 
        {
            amountBonds = BondsPortfolio.bondsOwned1Year[BondsPortfolio.bondsOwned1Year.Count - 13];
            valueBonds = amountBonds * BondMarketManager.bondMarketListGO[0].GetComponent<bondInfoPrefab>().costBond;
            //Ränta betalas till Spelaren
            TotalCash.incomeBonds(valueBonds * BondMarketManager.bondMarketListGO[0].GetComponent<bondInfoPrefab>().rate / 100);
            TotalCash.sellBonds(valueBonds);
        }
        
    }

}

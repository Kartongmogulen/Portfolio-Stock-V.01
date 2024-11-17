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
    [SerializeField] private float numberIterations;

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
            //TotalCash.sellBonds(valueBonds);
        }

        //______________________________
        //Långa räntor, 5 år

        //Debug.Log("längd 5 års räntor: " + BondsPortfolio.bondsOwned5Year.Count);
        if (BondsPortfolio.bondsOwned5Year.Count - 1 >= 12 && BondsPortfolio.bondsOwned5Year.Count < 24)
        {
            //numberIterations = BondsPortfolio.bondsOwned5Year[BondsPortfolio.bondsOwned5Year.Count] / 12;
            //Debug.Log(numberIterations);

            amountBonds = BondsPortfolio.bondsOwned5Year[BondsPortfolio.bondsOwned5Year.Count - 13];
            valueBonds = amountBonds * BondMarketManager.bondMarketListGO[1].GetComponent<bondInfoPrefab>().costBond;
            TotalCash.incomeBonds(valueBonds * BondMarketManager.bondMarketListGO[1].GetComponent<bondInfoPrefab>().rate / 100);
            //TotalCash.sellBonds(valueBonds);
            //Debug.Log(amountBonds);
        }

        if (BondsPortfolio.bondsOwned5Year.Count - 1 >= 24 && BondsPortfolio.bondsOwned5Year.Count < 36)
        {
            //numberIterations = BondsPortfolio.bondsOwned5Year[BondsPortfolio.bondsOwned5Year.Count] / 12;
            //Debug.Log(numberIterations);
            for (int i = 1; i < 3; i++)
            {
                amountBonds = BondsPortfolio.bondsOwned5Year[BondsPortfolio.bondsOwned5Year.Count - (12*i+1)];
                valueBonds = amountBonds * BondMarketManager.bondMarketListGO[1].GetComponent<bondInfoPrefab>().costBond;
                TotalCash.incomeBonds(valueBonds * BondMarketManager.bondMarketListGO[1].GetComponent<bondInfoPrefab>().rate / 100);
                //TotalCash.sellBonds(valueBonds);
                //Debug.Log(amountBonds);
            }
        }

        if (BondsPortfolio.bondsOwned5Year.Count - 1 >= 36 && BondsPortfolio.bondsOwned5Year.Count < 48)
        {
            //numberIterations = BondsPortfolio.bondsOwned5Year[BondsPortfolio.bondsOwned5Year.Count] / 12;
            //Debug.Log(numberIterations);
            for (int i = 1; i < 4; i++)
            {
                amountBonds = BondsPortfolio.bondsOwned5Year[BondsPortfolio.bondsOwned5Year.Count - (12 * i+1)];
                valueBonds = amountBonds * BondMarketManager.bondMarketListGO[1].GetComponent<bondInfoPrefab>().costBond;
                TotalCash.incomeBonds(valueBonds * BondMarketManager.bondMarketListGO[1].GetComponent<bondInfoPrefab>().rate / 100);
                //TotalCash.sellBonds(valueBonds);
                //Debug.Log(amountBonds);
            }
        }

        if (BondsPortfolio.bondsOwned5Year.Count - 1 >= 48 && BondsPortfolio.bondsOwned5Year.Count < 60)
        {
            //numberIterations = BondsPortfolio.bondsOwned5Year[BondsPortfolio.bondsOwned5Year.Count] / 12;
            //Debug.Log(numberIterations);
            for (int i = 1; i < 5; i++)
            {
                amountBonds = BondsPortfolio.bondsOwned5Year[BondsPortfolio.bondsOwned5Year.Count - (12 * i + 1)];
                valueBonds = amountBonds * BondMarketManager.bondMarketListGO[1].GetComponent<bondInfoPrefab>().costBond;
                TotalCash.incomeBonds(valueBonds * BondMarketManager.bondMarketListGO[1].GetComponent<bondInfoPrefab>().rate / 100);
                //TotalCash.sellBonds(valueBonds);
                //Debug.Log(amountBonds);
            }
        }

        if (BondsPortfolio.bondsOwned5Year.Count > 60)
        {
            
            amountBonds = BondsPortfolio.bondsOwned5Year[0];
            valueBonds = amountBonds * BondMarketManager.bondMarketListGO[1].GetComponent<bondInfoPrefab>().costBond;
            TotalCash.incomeBonds(valueBonds * BondMarketManager.bondMarketListGO[1].GetComponent<bondInfoPrefab>().rate / 100);
            //TotalCash.sellBonds(valueBonds);
           
        }
    }
}

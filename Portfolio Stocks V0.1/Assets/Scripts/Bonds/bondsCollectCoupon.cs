using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bondsCollectCoupon : MonoBehaviour
{
    //Adderar pengar till spelaren då ränta erhålls
    public totalCash TotalCash;
    public bondsPortfolio BondsPortfolio;

    //Hanteras idag i TotalCash-script
    public void CollectCoupon()
    {
        if (BondsPortfolio.bondsOwned1Year.Count - 1 == 12) 
        {
            Debug.Log("Bondsportfolio 1 year: Längd 12");
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bondMarketManager : MonoBehaviour
{
    public List<GameObject> bondMarketListGO;
    public GameObject bondsScriptsGO;
    public bondsPortfolio BondsPortfolio;

    [SerializeField]
    private float yield10YearBondAverage;
    [SerializeField]
    private float yield10YearBondStandardDev;

    private int willYieldChange;//Alternativen �r of�r�ndrad, minska, �ka

    private void Start()
    {
        bondMarketListGO[bondMarketListGO.Count - 1].GetComponent<bondInfoPrefab>().rate += yield10YearBondStandardDev;
    }

    public void updateYield()
    {
        willYieldChange = Random.Range(0, 3);
        Debug.Log("willYieldChange: " + willYieldChange);

        if (willYieldChange == 0) //Inget h�nder
        {
            return;
        }
        else if (willYieldChange == 1) //Yield minskar
        {

        }
        else if (willYieldChange == 2)//Yield �kar
        {

        }
    }

    public void updateEachRound()
    {
        BondsPortfolio.addPlaceInList();
        bondsScriptsGO.GetComponent<bondsCollectCoupon>().CollectCoupon();
        bondsScriptsGO.GetComponent<bondMaturityCheck>().checkIfMaturePassed();
        BondsPortfolio.bondsOwnedTotal();
    }
}

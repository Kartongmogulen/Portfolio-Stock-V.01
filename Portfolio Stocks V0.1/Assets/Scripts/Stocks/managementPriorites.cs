using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managementPriorites : MonoBehaviour
{
    //Vad prioriterar Ledningen att intäkterna ska användas till

    public float dividendShareOfResult; //Andel av resultatet som går till utdelning
    public float andelFoU; //Andel som läggs på FoU, lvl upp produkt;
    public float andelEffekiviseringar; //Andel som går till effektivisering för att sänka kostnader
    public float andelTillväxt; //Andel som läggs för att öka antalet enheter sålda;

    [SerializeField] float resultThisYear;

    public incomeStatement IncomeStatement;
    public costCuttingManager CostCuttingManager;
    public divPolicyPrefab DivPolicyPrefab;
    public productHolder ProductHolder;

    private void Start()
    {
        IncomeStatement = GetComponent<incomeStatement>();
        CostCuttingManager = GetComponent<costCuttingManager>();
        DivPolicyPrefab = GetComponent<divPolicyPrefab>();
        ProductHolder = GetComponent<productHolder>();
    }

    //Resultat att fördela
    public void getResult()
    {
        resultThisYear = IncomeStatement.EarningPerShareHistory[IncomeStatement.EarningPerShareHistory.Count - 1];
    }

    public void dividendPayoutOfResult()
    {
        DivPolicyPrefab.changeDividendPayoutTotal(resultThisYear * dividendShareOfResult);
    }

    public void allocateCapital()
    {
        getResult();//Hämtar årets resultat

        //Investerar i åtgärder som minskar kostnader
        CostCuttingManager.investeringInCostCutting(resultThisYear * andelEffekiviseringar);

        dividendPayoutOfResult();

        //Investerar i att öka antalet sålda enheter
        ProductHolder.Products[0].investInGrowth(resultThisYear * andelTillväxt);

        //Investerar i FoU för att förbättra produkt
        ProductHolder.Products[0].addExpericenToProduct(resultThisYear * andelFoU);
    }

}

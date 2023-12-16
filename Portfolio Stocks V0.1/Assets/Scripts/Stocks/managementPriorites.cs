using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managementPriorites : MonoBehaviour
{
    //Vad prioriterar Ledningen att int�kterna ska anv�ndas till

    public float dividendShareOfResult; //Andel av resultatet som g�r till utdelning
    public float andelFoU; //Andel som l�ggs p� FoU, lvl upp produkt;
    public float andelEffekiviseringar; //Andel som g�r till effektivisering f�r att s�nka kostnader
    public float andelTillv�xt; //Andel som l�ggs f�r att �ka antalet enheter s�lda;

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

    //Resultat att f�rdela
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
        getResult();//H�mtar �rets resultat

        //Investerar i �tg�rder som minskar kostnader
        CostCuttingManager.investeringInCostCutting(resultThisYear * andelEffekiviseringar);

        dividendPayoutOfResult();

        //Investerar i att �ka antalet s�lda enheter
        ProductHolder.Products[0].investInGrowth(resultThisYear * andelTillv�xt);

        //Investerar i FoU f�r att f�rb�ttra produkt
        ProductHolder.Products[0].addExpericenToProduct(resultThisYear * andelFoU);
    }

}

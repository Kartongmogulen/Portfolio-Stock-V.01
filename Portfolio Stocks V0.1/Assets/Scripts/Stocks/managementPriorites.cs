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
    
    //Prioritering inom ledning
    [SerializeField] List<float> prioritiseList;//Lista med värden som avgör prioritering av ledningen

    [SerializeField] float resultThisYear;

    public incomeStatement IncomeStatement;
    public costCuttingManager CostCuttingManager;
    public divPolicyPrefab DivPolicyPrefab;
    public productHolder ProductHolder;

    [SerializeField] float sumAllOfMangementPriorites; //Summan av utdelninsandel, FoU, Kostnadsbesparingar, Tillväxt

    private void Start()
    {
        IncomeStatement = GetComponent<incomeStatement>();
        CostCuttingManager = GetComponent<costCuttingManager>();
        DivPolicyPrefab = GetComponent<divPolicyPrefab>();
        ProductHolder = GetComponent<productHolder>();
        prioritiseFromBoard();
    }

    //Hur stor vikt som läggs på olika delar från ledningen
    public void prioritiseFromBoard()
    {
        int i = Random.Range(0, prioritiseList.Count);
        dividendShareOfResult = prioritiseList[i];
        //Debug.Log("Utdelning: " + prioritiseList[i]);
       
        i = Random.Range(0, prioritiseList.Count);
        andelFoU = prioritiseList[i];
        //Debug.Log("FoU: " + prioritiseList[i]);

        i = Random.Range(0, prioritiseList.Count);
        andelEffekiviseringar = prioritiseList[i];
        //Debug.Log("CostCutting: " + prioritiseList[i]);

        i = Random.Range(0, prioritiseList.Count);
        andelTillväxt = prioritiseList[i];
        //Debug.Log("Growth: " + prioritiseList[i]);

        normalizeManagementPriorites();
    }

    //Resultat att fördela
    public void getResult()
    {
        resultThisYear = IncomeStatement.EarningHistory[IncomeStatement.EarningHistory.Count - 1];
    }

    public void dividendPayoutOfResult()
    {
        DivPolicyPrefab.changeDividendPayoutTotal(IncomeStatement.EarningPerShareHistory[IncomeStatement.EarningPerShareHistory.Count - 1] * dividendShareOfResult);
    }

    public void allocateCapital()
    {
        //Debug.Log("Allokera kapital");
        getResult();//Hämtar årets resultat
        normalizeManagementPriorites(); //Kontrollerar så inte 100% överskrids

        //Investerar i åtgärder som minskar kostnader
        CostCuttingManager.investeringInCostCutting(resultThisYear * andelEffekiviseringar);

        dividendPayoutOfResult();

        //Investerar i att öka antalet sålda enheter
        ProductHolder.investInGrowth(resultThisYear * andelTillväxt, 0);

        //Investerar i FoU för att förbättra produkt
        ProductHolder.addExpericenToProduct(resultThisYear * andelFoU, 0);
    }

    //Kontrollera så inte utdelning, FoU, Kostnadsbesparingar och Tillväxt överstiger resultatet (100% av resultat)
    public void normalizeManagementPriorites()
    {
        sumAllOfMangementPriorites = dividendShareOfResult + andelFoU + andelEffekiviseringar + andelTillväxt;
        dividendShareOfResult = dividendShareOfResult / sumAllOfMangementPriorites;
        andelFoU = andelFoU / sumAllOfMangementPriorites;
        andelEffekiviseringar = andelEffekiviseringar / sumAllOfMangementPriorites;
        andelTillväxt = andelTillväxt / sumAllOfMangementPriorites;
    }

}

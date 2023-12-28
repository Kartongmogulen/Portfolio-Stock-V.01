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
    
    //Prioritering inom ledning
    [SerializeField] List<float> prioritiseList;//Lista med v�rden som avg�r prioritering av ledningen

    [SerializeField] float resultThisYear;

    public incomeStatement IncomeStatement;
    public costCuttingManager CostCuttingManager;
    public divPolicyPrefab DivPolicyPrefab;
    public productHolder ProductHolder;

    [SerializeField] float sumAllOfMangementPriorites; //Summan av utdelninsandel, FoU, Kostnadsbesparingar, Tillv�xt

    private void Start()
    {
        IncomeStatement = GetComponent<incomeStatement>();
        CostCuttingManager = GetComponent<costCuttingManager>();
        DivPolicyPrefab = GetComponent<divPolicyPrefab>();
        ProductHolder = GetComponent<productHolder>();
        prioritiseFromBoard();
    }

    //Hur stor vikt som l�ggs p� olika delar fr�n ledningen
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
        andelTillv�xt = prioritiseList[i];
        //Debug.Log("Growth: " + prioritiseList[i]);

        normalizeManagementPriorites();
    }

    //Resultat att f�rdela
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
        getResult();//H�mtar �rets resultat
        normalizeManagementPriorites(); //Kontrollerar s� inte 100% �verskrids

        //Investerar i �tg�rder som minskar kostnader
        CostCuttingManager.investeringInCostCutting(resultThisYear * andelEffekiviseringar);

        dividendPayoutOfResult();

        //Investerar i att �ka antalet s�lda enheter
        ProductHolder.investInGrowth(resultThisYear * andelTillv�xt, 0);

        //Investerar i FoU f�r att f�rb�ttra produkt
        ProductHolder.addExpericenToProduct(resultThisYear * andelFoU, 0);
    }

    //Kontrollera s� inte utdelning, FoU, Kostnadsbesparingar och Tillv�xt �verstiger resultatet (100% av resultat)
    public void normalizeManagementPriorites()
    {
        sumAllOfMangementPriorites = dividendShareOfResult + andelFoU + andelEffekiviseringar + andelTillv�xt;
        dividendShareOfResult = dividendShareOfResult / sumAllOfMangementPriorites;
        andelFoU = andelFoU / sumAllOfMangementPriorites;
        andelEffekiviseringar = andelEffekiviseringar / sumAllOfMangementPriorites;
        andelTillv�xt = andelTillv�xt / sumAllOfMangementPriorites;
    }

}

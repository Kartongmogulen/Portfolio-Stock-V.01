using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managementPriorites_FisherCompany : MonoBehaviour
{
    //Vad prioriterar Ledningen att int�kterna ska anv�ndas till
    public bool randomizedPriorites;
    public float dividendShareOfResult; //Andel av resultatet som g�r till utdelning
    public float employeesOfResult; //Andel av resultatet som l�ggs p� att anst�lla fler
    public float rodOfResult; //Andel av resultatet som l�ggs p� att k�pa fiskesp�n
    public float boatOfResult; //Andel av resultatet som l�ggs p� att k�pa b�tar

    public float employeesHireAmount;
    public float fishingRodAmount;
    public float boatInvestAmount;

    /*public float andelFoU; //Andel som l�ggs p� FoU, lvl upp produkt;
    public float andelEffekiviseringar; //Andel som g�r till effektivisering f�r att s�nka kostnader
    public float andelTillv�xt; //Andel som l�ggs f�r att �ka antalet enheter s�lda;
    */

    //Prioritering inom ledning
    [SerializeField] List<float> prioritiseList;//Lista med v�rden som avg�r prioritering av ledningen

    [SerializeField] float resultThisYear;

    public incomeStatement IncomeStatement;
    //public costCuttingManager CostCuttingManager;
    public divPolicyPrefab DivPolicyPrefab;
    //public productHolder ProductHolder;

    [SerializeField] float sumAllOfMangementPriorites; //Summan av utdelninsandel, FoU, Kostnadsbesparingar, Tillv�xt

    private void Awake()
    {
        IncomeStatement = GetComponent<incomeStatement>();
        //CostCuttingManager = GetComponent<costCuttingManager>();
        DivPolicyPrefab = GetComponent<divPolicyPrefab>();
        //ProductHolder = GetComponent<productHolder>();

        if (randomizedPriorites == true)
        {
            prioritiseFromBoard();
        }
    }

    //Hur stor vikt som l�ggs p� olika delar fr�n ledningen
    public void prioritiseFromBoard()
    {
        int i = Random.Range(0, prioritiseList.Count);
        dividendShareOfResult = prioritiseList[i];
        //Debug.Log("Utdelning: " + prioritiseList[i]);

        i = Random.Range(0, prioritiseList.Count);
        employeesOfResult = prioritiseList[i];
        //Debug.Log("FoU: " + prioritiseList[i]);

        i = Random.Range(0, prioritiseList.Count);
        rodOfResult = prioritiseList[i];
        //Debug.Log("CostCutting: " + prioritiseList[i]);

        i = Random.Range(0, prioritiseList.Count);
        boatOfResult = prioritiseList[i];
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
        DivPolicyPrefab.saveDividendHistory();
    }

    public void allocateCapital()
    {
        Debug.Log("Allokera kapital");
       
            getResult();//H�mtar �rets resultat
            normalizeManagementPriorites(); //Kontrollerar s� inte 100% �verskrids

            //Investerar i att anst�lla
            employeesHireAmount = employeesOfResult * resultThisYear;
            //Debug.Log("Pengar f�r att anst�lla: " + employeesHireAmount);

            //Utdelning
            dividendPayoutOfResult();

            //Investera i fiskesp�n
            fishingRodAmount = rodOfResult * resultThisYear;

            //Investerar i b�tar
            boatInvestAmount = boatOfResult * resultThisYear;
       
    }

    //Kontrollera s� inte utdelning, FoU, Kostnadsbesparingar och Tillv�xt �verstiger resultatet (100% av resultat)
    public void normalizeManagementPriorites()
    {
        
        sumAllOfMangementPriorites = dividendShareOfResult + employeesOfResult + rodOfResult + boatOfResult;
        dividendShareOfResult = dividendShareOfResult / sumAllOfMangementPriorites;
        employeesOfResult = employeesOfResult / sumAllOfMangementPriorites;
        rodOfResult = rodOfResult / sumAllOfMangementPriorites;
        boatOfResult = boatOfResult / sumAllOfMangementPriorites;
        
    }

}

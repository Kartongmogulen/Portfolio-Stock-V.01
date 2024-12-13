using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managementPriorites_FisherCompany : MonoBehaviour
{
    //Vad prioriterar Ledningen att intäkterna ska användas till
    public bool randomizedPriorites;
    public float dividendShareOfResult; //Andel av resultatet som går till utdelning
    public float employeesOfResult; //Andel av resultatet som läggs på att anställa fler
    public float rodOfResult; //Andel av resultatet som läggs på att köpa fiskespön
    public float boatOfResult; //Andel av resultatet som läggs på att köpa båtar

    public float employeesHireAmount;
    public float fishingRodAmount;
    public float boatInvestAmount;

    /*public float andelFoU; //Andel som läggs på FoU, lvl upp produkt;
    public float andelEffekiviseringar; //Andel som går till effektivisering för att sänka kostnader
    public float andelTillväxt; //Andel som läggs för att öka antalet enheter sålda;
    */

    //Prioritering inom ledning
    [SerializeField] List<float> prioritiseList;//Lista med värden som avgör prioritering av ledningen

    [SerializeField] float resultThisYear;

    public incomeStatement IncomeStatement;
    //public costCuttingManager CostCuttingManager;
    public divPolicyPrefab DivPolicyPrefab;
    //public productHolder ProductHolder;

    [SerializeField] float sumAllOfMangementPriorites; //Summan av utdelninsandel, FoU, Kostnadsbesparingar, Tillväxt

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

    //Hur stor vikt som läggs på olika delar från ledningen
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

    //Resultat att fördela
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
       
            getResult();//Hämtar årets resultat
            normalizeManagementPriorites(); //Kontrollerar så inte 100% överskrids

            //Investerar i att anställa
            employeesHireAmount = employeesOfResult * resultThisYear;
            //Debug.Log("Pengar för att anställa: " + employeesHireAmount);

            //Utdelning
            dividendPayoutOfResult();

            //Investera i fiskespön
            fishingRodAmount = rodOfResult * resultThisYear;

            //Investerar i båtar
            boatInvestAmount = boatOfResult * resultThisYear;
       
    }

    //Kontrollera så inte utdelning, FoU, Kostnadsbesparingar och Tillväxt överstiger resultatet (100% av resultat)
    public void normalizeManagementPriorites()
    {
        
        sumAllOfMangementPriorites = dividendShareOfResult + employeesOfResult + rodOfResult + boatOfResult;
        dividendShareOfResult = dividendShareOfResult / sumAllOfMangementPriorites;
        employeesOfResult = employeesOfResult / sumAllOfMangementPriorites;
        rodOfResult = rodOfResult / sumAllOfMangementPriorites;
        boatOfResult = boatOfResult / sumAllOfMangementPriorites;
        
    }

}

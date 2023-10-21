using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stocksPlayerKnow : MonoBehaviour
{
    // Aktier spelaren känner till
    public List<bool> utiStocks;
    public List<bool> techStocks;
    public List<int> unknownCompanies;
    public List<GameObject> buttonsCompany;
    [SerializeField] int numberOfUnknownCompanies;
    [SerializeField] int numberOfUnknownCompaniesUti;

    [SerializeField] int calcIndex; //Endast i beräkningar för looper
                                    //[SerializeField] List<int> falseIndexes;

    public saveIndexFalseValuesFromList SaveIndexFalseValues;


    private void Start()
    {
        //utiStocksKnown();
        //techStocksKnown();
        unknownLeftNumber();
        //unlockNewCompany();
    }

    public void utiStocksKnown()
    {
        for (int i = 0; utiStocks.Count > i; i++)
        {
            if (utiStocks[i] == true)
            {
                buttonsCompany[i].SetActive(true);
            }
            else
            {
                buttonsCompany[i].SetActive(false);
            }
        }               
    }

    public void techStocksKnown()
    {
        for (int i = 0; techStocks.Count > i; i++)
        {
            if (techStocks[i] == true)
            {
                buttonsCompany[i].SetActive(true);
            }
            else
            {
                buttonsCompany[i].SetActive(false);
            }
        }
    }

    public void unlockNewCompany()
    {
        unknownLeftNumber();
        Debug.Log("Unlock new Company!");
        calcIndex = 0;

        {
            int index = Random.Range(0, numberOfUnknownCompanies);
            //int index = 5;
            Debug.Log("index: " + index);
            //Debug.Log("Unkown companies: " + numberOfUnknownCompanies);

            if (numberOfUnknownCompaniesUti > index)
            {
                List<int> resultFalseValues = new List<int>();
                resultFalseValues = SaveIndexFalseValues.getIndexFalseValues(utiStocks);
                utiStocks[resultFalseValues[index]] = true;
            }

            else
            {
                List<int> resultFalseValues = new List<int>();
                resultFalseValues = SaveIndexFalseValues.getIndexFalseValues(techStocks);
                techStocks[resultFalseValues[index - numberOfUnknownCompaniesUti]] = true;
            }
        } 

    }
              

    public void unknownLeftNumber()
    {
        numberOfUnknownCompanies = 0;
        numberOfUnknownCompaniesUti = 0;

        for (int i = 0; utiStocks.Count > i; i++)
        {
            if (utiStocks[i] == false)
            {
                numberOfUnknownCompanies++;
                numberOfUnknownCompaniesUti++;
            }
        }

        for (int i = 0; techStocks.Count > i; i++)
        {
            if (techStocks[i] == false)
            {
                numberOfUnknownCompanies++;
            }
        }
    }

    public int getUnknownCompianesLeft()
    {
        return numberOfUnknownCompanies;
    }

}

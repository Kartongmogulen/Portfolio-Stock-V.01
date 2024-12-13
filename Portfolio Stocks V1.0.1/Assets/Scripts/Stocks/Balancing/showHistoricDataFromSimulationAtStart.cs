using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHistoricDataFromSimulationAtStart : MonoBehaviour
{
    //Visualisera data efter simulering från start

    public List<GameObject> stocks;
    public List<GameObject> stocksWithProducts;
    public List<Text> nameCompany;
    public List<Text> priceAppreciation;
    public List<Text> priceVolatility;

    //Företag med Products
    public List<Text> nameCompany_Products;
    public List<Text> priceAppreciation_Products;
    public List<Text> priceVolatility_Products;

    private void Start()
    {
        showName();
        //Invoke("priceAppreciationShow",0.2f); //KOMMENTERADE BORT FÖR ATT BUGGSÖKA DÅ FELMEDDELANDE ANNARS DÖK UPP VID START
        Invoke("volatilityPriceShow",0.2f);
    }

    public void showName()
    {
        nameCompany[0].text = "Name Company: ";
        for (int i = 1; i < nameCompany.Count;i++)
        {
            nameCompany[i].text = stocks[i-1].GetComponent<stock>().nameOfCompany;
        }

        if(stocksWithProducts.Count == 0)
        {
            return;
        }
        nameCompany_Products[0].text = "Name Company: ";
        for (int i = 1; i < nameCompany_Products.Count; i++)
        {
            nameCompany_Products[i].text = stocksWithProducts[i - 1].GetComponent<stockInformation>().nameCompany;
        }
        
    }

    public void priceAppreciationShow()
    {
        priceAppreciation[0].text = "Price Change (%): ";
        for (int i = 1; i < priceAppreciation.Count; i++)
        {
            //Debug.Log("i: " + i);
            float priceStart = stocks[i - 1].GetComponent<stock>().StockPrice[0];
            float priceEnd = stocks[i - 1].GetComponent<stock>().StockPrice[stocks[i - 1].GetComponent<stock>().StockPrice.Count - 1];
            //Debug.Log("Startingprice: " + priceStart);
            //Debug.Log("Endprice: " + priceEnd);
            float percentChangeStockPrice = changePercent(priceStart, priceEnd);

            priceAppreciation[i].text = "" + Mathf.Round((percentChangeStockPrice) * 100) + "%";
        }

        //Om det inte finns några bolag med Produkter-mekanik avslutas scriptet
        if (stocksWithProducts.Count == 0)
        {
            return;
        }
        priceAppreciation_Products[0].text = "Price Change (%): ";

        for (int i = 1; i < priceAppreciation_Products.Count; i++)
        {
            float priceStart = stocksWithProducts[i - 1].GetComponent<priceStock>().StockPrice[13];
            float priceEnd = stocksWithProducts[i - 1].GetComponent<priceStock>().StockPrice[stocksWithProducts[i - 1].GetComponent<priceStock>().StockPrice.Count - 1];

            float percentChangeStockPrice = changePercent(priceStart, priceEnd);
            priceAppreciation_Products[i].text = "" + Mathf.Round((percentChangeStockPrice) * 100) + "%";

        }
    }

    public void volatilityPriceShow()
    {
        priceVolatility[0].text = "Price Volatility (%): ";

        for (int i = 1; i < priceVolatility.Count; i++)
        {
            priceVolatility[i].text = "" + Mathf.Round(stocks[i-1].GetComponent<stock>().volatilityPercent * 10000)/100 + "%";
        }

        //Om det inte finns några bolag med Produkter-mekanik avslutas scriptet
        if (stocksWithProducts.Count == 0)
        {
            return;
        }
        priceVolatility_Products[0].text = "Price Volatility (%): ";

        for (int i = 1; i < priceVolatility_Products.Count; i++)
        {
            priceVolatility_Products[i].text = "" + Mathf.Round(stocksWithProducts[i - 1].GetComponent<priceStock>().getVolatilityPercent() * 10000) / 100 + "%";
        }

    }

    public float changePercent(float valueStart,float valueEnd)
    {
        return valueEnd / valueStart - 1;
    }
}

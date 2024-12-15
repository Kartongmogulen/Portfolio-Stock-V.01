using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stockPriceManager : MonoBehaviour
{
    public GameObject ScriptsStockGO;
    public GameObject StockMarketGO;

    public stockMarketManager StockMarketManager;
    public stockMarketManager_1850 StockMarketManager_1850;

    public GameObject stockSector_1;

    public GameObject stockScript;
    public DCF dcfCalculation;

    public float priceNow;

    private MarketDataProvider _marketDataProvider;
    private PriceCalculator _priceCalculator;
    private MarketTrendManager _marketTrendManager;

    [Header("Refactor")]
    // Initiala marknadsparametrar
    [SerializeField] float initialPremium; // = 0.05f; // 5%
    [SerializeField] float initialRiskFreeRate; // = 0.02f; // 2%
    [SerializeField] float volatility; // = 0.01f; // 1%

    public List<GameObject> Companies; // Lista över företag (GameObjects)

    private void Awake()
    {
        StockMarketManager = StockMarketGO.GetComponent<stockMarketManager>();
        _marketTrendManager = GetComponent<MarketTrendManager>();
    }

    public void Start()
    {
        //updateStockMarketPrice();
        _marketDataProvider = new MarketDataProvider(initialPremium, initialRiskFreeRate, volatility);
        _priceCalculator = new PriceCalculator(_marketDataProvider);
        // Testa en aktie
        //TestPriceCalculation();

        // Initialisera företag
        InitializeCompanies();

        // Testkör första rundan
        updateStockMarketPrice();
    }



    void TestPriceCalculation()
    {
        float eps = 2f; // Företagets vinst per aktie
        float growthRate = 0.1f; // Tillväxttakt (10%)
        int period = 10; // Period i år

        float price = _priceCalculator.CalculateDCFPrice(eps, growthRate, period);
        Debug.Log("Beräknat aktiepris: " + price);
    }

    public void UpdateMarket(float newPremium, float newRiskFreeRate)
    {
        _marketDataProvider.UpdateMarketConditions(newPremium, newRiskFreeRate);
        Debug.Log("Marknadsvillkor uppdaterade.");
    }

    void InitializeCompanies()
    {
        foreach (var companyGO in Companies)
        {
            var company = companyGO.GetComponent<stock>();
            if (company != null)
            {
                company.Initialize(_priceCalculator, _marketTrendManager);

                // Exempeldata för test
                //company.EPS = Random.Range(1f, 5f); // Slumpmässig EPS
                //company.GrowthRate = Random.Range(0.05f, 0.2f); // Tillväxt mellan 5% och 20%
                //company.ForecastPeriod = 10; // Prognos för 10 år
                //company.Sector = Random.Range(0, 2) == 0 ? "Railroad" : "Mine"; // Exempel: Tech eller Finance
            }
        }
    }
        
    public void updateStockMarketPrice()
        {

        Debug.Log("Updatera priser");
            foreach (var companyGO in Companies)
            {
                var company = companyGO.GetComponent<stock>();
                if (company != null)
                {
                    company.UpdatePrice();
                }
            }

            /// <summary>
            /// INNAN REFACTOR MED CHATGPT
            /// </summary>
            ///   

            /*
            public void updateStockMarketPrice()
        {
      
        for (int i = 0; i < StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++) {
            priceNow = ScriptsStockGO.GetComponent<priceChange>().DCFbasedPriceTest(StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i]);
            StockMarketManager.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i].StockPrice.Add(priceNow);
        }

        for (int i = 0; i < StockMarketManager_1850.StockMarketListGO.GetComponent<stockMarketInventory>().Stock.Count; i++)
        {
            //Debug.Log("Price manager: " + i);
            priceNow = ScriptsStockGO.GetComponent<priceChange>().DCFbasedPriceTest(StockMarketManager_1850.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i]);
            StockMarketManager_1850.StockMarketListGO.GetComponent<stockMarketInventory>().Stock[i].StockPrice.Add(priceNow);
        }

        for (int i = 0; i < StockMarketManager_1850.StockPrefabListIndustri.Count; i++)
        {
            //Debug.Log("Price manager: " + i);
            if (StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<incomeStatement>() != null)
            {
                priceNow = ScriptsStockGO.GetComponent<priceChange>().DCFbasedPrice_OneCompany_IncomeStatement(StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<incomeStatement>());
                StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().StockPrice.Add(priceNow);
            }
            else
            {
                priceNow = ScriptsStockGO.GetComponent<priceChange>().DCFbasedPriceTest(StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stock>());
                //StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stock>().StockPrice.Add(priceNow);
            }
                //Debug.Log("Pris nu: " + priceNow);
            //StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().StockPrice.Add(priceNow);
           
        }
      */
        }


        public void priceUpdate_RevenueGrowth()
    {
        //Debug.Log("PriceUpdate_RevenueGrowth");
        for (int i = 0; i < StockMarketGO.GetComponent<stockMarketInventory>().masterList.Count; i++)
        {
            int priceNowTotalCompany = ScriptsStockGO.GetComponent<priceChange>().DCFbasedPrice_HistoricRevenueGrowth(StockMarketGO.GetComponent<stockMarketInventory>().masterList[i].GetComponent<incomeStatement>());
            //Debug.Log("PRIS: " + priceNowTotalCompany);
            //Debug.Log("Antal aktier: " + StockMarketGO.GetComponent<stockMarketInventory>().masterList[i].GetComponent<stockInformation>().getNumberOfShares());
            int priceNow = priceNowTotalCompany / StockMarketGO.GetComponent<stockMarketInventory>().masterList[i].GetComponent<stockInformation>().getNumberOfShares();
            StockMarketGO.GetComponent<stockMarketInventory>().masterList[i].GetComponent<priceStock>().StockPrice.Add(priceNow);
        }
    }
}

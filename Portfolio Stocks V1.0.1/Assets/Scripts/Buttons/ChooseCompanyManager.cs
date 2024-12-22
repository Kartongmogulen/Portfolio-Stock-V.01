using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Huvudklassen som hanterar val av företag
public class ChooseCompanyManager : MonoBehaviour, ICompanyChooser
{
    [SerializeField] private CityManager cityManager;
    [SerializeField] private activeSector_1850 ActiveSectorManager;
    [SerializeField] private SectorDataProvider sectorDataProvider;
    [SerializeField] private DividendUIUpdater dividendUIUpdater;
    [SerializeField] private KeyDataUiUpdater keyDataUiUpdater;

    private void Start()
    {
        chosseCompanyButton();
    }

    public void ChooseCompany(int cityIndex, int sectorIndex)
    {
        List <GameObject> stockMarketSector = sectorDataProvider.GetStockMarketSector(sectorIndex);
        if (stockMarketSector == null || stockMarketSector.Count <= cityIndex) return;

        GameObject selectedCompany = stockMarketSector[cityIndex];
        float stockPrice = sectorDataProvider.GetStockPrice(selectedCompany);
        float dividendPayout = sectorDataProvider.GetDividendPayout(selectedCompany);
        float payoutRatioOnEPS = sectorDataProvider.GetPayoutRatioOnEPS(selectedCompany);

        float dividendYield = dividendPayout / stockPrice;
        //Debug.Log("Dir.avk: " + dividendYield);
        dividendUIUpdater.UpdateDividendUI(dividendYield, dividendPayout, payoutRatioOnEPS);

        updateUIKeyData(selectedCompany);
    }

    public void updateUIKeyData(GameObject selectedCompany)
    {
        float earningsPerShare = selectedCompany.GetComponent<stock>().EPSnow;
        float priceEarnings = selectedCompany.GetComponent<stock>().CurrentPrice/ earningsPerShare;


        keyDataUiUpdater.UpdateKeyDataUI(priceEarnings, earningsPerShare);
    }

    public void chosseCompanyButton()
    {
        int cityIndex = cityManager.activeCity;
        int sectorIndex = ActiveSectorManager.getActiveSector();
        ChooseCompany(cityIndex, sectorIndex);
    }

}

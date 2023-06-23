using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bondMaturityCheck : MonoBehaviour
{
    // Kontrollerar om r�ntepappret har uppn�tt slutdatum
    public bondsPortfolio BondsPortfolio;
    public totalCash TotalCash;
    public bondMarketManager BondMarketManager;

    [SerializeField] private float amountBonds;
    [SerializeField] private float valueBonds;

    public void checkIfMaturePassed()
    {
        
        checkOneYearBonds();
        checkFiveYearBonds(1);
    }

    public void checkOneYearBonds()
    {
        if (BondsPortfolio.bondsOwned1Year.Count-1 < 12 * BondMarketManager.bondMarketListGO[0].GetComponent<bondInfoPrefab>().duration)
        {
            Debug.Log("12 m�n har ej passerat");
            return; 
        }
        else
        {
            amountBonds = BondsPortfolio.bondsOwned1Year[BondsPortfolio.bondsOwned1Year.Count - 13];
            Debug.Log("Antal Korta r�ntor: " + amountBonds);
            valueBonds = amountBonds * BondMarketManager.bondMarketListGO[0].GetComponent<bondInfoPrefab>().costBond;
            //TotalCash.incomeBonds(valueBonds * BondMarketManager.bondMarketListGO[0].GetComponent<bondInfoPrefab>().rate / 100);
            BondsPortfolio.removeBondsFromListWhenMature(0);
            TotalCash.sellBonds(valueBonds);
            //BondsPortfolio.bondsOwned1Year[BondsPortfolio.bondsOwned1Year.Count-12]
        }
    }

    public void checkFiveYearBonds(int bondInt)
    {
        if (BondsPortfolio.bondsOwned5Year.Count - 1 < 12 * BondMarketManager.bondMarketListGO[bondInt].GetComponent<bondInfoPrefab>().duration)
        {
            Debug.Log("60 m�n har ej passerat");
            return;
        }

        else
        {
            Debug.Log("60 m�n HAR passerat");
            amountBonds = BondsPortfolio.bondsOwned5Year[BondsPortfolio.bondsOwned5Year.Count - Mathf.RoundToInt(12 * BondMarketManager.bondMarketListGO[bondInt].GetComponent<bondInfoPrefab>().duration + 1)];
            Debug.Log("Antal L�nga r�ntor: " + amountBonds);
            valueBonds = amountBonds * BondMarketManager.bondMarketListGO[bondInt].GetComponent<bondInfoPrefab>().costBond;
            Debug.Log("V�rde L�nga r�ntor: " + valueBonds);
            //TotalCash.incomeBonds(valueBonds * BondMarketManager.bondMarketListGO[bondInt].GetComponent<bondInfoPrefab>().rate / 100);
            BondsPortfolio.removeBondsFromListWhenMature(bondInt);
            TotalCash.sellBonds(valueBonds);
        }
    }


}

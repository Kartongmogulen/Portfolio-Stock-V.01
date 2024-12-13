using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bondMaturityCheck : MonoBehaviour
{
    // Kontrollerar om r�ntepappret har uppn�tt slutdatum
    public bondsPortfolio BondsPortfolio;
    public totalCash TotalCash;
    public bondMarketManager BondMarketManager;
    public GameObject bondsScriptsGO;

    [SerializeField] private float amountBonds;
    [SerializeField] private float valueBonds;

    //Kontrollerar om r�ntepappret ska l�sas in och tar sedan bort den ur listan f�r �gda r�ntor
    public void checkIfMaturePassed()
    {
        
        checkOneYearBonds();
        checkFiveYearBonds(1);
    }

    public void checkOneYearBonds()
    {
        if (BondsPortfolio.bondsOwned1Year.Count-1 < 12 * BondMarketManager.bondMarketListGO[0].GetComponent<bondInfoPrefab>().duration)
        {
            //Debug.Log("12 m�n har ej passerat");
            return; 
        }
        else
        {
            BondsPortfolio.removeBondsFromListWhenMature(0);
        }
    }

    public void checkFiveYearBonds(int bondInt)
    {
        
        if (BondsPortfolio.bondsOwned5Year.Count - 1 < 12 * BondMarketManager.bondMarketListGO[bondInt].GetComponent<bondInfoPrefab>().duration)
        {
            //Debug.Log("60 m�n har ej passerat");
            return;
        }

        else
        {
            BondsPortfolio.removeBondsFromListWhenMature(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valuePortfolio : MonoBehaviour
{
	public float totalValueSector;
	public float valueSector(List<float> companySharesOwned, List<stock> stockList)
	{
		totalValueSector = 0;

		for (int i = 0; i < companySharesOwned.Count; i++)
		{
			totalValueSector += stockList[i].StockPrice[stockList[i].StockPrice.Count-1] * companySharesOwned[i];
			//Debug.Log("ValueStock-script loop" + totalValueSector);
		}

		return totalValueSector;
	}

	public float valueSectorGameObjects(List<float> companySharesOwned, List<GameObject> stockList)
	{
		totalValueSector = 0;

		for (int i = 0; i < companySharesOwned.Count; i++)
		{
			totalValueSector += stockList[i].GetComponent<stock>().StockPrice[stockList[i].GetComponent<stock>().StockPrice.Count-1] * companySharesOwned[i];
			//Debug.Log("ValueStock-script loop" + totalValueSector);
		}

		return totalValueSector;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnPortfolio : MonoBehaviour
{
	//List<stock> stockList;
	//List<float> stockListGAV;
	public List<float> stockListReturn;

	private float priceNow;
	float totalReturnAmount;

	public List<float> returnStocksPercent(List<stock> stockList, List<float> stockListGAV)
	{


		//Avkastning per företag
		for (int i = 0; i < stockList.Count; i++)
		{
			priceNow = stockList[i].StockPrice[stockList[i].StockPrice.Count - 1];
			stockListReturn[i] = (priceNow / stockListGAV[i]);
		}
		return stockListReturn;
	}

	public	float returnSector(List<stock> stockList, List<float> stockListGAV, List<float> sharesOwned)
		{
		totalReturnAmount = 0;

			for (int i = 0; i < stockList.Count; i++)
			{
				priceNow = stockList[i].StockPrice[stockList[i].StockPrice.Count - 1];
				totalReturnAmount += (sharesOwned[i] * priceNow) - (sharesOwned[i]*stockListGAV[i]);
				Debug.Log("Total return: " + totalReturnAmount);
		}

		return totalReturnAmount;

		
	}


}

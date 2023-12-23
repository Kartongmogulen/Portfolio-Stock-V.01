using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incomeStatement : MonoBehaviour
{
	public float moneyTest; //För Test

	[SerializeField] List<float> revenue;
	[SerializeField] List<float> cost;

	
	public float EarningPerShareNow;
	public List<float> EarningPerShareHistory;
	public float EarningPerShareGrowth;

	public costCuttingManager CostCuttingManager;
	//public float EPSGrowthMin;
	//public float EPSGrowthMax;

	/*
public void revenueCalculation(float revenue, float cost, float amount)
{
	EarningPerShareNow = (revenue * amount) - (cost * amount);
}
*/

	private void Start()
	{
		CostCuttingManager = GetComponent<costCuttingManager>();
	}

	public void revenueFromProduct (productInfo ProductInfo)
	{
		float costPerUnit = ProductInfo.cost[ProductInfo.lvlProduct] - CostCuttingManager.lvlNow; //Minskar kostnaden/enhet per lvl
		Debug.Log("Cost per unit: " + costPerUnit);
		revenue.Add(ProductInfo.revenue[ProductInfo.lvlProduct] * ProductInfo.amountSoldNow);
		cost.Add(costPerUnit * ProductInfo.amountSoldNow);
		EarningPerShareHistory.Add(revenue[revenue.Count - 1] - cost[cost.Count - 1]);
		Debug.Log("EPS: " + EarningPerShareNow);
		//return EarningPerShareNow;
		
	}
	
}

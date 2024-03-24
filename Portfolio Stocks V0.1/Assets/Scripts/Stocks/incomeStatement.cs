using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incomeStatement : MonoBehaviour
{
	public float moneyTest; //För Test

	[SerializeField] List<float> revenue;
	[SerializeField] List<float> cost;

	
	public float EarningPerShareStart;
	[SerializeField] float EarningsPerShareNow;
	public List<float> EarningPerShareHistory;
	public List<float> EarningHistory;
	public float EarningPerShareGrowth;

	public costCuttingManager CostCuttingManager;
	public productHolder ProductHolder;
	public stockInformation StockInformation;
	//public float EPSGrowthMin;
	//public float EPSGrowthMax;

	/*
public void revenueCalculation(float revenue, float cost, float amount)
{
	EarningPerShareNow = (revenue * amount) - (cost * amount);
}
*/

	private void Awake()
	{
		EarningPerShareHistory.Add(EarningPerShareStart);
		CostCuttingManager = GetComponent<costCuttingManager>();
		ProductHolder = GetComponent<productHolder>();
		StockInformation = GetComponent<stockInformation>();
		//Debug.Log("IncomeStatement: " + name);
		//EarningPerShareHistory.Add(0);//För att annat ska funka
	}

	public float getEarningsPerShareNow()
	{
		EarningsPerShareNow = EarningPerShareHistory[EarningPerShareHistory.Count - 1];
		return EarningsPerShareNow;
	}

	public void revenueFromProduct (productInfo ProductInfo)
	{
		//Debug.Log("Intäkter från produkt");
		
		float costPerUnit = ProductInfo.cost[ProductInfo.lvlProduct] - CostCuttingManager.lvlNow; //Minskar kostnaden/enhet per lvl
		//Debug.Log("Kostnad per produkt: " + costPerUnit);

		revenue.Add(ProductInfo.revenue[ProductInfo.lvlProduct] * ProductHolder.getAmountSold(0));
		cost.Add(costPerUnit * ProductHolder.getAmountSold(0));
		EarningHistory.Add(revenue[revenue.Count - 1] - cost[cost.Count - 1]);
		EarningPerShareHistory.Add(EarningHistory[EarningHistory.Count - 1] / StockInformation.getNumberOfShares());

		//Debug.Log("EPS: " + EarningPerShareNow);
		//return EarningPerShareNow;

	}

	public void revenue_AddOwnAmount(int revenueToAdd)
	{
		revenue.Add(revenueToAdd);
	}

	public void cost_AddOwnAmount(int costToAdd)
	{
		cost.Add(costToAdd);
	}

	public void addEarningsPerShareToHistory()
	{
		EarningPerShareHistory.Add(EarningHistory[EarningHistory.Count - 1] / StockInformation.getNumberOfShares());
	}

	public List<float> getRevenue()
	{
		return revenue;
	}

	public List<float> getCost()
	{
		return cost;
	}

}

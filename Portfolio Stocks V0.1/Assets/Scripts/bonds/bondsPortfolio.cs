using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bondsPortfolio : MonoBehaviour
{
	public GameObject bondsPanel;
	public GameObject bottomPanel;

	public int[] bondsOwned;
	public List<int> bondsOwned1Year;//Hur många räntepapper som ägs för denna duration
	public List<int> bondsOwned5Year;//Hur många räntepapper som ägs för denna duration
	public float totalValueBonds;
	public float totalBondsInvest;
	[SerializeField] private float totalBondsInvestLifetime;
	public float bondsGAVOne;
	public float cashFlowBondsNow;

	public Text cashFlowBondsNowText;

	private void Start()
	{
		addPlaceInList();
	}

	public void addBonds(int nrBond){
		
		if (nrBond == 0)
			bondsOwned1Year[bondsOwned1Year.Count - 1]++;
		
		if (nrBond == 1)
			bondsOwned5Year[bondsOwned1Year.Count - 1]++;

		bondsOwned[nrBond]++;
		bondsOwnedTotal();
		valueBondPort();

	}

	public void bondsOwnedTotal()
	{
		//Nollställer antalet innan summering
		for (int i = 0; i < bondsOwned.Length-1;i++)
		{
			bondsOwned[i] = 0;
		}
		//Debug.Log("Korta räntor antal (ska vara noll): " + bondsOwned[0]);
		//Debug.Log("Långa räntor antal (ska vara noll): " + bondsOwned[1]);

		//Summerar antalet 
		foreach (int nummer in bondsOwned1Year)
		{
			bondsOwned[0] += nummer;
		}

		foreach (int nummer in bondsOwned5Year)
		{
			bondsOwned[1] += nummer;
		}

		//Debug.Log("Korta räntor antal (ska vara korrekt): " + bondsOwned[0]);
		//Debug.Log("Långa räntor antal (ska vara korrekt): " + bondsOwned[1]);
	}

	public void addPlaceInList()
	{
		bondsOwned1Year.Add(0);
		bondsOwned5Year.Add(0);
	}

	public void removeBondsFromListWhenMature(int bondOrderNumb)
	{
		if (bondOrderNumb == 0)
		bondsOwned1Year.RemoveAt(0);
		if (bondOrderNumb == 1)
		bondsOwned5Year.RemoveAt(0);
	}

	public void sellBonds(int nrBond){
		//nrBond--;
		//bondsOwned[nrBond] = bondsOwned[nrBond] - 1;

		valueBondPort();
	}

	public void valueBondPort(){
		totalValueBonds = bondsOwned[0]*bondsPanel.GetComponent<buyBonds>().costBond;
	}

	public void bondsGAV(float cost){
		
		bondsGAVOne = totalBondsInvest / bondsOwned [0];
		if (bondsOwned [0] == 0) {
			bondsGAVOne = 0;
		}
	}

	public void cashFlowBondsAdd(float addCashFlow)
	{
		Debug.Log("Utökar cashflow från räntor med: " + addCashFlow);
		//cashFlowBondsNow = cashFlowBondsNow + bottomPanel.GetComponent<BondSelectedInfoButton>().cashflow[0];
		cashFlowBondsNow += addCashFlow;

		cashFlowBondsNowText.text = "Bonds/Year: " + cashFlowBondsNow;
	}

	public void cashFlowBondsRemove()
	{
		cashFlowBondsNow = cashFlowBondsNow - bottomPanel.GetComponent<BondSelectedInfoButton>().cashflow[0];

		cashFlowBondsNowText.text = "Bonds/Year: " + cashFlowBondsNow;
	}

	public void bondsTotalInvest(float cost){

		totalBondsInvest = totalBondsInvest + cost;
		//Debug.Log("Totalt investerat i räntor, löpande: " + totalBondsInvestLifetime);
		if (totalBondsInvest < 0) {
			totalBondsInvest = 0;
		}

		if (cost > 0)
			totalBondsInvestLifetime += cost;
	}

	public float getTotalBondsInvestedLifetime()
	{
		return totalBondsInvestLifetime;
	}
}

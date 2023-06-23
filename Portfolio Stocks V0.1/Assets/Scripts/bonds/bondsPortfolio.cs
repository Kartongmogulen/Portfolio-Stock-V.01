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
	public float bondsGAVOne;
	public float cashFlowBondsNow;

	public Text cashFlowBondsNowText;

	private void Start()
	{
		addPlaceInList();
	}

	public void addBonds(int nrBond){
		//nrBond--;
		//bondsOwned[nrBond]++;
		if (nrBond == 0)
		bondsOwned1Year[bondsOwned1Year.Count-1]++;
		if(nrBond == 1)
		bondsOwned5Year[bondsOwned1Year.Count - 1]++;

		valueBondPort();

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

		if (totalBondsInvest < 0) {
			totalBondsInvest = 0;
		}

	}
}

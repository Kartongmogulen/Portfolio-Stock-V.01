using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bondsPortfolio : MonoBehaviour
{
	public GameObject bondsPanel;
	public GameObject bottomPanel;

	public int[] bondsOwned;
	public float totalValueBonds;
	public float totalBondsInvest;
	public float bondsGAVOne;
	public float cashFlowBondsNow;

	public Text cashFlowBondsNowText;

	public void addBonds(int nrBond){
		nrBond--;
		bondsOwned[nrBond] = bondsOwned[nrBond] + 1;

		valueBondPort();

	}

	public void sellBonds(int nrBond){
		nrBond--;
		bondsOwned[nrBond] = bondsOwned[nrBond] - 1;

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

	public void cashFlowBondsAdd()
	{
		cashFlowBondsNow = cashFlowBondsNow + bottomPanel.GetComponent<BondSelectedInfoButton>().cashflow[0];

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

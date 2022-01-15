using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyBonds : MonoBehaviour
{
	public GameObject bottomPanel;
	public GameObject playerPanelGO;

	public Text amountOwnedBondText;
	//public Text cashFlowBondsNowText;

	public int activeBond;
	public float costBond;
	public float moneyBefore;
	//public float[] bondsOwned;

	public float cashFlowBondsNow;

	public void buyBondsOne (){

		activeBond = bottomPanel.GetComponent<BondSelectedInfoButton>().activeBond;
		costBond = bottomPanel.GetComponent<BondSelectedInfoButton>().bondCost;
		//moneyBefore = playerPanelGO.GetComponent<totalCash>().moneyNow;

		if (costBond<=moneyBefore && activeBond==1) {

			playerPanelGO.GetComponent<bondsPortfolio>().addBonds(activeBond);
			//playerPanelGO.GetComponent<totalCash>().buyBonds(costBond);

			amountOwnedBondText.text = "Owned (amount): " + playerPanelGO.GetComponent<bondsPortfolio>().bondsOwned[activeBond-1];
			playerPanelGO.GetComponent<bondsPortfolio>().cashFlowBondsAdd();
		}
	}

	//public void cashFlowBonds()
	//{
		//cashFlowBondsNow = cashFlowBondsNow + bottomPanel.GetComponent<BondSelectedInfoButton>().cashflow[0];
		
		//cashFlowBondsNowText.text = "Bonds: " + cashFlowBondsNow;
	//}
		
}

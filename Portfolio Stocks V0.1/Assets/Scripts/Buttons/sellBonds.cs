using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sellBonds : MonoBehaviour
{
	public int activeBond;
	public float costBond;
	public float bondsOwned;
	//public float moneyBefore;

	public GameObject bottomPanel; 
	public GameObject playerPanelGO;

	public Text amountOwnedBondText;

	public void sellBondsOne (){

		activeBond = bottomPanel.GetComponent<BondSelectedInfoButton>().activeBond;
		costBond = bottomPanel.GetComponent<BondSelectedInfoButton>().bondCost;
		bondsOwned = playerPanelGO.GetComponent<bondsPortfolio>().bondsOwned[activeBond-1];

		if (bondsOwned > 0 && activeBond==1) {

			playerPanelGO.GetComponent<bondsPortfolio>().sellBonds(activeBond);
			//playerPanelGO.GetComponent<totalCash>().sellBonds(costBond);

			amountOwnedBondText.text = "Owned (amount): " + playerPanelGO.GetComponent<bondsPortfolio>().bondsOwned[activeBond-1];
			playerPanelGO.GetComponent<bondsPortfolio>().cashFlowBondsRemove();
		}


}
}

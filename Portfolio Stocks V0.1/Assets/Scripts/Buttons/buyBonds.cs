using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyBonds : MonoBehaviour
{
	public BondSelectedInfoButton bondSelectedInfoButton;
	public bondMarketManager BondMarketManager;
	public moneyManager MoneyManager;
	public bondsPortfolio BondsPortfolio;
	public totalCash TotalCash;

	private int activeBond;
	[SerializeField]
	private bool enoughMoneyBool;

	//____________________________
	public GameObject bottomPanel;
	public GameObject playerPanelGO;

	public Text amountOwnedBondText;
	//public Text cashFlowBondsNowText;

	
	public float costBond;
	public float moneyBefore;
	//public float[] bondsOwned;

	public float cashFlowBondsNow;

	public void buyBond()
	{
		activeBond = bondSelectedInfoButton.activeBond;
		costBond = BondMarketManager.bondMarketListGO[activeBond].GetComponent<bondInfoPrefab>().costBond;
		
		//Kontrollerar om spelaren har tillräckligt med pengar
		enoughMoneyBool = MoneyManager.enoughMoney(TotalCash.moneyNow, costBond);
		
		if (enoughMoneyBool == true)
		{
			//Adderar till portföljen
			BondsPortfolio.addBonds(activeBond);

			//Minskar spelaren pengar
			TotalCash.buyBonds(costBond);
		}
	}

//---------------------------------
//TIDIGARE SCRIPT
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

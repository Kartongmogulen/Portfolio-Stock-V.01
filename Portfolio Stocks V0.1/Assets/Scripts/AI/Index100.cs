using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Index100 : MonoBehaviour
{
	//Player who only invest in Index

	public GameObject playerPanelGO;
	public float startMoney;
	public float incomeFromWork;
	public float moneyNow;

	public GameObject StockScriptGO;
	public float indexFundNAV;

	public float amountToInvestThisRound;
	public float valueIndexPortfolio;
	public float newSharesThisRound;
	public float totalSharesPortfolio;
	public float totalValuePortfolio;
	public float totalInvestment;

	public Text strategyName;
	public Text valuePortfolioText;
	public Text returnPortfolioText;

	void Start (){

		strategyName.text = "Index: 100%";

		//startMoney = playerPanelGO.GetComponent<totalCash> ().moneyStart;
		//incomeFromWork = playerPanelGO.GetComponent<incomeWork> ().incomeWorkPerMonth; //Hämtar inkomst
		moneyNow = startMoney; //Hur mycket pengar spelaren har vid start
	}

		public void investIndex(){

		indexFundNAV = StockScriptGO.GetComponent<indexFunds> ().NAVIndexFund;
		//Debug.Log("Index NAV: " + indexFundNAV);
		//valuePortfolioText.text = "Value portfolio: " + valueIndexPortfolio;
		//incomeFromWork = playerPanelGO.GetComponent<incomeWork> ().workIncomeStart;
		moneyNow = moneyNow + incomeFromWork;

		amountToInvestThisRound = moneyNow;
		totalInvestment = totalInvestment + amountToInvestThisRound;
		moneyNow = moneyNow - amountToInvestThisRound;
		newSharesThisRound = amountToInvestThisRound / indexFundNAV;

		totalSharesPortfolio = totalSharesPortfolio + newSharesThisRound;

		totalValuePortfolio = totalSharesPortfolio * indexFundNAV;

		valuePortfolioText.text = "Value portfolio: " + totalValuePortfolio;

		returnPortfolioText.text = "Return: " + Mathf.Round((totalValuePortfolio / totalInvestment - 1)*10000)/100 + "%";
		}
}

	


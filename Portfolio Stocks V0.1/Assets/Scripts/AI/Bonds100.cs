using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonds100 : MonoBehaviour
{
    //Player who only invest in Bonds

	public float valueBondPortfolio;

	public GameObject playerPanelGO;
	public GameObject playerGO;
	public float startMoney;
	public float incomeFromWork;
	public float moneyNow;
	public float incomeBondsYearEnd;

	public GameObject bottomPanelGO;
	public float costBond;

	public int amountBonds;
	public float bondRate;

	public int errorInt; //För att räkna så inte looper håller på för alltid

	public Text strategyName;
	public Text valuePortfolioText;
	//public Text returnPortfolioText;

	void Start (){

		strategyName.text = "Bonds: 100%";

		//startMoney = playerPanelGO.GetComponent<totalCash> ().moneyStart;
		incomeFromWork = playerPanelGO.GetComponent<incomeWork> ().incomeWorkPerMonth;
		moneyNow = startMoney;
	}

	public void investBonds(){

		errorInt = 0;

		valuePortfolioText.text = "Value portfolio: " + valueBondPortfolio;
		incomeFromWork = playerGO.GetComponent<incomeWork> ().incomeWorkPerMonth;
		moneyNow = moneyNow + incomeFromWork;

		costBond = bottomPanelGO.GetComponent<BondSelectedInfoButton> ().costBond [0];

		while (moneyNow > costBond) {
			moneyNow = moneyNow - costBond;
			amountBonds++;
			errorInt++;

			valueBondPortfolio = amountBonds * costBond;

			if (errorInt == 25){
				break;

			}
		}

	}

	public void dividendBonds(){

		bondRate = bottomPanelGO.GetComponent<BondSelectedInfoButton> ().rate [0];
		incomeBondsYearEnd = valueBondPortfolio * (bondRate/100);
		moneyNow = moneyNow + incomeBondsYearEnd;

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class divPolicy : MonoBehaviour
{
	//Script för att uppdatera utifrån div policy

	public stock Stock;

	public float newDividend;
	public float oldDividend;

	public float newDivShare;
	public float oldDivShare;

	public float divPolicyRaise;

	public float divPayoutRatioAfter;

	public void endOfYearUpdate(stock Stock)
	{
		oldDividend = Stock.divPayout;
		
		oldDivShare = Stock.divPayout/Stock.EPSnow;

		divPolicyRaise = Stock.divPolicyChangeDiv;

		newDividend = oldDividend * (1 + divPolicyRaise/100);

		divPayoutRatioAfter = newDividend / Stock.EPSnow;

		//Utdelningstak
		if (divPayoutRatioAfter <= Stock.divPolicyMaxPayouRatio / 100 && Stock.divPolicyMaxPayouRatio >= 0) //Utrymme att höja utdelning
		{
			Stock.divPayout = newDividend;

		}

		if (divPayoutRatioAfter > Stock.divPolicyMaxPayouRatio/100)
		{
			newDividend = Stock.EPSnow * Stock.divPolicyMaxPayouRatio/100;
			Stock.divPayout = newDividend;
		}
	}

	/*

		//Utdelningsgolv
		if (utiDivPayoutRatioAfter < utiDivPolMin*100)
		{
			utiDivPayoutAfter = utiEPSNow*utiDivPolMin;
		}

		if (finDivPayoutRatioAfter < finDivPolMin*100)
		{
			finDivPayoutAfter = finEPSNow*finDivPolMin;
		}

		if (techDivPayoutRatioAfter < techDivPolMin*100)
		{
			techDivPayoutAfter = techEPSNow*techDivPolMin;
		}

		mainCanvasGO.GetComponent<infoStockSector>().yearsOfDivRaise(utiDivPayoutBefore, utiDivPayoutAfter, 1);
		mainCanvasGO.GetComponent<infoStockSector>().yearsOfDivRaise(finDivPayoutBefore, finDivPayoutAfter, 2);
		mainCanvasGO.GetComponent<infoStockSector>().yearsOfDivRaise(techDivPayoutBefore, techDivPayoutAfter, 3);

		utiDivPayoutBefore = utiDivPayoutAfter;
		finDivPayoutBefore = finDivPayoutAfter;
		techDivPayoutBefore = techDivPayoutAfter;
	}
	*/

}

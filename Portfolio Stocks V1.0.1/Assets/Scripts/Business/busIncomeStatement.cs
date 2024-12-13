using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class busIncomeStatement : MonoBehaviour
{
	public float revenuePerLemonade;
	public float costPerLemonade;
	public float soldAmountLemonadeMonth;
	public float[] revenueĹemonadeHist;
	public float[] costOfRevLemonadeHist;
	public float[] grossMarginLemonadeHist;
	public float changeSoldAmountLemonade;
	public float[] cashflowBusiness;


	public float[] yearNow;
	public Text yearHeadlineText;
	public Text yearNumberText;
	public Text revenueHeadlineText;
	public Text revenueText1;
	public Text revenueText2;
	public Text revenueText3;
	public Text revenueText4;
	public Text revenueText5;
	public Text costOfRevHeadlineText;
	public Text costOfRevText1;
	public Text costOfRevText2;
	public Text costOfRevText3;
	public Text costOfRevText4;
	public Text costOfRevText5;
	public Text grossMarginHeadlineText;
	public Text grossMarginText1;
	public Text grossMarginText2;
	public Text grossMarginText3;
	public Text grossMarginText4;
	public Text grossMarginText5;

	public GameObject MainCanvasGO;

	//Uppdaterar Income Statement
	public void incomeStateUpdate() {
		
		//yearTextUpdateIncomeStat();
		UpdateText();
		cashflowBusniess();
	}

	public void revenueUpdateValue(){

	soldAmountLemonadeMonth = soldAmountLemonadeMonth + changeSoldAmountLemonade;

		revenueĹemonadeHist[4] = revenueĹemonadeHist[3];
		revenueĹemonadeHist[3] = revenueĹemonadeHist[2];
		revenueĹemonadeHist[2] = revenueĹemonadeHist[1];
		revenueĹemonadeHist[1] = revenueĹemonadeHist[0];

		revenueĹemonadeHist[0] = revenuePerLemonade*soldAmountLemonadeMonth*12/1000;

}

	public void UpdateText(){

		revenueHeadlineText.text = "Revenue (t$): "; 
		revenueText1.text = Mathf.Round(revenueĹemonadeHist[0]*10)/10 + "";
		revenueText2.text = Mathf.Round(revenueĹemonadeHist[1]*10)/10 + "";
		revenueText3.text = Mathf.Round(revenueĹemonadeHist[2]*10)/10 + "";
		revenueText4.text = Mathf.Round(revenueĹemonadeHist[3]*10)/10 + "";
		revenueText5.text = Mathf.Round(revenueĹemonadeHist[4]*10)/10 + "";

		costOfRevHeadlineText.text = "Cost of Rev. (t$): ";
		costOfRevText1.text = Mathf.Round(costOfRevLemonadeHist[0]*10)/10 + "";
		costOfRevText2.text = Mathf.Round(costOfRevLemonadeHist[1]*10)/10 + "";
		costOfRevText3.text = Mathf.Round(costOfRevLemonadeHist[2]*10)/10 + "";
		costOfRevText4.text = Mathf.Round(costOfRevLemonadeHist[3]*10)/10 + "";
		costOfRevText5.text = Mathf.Round(costOfRevLemonadeHist[4]*10)/10 + "";

		grossMarginHeadlineText.text = "Gross Margin(%): ";
		grossMarginText1.text = Mathf.Round(grossMarginLemonadeHist[0]*10)/10 + "";
		grossMarginText2.text = Mathf.Round(grossMarginLemonadeHist[1]*10)/10 + "";
		grossMarginText3.text = Mathf.Round(grossMarginLemonadeHist[2]*10)/10 + "";
		grossMarginText4.text = Mathf.Round(grossMarginLemonadeHist[3]*10)/10 + "";
		grossMarginText5.text = Mathf.Round(grossMarginLemonadeHist[4]*10)/10 + "";
	}

	public void costOfRevUpdateValue(){

		costOfRevLemonadeHist[4] = costOfRevLemonadeHist[3];
		costOfRevLemonadeHist[3] = costOfRevLemonadeHist[2];
		costOfRevLemonadeHist[2] = costOfRevLemonadeHist[1];
		costOfRevLemonadeHist[1] = costOfRevLemonadeHist[0];

		costOfRevLemonadeHist[0] = costPerLemonade*soldAmountLemonadeMonth*12/1000;

	}

	public void grossMarginUpdateValue(){

		grossMarginLemonadeHist[4] = grossMarginLemonadeHist[3];
		grossMarginLemonadeHist[3] = grossMarginLemonadeHist[2];
		grossMarginLemonadeHist[2] = grossMarginLemonadeHist[1];
		grossMarginLemonadeHist[1] = grossMarginLemonadeHist[0];

		grossMarginLemonadeHist[0] = ((revenuePerLemonade-costPerLemonade)/revenuePerLemonade)*100;

	}

	/*
	public void yearTextUpdateIncomeStat(){
		yearNow[0] = MainCanvasGO.GetComponent<endRoundButton>().year;
		yearNow[1] = yearNow[0]-1;
		yearNow[2] = yearNow[1]-1;
		yearNow[3] = yearNow[2]-1;
		yearNow[4] = yearNow[3]-1;

		yearHeadlineText.text = "Year: "; 
		yearNumberText.text = yearNow[0]+ "     " + yearNow[1] + "     " + yearNow[2] + "     " + yearNow[3] + "     " + yearNow[4];
	}
	*/

	public void cashflowBusniess(){
		
		cashflowBusiness[0] = ((revenueĹemonadeHist[0]-costOfRevLemonadeHist[0])/12)*1000;

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour
{
    //Script som innehåller spelarens skills
	public int startRP; //RP = Research point
	public int RPleft;
	public int baseRPleft;
	public int[] RP;
	public int[] lvlSkills;
	public int[] lvlLimits;


	public int stockRPNow;
	public int bondRPNow;
	public int realEstateRPNow;

	public int stocksPointsLeftToLvl;
	public int bondsPointsLeftToLvl;
	public int realEstatePointsLeftToLvl;

	public Text textRPLeft;
	public Text textStockRPThisRound;
	public Text textBondRPThisRound;
	public Text textRealEstateRPThisRound;
	public Text stockPlayerLvl;
	public Text bondPlayerLvl;
	public Text realEstatePlayerLvl;

	public Text textStockPointsLeftToLvlUp;
	public Text textBondsPointsLeftToLvlUp;
	public Text textRealEstatePointsLeftToLvlUp;

	public GameObject BottomPanelGO;
	public GameObject IndexPanelGO;

	public void Start (){
		//RPleft = startRP;
		//baseRPleft = startRP;
		//textRPLeft.text = "RP left: " + RPleft;
		/*textStockRPThisRound.text = "Stock: " + stockRPNow;
		textBondRPThisRound.text = "Bond: " + bondRPNow;
		textRealEstateRPThisRound.text = "Real Est: " + realEstateRPNow;

		stockPlayerLvl.text = "Stock (lvl): " + lvlSkills [0];
		bondPlayerLvl.text = "Bond (lvl): " + lvlSkills [1];
		realEstatePlayerLvl.text = "Real estate (lvl): " + lvlSkills [2];
*/

		//pointsLeft ();

	}

	public void endRoundResearch(){
		/*RP [0] = RP [0] + stockRPNow;
		RP [1] = RP [1] + bondRPNow;
		RP [2] = RP [2] + realEstateRPNow;
		*/

		//Reset round
		stockRPNow = 0;
		bondRPNow = 0;
		realEstateRPNow = 0;

		//textStockRPThisRound.text = "Stock: " + stockRPNow;
		//textBondRPThisRound.text = "Bond: " + bondRPNow;
		//textRealEstateRPThisRound.text = "RE: " + realEstateRPNow;
		//RPleft = baseRPleft;
		//textRPLeft.text = "RP left: " + RPleft;
		//lvlUp ();
		//pointsLeft ();
	}

	public void increaseRP(int rpIncrease){
		baseRPleft = baseRPleft + rpIncrease;
		RPleft = RPleft + rpIncrease;
		textRPLeft.text = "RP left: " + RPleft;
	}

	public void updateRPtext(){
		textRPLeft.text = "RP left: " + RPleft;
	}

	public void unlockIndexFunds(){
		IndexPanelGO.SetActive (true);
	}

	public void lvlUp() //Kollar vilken lvl-spelaren har
	{
		//STOCKS
		if (RP [0] >= lvlLimits [0] && RP [0] < lvlLimits [1]) {
			lvlSkills [0] = 1;
			stockPlayerLvl.text = "Stock (lvl): " + lvlSkills [0];
			unlockIndexFunds ();
		}

		if (RP [0] >= lvlLimits [1] && RP [0] < lvlLimits [2]) {
			lvlSkills [0] = 2;
			stockPlayerLvl.text = "Stock (lvl): " + lvlSkills [0];

		}

		//BONDS
		if (RP [1] >= lvlLimits [0] && RP [1] < lvlLimits [1] && lvlSkills [1] == 0) {
			lvlSkills [1] = 1;
			BottomPanelGO.GetComponent<BondSelectedInfoButton> ().lvlUpBondInterestRate ();
			bondPlayerLvl.text = "Bond (lvl): " + lvlSkills [1];
		}

		if (RP [1] >= lvlLimits [1] && RP [1] < lvlLimits [2] && lvlSkills [1] == 1) {
			lvlSkills [1] = 2;
			BottomPanelGO.GetComponent<BondSelectedInfoButton> ().lvlUpBondInterestRate ();
			bondPlayerLvl.text = "Bond (lvl): " + lvlSkills [1];
		}

		if (RP [1] >= lvlLimits [2] && lvlSkills [1] == 2) {
			lvlSkills [1] = 3;
			BottomPanelGO.GetComponent<BondSelectedInfoButton> ().lvlUpBondInterestRate ();
			bondPlayerLvl.text = "Bond (lvl): " + lvlSkills [1];
		}

		//REAL ESTATE
		if (RP [2] >= lvlLimits [0] && RP [2] < lvlLimits [1] && lvlSkills [2] == 0) {
			lvlSkills [2] = 1;
			BottomPanelGO.GetComponent<infoRealEstateButton> ().increaseRent ();
			realEstatePlayerLvl.text = "Real estate (lvl): " + lvlSkills [2];
		}

		if (RP [2] >= lvlLimits [1] && RP [2] < lvlLimits [2] && lvlSkills [2] == 1) {
			lvlSkills [2] = 2;
			BottomPanelGO.GetComponent<infoRealEstateButton> ().increaseRent ();
			realEstatePlayerLvl.text = "Real estate (lvl): " + lvlSkills [2];
		}

		if (RP [2] >= lvlLimits [2] && lvlSkills [2] == 2) {
			lvlSkills [2] = 3;
			BottomPanelGO.GetComponent<infoRealEstateButton> ().increaseRent ();
			realEstatePlayerLvl.text = "Real estate (lvl): " + lvlSkills [2];
		}

	}

	public void pointsLeft (){

		//STOCKS
		stocksPointsLeftToLvl = lvlLimits [0] - RP [0];
		textStockPointsLeftToLvlUp.text = "To lvl-up: " + stocksPointsLeftToLvl;

		if (RP [0] >= lvlLimits [0] && RP [0] < lvlLimits [1]) {
			stocksPointsLeftToLvl = lvlLimits [1] - RP [0];
			textStockPointsLeftToLvlUp.text = "To lvl-up: " + stocksPointsLeftToLvl;
		}

		if (RP [0] >= lvlLimits [1] && RP [0] < lvlLimits [2]) {
			stocksPointsLeftToLvl = lvlLimits [2] - RP [0];
			textStockPointsLeftToLvlUp.text = "To lvl-up: " + stocksPointsLeftToLvl;
		}	

		//BONDS

		bondsPointsLeftToLvl = lvlLimits [0] - RP [1];
		textBondsPointsLeftToLvlUp.text = "To lvl-up: " + bondsPointsLeftToLvl;

		if (RP [1] >= lvlLimits [0] && RP [1] < lvlLimits [1])
		{
			bondsPointsLeftToLvl = lvlLimits [1] - RP [1];
			textBondsPointsLeftToLvlUp.text = "To lvl-up: " + bondsPointsLeftToLvl;
		}

		if (RP [1] >= lvlLimits [1] && RP [1] < lvlLimits [2]) {
			bondsPointsLeftToLvl = lvlLimits [2] - RP [1];
			textBondsPointsLeftToLvlUp.text = "To lvl-up: " + bondsPointsLeftToLvl;
		}

		if (RP [1] >= lvlLimits [2] && lvlSkills [1] == 2) {
			bondsPointsLeftToLvl = lvlLimits [3] - RP [1];
			textBondsPointsLeftToLvlUp.text = "To lvl-up: " + bondsPointsLeftToLvl;
		}

		//Real Estate
		realEstatePointsLeftToLvl = lvlLimits [0] - RP [2];
		textRealEstatePointsLeftToLvlUp.text = "To lvl-up: " + realEstatePointsLeftToLvl;

		if (RP [2] >= lvlLimits [0] && RP [2] < lvlLimits [1]) {
			realEstatePointsLeftToLvl = lvlLimits [1] - RP [2];
			textRealEstatePointsLeftToLvlUp.text = "To lvl-up: " + realEstatePointsLeftToLvl;

		}

		if (RP [2] >= lvlLimits [1] && RP [2] < lvlLimits [2]) {
			realEstatePointsLeftToLvl = lvlLimits [2] - RP [2];
			textRealEstatePointsLeftToLvlUp.text = "To lvl-up: " + realEstatePointsLeftToLvl;
		}

		if (RP [2] >= lvlLimits [2] && lvlSkills [2] == 2) {
			realEstatePointsLeftToLvl = lvlLimits [3] - RP [2];
			textRealEstatePointsLeftToLvlUp.text = "To lvl-up: " + realEstatePointsLeftToLvl;
		}
	}
}

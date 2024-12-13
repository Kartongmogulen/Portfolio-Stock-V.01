using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addRP : MonoBehaviour
{
	//public int startRP; //RP = Research point
	public int RPleft;

	public int stockRPNow;
	public int bondRPNow;
	public int realEstateRPNow;

	public Text textRPLeft;
	public Text textStockRPThisRound;
	public Text textBondRPThisRound;
	public Text textRealEstateRPThisRound;

	public GameObject playerPanelGO;

	public void addStockRP(){

		RPleft = playerPanelGO.GetComponent<playerStats>().RPleft;

		if (RPleft > 0) {
			RPleft--;
			playerPanelGO.GetComponent<playerStats> ().RPleft--;
			playerPanelGO.GetComponent<playerStats> ().stockRPNow++;
			stockRPNow = playerPanelGO.GetComponent<playerStats> ().stockRPNow;
			textStockRPThisRound.text = "Stock: " + stockRPNow;
			textRPLeft.text = "RP left: " + RPleft;
		}
	}

	public void addBondRP(){

		RPleft = playerPanelGO.GetComponent<playerStats>().RPleft;

		if (RPleft > 0) {
			RPleft--;
			playerPanelGO.GetComponent<playerStats> ().RPleft--;
			playerPanelGO.GetComponent<playerStats> ().bondRPNow++;
			bondRPNow = playerPanelGO.GetComponent<playerStats> ().bondRPNow;
			textBondRPThisRound.text = "Bond: " + bondRPNow;
			textRPLeft.text = "RP left: " + RPleft;
		}
	}

	public void addRealEstateRP(){

		RPleft = playerPanelGO.GetComponent<playerStats>().RPleft;

		if (RPleft > 0) {
			RPleft--;
			playerPanelGO.GetComponent<playerStats> ().RPleft--;
			playerPanelGO.GetComponent<playerStats> ().realEstateRPNow++;
			realEstateRPNow = playerPanelGO.GetComponent<playerStats> ().realEstateRPNow;
			textRealEstateRPThisRound.text = "RE: " + realEstateRPNow;
			textRPLeft.text = "RP left: " + RPleft;
		}
	}
}

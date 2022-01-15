using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stockInfoUI : MonoBehaviour
{
	public stock Stock;  
	//public Text sectorNameText;
	//public Text payoutText;

	public virtual void Click(stock Stock){
		this.Stock = Stock;
		//sectorNameText.text = "Sector: " + Stock.sectorName;
		//payoutText.text = "Payout: " + Stock.payout;


	}
}

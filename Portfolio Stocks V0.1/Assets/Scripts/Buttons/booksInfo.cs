using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class booksInfo : MonoBehaviour
{
  //SCRIPT MED INFO OM BÖCKERNA


	public float[] costBooks;
	public int attributeBoostBookNr1;
	public int attributeBoostBookNr2;
	public int[] ownedBooks;
	public int activeBook; //Which book that is showing

	public Text bookName;
	public Text bookBoost; //What attribute the book changes
	public Text bookCostText;
	public Text bookNameInfoButtonOne;
	public Text bookNameInfoButtonTwo;
	public Text bookButtonBuyText;

	public GameObject playerPanelGO;

	public void Start(){
		bookNameInfoButtonOne.text = "Rich Dad, Poor Dad";
		bookNameInfoButtonTwo.text = "One up on Wall street";
	}

	public void bookNrOne(){
		
		bookName.text = "Rich Dad, Poor Dad";
		bookBoost.text = "Increase Research Points: " + attributeBoostBookNr1;
		bookCostText.text = "Cost: " + costBooks [0];
		activeBook = 1;
	}

	public void bookNrTwo(){

		bookName.text = "One up on Wall street";
		bookBoost.text = "Stock lvl increase: " + attributeBoostBookNr2;
		bookCostText.text = "Cost: " + costBooks [1];
		activeBook = 2;
	}

	public void buyBook (){
		if (activeBook == 1) {

			if (ownedBooks [0] == 0 /*&& playerPanelGO.GetComponent<totalCash> ().moneyNow >= costBooks [0]*/) {

				playerPanelGO.GetComponent<playerStats> ().increaseRP (attributeBoostBookNr1);
				//playerPanelGO.GetComponent<totalCash> ().buyBook (costBooks [0]);
				ownedBooks [0] = 1;
				bookButtonBuyText.text = "Already owned";
			}
		}

		if (activeBook == 2) {
			if (ownedBooks [1] == 0 /*&& playerPanelGO.GetComponent<totalCash> ().moneyNow >= costBooks [1]*/) {

				playerPanelGO.GetComponent<playerStats> ().lvlSkills [0]++;
				//playerPanelGO.GetComponent<totalCash> ().buyBook (costBooks [1]);
				ownedBooks [1] = 1;
				bookButtonBuyText.text = "Already owned";
			}
		}
	}
}

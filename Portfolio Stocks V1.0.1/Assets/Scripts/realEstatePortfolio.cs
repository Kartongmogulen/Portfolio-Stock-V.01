using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class realEstatePortfolio : MonoBehaviour
{
	public float[] realEstateOwned;
	public float totInvestRealEstate;

	public void investTotRealEstate (float cost){
		totInvestRealEstate = totInvestRealEstate + cost;
	}
}

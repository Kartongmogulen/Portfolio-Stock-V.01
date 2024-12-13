using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class indexFunds : MonoBehaviour
{

	//Script for index-funds
	public float NAVIndexFund;
	public float priceUti;
	public float priceFin;
	public float priceTech;

	public float utiShare;
	public float finShare;
	public float techShare;

	public GameObject mainCanvasGO;

	public Text priceIndex;
	public Text shareSizeUti;
	public Text shareSizeFin;
	public Text shareSizeTech;

	public InputField inputAmount;

	void Awake (){



		//priceSectors ();
	}

	public void updateIndex(){
		priceSectors();
		indexFundNAV();
		sectorAllocation();
		}

	void priceSectors(){
		priceUti = mainCanvasGO.GetComponent <infoStockSector> ().utiStockPrice;
		priceFin = mainCanvasGO.GetComponent <infoStockSector> ().finPriceNow;
		priceTech = mainCanvasGO.GetComponent <infoStockSector> ().techPriceNow;
	
	}

	public void indexFundNAV(){
		priceSectors ();
		NAVIndexFund = priceUti + priceFin + priceTech;
		priceIndex.text = "NAV: " + NAVIndexFund;

		}

	public void sectorAllocation(){
		utiShare = priceUti / NAVIndexFund;
		shareSizeUti.text = Mathf.Round(utiShare*10000)/100 + "%";

		finShare = priceFin / NAVIndexFund;
		shareSizeFin.text = Mathf.Round(finShare*10000)/100 + "%";

		techShare = priceTech / NAVIndexFund;
		shareSizeTech.text = Mathf.Round(techShare*10000)/100 + "%";
	}


}

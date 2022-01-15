using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stockMarketUI : MonoBehaviour
{

	public stockMarketInventory StockMarketInventory; 
	public Transform content;
	public stockUI StockUIPrefab;

	public Text stockSectorText; 
	public Text payoutText;
	public Text divPolicyText;
	public Text EPSnowText;
	public Text EPSGrowthText;
	public Text PayoutRatioText;
	public Text priceText;

	public float priceNow;

	public GameObject StockInfoPanel;
	//public GameObject sectorNameText;


    // Start is called before the first frame update
    void Start()
    {
		//StockMarketInventory = GetComponent<stockMarketInventory>();

		if (StockMarketInventory)
			Display (StockMarketInventory);
    }

	public virtual void Display(stockMarketInventory i)
	{
		this.StockMarketInventory = i;
		Refresh ();

	}

	public virtual void Refresh(){

		//stockUI ui = stockUI.Instantiate (StockInfoPanel, stockInfoPanelContent);

		foreach (Transform t in content) {
			Destroy (t.gameObject);
		}

		foreach (stock i in StockMarketInventory.Stock) {
			stockUI ui = stockUI.Instantiate (StockUIPrefab, content);
			ui.onClicked.AddListener (UIClicked);
			ui.Display (i);
		}

		//foreach (Transform t in stockInfoPanelContent) {
			//Destroy (t.gameObject);
		//}
			
	}

	public virtual void UIClicked(stockUI iui){

		stockSectorText.text = "Sector: " + iui.Stock.sectorName;

		//Utdelningspolicy
		if (iui.Stock.companyPaysDividend == true)
			divPolicyText.text = "Div. Policy: Will aim to increase dividends with: " + iui.Stock.divPolicyChangeDiv + "%/year";
		else
			divPolicyText.text = "Div. Policy: Focus on growth, hence no dividend";

		//payoutText.text = "Payout: " + iui.Stock.payout;

		EPSnowText.text = "EPS: " + iui.Stock.EPSnow;

		EPSGrowthText.text = "EPS growth: " + iui.Stock.EPSGrowthMin + "-" + iui.Stock.EPSGrowthMax + "%/year";

		//PayoutRatioText.text = "Payout ratio: " + (Mathf.Round((iui.Stock.payout / iui.Stock.EPSnow)*100)/100)*100 + "%";

		priceNow = iui.Stock.priceNow;

		Debug.Log ("Price: " + priceNow);

		//priceText.text = "Price: " + iui.Stock.StockPrice[0];
	}
}

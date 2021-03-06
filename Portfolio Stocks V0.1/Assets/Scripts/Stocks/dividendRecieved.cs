using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dividendRecieved : MonoBehaviour
{
	//Utdelningar som erhållits
	/* Hämta spelarens portfölj
	 * Gå igenom portföljen för att få ut utdelnignen
	 */

	//public GameObject playerPanelGO;

	public GameObject StockMarketGO;
	public stockMarketManager StockMarketManager;
	public GameObject playerScriptsGO;

	public portfolioStock PortfolioStock; 
	public utilitiesInfoStock UtiInfoStock;
	public techInfoStock TechInfoStock;

	public List<float> utiCompanySharesOwned;
	public List<float> utiCompanyDivPayout = new List<float>();
	public List<float> utiCompanyDivRecieved = new List<float> ();

	public List<float> techCompanySharesOwned;
	public List<float> techCompanyDivPayout;
	public List<float> techCompanyDivRecieved = new List<float> ();

	public List<float> divRecPerYear = new List<float> ();

	public float totalDivRecieved;

	int year = 0; 
	
    // Start is called before the first frame update
    void Awake()
    {
		PortfolioStock = playerScriptsGO.GetComponent<portfolioStock> ();
		StockMarketManager = StockMarketGO.GetComponent<stockMarketManager>();

		//SKAPAR STORLEK PÅ LISTA EFTER ANTALET BOLAG
		for (int i = 0; i < StockMarketManager.StockUtiList.Count; i++)
		{
			utiCompanySharesOwned.Add(0);
			utiCompanyDivPayout.Add(StockMarketManager.StockUtiList[i].divPayout);
			utiCompanyDivRecieved.Add(0);

		}

		//SKAPAR STORLEK PÅ LISTA EFTER ANTALET BOLAG
		for (int i = 0; i < StockMarketManager.StockTechList.Count; i++)
		{

			techCompanySharesOwned.Add(0);
			techCompanyDivPayout.Add(StockMarketManager.StockTechList[i].divPayout);
			techCompanyDivRecieved.Add(0);
		}

	}

    // Update is called once per frame
	public void recievedDividends()
    {
		
		divRecPerYear.Add (0);
		
		//GÅR IGENOM SEKTOR FÖR SEKTOR

		//Gå igenom alla utilites-bolag
		for (int i = 0; i < StockMarketManager.StockUtiList.Count; i++) {
			utiCompanyDivPayout[i] = StockMarketManager.StockUtiList[i].GetComponent<stock>().divPayout;
			utiCompanySharesOwned[i] = PortfolioStock.utiCompanySharesOwned[i];
			utiCompanyDivRecieved[i] = utiCompanyDivPayout [i] * utiCompanySharesOwned [i];
			divRecPerYear[year] += utiCompanyDivRecieved[i];
		}


		//Gå igenom alla tech-bolag
		for (int i = 0; i < StockMarketManager.StockTechList.Count; i++)
		{
			techCompanyDivPayout[i] = StockMarketManager.StockTechList[i].GetComponent<stock>().divPayout;
			techCompanySharesOwned[i] = PortfolioStock.techCompanySharesOwned[i];
			techCompanyDivRecieved[i] = techCompanyDivPayout[i] * techCompanySharesOwned[i];
			divRecPerYear[year] += techCompanyDivRecieved[i];
		}

		//playerPanelGO.GetComponent <totalCash> ().addMoney(divRecPerYear [year]);



		//Debug.Log("UTD: " + (utiCompanyDivPayout[0] * utiCompanySharesOwned [0]));

		year++;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portfolioStock : MonoBehaviour
{
	public GameObject stockScriptsGO;
	public GameObject stockMarketGO;

	public GameObject playerUtiGO;
	public GameObject playerTechGO;

	public List<stock> stockListUti;
	public List<stock> stockListTech;

	//Lista där antal aktier i specifik sector sparas
	public List<float> utiCompanySharesOwned = new List<float> (); 
	public List<float> techCompanySharesOwned = new List<float> ();
	public List<float> materialsCompanySharesOwned = new List<float> ();

	public List<float> utiGAV= new List<float>();
	public List<float> techGAV = new List<float>();

	public float totalValuePortfolio;
	public float totalInvestAmountPortfolio;
	public float totalReturnPortfolioPercent;
	public float totalReturnPortfolioAmount;
	public float totalValueUti;
	public float totalValueTech;

	public float[] utiTotalInvest; //Summan som har investerats i specifikt företag
	public List<float> returnUtiCompanies;
	public float utiTotalInvestAmount;
	public float utiTotalReturnAmount;
	public float utiTotalReturnPercent;
	public float utiTotalValue;

	public float[] techTotalInvest; //Summan som har investerats i specifikt företag
	public List<float> returnTechCompanies;
	public float techTotalInvestAmount;
	public float techTotalReturnAmount;
	public float techTotalReturnPercent;
	public float techTotalValue;

	public float[] materialsTotalInvest; //Summan som har investerats i specifikt företag
	public float materialsTotalInvestAmount;
	public float[] materialsGAV; 
	public float materialsTotalReturn;

	
	public float[] returnTech;

	//UTDELNINGAR
	public float totalDivIncome;
	public float divUtiCompanyOne;
	public float divUtiCompanyTwo;
	public float divTechCompanyOne;
	public float divTechCompanyTwo;

	//ANDEL PORTFÖLJ
	public float utiSharePortfolio;
	public Text utiSharePortfolioText;
	public float techSharePortfolio;
	public Text techSharePortfolioText;

	//SEKTORNS AVKASTNING
	public Text utiReturnText;
	public Text techReturnText;


	public priceChange PriceChange;

	public Text valuePortfolioText;
	public Text returnPortfolioText;
	public Text dividendPerYearText;

	public utilitiesInfoStock UtilitiesInfoStock;
	public techInfoStock TechInfoStock;

	void Awake(){
		
		PriceChange = GetComponent<priceChange> ();
		UtilitiesInfoStock = GetComponent<utilitiesInfoStock> ();
		TechInfoStock = GetComponent<techInfoStock> ();

		stockListUti = stockMarketGO.GetComponent<stockMarketManager>().StockUtiList;
		stockListTech = stockMarketGO.GetComponent<stockMarketManager>().StockTechList;
	}


	public void addUtiShares(int shares, int activeCompany){
		utiCompanySharesOwned [activeCompany] += shares;
		GetComponent<GAV>().utiGAV();

	}

	public void sellUtiShares(int shares, int activeCompany, float orderValue)
	{
		utiCompanySharesOwned [activeCompany] -= shares;
		utiTotalInvest[activeCompany] -= orderValue;
		GetComponent<GAV>().utiGAVSell();
	}

	public void addTechShares(int shares, int activeCompany){
		techCompanySharesOwned [activeCompany] += shares;
		GetComponent<GAV>().techGAV();

	}

	public void sellTechShares(int shares, int activeCompany){
		techCompanySharesOwned [activeCompany] -= shares;
		GetComponent<GAV>().techGAVSell();
	}

	public void addMaterialShares(int shares, int activeCompany){
		materialsCompanySharesOwned [activeCompany] += shares;

	}

	public void sellMaterialShares(int shares, int activeCompany){
		materialsCompanySharesOwned [activeCompany] -= shares;

	}

	public void totalInvest(){

		//valuePortfolio ();

		utiTotalInvestAmount = 0;
		techTotalInvestAmount = 0;

		//Avkastning per företag
		/*for (int i = 0; i < returnUti.Length; i++) {
			returnUti[i] = (utiCompanySharesOwned [i]*PriceChange.priceNowUti[i])/utiTotalInvest [i];
		}

		for (int i = 0; i < returnTech.Length; i++) {
			returnTech[i] = (techCompanySharesOwned [i]*PriceChange.priceNowTech[i])/techTotalInvest [i];
		}*/

		//Total investering i sektorn
		for (int i = 0; i < utiTotalInvest.Length; i++) {
			utiTotalInvestAmount = utiTotalInvestAmount + utiGAV [i]*utiCompanySharesOwned [i];
		}

		for (int i = 0; i < techTotalInvest.Length; i++) {
			techTotalInvestAmount = techTotalInvestAmount + techGAV [i]*techCompanySharesOwned [i];
		}

		totalInvestAmountPortfolio = utiTotalInvestAmount + techTotalInvestAmount;

		//Total avkastning i sektorn
		/*for (int i = 0; i < returnUti.Length; i++) {
			utiTotalReturn = totalValueUti/utiTotalInvestAmount-1;
		}

		for (int i = 0; i < returnTech.Length; i++) {
			techTotalReturn = totalValueTech/techTotalInvestAmount-1;
		}
	
		totalInvestAmountPortfolio = utiTotalInvestAmount + techTotalInvestAmount;
		totalReturnPortfolio = totalValuePortfolio / totalInvestAmountPortfolio-1;
		returnPortfolioText.text = "Return Portfolio: " + Mathf.Round(totalReturnPortfolio*100) + "%";
		*/

	}
	

	public void showPortfolioData(){

		totalInvest();
		//GAVupdate();
		//utiGAV = stockScriptsGO.GetComponent<GAV>().stockListCalculation(utiCompanySharesOwned, utiTotalInvest);
		//techGAV = stockScriptsGO.GetComponent<GAV>().stockListCalculation(techCompanySharesOwned, techTotalInvest);

		utiSharePortfolio = 0;
		techSharePortfolio = 0;
		utiTotalValue = 0;
		techTotalValue = 0;

		//stockListUti = stockMarketGO.GetComponent<stockMarketManager>().StockUtiList;
		//stockListTech = stockMarketGO.GetComponent<stockMarketManager>().StockTechList;

		//SEKTORNS ANDEL AV PORTFÖLJEN
		for (int i = 0; i < stockListUti.Count; i++) {
			utiTotalValue += (utiCompanySharesOwned [i] * stockListUti[i].StockPrice[stockListUti[i].StockPrice.Count-1]);
			//utiSharePortfolio += utiTotalValue;
			
		}

		for (int i = 0; i < stockListTech.Count; i++)
		{
			techTotalValue += (techCompanySharesOwned[i] * stockListTech[i].StockPrice[stockListTech[i].StockPrice.Count - 1]);
			//techSharePortfolio += techTotalValue;
			Debug.Log("UtiShare: " + techSharePortfolio);
		}

		totalValuePortfolio = utiTotalValue + techTotalValue;

		utiSharePortfolio = utiTotalValue / totalValuePortfolio;
		techSharePortfolio = techTotalValue / totalValuePortfolio;

		utiSharePortfolioText.text = " " + Mathf.Round(utiSharePortfolio*100) + "%";
		techSharePortfolioText.text = " " + Mathf.Round(techSharePortfolio * 100) + "%";

		//VÄRDE AV PORTFÖLJEN
		//totalValueSector = GetComponent<valuePortfolio>()

		//SEKTORNS AVKASTNING
		returnPortfolio();
		//Utilites
		/*returnUtiCompanies = playerUtiGO.GetComponent<returnPortfolio>().returnStocksPercent(stockListUti, utiGAV);
		utiTotalReturnAmount = playerUtiGO.GetComponent<returnPortfolio>().returnSector(stockListUti, utiGAV, utiCompanySharesOwned);
		 
		utiTotalReturnPercent = utiTotalReturnAmount / utiTotalInvestAmount;
		utiReturnText.text = " " + Mathf.Round(utiTotalReturnPercent * 10000)/100 + "%";

		//Tech
		returnTechCompanies = playerTechGO.GetComponent<returnPortfolio>().returnStocksPercent(stockListTech, techGAV);
		techTotalReturnAmount = playerTechGO.GetComponent<returnPortfolio>().returnSector(stockListTech, techGAV, techCompanySharesOwned);

		techTotalReturnPercent = techTotalReturnAmount / techTotalInvestAmount;
		techReturnText.text = " " + Mathf.Round(techTotalReturnPercent*10000)/100 + "%";
		*/
	}

	public void returnPortfolio()
	{
		//Utilites
		returnUtiCompanies = playerUtiGO.GetComponent<returnPortfolio>().returnStocksPercent(stockListUti, utiGAV);
		utiTotalReturnAmount = playerUtiGO.GetComponent<returnPortfolio>().returnSector(stockListUti, utiGAV, utiCompanySharesOwned);

		utiTotalReturnPercent = utiTotalReturnAmount / utiTotalInvestAmount;
		utiReturnText.text = " " + Mathf.Round(utiTotalReturnPercent * 10000) / 100 + "%";

		//Tech
		returnTechCompanies = playerTechGO.GetComponent<returnPortfolio>().returnStocksPercent(stockListTech, techGAV);
		techTotalReturnAmount = playerTechGO.GetComponent<returnPortfolio>().returnSector(stockListTech, techGAV, techCompanySharesOwned);

		techTotalReturnPercent = techTotalReturnAmount / techTotalInvestAmount;
		techReturnText.text = " " + Mathf.Round(techTotalReturnPercent * 10000) / 100 + "%";

		totalReturnPortfolioAmount = utiTotalReturnAmount + techTotalReturnAmount;

		totalInvest();
		totalReturnPortfolioPercent = totalReturnPortfolioAmount / totalInvestAmountPortfolio;

	}

}

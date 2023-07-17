using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalCash : MonoBehaviour
{
	//Script med data över hur mycket pengar som finns tillgängligt

	//==START VARIABLER
	public float moneyStart;

	//==COMPONENTER
	public moneyManager MoneyManager;
	public bondMarketManager BondMarketManager;
	public bondsPortfolio BondsPortfolio;

	//==Variabler
	[SerializeField] private float rate;
	[SerializeField] private float amountBonds;

	private int i;

	//Step 3.1.1
	public GameObject ScriptsGO;

	//________________________
	
	public float moneyBefore;
	public float moneyAfter;
	public float moneyNow;
	public Text moneyText;

	public float incomeTotDivNow;
	public float incomeTotDivBefore;

	public float incomeBusiness;

	public float incomeBondsLifetime;

	public float incomeRealEstateLifetime;

	public GameObject MainCanvas;

	public GameObject playerPanelGo;

	public GameObject PanelSector;
	public float stockPriceUti; 
	public float stockPriceFin;
	public float stockPriceTech;
	public float stockPriceIndex;

	public GameObject panelRealEstateGO;

	public GameObject panelBonds;

	// Start is called before the first frame update
	void Start()
	{
		moneyText.text = "Money: " + moneyStart;
		moneyBefore = moneyStart;
		moneyNow = moneyBefore;
	}

	public void updateStartingMoney()
	{
		moneyText.text = "Money: " + moneyStart;
		moneyBefore = moneyStart;
		moneyNow = moneyBefore;
	}

	public void updateMoney(){
	
		moneyText.text = "Money: " + moneyNow;
	}

	public void incomeWork()
	{
		moneyNow = MoneyManager.moneyTransaction(moneyNow,GetComponent<incomeWork>().incomeWorkPerMonth);
		updateMoney();
		GetComponent<incomeWork>().incomeDuringLife();
		/*
		moneyBefore = moneyNow;
		moneyNow = moneyBefore + playerPanelGo.GetComponent<incomeWork>().workIncomeNow;
		moneyText.text = "Money: " + moneyNow;
		moneyBefore = moneyNow;
		playerPanelGo.GetComponent<incomeWork>().incomeLifeFromWork(); //Beräknar total inkomst från arbete
	*/
	}

	public void incomeDividend(float incomeDiv)
	{
		moneyNow = MoneyManager.moneyTransaction(moneyNow, incomeDiv);
		updateMoney();
		GetComponent<incomeDividends>().updateIncomeDividends();
	}

	public void incomeRealEstate(){
		moneyBefore = moneyNow;
		moneyNow = moneyBefore + panelRealEstateGO.GetComponent<buyRealEstate>().cashFlowRealEstateNow;
		moneyText.text = "Money: " + moneyNow;
		moneyBefore = moneyNow;
		incomeRealEstateLifetime = incomeRealEstateLifetime + panelRealEstateGO.GetComponent<buyRealEstate>().cashFlowRealEstateNow;
	}

	public void incomeBonds (float income){
		moneyBefore = moneyNow;
		moneyNow += income;
		//moneyNow = moneyBefore + playerPanelGo.GetComponent<bondsPortfolio>().cashFlowBondsNow;
		moneyText.text = "Money: " + moneyNow;
		moneyBefore = moneyNow;
		incomeBondsLifetime += income;
		//incomeBondsLifetime = incomeBondsLifetime + panelBonds.GetComponent<buyBonds>().cashFlowBondsNow;
	}

	//Räntor som betalar ut räntan var 12 månad
	public void incomeBondsOncePerYear()
	{
		//Korta räntor, 1 år
		rate = BondMarketManager.GetComponent<bondMarketManager>().bondMarketListGO[0].GetComponent<bondInfoPrefab>().rate / 100;
		//Debug.Log("Ränta: " + rate);
		amountBonds = BondsPortfolio.bondsOwned1Year[0];
		//Debug.Log("Antal: " + amountBonds);
		moneyNow += rate * amountBonds * BondMarketManager.GetComponent<bondMarketManager>().bondMarketListGO[0].GetComponent<bondInfoPrefab>().costBond;
		incomeBondsLifetime += rate * amountBonds * BondMarketManager.GetComponent<bondMarketManager>().bondMarketListGO[0].GetComponent<bondInfoPrefab>().costBond;
		//Debug.Log("Intäkt räntor: " + rate * amountBonds * BondMarketManager.GetComponent<bondMarketManager>().bondMarketListGO[0].GetComponent<bondInfoPrefab>().costBond);

		//Långa räntor, 5 år
		rate = BondMarketManager.GetComponent<bondMarketManager>().bondMarketListGO[1].GetComponent<bondInfoPrefab>().rate / 100;
		//Debug.Log("Ränta: " + rate);
		amountBonds = BondsPortfolio.bondsOwned5Year[0];
		//Debug.Log("Antal: " + amountBonds);
		moneyNow += rate * amountBonds * BondMarketManager.GetComponent<bondMarketManager>().bondMarketListGO[1].GetComponent<bondInfoPrefab>().costBond;
		incomeBondsLifetime += rate * amountBonds * BondMarketManager.GetComponent<bondMarketManager>().bondMarketListGO[1].GetComponent<bondInfoPrefab>().costBond;
		//Debug.Log("Intäkt räntor: " + rate * amountBonds * BondMarketManager.GetComponent<bondMarketManager>().bondMarketListGO[1].GetComponent<bondInfoPrefab>().costBond);
		moneyText.text = "Money: " + moneyNow;


		/*foreach (GameObject bondPrefab in BondMarketManager.GetComponent<bondMarketManager>().bondMarketListGO)
		{

			rate = bondPrefab.GetComponent<bondInfoPrefab>().rate/100;
			Debug.Log("Ränta: " + rate);
			//moneyNow += rate/100 * 
		}*/
	}

	public void buyStockUti(int amount){
		stockPriceUti = PanelSector.GetComponent<buyStock>().priceUti;
		moneyNow = moneyNow - stockPriceUti*amount;
		moneyText.text = "Money: " + moneyNow;
	}

	public void sellStockUti(int amount){
		stockPriceUti = PanelSector.GetComponent<buyStock>().priceUti;
		moneyNow = moneyNow + stockPriceUti*amount;
		moneyText.text = "Money: " + moneyNow;
	}

	public void buyStockFin(int amount){
		stockPriceFin  = PanelSector.GetComponent<buyStock>().priceFin;
		moneyNow = moneyNow - stockPriceFin*amount;
		moneyText.text = "Money: " + moneyNow;
	}

	public void sellStockFin(int amount){
		stockPriceFin  = PanelSector.GetComponent<buyStock>().priceFin;
		moneyNow = moneyNow + stockPriceFin*amount;
		moneyText.text = "Money: " + moneyNow;
	}

	public void buyStockTech(int amount){
		stockPriceTech  = PanelSector.GetComponent<priceChange>().techStockPriceNow;
		moneyNow = moneyNow - stockPriceTech*amount;
		moneyText.text = "Money: " + moneyNow;

	}

	public void sellStockTech(int amount){
		stockPriceTech  = PanelSector.GetComponent<buyStock>().priceTech;
		moneyNow = moneyNow + stockPriceTech*amount;
		moneyText.text = "Money: " + moneyNow;
	}

	public void buyStockIndex(float amount){
		moneyNow = moneyNow - amount;
		moneyText.text = "Money: " + moneyNow;
	}

	public void sellStockIndex(float amount){
		moneyNow = moneyNow + amount;
		moneyText.text = "Money: " + moneyNow;
	}

	public void buyRealEstate (float downPayment) {
		moneyNow = moneyNow - downPayment;
		moneyText.text = "Money: " + moneyNow;
	}

	public void buyBonds (float cost)
	{
		moneyNow = moneyNow - cost;
		moneyText.text = "Money: " + moneyNow;
		playerPanelGo.GetComponent<bondsPortfolio>().bondsTotalInvest(cost);
		playerPanelGo.GetComponent<bondsPortfolio>().bondsGAV(cost);

	}

	public void sellBonds (float cost)
	{
		moneyNow = moneyNow + cost;
		moneyText.text = "Money: " + moneyNow;
		playerPanelGo.GetComponent<bondsPortfolio>().bondsTotalInvest(-cost);

	}

	public void buyBusiness(float cost){

		moneyNow = moneyNow - cost;
		moneyText.text = "Money: " + moneyNow;

	}

	public void cashflowFromBusiness(){
		incomeBusiness = playerPanelGo.GetComponent<ownedBusiness>().cashflowPlayer;
		moneyNow = moneyNow + incomeBusiness;
		moneyText.text = "Money: " + moneyNow;
	}

	public void buyBook(float costBook){
	
		moneyNow = moneyNow - costBook;
		moneyText.text = "Money: " + moneyNow;
	}


}


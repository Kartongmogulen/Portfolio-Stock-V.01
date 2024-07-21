using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portfolioStock : MonoBehaviour
{
	public GameObject stockScriptsGO;
	public GameObject stockMarketGO;
	public createListWithLength CreateListWithLength;
	public stockMarketManager_1850 StockMarketManager_1850;
	public GameObject stockMarket_1850GO;
	public GAV GAV_;

	public GameObject playerUtiGO;
	public GameObject playerTechGO;

	[HideInInspector]public List<stock> stockListUti;
	public List<stock> stockListTech;

	//Lista där antal aktier i specifik sector sparas
	public List<float> utiCompanySharesOwned = new List<float>();
	public List<float> techCompanySharesOwned = new List<float>();
	public List<float> materialsCompanySharesOwned = new List<float>();

	//1850
	public List<float> minesCompanySharesOwned = new List<float>();
	public List<float> mineTotalInvestAmount;
	public List<float> mineTotalReturnAmount;
	public float mineTotalReturnPercent;
	public float mineTotalValue;
	public float minesTotalInvest;
	public List<float> minesCompanyGAV;

	public List<float> railroadCompanySharesOwned = new List<float>();
	public List<float> railroadTotalInvestAmount;
	public List<float> railroadTotalReturnAmount;
	public float railroadTotalReturnPercent;
	public float railroadTotalValue;
	public float railroadTotalInvest;
	public List<float> railroadCompanyGAV;

	public List<float> industriCompanySharesOwned = new List<float>();
	public List<float> industriTotalInvestAmount;
	public List<float> industriTotalReturnAmount;
	public float industriTotalReturnPercent;
	public float industriTotalValue;
	public float industriTotalInvest;
	public List<float> industriCompanyGAV;

	public List<float> utiGAV = new List<float>();
	public List<float> techGAV = new List<float>();
	

	public float totalValuePortfolio;
	public float totalInvestAmountPortfolio;
	public float totalReturnPortfolioPercent;
	public float totalReturnPortfolioAmount;
	public float totalValueUti;
	public float totalValueTech;

	public List<float> utiTotalInvest; //Summan som har investerats i specifikt företag
	public List<float> returnUtiCompanies;
	public float utiTotalInvestAmount;
	public float utiTotalReturnAmount;
	public float utiTotalReturnPercent;
	public float utiTotalValue;

	public List<float> techTotalInvest; //Summan som har investerats i specifikt företag
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
	public List<float> returnPortfolioEachTurn;

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
	public float mineSharePortfolio;
	public Text shareOfStockPortfolio_firstSector_1850;
	public float railroadSharePortfolio;
	public Text shareOfStockPortfolio_secondSector_1850;
	public float industriSharePortfolio;
	public Text shareOfStockPortfolio_thirdSector_1850;

	//SEKTORNS AVKASTNING
	public Text utiReturnText;
	public Text techReturnText;
	public Text minesReturnText;
	public Text railroadReturnText;
	public Text industriReturnText;

	public priceChange PriceChange;

	public Text valuePortfolioText;
	public Text returnPortfolioText;
	public Text dividendPerYearText;

	public utilitiesInfoStock UtilitiesInfoStock;
	public techInfoStock TechInfoStock;

	void Awake() {

		PriceChange = GetComponent<priceChange>();
		UtilitiesInfoStock = GetComponent<utilitiesInfoStock>();
		TechInfoStock = GetComponent<techInfoStock>();

		if (stockMarketGO.GetComponent<stockMarketManager>() != null)
		stockListUti = stockMarketGO.GetComponent<stockMarketManager>().StockUtiList;

		if(stockMarketGO.GetComponent<stockMarketManager>() != null)
		stockListTech = stockMarketGO.GetComponent<stockMarketManager>().StockTechList;

		//Skapar rätt längd på listor
		if (stockMarketGO.GetComponent<stockMarketManager>() != null)
		{
			utiCompanySharesOwned = CreateListWithLength.listWithRightLengthFloat(stockMarketGO.GetComponent<stockMarketManager>().StockPrefabUtiList.Count);
			utiTotalInvest = CreateListWithLength.listWithRightLengthFloat(stockMarketGO.GetComponent<stockMarketManager>().StockPrefabUtiList.Count);
			returnUtiCompanies = CreateListWithLength.listWithRightLengthFloat(stockMarketGO.GetComponent<stockMarketManager>().StockPrefabUtiList.Count);
			utiGAV = CreateListWithLength.listWithRightLengthFloat(stockMarketGO.GetComponent<stockMarketManager>().StockPrefabUtiList.Count);

			techCompanySharesOwned = CreateListWithLength.listWithRightLengthFloat(stockMarketGO.GetComponent<stockMarketManager>().StockTechList.Count);
			techTotalInvest = CreateListWithLength.listWithRightLengthFloat(stockMarketGO.GetComponent<stockMarketManager>().StockTechList.Count);
			returnTechCompanies = CreateListWithLength.listWithRightLengthFloat(stockMarketGO.GetComponent<stockMarketManager>().StockTechList.Count);
			techGAV = CreateListWithLength.listWithRightLengthFloat(stockMarketGO.GetComponent<stockMarketManager>().StockTechList.Count);

		}
		minesCompanySharesOwned = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListMines.Count);
		mineTotalInvestAmount = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListMines.Count);
		mineTotalReturnAmount = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListMines.Count);
		minesCompanyGAV = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListMines.Count);

		railroadCompanySharesOwned = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListRailroad.Count);
		railroadTotalInvestAmount = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListRailroad.Count);
		railroadTotalReturnAmount = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListRailroad.Count);
		railroadCompanyGAV = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListRailroad.Count);

		industriCompanySharesOwned = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListIndustri.Count);
		industriTotalInvestAmount = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListIndustri.Count);
		industriTotalReturnAmount = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListIndustri.Count);
		industriCompanyGAV = CreateListWithLength.listWithRightLengthFloat(StockMarketManager_1850.StockPrefabListIndustri.Count);
		
		//Text vid start
		valuePortfolioText.text = "Value: " + totalValuePortfolio; ;
		returnPortfolioText.text = "Return stocks: " + totalReturnPortfolioPercent;
	}

	public void addMineShares(int shares, int activeCompany)
	{
		minesCompanySharesOwned[activeCompany] += shares;
	}

	public void addRailroadShares(int shares, int activeCompany)
	{
		railroadCompanySharesOwned[activeCompany] += shares;
	}

	public void addIndustriShares(int shares, int activeCompany)
	{
		industriCompanySharesOwned[activeCompany] += shares;
	}

	public void checkIfAllStocksAreSold_ResetValues()
	{
		for (int i = 0; i < mineTotalInvestAmount.Count; i++)
		{
			if(minesCompanySharesOwned[i] == 0)
			{
				mineTotalInvestAmount[i] = 0;
				mineTotalReturnAmount[i] = 0;
				minesCompanyGAV[i] = 0;
			}
		}

		for (int i = 0; i < railroadTotalInvestAmount.Count; i++)
		{
			if (railroadCompanySharesOwned[i] == 0)
			{
				railroadTotalInvestAmount[i] = 0;
				railroadTotalReturnAmount[i] = 0;
				railroadCompanyGAV[i] = 0;
			}
		}

		for (int i = 0; i < industriTotalInvestAmount.Count; i++)
		{
			if (industriCompanySharesOwned[i] == 0)
			{
				industriTotalInvestAmount[i] = 0;
				industriTotalReturnAmount[i] = 0;
				industriCompanyGAV[i] = 0;
			}
		}
	}

	public void totalInvest() {

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
		for (int i = 0; i < utiTotalInvest.Count; i++) {
			//Debug.Log("Uti Längd: " + i);
			utiTotalInvestAmount = utiTotalInvestAmount + utiGAV[i] * utiCompanySharesOwned[i];
		}

		for (int i = 0; i < techTotalInvest.Count; i++) {
			techTotalInvestAmount = techTotalInvestAmount + techGAV[i] * techCompanySharesOwned[i];
			//Debug.Log("Tech Längd: " + i);
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

	public void totalInvest_1850()
	{
		minesTotalInvest = 0;
		railroadTotalInvest = 0;
		industriTotalInvest = 0;

		for (int i = 0; i < mineTotalInvestAmount.Count; i++)
		{
			//Debug.Log("Uti Längd: " + i);
			minesTotalInvest += mineTotalInvestAmount[i];
			minesCompanyGAV[i] = GAV_.GAV_OwnedSharesAndInvestedCapital(minesCompanySharesOwned[i], mineTotalInvestAmount[i]);
		}

		for (int i = 0; i < railroadTotalInvestAmount.Count; i++)
		{
			//Debug.Log("Uti Längd: " + i);
			railroadTotalInvest += railroadTotalInvestAmount[i];
			railroadCompanyGAV[i] = GAV_.GAV_OwnedSharesAndInvestedCapital(railroadCompanySharesOwned[i], railroadTotalInvestAmount[i]);
		}

		for (int i = 0; i < industriTotalInvestAmount.Count; i++)
		{
			//Debug.Log("Uti Längd: " + i);
			industriTotalInvest += industriTotalInvestAmount[i];
			industriCompanyGAV[i] = GAV_.GAV_OwnedSharesAndInvestedCapital(industriCompanySharesOwned[i], industriTotalInvestAmount[i]);
		}
		//GetComponent<GAV>().minesGAV();
		

		totalInvestAmountPortfolio = minesTotalInvest + railroadTotalInvest + industriTotalInvest;
		//Debug.Log("Total investering: " + totalInvestAmountPortfolio);
	}

	public void returnFromSector_1850()
	{
		mineTotalValue = 0;
		railroadTotalValue = 0;
		industriTotalValue = 0;

		//Gruvor (Avkastning)
		for (int i = 0; i < minesCompanySharesOwned.Count; i++)
		{
			int lengthList = StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice.Count;
			mineTotalValue += (minesCompanySharesOwned[i] * StockMarketManager_1850.StockPrefabListMines[i].GetComponent<stock>().StockPrice[lengthList - 1]);
			
		}

		mineTotalReturnPercent = returnStockSector(mineTotalValue, minesTotalInvest);
		//mineTotalReturnPercent = mineTotalValue / minesTotalInvest - 1;

		//___________

		//Järnväg (Avkastning)
		for (int i = 0; i < railroadCompanySharesOwned.Count; i++)
		{
			int lengthList = StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().StockPrice.Count;
			railroadTotalValue += (railroadCompanySharesOwned[i] * StockMarketManager_1850.StockPrefabListRailroad[i].GetComponent<stock>().StockPrice[lengthList - 1]);
			//Debug.Log("Totalt värde (Järnväg): " + railroadTotalValue);
			
		}

		railroadTotalReturnPercent = returnStockSector(railroadTotalValue, railroadTotalInvest);
		//railroadTotalReturnPercent = railroadTotalValue / railroadTotalInvest - 1;
		//____________

		//Industri (Avkastning)
		for (int i = 0; i < industriCompanySharesOwned.Count; i++)
		{
			if (StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>() != null)
			{
				int lengthList = StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().StockPrice.Count;
				industriTotalValue += (industriCompanySharesOwned[i] * StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<priceStock>().StockPrice[lengthList - 1]);
			}
			else
			{
				int lengthList = StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stock>().StockPrice.Count;
				industriTotalValue += (industriCompanySharesOwned[i] * StockMarketManager_1850.StockPrefabListIndustri[i].GetComponent<stock>().StockPrice[lengthList - 1]);
			}

			//Debug.Log("Totalt värde (Industri): " + industriTotalValue);
		}

		industriTotalReturnPercent = returnStockSector(industriTotalValue, industriTotalInvest);
		//industriTotalReturnPercent = industriTotalValue / industriTotalInvest - 1;


	}
	public void showPortfolioData_1850()
		{
		totalInvest_1850();
		returnFromSector_1850();

		//Avkastning
		minesReturnText.text = " " + Mathf.Round(mineTotalReturnPercent * 10000) / 100 + "%";
		railroadReturnText.text = " " + Mathf.Round(railroadTotalReturnPercent * 10000) / 100 + "%";
		industriReturnText.text = " " + Mathf.Round(industriTotalReturnPercent * 10000) / 100 + "%";

		//Andel av portfölj
		totalValuePortfolio = mineTotalValue + railroadTotalValue + industriTotalValue;

		mineSharePortfolio = mineTotalValue / totalValuePortfolio;
		railroadSharePortfolio = railroadTotalValue / totalValuePortfolio;
		industriSharePortfolio = industriTotalValue / totalValuePortfolio;

		shareOfStockPortfolio_firstSector_1850.text = " " + Mathf.Round(mineSharePortfolio * 100) + "%";
		shareOfStockPortfolio_secondSector_1850.text = " " + Mathf.Round(railroadSharePortfolio * 100) + "%";
		shareOfStockPortfolio_thirdSector_1850.text = " " + Mathf.Round(industriSharePortfolio * 100) + "%";
		//techSharePortfolioText.text = " " + Mathf.Round(techSharePortfolio * 100) + "%";

	}

	public void returnPortfolio_1850()
	{
		totalInvest_1850();
		valuePortfolio();
		//Debug.Log("Värde portfölj: " + totalValuePortfolio);
		//Debug.Log("Investerat i portfölj: " + totalInvestAmountPortfolio);
		totalReturnPortfolioPercent = (totalValuePortfolio / totalInvestAmountPortfolio)-1;
		returnPortfolioText.text = "Return stocks: " + Mathf.Round(totalReturnPortfolioPercent*100) + "%";
		savePortfolioReturnEachTurn();
	}

	public void showPortfolioData() {

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
				utiTotalValue += (utiCompanySharesOwned[i] * stockListUti[i].StockPrice[stockListUti[i].StockPrice.Count - 1]);
				//utiSharePortfolio += utiTotalValue;

			}

			for (int i = 0; i < stockListTech.Count; i++)
			{
				techTotalValue += (techCompanySharesOwned[i] * stockListTech[i].StockPrice[stockListTech[i].StockPrice.Count - 1]);
				//techSharePortfolio += techTotalValue;
				//Debug.Log("UtiShare: " + techSharePortfolio);
			}

			totalValuePortfolio = utiTotalValue + techTotalValue;

			utiSharePortfolio = utiTotalValue / totalValuePortfolio;
			techSharePortfolio = techTotalValue / totalValuePortfolio;

			utiSharePortfolioText.text = " " + Mathf.Round(utiSharePortfolio * 100) + "%";
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
		if (stockListUti != null)
		{
			returnUtiCompanies = playerUtiGO.GetComponent<returnPortfolio>().returnStocksPercent(stockListUti, utiGAV);
			utiTotalReturnAmount = playerUtiGO.GetComponent<returnPortfolio>().returnSector(stockListUti, utiGAV, utiCompanySharesOwned);

			utiTotalReturnPercent = utiTotalReturnAmount / utiTotalInvestAmount;
			utiReturnText.text = " " + Mathf.Round(utiTotalReturnPercent * 10000) / 100 + "%";
		}
			//Tech
			returnTechCompanies = playerTechGO.GetComponent<returnPortfolio>().returnStocksPercent(stockListTech, techGAV);
			techTotalReturnAmount = playerTechGO.GetComponent<returnPortfolio>().returnSector(stockListTech, techGAV, techCompanySharesOwned);

			techTotalReturnPercent = techTotalReturnAmount / techTotalInvestAmount;
			techReturnText.text = " " + Mathf.Round(techTotalReturnPercent * 10000) / 100 + "%";

			totalReturnPortfolioAmount = utiTotalReturnAmount + techTotalReturnAmount;

			totalInvest();
			totalReturnPortfolioPercent = (totalReturnPortfolioAmount / totalInvestAmountPortfolio)-1;
			savePortfolioReturnEachTurn();
		}

		public void savePortfolioReturnEachTurn()
		{

			returnPortfolioEachTurn.Add(totalReturnPortfolioPercent);
		}

		public void valuePortfolio()
		{
			//Debug.Log("ValuePortfolio");
			totalValuePortfolio = 0; //Nollställer innan varje körning

			//totalValuePortfolio = GetComponent<valuePortfolio>().valueSector(utiCompanySharesOwned, stockListUti);
			//totalValuePortfolio += GetComponent<valuePortfolio>().valueSector(techCompanySharesOwned, stockListTech);
			totalValuePortfolio += GetComponent<valuePortfolio>().valueSectorGameObjects_PrefabOne(minesCompanySharesOwned, StockMarketManager_1850.StockPrefabListMines);
			totalValuePortfolio += GetComponent<valuePortfolio>().valueSectorGameObjects_PrefabOne(railroadCompanySharesOwned, StockMarketManager_1850.StockPrefabListRailroad);

		//totalValuePortfolio += GetComponent<valuePortfolio>().valueSectorGameObjects_PrefabTwo(industriCompanySharesOwned, StockMarketManager_1850.StockPrefabListIndustri);
		totalValuePortfolio += GetComponent<valuePortfolio>().valueSectorGameObjects_PrefabOne(industriCompanySharesOwned, StockMarketManager_1850.StockPrefabListIndustri);
		//Debug.Log("ValuePortfolio");

		valuePortfolioText.text = "Value: " + totalValuePortfolio;
		}

	public float returnStockSector(float valueSector, float investedAmountSector)
	{
		float result;
		if (investedAmountSector == 0)
		{
			return 0;
		}
		else
		{
			result = valueSector / investedAmountSector - 1;
		}

		return result;
	}

	}

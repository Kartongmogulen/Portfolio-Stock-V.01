using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stocks_UnlockInfo_1850 : MonoBehaviour
{
	public actionPointsManager ActionPointsManager;
	public createListWithLength CreateListWithLength;
	public stockMarketManager_1850 StockMarketManager;
	public CityManager cityManager;
	public activeSector_1850 ActiveSector_1850;
	public chooseCompany_1850 ChooseCompany_1850;

	[SerializeField] int divPolicyUnlockCost;

	//Div policy
	public List<int> minesDivPolicyUnlocked; //= new int[2];//0 = Spelaren har inte låst upp
	public List<int> railroadDivPolicyUnlocked; //= new int[2];//0 = Spelaren har inte låst upp

	[SerializeField] int activeCity;
	[SerializeField] int activeSector;

	private void Start()
	{
		minesDivPolicyUnlocked = CreateListWithLength.listWithRightLengthInt(StockMarketManager.StockPrefabListMines.Count);
		railroadDivPolicyUnlocked = CreateListWithLength.listWithRightLengthInt(StockMarketManager.StockPrefabListRailroad.Count);
	}


	public void unlockDivPolicy()
	{
		activeSector = ActiveSector_1850.getActiveSector();
		activeCity = cityManager.getActiveCity();

		//MINES
		if (ActionPointsManager.remainingAP >= divPolicyUnlockCost && minesDivPolicyUnlocked[activeCity] == 0)
		{
			if (activeSector == 0) //&& activeCity == 0)
			{
				minesDivPolicyUnlocked[activeCity] = 1;
				ActionPointsManager.actionPointSub(divPolicyUnlockCost);
				ChooseCompany_1850.chooseCompany();
				Debug.Log("Mines One: Div Pol UNLOCKED!");
			}
			if (activeSector == 1) //&& activeCity == 0)
			{
				railroadDivPolicyUnlocked[activeCity] = 1;
				ActionPointsManager.actionPointSub(divPolicyUnlockCost);
				ChooseCompany_1850.chooseCompany();
				Debug.Log("Mines One: Div Pol UNLOCKED!");
			}


		}

	}

	public int getCost_UnlockDivPolicy()
	{
		return divPolicyUnlockCost;
	}
}

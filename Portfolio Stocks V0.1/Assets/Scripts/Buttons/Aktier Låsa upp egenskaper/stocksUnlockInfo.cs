using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Kontrollera vilken data spelaren har tillgång till

public class stocksUnlockInfo : MonoBehaviour
{
	public chooseCompany ChooseCompany; 
	public utilitiesInfoStock UtilitiesInfoStock;
	public techInfoStock TechInfoStock;
	public actionPointsManager ActionPointsManager;

	public int divPolicyUnlockCost;
	public int epsGrowthUnlockCost;

	public int[] utiDivPolicyUnlocked = new int[2];//0 = Spelaren har inte låst upp
	public int[] utiEPSGrowthUnlocked = new int[2];//0 = Spelaren har inte låst upp 

	public int[] techDivPolicyUnlocked = new int[2];//0 = Spelaren har inte låst upp
	public int[] techEPSGrowthUnlocked = new int[2];//0 = Spelaren har inte låst upp 

	public int activeSector;
	public int activeCompany;

	public GameObject playerScriptsGO;
	public GameObject scriptsStockGO;
	public GameObject managerScriptsStockGO;

	void Awake(){

		ChooseCompany = GetComponent<chooseCompany> ();
		UtilitiesInfoStock = scriptsStockGO.GetComponent<utilitiesInfoStock> ();
		TechInfoStock = scriptsStockGO.GetComponent<techInfoStock> ();
		ActionPointsManager = managerScriptsStockGO.GetComponent<actionPointsManager>();
	}

	public void unlockDivPolicy(){
		activeSector = ChooseCompany.activeSector;
		activeCompany = ChooseCompany.activeCompany;

		//UTILITIES
		if (ActionPointsManager.remainingAP >= divPolicyUnlockCost && utiDivPolicyUnlocked [activeCompany-1] == 0){
			if (activeSector == 1 && activeCompany == 1) {
				utiDivPolicyUnlocked [activeCompany-1] = 1;
				ActionPointsManager.actionPointSub(divPolicyUnlockCost);
				ChooseCompany.chosenCompanyOne ();
			}
		}
		
		if (ActionPointsManager.remainingAP >= divPolicyUnlockCost && utiDivPolicyUnlocked [activeCompany-1] == 0){
			if (activeSector == 1 && activeCompany == 2) {
				utiDivPolicyUnlocked [activeCompany-1] = 1;
				ActionPointsManager.actionPointSub(divPolicyUnlockCost);
				ChooseCompany.chosenCompanyTwo ();
			}
		}
		
		//TECH
		if (ActionPointsManager.remainingAP >= divPolicyUnlockCost && techDivPolicyUnlocked [activeCompany-1] == 0){
			if (activeSector == 2 && activeCompany == 1) {
				techDivPolicyUnlocked [activeCompany-1] = 1;
				ActionPointsManager.actionPointSub(divPolicyUnlockCost);
				ChooseCompany.chosenCompanyOne ();
			}
		}
		
		if (ActionPointsManager.remainingAP >= divPolicyUnlockCost && techDivPolicyUnlocked [activeCompany-1] == 0){
			if (activeSector == 2 && activeCompany == 2) {
				techDivPolicyUnlocked [activeCompany-1] = 1;
				ActionPointsManager.actionPointSub(divPolicyUnlockCost);
				ChooseCompany.chosenCompanyTwo ();
			}
		}
		

	}

	public void growthEPS(){
		activeSector = ChooseCompany.activeSector;
		activeCompany = ChooseCompany.activeCompany;
		
		//UTILITIES
		if (ActionPointsManager.remainingAP >= UtilitiesInfoStock.costUnlockEPSGrowth && utiEPSGrowthUnlocked [activeCompany - 1] == 0) {
			if (activeSector == 1 && activeCompany == 1) {
				utiEPSGrowthUnlocked [activeCompany-1] = 1;
				ActionPointsManager.actionPointSub(epsGrowthUnlockCost);
				ChooseCompany.chosenCompanyOne();
			}
		}
		
		if (ActionPointsManager.remainingAP >= UtilitiesInfoStock.costUnlockEPSGrowth && utiEPSGrowthUnlocked [activeCompany - 1] == 0) {
			if (activeSector == 1 && activeCompany == 2) {
				utiEPSGrowthUnlocked [activeCompany-1] = 1;
				ActionPointsManager.actionPointSub(epsGrowthUnlockCost);
				ChooseCompany.chosenCompanyTwo();
			}
		}
		
		//TECH
		if (ActionPointsManager.remainingAP >= TechInfoStock.costUnlockEPSGrowth && techEPSGrowthUnlocked [activeCompany - 1] == 0) {
			if (activeSector == 2 && activeCompany == 1) {
				techEPSGrowthUnlocked [activeCompany - 1] = 1;
				ActionPointsManager.actionPointSub(epsGrowthUnlockCost);
				ChooseCompany.chosenCompanyOne();
			}
		}

		if (ActionPointsManager.remainingAP >= TechInfoStock.costUnlockEPSGrowth && techEPSGrowthUnlocked [activeCompany - 1] == 0) {
			if (activeSector == 2 && activeCompany == 2) {
				techEPSGrowthUnlocked [activeCompany - 1] = 1;
				ActionPointsManager.actionPointSub(epsGrowthUnlockCost);
				ChooseCompany.chosenCompanyTwo();
			}
		}
	}
}

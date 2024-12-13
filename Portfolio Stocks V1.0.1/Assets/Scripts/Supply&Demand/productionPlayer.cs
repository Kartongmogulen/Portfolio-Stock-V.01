using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productionPlayer : MonoBehaviour
{
    [SerializeField] int foodProduction;
    [SerializeField] int waterProduction;
    [SerializeField] int woodProduction;
    public projectsUI ProjectsUI;
    [SerializeField] supplyIncreaseProjects project;
    public SupplyDemandManager supplyDemandManagerSO;

    public totalCash TotalCash;
    public moneyManager MoneyManager;
    public bool moneyEnough;

    public void addProduction()
    {
        project = ProjectsUI.getActiveProject();
        
        moneyEnough = MoneyManager.HasEnoughMoney(project.getPrice());
        
        Debug.Log("Name Project: " + project.NeedsName);
        Debug.Log("Tillr�ckligt med pengar: " + moneyEnough);
        
        if (moneyEnough == true)
        {

           TotalCash.transactionMoneyNoUpdateText( -project.getPrice());

            //Uppdaterar Behovets Suppply
            foreach (NeedsPeople needs in supplyDemandManagerSO.needsPeoplesList)
            {
                Debug.Log("Foreach Add production");
                if (project.NeedsName == needs.NeedsName)
                {
                    needs.setSupply(project.getOutput());
                }
            }

            if (project.NeedsName == needsName.Food)
            {
                //�ka produktion f�r spelaren
                foodProduction += project.getOutput();
                Debug.Log("Food: " + foodProduction);

            }

            if (project.NeedsName == needsName.Water)
            {
                //�ka produktion f�r spelaren
                waterProduction += project.getOutput();

            }

            if (project.NeedsName == needsName.Wood)
            {
                //�ka produktion f�r spelaren
                woodProduction += project.getOutput();

            }

        }
    }


    public int getFoodProduction()
    {
        return foodProduction;
    }

    public int getWaterProduction()
    {
        return waterProduction;
    }

    public int getWoodProduction()
    {
        return woodProduction;
    }
}

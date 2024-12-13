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
        Debug.Log("Tillräckligt med pengar: " + moneyEnough);
        
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
                //Öka produktion för spelaren
                foodProduction += project.getOutput();
                Debug.Log("Food: " + foodProduction);

            }

            if (project.NeedsName == needsName.Water)
            {
                //Öka produktion för spelaren
                waterProduction += project.getOutput();

            }

            if (project.NeedsName == needsName.Wood)
            {
                //Öka produktion för spelaren
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class projectsUI : MonoBehaviour
{
    public Text nameNeed;
    public Text cost;
    public Text output;

    public Button buttonBuy;

    [SerializeField] supplyIncreaseProjects activeProject;
    public SupplyDemandManager supplyDemandManager;
    [SerializeField] projectsManager ProjectsManager;

    //Kontrollerar valt behov och uppdaterar projekt utifrån det
    public void updateUIfromNeed()
    {

        activeProject = ProjectsManager.getProject(supplyDemandManager.getActiveNeedID());

        nameNeed.text = "Need: " + activeProject.NeedsName;
        cost.text = "Cost: " + activeProject.getPrice();
        output.text = "Output (units): " + activeProject.getOutput();
        
    }

    public void updateUIFromProject(supplyIncreaseProjects project)
    {
        activeProject = project;

        nameNeed.text = "Need: " + project.NeedsName;
        cost.text = "Cost: " + project.getPrice();
        output.text = "Output (units): " + project.getOutput();
    }

    public supplyIncreaseProjects getActiveProject()
    {
        return activeProject;
    }

}

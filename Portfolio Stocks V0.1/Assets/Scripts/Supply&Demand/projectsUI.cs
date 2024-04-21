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

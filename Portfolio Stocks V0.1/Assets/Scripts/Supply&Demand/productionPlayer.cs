using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productionPlayer : MonoBehaviour
{
    [SerializeField] int foodProduction;
    public projectsUI ProjectsUI;
    [SerializeField] supplyIncreaseProjects project;

    public void addProduction ()
    {
       project = ProjectsUI.getActiveProject();

       Debug.Log("Name Project: " + project.NeedsName);

    if (project.NeedsName == needsName.Food)
        {
            foodProduction += project.getOutput();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectsManager : MonoBehaviour
{
    [SerializeField] List<supplyIncreaseProjects> projectsList;

    public supplyIncreaseProjects getProject(int id)
    {
        return projectsList[id];
    }

}

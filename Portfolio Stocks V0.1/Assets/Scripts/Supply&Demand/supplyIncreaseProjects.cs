using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Projects", menuName = "Needs/Projects")]
public class supplyIncreaseProjects : ScriptableObject
{
    public needsName NeedsName; //Vilket behov projektet tillgodoser
    [SerializeField] float price;
    [SerializeField] int output;

    public float getPrice()
    {
        return price;
    }

    public int getOutput()
    {
        return output;
    }
}

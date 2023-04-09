using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sectorEffectFromEconomicClimateSO")]

public class sectorEffectFromEconomicClimateSO : ScriptableObject
{
    public float utilitesFactor; //Hur makrofaktorer påverkar Earnings
    public float technologyFactor; //Hur makrofaktorer påverkar Earnings
    //public int utilitesRecession;
}

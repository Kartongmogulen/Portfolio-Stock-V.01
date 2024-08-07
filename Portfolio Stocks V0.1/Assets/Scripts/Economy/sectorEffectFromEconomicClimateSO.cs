using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sectorEffectFromEconomicClimateSO")]

public class sectorEffectFromEconomicClimateSO : ScriptableObject
{
    public float utilitesFactor; //Hur makrofaktorer p�verkar Earnings
    public float technologyFactor; //Hur makrofaktorer p�verkar Earnings
    public float minesFactor; //Hur makrofaktorer p�verkar Earnings
    public float railroadFactor; //Hur makrofaktorer p�verkar Earnings
    public float industriFactor; //Hur makrofaktorer p�verkar Earnings
    //public int utilitesRecession;
}

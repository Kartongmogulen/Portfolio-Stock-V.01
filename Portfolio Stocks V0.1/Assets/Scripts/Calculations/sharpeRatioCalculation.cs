using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpeRatioCalculation : MonoBehaviour
{
    [SerializeField] float result;
    
    public float sharpeRatio(float riskFreeRate, float returnAsset, float standardDeviation)
    {
        
        result = (returnAsset - riskFreeRate) / standardDeviation;

        return result;
    }
}

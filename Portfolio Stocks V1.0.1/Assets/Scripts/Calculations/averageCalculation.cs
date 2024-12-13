using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class averageCalculation : MonoBehaviour
{
    //Ber�knar medelv�rde av ett dataset
    private float averageResult;
    [SerializeField] float sumFromDataSet;

    public float listOfFloats(List<float> dataset)
    {
        sumFromDataSet = 0;

        foreach (float f in dataset)
        {
            sumFromDataSet += f;
        }

        //Ber�knar medelpriset
        averageResult = sumFromDataSet / dataset.Count;

        return averageResult;
    }
}

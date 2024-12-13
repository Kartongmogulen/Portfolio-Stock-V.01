using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class averageCalculation : MonoBehaviour
{
    //Beräknar medelvärde av ett dataset
    private float averageResult;
    [SerializeField] float sumFromDataSet;

    public float listOfFloats(List<float> dataset)
    {
        sumFromDataSet = 0;

        foreach (float f in dataset)
        {
            sumFromDataSet += f;
        }

        //Beräknar medelpriset
        averageResult = sumFromDataSet / dataset.Count;

        return averageResult;
    }
}

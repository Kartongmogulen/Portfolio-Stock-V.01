using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalizeValue : MonoBehaviour
{
    //Normaliserar v�rdet mot en referens

    public float result;

    public float normalizeOneValue(float valueToNomalize, float referenceValue)
    {

        Debug.Log("normalized value");
        result = valueToNomalize / referenceValue;

        return result;
    }
}

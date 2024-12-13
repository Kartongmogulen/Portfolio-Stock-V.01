using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalizeValue : MonoBehaviour
{
    //Normaliserar värdet mot en referens

    public float result;

    public float normalizeOneValue(float valueToNomalize, float referenceValue)
    {

        result = valueToNomalize / referenceValue;

        return result;
    }
}

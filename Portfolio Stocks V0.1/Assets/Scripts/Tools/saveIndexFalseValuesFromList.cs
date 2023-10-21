using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveIndexFalseValuesFromList : MonoBehaviour
{
    public List<int> getIndexFalseValues(List<bool> ListToCheck)
    {
        List<int> falseIndexes = new List<int>();

        for (int i = 0; i < ListToCheck.Count; i++)
        {
            if (!ListToCheck[i]) // Om elementet är falskt
            {
                falseIndexes.Add(i); // Spara index i listan
            }
        }

    return falseIndexes;

    }
}

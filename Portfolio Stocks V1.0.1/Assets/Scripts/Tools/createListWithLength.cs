using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createListWithLength : MonoBehaviour
{
    
    public List<float> listWithRightLengthFloat(int lengthToCreate)
    {
        List<float> resultList = new List<float>();

        for (int i = 0; i < lengthToCreate; i++)
        {
            resultList.Add(0);
        }

        return resultList;
    }

    public List<int> listWithRightLengthInt(int lengthToCreate)
    {
        List<int> resultList = new List<int>();

        for (int i = 0; i < lengthToCreate; i++)
        {
            resultList.Add(0);
        }

        return resultList;
    }


}

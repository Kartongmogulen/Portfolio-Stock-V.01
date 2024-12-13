using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class employeeStatManager : MonoBehaviour
{
    [SerializeField] int priceToHire;

    public int getPriceToHire()
    {
        return priceToHire;
    }
    
}

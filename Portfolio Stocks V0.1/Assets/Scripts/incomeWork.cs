using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incomeWork : MonoBehaviour
{
    public float incomeWorkPerMonth;
    public float totalIncomeFromWork;

   public void incomeDuringLife()
    {
        totalIncomeFromWork += incomeWorkPerMonth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stockInformation : MonoBehaviour
{
  public sectorNameEnum SectorName;
    [SerializeField] int numberOfSharesStart;
    [SerializeField] int numberOfSharesNow;
    public string nameCompany;

    private void Awake()
    {
        numberOfSharesNow = numberOfSharesStart;
    }

    public int getNumberOfShares()
    {
        return numberOfSharesNow;
    }

}

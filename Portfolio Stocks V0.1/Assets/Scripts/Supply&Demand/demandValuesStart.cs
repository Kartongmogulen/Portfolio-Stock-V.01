using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demandValuesStart : MonoBehaviour
{
    public List<int> demandValues;
    public SupplyDemandManager supplyDemandManager;

    private void Start()
    {
        resetListInSO();

        if (supplyDemandManager.demandRandomStart == true)
        {
            setStartDemandValues();
        }
    }

    public void resetListInSO()
    {

        supplyDemandManager.demandStart.Clear();
        
    }

    //Sätter startvärde för Demand. Varje index kan endast användas en gång
    public void setStartDemandValues()
    {
        for (int i = 0; i < supplyDemandManager.needsPeoplesList.Count; i++)
        {
            int random = Random.Range(0, demandValues.Count);
            supplyDemandManager.needsPeoplesList[i].setDemand(demandValues[random]);
            demandValues.RemoveAt(random);
        }
    }
}

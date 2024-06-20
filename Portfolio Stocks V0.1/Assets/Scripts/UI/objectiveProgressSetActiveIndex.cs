using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class objectiveProgressSetActiveIndex : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] int thisObjectsIndex;
    public objectiveProgressUI ObjectiveProgressUI;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Debug.Log("Index: " + thisObjectsIndex);
        ObjectiveProgressUI.setActiveIndex(thisObjectsIndex);
    }

}

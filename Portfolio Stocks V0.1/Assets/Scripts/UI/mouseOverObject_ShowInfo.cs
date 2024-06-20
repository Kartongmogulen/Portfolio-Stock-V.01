using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mouseOverObject_ShowInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //public bool mouseOverObject;
    public GameObject objectToActivate;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        objectToActivate.SetActive(true);
    }

   public void OnPointerExit(PointerEventData pointerEventData)
    {
        objectToActivate.SetActive(false);
    }
}
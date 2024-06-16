using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mouseOverObject_ShowInfo : MonoBehaviour
{
    public bool mouseOverObject;
    public GameObject objectToActivate;

    private void Update()
    {
        isMouseOverUI();
        if (mouseOverObject == true)
        {
            objectToActivate.SetActive(true);
            
        }
        else
            objectToActivate.SetActive(false);

    }

    private bool isMouseOverUI()
    {


        if (EventSystem.current.IsPointerOverGameObject() == true)
        {
            mouseOverObject = true;
        }
        else
            mouseOverObject = false;

        return mouseOverObject;
    }

}
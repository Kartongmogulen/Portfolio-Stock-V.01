using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class objectiveProgressSetActiveIndex : MonoBehaviour
{
    [SerializeField] int thisObjectsIndex;
    public objectiveProgressUI ObjectiveProgressUI;

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            Debug.Log("Mus över objekt");
            //currentHoveredObject = gameObject;
            //ActivateObject();
        }
            //setIndex();
    }


    public void setIndex()
    {
        Debug.Log("Detta index: " + thisObjectsIndex);
        ObjectiveProgressUI.setActiveIndex(thisObjectsIndex);
    }

}

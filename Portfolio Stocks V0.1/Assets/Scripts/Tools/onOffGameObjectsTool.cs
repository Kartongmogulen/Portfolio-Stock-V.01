using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onOffGameObjectsTool : MonoBehaviour
{
    public GameObject objectToActivate;
    public List<GameObject> objectsToTurnOff;
    [SerializeField] bool stayActiveEvenWhenButtonPress; //Om objektet ska vara aktivt även om man trycker på samma knapp

    public void activateObject()
    {
        if (objectToActivate.activeSelf && stayActiveEvenWhenButtonPress == false)
        {
            objectToActivate.SetActive(false);
        }
        else
        {
            objectToActivate.SetActive(true);
            turnOffObjects();
        }
    }

    public void turnOffObjects()
    {
        for (int i = 0; i < objectsToTurnOff.Count; i++)
        {
            objectsToTurnOff[i].SetActive(false);
        }
    }
}

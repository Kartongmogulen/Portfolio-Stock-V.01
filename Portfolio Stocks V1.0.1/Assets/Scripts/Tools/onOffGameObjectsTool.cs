using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onOffGameObjectsTool : MonoBehaviour
{
    public GameObject objectToActivate;
    public List<GameObject> objectS_ToActivate;
    public List<GameObject> objectsToTurnOff;
    [SerializeField] bool stayActiveEvenWhenButtonPress; //Om objektet ska vara aktivt även om man trycker på samma knapp
    [SerializeField] bool activateAtStart;
    [SerializeField] bool inactivateAtStart;

    private void Start()
    {
        if (activateAtStart == true)
        {
            if (objectToActivate != null)
            {
                activateObject();
                objectToActivate.SetActive(true);
            }

            else
            {
                activateObjectS();
            }
        }  

        if(inactivateAtStart == true)
        {
            turnOffObjects();
        }
    }

    public void activateObjectS()
    {
       
        for (int i = 0; i < objectS_ToActivate.Count; i++)
        {
            objectS_ToActivate[i].SetActive(true);
        }
    }

public void activateObject()
    {
        //Debug.Log("Aktivera objekt: " + objectToActivate.name);
        if (objectToActivate.activeSelf == true && stayActiveEvenWhenButtonPress == false)
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

    public void turnOnOrOffEachClick()
    {
        if (objectToActivate.activeSelf == true)
        {
            objectToActivate.SetActive(false);
        }
        else
            objectToActivate.SetActive(true);
    }
}

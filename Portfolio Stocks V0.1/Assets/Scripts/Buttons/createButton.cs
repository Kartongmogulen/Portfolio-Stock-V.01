using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createButton : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;  // Prefab för knappen
    public Transform parentTransform;
    [SerializeField] int latestID;
    [SerializeField] showEventInfo ShowEventInfo;

    public void buttonSpawn()
    {
        Debug.Log("ButtonSpawn");
        GameObject buttonInstance = Instantiate(buttonPrefab, parentTransform);

        // Ställ in knappens text
        Text buttonTextComponent = buttonInstance.GetComponentInChildren<Text>();
        if (buttonTextComponent != null)
        {
            buttonTextComponent.text = "" + (latestID+1);
        }

        //Koppla info till knappen
        ShowEventInfo = FindObjectOfType<showEventInfo>();
        ShowEventInfo.index = latestID;
       
        latestID++;
    }

}

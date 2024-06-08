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
        GameObject buttonInstance = Instantiate(buttonPrefab, parentTransform);

        // Ställ in knappens text
        Text buttonTextComponent = buttonInstance.GetComponentInChildren<Text>();
        if (buttonTextComponent != null)
        {
            buttonTextComponent.text = "" + (latestID+1);
        }

        //Koppla info till knappen
        //Button button = buttonInstance.GetComponent<Button>();
        ShowEventInfo = FindObjectOfType<showEventInfo>();
        ShowEventInfo.index = latestID;
        //buttonInstance.GetComponent<Button>().onClick.AddListener(() => ShowEventInfo.updateUI());
        //button.onClick.AddListener(OnButtonClick);     

        latestID++;
    }

    public void OnButtonClick()
    {
        Debug.Log("Knapp");
    }
}

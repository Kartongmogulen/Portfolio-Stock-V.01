using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateUITool : MonoBehaviour
{
    [SerializeField] List<Text> textToUpdateList;
    [SerializeField] List<string> textStartList;

    public void updateTextStart ()
    {
        for(int i = 0; i < textStartList.Count; i++)
        {
            textToUpdateList[i].text = "" + textStartList[i];// + figure[i];
        }
    }

  
}

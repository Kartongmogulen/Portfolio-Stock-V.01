using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cityNameTextStartOfGame : MonoBehaviour
{
    [SerializeField] List<Button> cityChooseButton;
    [SerializeField] List<Text> cityTextButton;
    public colorButtonFromList ColorButtonFromList;

    // Start is called before the first frame update
    void Start()
    {
        setName();
        ColorButtonFromList.colorOnButtonGreen(0);
    }

    public void setName()
    {
        for (int i = 0; cityChooseButton.Count > i; i++)
        {
            cityTextButton[i].text = "" + cityChooseButton[i].GetComponent<cityNameText>().getCityName(i);
        }
    }

    
}

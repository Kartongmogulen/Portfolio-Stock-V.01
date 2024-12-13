using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorButtonFromList : MonoBehaviour
{
    //Från en lista se till att endast den senaste aktiva blir grön
    public List<Button> buttonList;
    public int activeObject;

    private void Start()
    {
        //setAllColorToWhite();
    }

    public void setAllColorToWhite()
    {
        foreach (Button button in buttonList)
        {
            button.GetComponent<Image>().color = Color.white;
        }
    }

    public void colorOnButtonGreen(int i)
    {
        setAllColorToWhite();
        buttonList[i].GetComponent<Image>().color = Color.green;
        activeObject = i;
    }

    //GetComponent<Image>().color = Color.green;
}

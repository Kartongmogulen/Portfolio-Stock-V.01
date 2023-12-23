using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_clickOtherButton : MonoBehaviour
{
    [SerializeField] Button button_1;

    public void clickSingelButton()
    {
        button_1.onClick.Invoke();
    }
}

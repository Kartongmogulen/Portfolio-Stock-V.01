using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePlayAssetClasses : MonoBehaviour
{
    //Vilka olika tillg�ngar som ska vara tillg�ngliga

    public bool Bonds;

    public GameObject bondsButtonPanel;

    private void Start()
    {
        bondsActiveOrNot();
    }

    public void bondsActiveOrNot()
    {
        if (Bonds == true)
        {
            bondsButtonPanel.SetActive(true);
        }
        else bondsButtonPanel.SetActive(false);
    }

}

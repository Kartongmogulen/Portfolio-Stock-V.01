using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePlayAssetClasses : MonoBehaviour
{
    //Vilka olika tillgångar som ska vara tillgängliga

    public bool Bonds;

    public GameObject bondsButtonPanel;
    public GameObject bondsButtonPanel_1850;

    //Portfölj-vy
    public List<GameObject> stocksAndBondsUpdateButton;

    private void Start()
    {
        bondsActiveOrNot();
    }

    public void bondsActiveOrNot()
    {
        if (Bonds == true)
        {
            bondsButtonPanel.SetActive(true);
            bondsButtonPanel_1850.SetActive(true);
        }
        else
        {
            if (bondsButtonPanel != null)
            {
                bondsButtonPanel.SetActive(false);
                bondsButtonPanel_1850.SetActive(false);
            }

            for (int i = 0; i < stocksAndBondsUpdateButton.Count; i++) 
            {
                stocksAndBondsUpdateButton[i].SetActive(false);
            }
        }
    }

}

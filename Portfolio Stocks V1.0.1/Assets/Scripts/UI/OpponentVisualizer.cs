using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpponentVisualizer : MonoBehaviour
{
    public List<GameObject> OpponentList;
    public List<TextMeshProUGUI> nameTextList;
    public List<TextMeshProUGUI> moneyTextList;

    private void Update()
    {
        updateNameUI();
        updateMoneyUI();
    }

    public void updateNameUI()
    {
        for (int i = 0; i < OpponentList.Count; i++)
        {
            nameTextList[i].text = "" + OpponentList[i].GetComponent<AIManager_CardMechanic>().name;
        }
    }

    public void updateMoneyUI()
    {
        for (int i = 0; i < OpponentList.Count; i++)
        {
            moneyTextList[i].text = "" + OpponentList[i].GetComponent<moneyManager>().MoneyNow;
        }
    }
}

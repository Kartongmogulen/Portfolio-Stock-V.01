using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentsManager : MonoBehaviour
{
    public List<GameObject> opponentsList;
    public List<PlayerBase> Players = new List<PlayerBase>();

    public void investInProjcets()
    {
        for (int i = 0; i < opponentsList.Count; i++)
        {
                opponentsList[i].GetComponent<AIManager_CardMechanic>().investInProject();
        }
    }

    public void baseInitilize()
    {
        for (int i = 0; i < opponentsList.Count; i++)
        {
            //opponentsList[i].AddComponent<PlayerBase>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_CardMechanic : MonoBehaviour
{
    public List<GameObject> playerList;

    public void Awake()
    {
       if(playerList != null)
        {
            foreach (GameObject player in playerList)
            {
                //player.AddComponent<PlayerBase>();
            }
        }
    }
}

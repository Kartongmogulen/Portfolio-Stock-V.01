using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anslagstavla : MonoBehaviour
{
    // Referens till text rutan
    public GameObject textRuta;

    // Bool f�r att h�lla reda p� om spelaren �r n�ra anslagstavlan
    [SerializeField] bool playerNear;

    void Start()
    {
        // D�lj text rutan n�r spelet startar
        textRuta.SetActive(false);
    }

    void Update()
    {
        // Kolla om spelaren �r n�ra anslagstavlan och trycker p� knappen
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            // Visa text rutan
            textRuta.SetActive(true);
        }
    }

    // N�r spelaren g�r in i triggeromr�det f�r anslagstavlan
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Anslagstavla");
        //if (other.CompareTag("Player"))
        //{
            // S�tt playerNear till true
            playerNear = true;
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger!");
        if (other.CompareTag("Player"))
        {
        // S�tt playerNear till true
        playerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // S�tt playerNear till false
            playerNear = false;
            // D�lj text rutan n�r spelaren g�r iv�g fr�n anslagstavlan
            textRuta.SetActive(false);
        }
    }
}

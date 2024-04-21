using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anslagstavla : MonoBehaviour
{
    // Referens till text rutan
    public GameObject textRuta;

    // Bool för att hålla reda på om spelaren är nära anslagstavlan
    [SerializeField] bool playerNear;

    void Start()
    {
        // Dölj text rutan när spelet startar
        textRuta.SetActive(false);
    }

    void Update()
    {
        // Kolla om spelaren är nära anslagstavlan och trycker på knappen
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            // Visa text rutan
            textRuta.SetActive(true);
        }
    }

    // När spelaren går in i triggerområdet för anslagstavlan
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Anslagstavla");
        //if (other.CompareTag("Player"))
        //{
            // Sätt playerNear till true
            playerNear = true;
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger!");
        if (other.CompareTag("Player"))
        {
        // Sätt playerNear till true
        playerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Sätt playerNear till false
            playerNear = false;
            // Dölj text rutan när spelaren går iväg från anslagstavlan
            textRuta.SetActive(false);
        }
    }
}

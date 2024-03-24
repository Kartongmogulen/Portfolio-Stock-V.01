using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapInteraction : MonoBehaviour
{
    public Tilemap tilemap;

    private void Update()
    {
        // Kontrollera om användaren klickar med musen
        if (Input.GetMouseButtonDown(0))
        {
            // Konvertera musens skärmposition till världsposition
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Hämta rutan nära den klickade positionen
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);

            // Hämta tile på den klickade positionen
            TileBase clickedTile = tilemap.GetTile(cellPosition);

            // Om det finns ett tileobjekt på den klickade positionen
            if (clickedTile != null)
            {
                Debug.Log("Tile clicked! " + cellPosition);
                // Gör något med tileobjektet här, t.ex. förstöra det
                //tilemap.SetTile(cellPosition, null);
            }
        }
    }
}

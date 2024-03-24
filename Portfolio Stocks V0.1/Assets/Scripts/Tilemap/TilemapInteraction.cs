using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapInteraction : MonoBehaviour
{
    public Tilemap tilemap;

    private void Update()
    {
        // Kontrollera om anv�ndaren klickar med musen
        if (Input.GetMouseButtonDown(0))
        {
            // Konvertera musens sk�rmposition till v�rldsposition
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // H�mta rutan n�ra den klickade positionen
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);

            // H�mta tile p� den klickade positionen
            TileBase clickedTile = tilemap.GetTile(cellPosition);

            // Om det finns ett tileobjekt p� den klickade positionen
            if (clickedTile != null)
            {
                Debug.Log("Tile clicked! " + cellPosition);
                // G�r n�got med tileobjektet h�r, t.ex. f�rst�ra det
                //tilemap.SetTile(cellPosition, null);
            }
        }
    }
}

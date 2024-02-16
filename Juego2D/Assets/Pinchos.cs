using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D colision)
    {
        // Verificar si el enemigo ha tocado al jugador
        if (colision.gameObject.CompareTag("Player"))
        {
            // Destruir al jugador
            Destroy(colision.gameObject);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerMonedas : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.SumarPuntos(puntosASumar);

        if (collision.collider.CompareTag("Coin"))
        {
            GameManager.Instance.SumarPuntos(1);// Suma 1 por la moneda normal.
            Destroy(collision.gameObject); // Destruye el objeto moneda.
        }
        else if (collision.collider.CompareTag("MegaCoin"))
        {
            GameManager.Instance.SumarPuntos(10); // Suma 10 por la MegaCoin.
            Destroy(collision.gameObject); // Destruye el objeto MegaCoin.
        }
    }
}
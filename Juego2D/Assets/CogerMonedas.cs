using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerMonedas : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            CoinCollector.AddPoints(1); // Suma 1 por la moneda normal.
            Destroy(collision.gameObject); // Destruye el objeto moneda.
        }
        else if (collision.collider.CompareTag("MegaCoin"))
        {
            CoinCollector.AddPoints(10); // Suma 10 por la MegaCoin.
            Destroy(collision.gameObject); // Destruye el objeto MegaCoin.
        }
    }
}
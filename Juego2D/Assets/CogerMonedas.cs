using UnityEngine;

public class CogerMonedas : MonoBehaviour
{
    private CoinCollector coinCollector;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            coinCollector = playerObject.GetComponent<CoinCollector>();
            if (coinCollector == null)
            {
                Debug.LogError("No se encontró el componente CoinCollector en el objeto con tag 'Player'.");
            }
        }
        else
        {
            Debug.LogError("No se encontró un objeto con tag 'Player'.");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            coinCollector?.AddPoints(1); 
            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("MegaCoin"))
        {
            coinCollector?.AddPoints(10);
            Destroy(collision.gameObject);
        }
    }
}

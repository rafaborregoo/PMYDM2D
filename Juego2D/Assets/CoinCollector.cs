using UnityEngine;
using UnityEngine.UI; // Aseg�rate de incluir esta biblioteca para trabajar con la UI.

public class CoinCollector : MonoBehaviour
{
    
    public static int totalCoins = 0; // Contador de monedas.
    public static int score = 0; // Contador de puntos.

    // M�todo para incrementar el contador de monedas y mostrarlo en la consola.
    public static void AddCoin()
    {
        totalCoins++;
        Debug.Log("Monedas Recolectadas: " + totalCoins);
    }

    // M�todo para a�adir puntos y mostrar el total en la consola.
    public static void AddPoints(int points)
    {
        score += points; // A�ade los puntos al total.
        Debug.Log("Puntos: " + score); // Muestra el total de puntos en la consola.
    }
}
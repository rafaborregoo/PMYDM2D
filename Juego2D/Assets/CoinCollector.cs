using UnityEngine;
using UnityEngine.UI; // Necesitas esta biblioteca para trabajar con UI.

public class CoinCollector : MonoBehaviour
{
    public static int totalCoins = 0; // Contador de monedas.
    public static int score = 0; // Contador de puntos.
    public static Text coinsText; // Referencia al texto de monedas en el HUD.
    public static Text scoreText; // Referencia al texto de puntuación en el HUD.

    // Método para incrementar el contador de monedas y actualizar el HUD.
    public static void AddCoin()
    {
        totalCoins++;
        coinsText.text = "Monedas: " + totalCoins;
    }

    // Método para añadir puntos y actualizar el HUD.
    public static void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Puntos: " + score;
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public int totalCoins = 0; // Hace que totalCoins no sea est�tico
    public int score = 0; // Hace que score no sea est�tico
    public TMP_Text scoreText; // Referencia al componente de texto de la UI donde se mostrar� el puntaje
    
    private void Start()
    {
        UpdateScoreText(); // Asegura que el texto de puntuaci�n se inicialice correctamente al comenzar
    }

    public void AddCoin()
    {
        totalCoins++;
        Debug.Log("Monedas Recolectadas: " + totalCoins);
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Puntos: " + score);
        UpdateScoreText(); // Actualiza el texto de puntuaci�n cada vez que se modifica el puntaje
    }

    private void UpdateScoreText()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
    }
}

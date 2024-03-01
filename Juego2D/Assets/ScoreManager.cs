using UnityEngine;
using UnityEngine.UI; // Importante para trabajar con la UI de texto

public class ScoreManager : MonoBehaviour
{
    public static int score = 0; // Puntaje actual, static para fácil acceso desde otros scripts
    public Text scoreText; // Referencia al componente Text donde mostrarás el puntaje

    // Inicializa el puntaje y la UI en el inicio
    void Start()
    {
        score = 0;
        UpdateScoreUI();
    }

    // Método para añadir puntaje
    public void AddScore(int amount)
    {
        score += amount; // Aumenta el puntaje
        UpdateScoreUI(); // Actualiza la UI
    }

    // Actualiza el texto de la UI para mostrar el puntaje actual
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}

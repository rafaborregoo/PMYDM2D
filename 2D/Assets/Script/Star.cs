using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Puedes agregar aquí cualquier lógica adicional antes de terminar el juego, como reproducir una animación de explosión o sonido.

            // Terminar el juego
            TerminarJuego();
        }
    }

    void TerminarJuego()
    {
        // Aquí puedes agregar cualquier lógica que necesites antes de terminar el juego, como guardar puntuaciones, mostrar un mensaje final, etc.

        // Cargar la escena de Game Over
        SceneManager.LoadScene("GameOverScene"); // Reemplaza "GameOverScene" con el nombre de tu escena de Game Over
    }
}

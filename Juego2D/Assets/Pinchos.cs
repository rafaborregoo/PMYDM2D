using UnityEngine;

public class Pinchos : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Player"))
        {
            // Encuentra el componente Vida en el jugador y llama al m�todo para perder vida
            Vida vida = colision.gameObject.GetComponent<Vida>();
            if (vida != null)
            {
                vida.PerderVida(); // Asume que tienes un m�todo PerderVida() en tu script de vidas
            }
            else
            {
                Debug.LogError("Componente Vida no encontrado en el jugador.");
            }
        }
    }
}

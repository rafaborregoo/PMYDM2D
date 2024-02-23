using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del enemigo
    public float minX = -5f; // Límite izquierdo del movimiento
    public float maxX = 5f;  // Límite derecho del movimiento

    private int direction = 1; // Dirección inicial del movimiento: 1 (hacia la derecha)

    void Update()
    {
        // Calcula el desplazamiento en la dirección actual
        float movement = speed * Time.deltaTime * direction;

        // Mueve el enemigo en la dirección actual
        transform.Translate(new Vector3(movement, 0f, 0f));

        // Si el enemigo alcanza el límite derecho o izquierdo, cambia la dirección
        if (transform.position.x >= maxX)
        {
            direction = -1; // Cambia la dirección a la izquierda
        }
        else if (transform.position.x <= minX)
        {
            direction = 1; // Cambia la dirección a la derecha
        }
    }
}


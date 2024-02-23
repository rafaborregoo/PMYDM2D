using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del enemigo
    public float minX = -5f; // L�mite izquierdo del movimiento
    public float maxX = 5f;  // L�mite derecho del movimiento

    private int direction = 1; // Direcci�n inicial del movimiento: 1 (hacia la derecha)

    void Update()
    {
        // Calcula el desplazamiento en la direcci�n actual
        float movement = speed * Time.deltaTime * direction;

        // Mueve el enemigo en la direcci�n actual
        transform.Translate(new Vector3(movement, 0f, 0f));

        // Si el enemigo alcanza el l�mite derecho o izquierdo, cambia la direcci�n
        if (transform.position.x >= maxX)
        {
            direction = -1; // Cambia la direcci�n a la izquierda
        }
        else if (transform.position.x <= minX)
        {
            direction = 1; // Cambia la direcci�n a la derecha
        }
    }
}


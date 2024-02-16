using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float distance = 5f; // Distancia a recorrer

    private Vector3 initialPosition; // Posición inicial del personaje
    private Vector3 targetPosition; // Posición objetivo hacia donde se moverá

    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer para girar el sprite

    private void Start()
    {
        initialPosition = transform.position; // Guarda la posición inicial del personaje
        targetPosition = initialPosition + Vector3.right * distance; // Calcula la posición objetivo
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtiene el componente SpriteRenderer
    }

    private void Update()
    {
        // Calcula la dirección del movimiento
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Mueve el personaje en la dirección calculada
        transform.Translate(direction * speed * Time.deltaTime);

        // Gira el sprite del personaje
        if (direction.x > 0)
            spriteRenderer.flipX = false; // No gira si se mueve hacia la derecha
        else if (direction.x < 0)
            spriteRenderer.flipX = true; // Gira si se mueve hacia la izquierda

        // Verifica si el personaje ha llegado a la posición objetivo
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Cambia la posición objetivo
            if (targetPosition == initialPosition)
                targetPosition = initialPosition + Vector3.right * distance;
            else
                targetPosition = initialPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        // Verificar si el enemigo ha tocado al jugador
        if (colision.gameObject.CompareTag("Player"))
        {
            // Destruir al jugador
            Destroy(colision.gameObject);
        }
    }
}

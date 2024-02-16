using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float distance = 5f; // Distancia a recorrer

    private Vector3 initialPosition; // Posici�n inicial del personaje
    private Vector3 targetPosition; // Posici�n objetivo hacia donde se mover�

    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer para girar el sprite

    private void Start()
    {
        initialPosition = transform.position; // Guarda la posici�n inicial del personaje
        targetPosition = initialPosition + Vector3.right * distance; // Calcula la posici�n objetivo
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtiene el componente SpriteRenderer
    }

    private void Update()
    {
        // Calcula la direcci�n del movimiento
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Mueve el personaje en la direcci�n calculada
        transform.Translate(direction * speed * Time.deltaTime);

        // Gira el sprite del personaje
        if (direction.x > 0)
            spriteRenderer.flipX = false; // No gira si se mueve hacia la derecha
        else if (direction.x < 0)
            spriteRenderer.flipX = true; // Gira si se mueve hacia la izquierda

        // Verifica si el personaje ha llegado a la posici�n objetivo
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Cambia la posici�n objetivo
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


using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 5f; 

    private Vector3 initialPosition; 
    private Vector3 targetPosition; 

    private SpriteRenderer spriteRenderer; 

    private void Start()
    {
        initialPosition = transform.position; 
        targetPosition = initialPosition + Vector3.right * distance; 
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void Update()
    {
        // Calcula la dirección del movimiento
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Mueve el personaje en la dirección calculada
        transform.Translate(direction * speed * Time.deltaTime);

        // Gira el sprite del personaje
        if (direction.x > 0)
            spriteRenderer.flipX = false; 
        else if (direction.x < 0)
            spriteRenderer.flipX = true; 

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
        if (colision.gameObject.CompareTag("Player"))
        {
            Vida vida = FindObjectOfType<Vida>();
            if (vida != null)
            {
                vida.PerderVida();
            }
        }
    }
}

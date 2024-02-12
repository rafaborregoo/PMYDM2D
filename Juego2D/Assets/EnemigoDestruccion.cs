using UnityEngine;

public class EnemigoDestruccion : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] movePoints;
    private int currentPointIndex = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = movePoints[currentPointIndex].position; // Inicia en el primer punto
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // Mover al enemigo hacia el punto actual
        transform.position = Vector2.MoveTowards(transform.position, movePoints[currentPointIndex].position, speed * Time.deltaTime);

        // Si el enemigo alcanza el punto, cambia al siguiente
        if (Vector2.Distance(transform.position, movePoints[currentPointIndex].position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % movePoints.Length;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destruye al jugador
        }
    }
}

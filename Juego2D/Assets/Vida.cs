using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public int vidasTotales = 3; 
    private int vidasRestantes; 
    public GameObject[] iconosVidas; 

    private void Start()
    {
        vidasRestantes = vidasTotales; 
        ActualizarUIVidas();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemigo") && other.gameObject.CompareTag("pinchos"))
        {
            PerderVida();
        }
    }

    public void PerderVida()
    {
        if (vidasRestantes > 0)
        {
            vidasRestantes--; 
            ActualizarUIVidas();

            if (vidasRestantes <= 0)
            {
                Debug.Log("El jugador ha muerto.");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
        }
    }

    void ActualizarUIVidas()
    {
        for (int i = 0; i < iconosVidas.Length; i++)
        {
            if (i < vidasRestantes)
            {
                iconosVidas[i].SetActive(true);
            }
            else
            {
                iconosVidas[i].SetActive(false);
            }
        }
    }
}

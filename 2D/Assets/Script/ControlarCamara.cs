using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlarCamara : MonoBehaviour
{   
    public Transform personaje;

    private float tamanoCamara;
    private float alturaCamara;

    // Start is called before the first frame update
    void Start()
    {
        tamanoCamara = Camera.main.orthographicSize;
        alturaCamara = tamanoCamara * 2;
        
    }

    // Update is called once per 
    void Update()
    {
        CalcularPosicion();   
    }

    void CalcularPosicion()
{
    if (personaje != null)
    {
        int pantallaPersonaje = (int)(personaje.position.y / alturaCamara);
        float nuevaAlturaCamara = (pantallaPersonaje * alturaCamara) + tamanoCamara;
        transform.position = new Vector3(transform.position.x, nuevaAlturaCamara, transform.position.z);
    }
    else
    {
        Debug.LogWarning("El objeto personaje no está asignado.");
    }
}

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{
    public float speed;
    float entradaMovimiento;
    public float velocidadSalto;
    Rigidbody2D rigiBody2D;
    public bool estaMirandoDerecha;
    BoxCollider2D boxCollider;
    public bool estaEnSuelo;

    public LayerMask surfaceLayer;

    public bool estaCorriendo;
    private Animator animator;

    // Variables para el doble salto
    private int saltosRestantes = 2; // Número de saltos permitidos antes de tocar el suelo

    private void Start()
    {
        rigiBody2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        estaEnSuelo = ComprobarSuelo();
        if (estaEnSuelo && rigiBody2D.velocity.y <= 0)
        {
            saltosRestantes = 2; // Restablece los saltos cuando está en el suelo
        }

        MovimientoProceso();
        ProcesoSalto();
    }

    private void MovimientoProceso()
    {
        entradaMovimiento = Input.GetAxis("Horizontal");
        estaCorriendo = entradaMovimiento != 0 ? true : false;
        animator.SetBool("estaCorriendo", estaCorriendo);
        rigiBody2D.velocity = new Vector2(speed * entradaMovimiento, rigiBody2D.velocity.y);
        OrientacionPersonaje(entradaMovimiento);
    }

    private void OrientacionPersonaje(float entradaMovimiento)
    {
        if ((estaMirandoDerecha && entradaMovimiento < 0) || (!estaMirandoDerecha && entradaMovimiento > 0))
        {
            estaMirandoDerecha = !estaMirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void ProcesoSalto()
    {           
        animator.SetBool("EstaSaltando", !estaEnSuelo);
        if (Input.GetKeyDown(KeyCode.Space) && (estaEnSuelo || saltosRestantes > 0))
        {
            rigiBody2D.velocity = new Vector2(rigiBody2D.velocity.x, 0); // Resetea la velocidad en Y para hacer el salto más consistente
            rigiBody2D.AddForce(Vector2.up * velocidadSalto, ForceMode2D.Impulse);

 

            if (!estaEnSuelo && saltosRestantes == 1) // Condicional para activar la animación de doble salto
            {
                animator.SetTrigger("DobleSalto");
            }

            saltosRestantes--;
        }
    }


    bool ComprobarSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0f,
            Vector2.down,
            0.1f, // Puedes ajustar esta distancia según la necesidad
            surfaceLayer
        );
        return raycastHit.collider != null;
    }
}

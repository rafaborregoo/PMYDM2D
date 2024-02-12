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

    private void Start()
    {
        rigiBody2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        estaEnSuelo = ComprobarSuelo();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        MovimientoProceso();
        ProcesoSalto();
        estaEnSuelo = ComprobarSuelo();
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
        if((estaMirandoDerecha && entradaMovimiento < 0) || (!estaMirandoDerecha && entradaMovimiento > 0))
        {
            estaMirandoDerecha = !estaMirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void ProcesoSalto()
    {
        if(Input.GetKeyDown(KeyCode.Space) && estaEnSuelo)
        {
            rigiBody2D.AddForce(Vector2.up * velocidadSalto, ForceMode2D.Impulse);
        }
    }
    bool ComprobarSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxCollider.bounds.center,
            new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y),
            0f,
            Vector2.down,
            0.2f,
            surfaceLayer
            );
        return raycastHit.collider != null;
    }
}

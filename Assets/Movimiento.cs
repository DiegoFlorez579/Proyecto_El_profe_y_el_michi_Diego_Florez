using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 5f;
    private Rigidbody2D rb;
    private bool enSuelo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        AplicarRestriccionesRotacion();
    }

    private void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Mover el personaje horizontalmente
        Vector2 movimiento = new Vector2(movimientoHorizontal * velocidadMovimiento, rb.velocity.y);
        rb.velocity = movimiento;

        // Si el personaje está en el suelo y se presiona la tecla de salto
        if (enSuelo && Input.GetButtonDown("Jump"))
        {
            // Aplicar una fuerza vertical para el salto
            rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el personaje está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verificar si el personaje deja de estar en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = false;
        }
    }

    private void AplicarRestriccionesRotacion()
    {
        // Restringir rotación alrededor del eje Z (evitar giro)
        rb.freezeRotation = true;
    }
}

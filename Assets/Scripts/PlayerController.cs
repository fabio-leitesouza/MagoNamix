using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtenha a posição do mouse no mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Certifique-se de que a coordenada Z seja 0

        // Calcule a direção do mouse em relação ao jogador
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Mova o jogador com base na entrada do teclado
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        rb.velocity = movement * moveSpeed;

        // Atualize os parâmetros do Animator com base na direção do movimento
        animator.SetFloat("MovimentoX", movement.x);
        animator.SetFloat("MovimentoY", movement.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 currentDirection; // Armazena a direção atual

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentDirection = Vector2.down; // Inicialmente apontando para baixo
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

        // Atualize a animação apenas quando a direção mudar
        if (direction.magnitude > 0.1f && direction != currentDirection)
        {
            currentDirection = direction;
            UpdateAnimation(direction);
        }
        else if (movement.magnitude < 0.1f && direction == currentDirection)
        {
            // Se o jogador não estiver se movendo e a direção não mudou, defina a animação para o estado idle
            animator.SetTrigger("Idle");
        }
    }

    // Atualize a animação com base na direção atual
    private void UpdateAnimation(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle > -45 && angle <= 45) // Apontar para a direita
        {
            animator.SetTrigger("WalkRight");
        }
        else if (angle > 45 && angle <= 135) // Apontar para cima
        {
            animator.SetTrigger("WalkUp");
        }
        else if (angle > 135 || angle <= -135) // Apontar para a esquerda
        {
            animator.SetTrigger("WalkLeft");
        }
        else // Apontar para baixo
        {
            animator.SetTrigger("WalkDown");
        }
    }
}

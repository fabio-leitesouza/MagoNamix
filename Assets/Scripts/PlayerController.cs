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
    float moveX = Input.GetAxis("Horizontal");
    float moveY = Input.GetAxis("Vertical");

    Vector2 movement = new Vector2(moveX, moveY).normalized;
    
    rb.velocity = movement * moveSpeed;

    if (movement.magnitude > 0.1f)
    {
        if (moveX > 0) // Mover para a direita
        {
            animator.SetTrigger("WalkRight");
        }
        else if (moveX < 0) // Mover para a esquerda
        {
            animator.SetTrigger("WalkLeft");
        }
        else if (moveY > 0) // Mover para cima
        {
            animator.SetTrigger("WalkUp");
        }
        else if (moveY < 0) // Mover para baixo
        {
            animator.SetTrigger("WalkDown");
        }
    }
    else // Jogador parado
    {
        animator.ResetTrigger("WalkUp");
        animator.ResetTrigger("WalkDown");
        animator.ResetTrigger("WalkLeft");
        animator.ResetTrigger("WalkRight");
    }

    animator.SetFloat("Speed", movement.magnitude);
}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical"); 

        if (movement.x < 0)
        {
            spriteRenderer.flipX = true; 
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false; 
        }

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("IsMoving", true); 
        }
        else
        {
            animator.SetBool("IsMoving", false); 
        }
    }
    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }
}


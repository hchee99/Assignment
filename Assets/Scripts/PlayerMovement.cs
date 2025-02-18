using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewBehaviourScript : MonoBehaviour
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
        movement.x = Input.GetAxisRaw("Horizontal"); // 방향키 혹은 A/D
        movement.y = Input.GetAxisRaw("Vertical"); // 방향키 혹은 W/S

        // 반대 방향으로 움직일 때 이미지를 반전
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // 왼쪽으로 이동 시 이미지 반전
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // 오른쪽으로 이동 시 이미지 원상태
        }

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("IsMoving", true); // 이동 중
        }
        else
        {
            animator.SetBool("IsMoving", false); // 이동하지 않으면 대기 상태
        }
    }
    void FixedUpdate()
    {
        // 물리적으로 캐릭터 이동
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Debug.Log($"movement : {movement} moveSpeed : {moveSpeed}");
        
    }
}


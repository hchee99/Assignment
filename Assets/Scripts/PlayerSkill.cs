using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private Animator animator;

    public int damageQ = 20;
    public int damageW = 20;
    public int damageE = 20;

    public float attackRange = 2f;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Skill_Q");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Skill_W");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Skill_E");
        }
    }
    void UseSkill(int damage)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            // Enemy 스크립트가 붙어있는 적에게 데미지를 적용
            Enemy enemy = enemyCollider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

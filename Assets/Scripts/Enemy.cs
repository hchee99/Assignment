using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Animator animator;
    public GameObject enemyDieobject;
    public GameObject portalPrefab;

    private int enemyHealth;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        float r = Random.value;

        if (r < 0.5f)
        {
            enemyHealth = Random.Range(50, 125);
        }
        else if (r < 0.8f)
        {
            enemyHealth = Random.Range(125, 170);
        }
        else if (r < 0.92f)
        {
            enemyHealth = Random.Range(170, 188);
        }
        else
        {
            enemyHealth = Random.Range(188, 201);
        }      
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        isDead = true;

        if (animator != null)
        {
            animator.SetBool("IsDead", true);
        }

        // enemyDieObject 활성화 (필요한 경우)
       

        // 포탈 생성: portalPrefab을 Enemy의 위치에서 인스턴스화
        if (portalPrefab != null)
        {
            Instantiate(portalPrefab, transform.position, Quaternion.identity);
        }



    }
}

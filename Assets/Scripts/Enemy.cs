using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public GameObject lowMoneyDropPrefab;      
    public GameObject mediumMoneyDropPrefab;   
    public GameObject manyMoneyDropPrefab;     
    public GameObject veryManyMoneyDropPrefab; 

    private int enemyHealth;
    private bool isDead = false;
    private int rewardMoney;

    void Start()
    {
        float r = Random.value;

        if (r < 0.5f)
        {
            enemyHealth = Random.Range(50, 125);
            rewardMoney = 5000;
        }
        else if (r < 0.8f)
        {
            enemyHealth = Random.Range(125, 170);
            rewardMoney = 50000;
        }
        else if (r < 0.92f)
        {
            enemyHealth = Random.Range(170, 188);
            rewardMoney = 500000;
        }
        else
        {
            enemyHealth = Random.Range(188, 201);
            rewardMoney = 5000000;
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

        if (rewardMoney == 5000)
        {
            Instantiate(lowMoneyDropPrefab, transform.position, Quaternion.identity);
        }
        else if (rewardMoney == 50000)
        {
            Instantiate(mediumMoneyDropPrefab, transform.position, Quaternion.identity);
        }
        else if (rewardMoney == 500000)
        {
            Instantiate(manyMoneyDropPrefab, transform.position, Quaternion.identity);
        }
        else if (rewardMoney == 5000000)
        {
            Instantiate(veryManyMoneyDropPrefab, transform.position, Quaternion.identity);
        }
    }

}
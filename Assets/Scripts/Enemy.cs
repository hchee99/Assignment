using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    // �� ���� �������� Inspector���� �Ҵ� (Project â�� ������ ����)
    public GameObject lowMoneyDropPrefab;      // ����: 5000
    public GameObject mediumMoneyDropPrefab;   // ����: 50000
    public GameObject manyMoneyDropPrefab;     // ����: 500000
    public GameObject veryManyMoneyDropPrefab; // ����: 5000000

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

        Debug.Log($"{gameObject.name} ü��: {enemyHealth}, ����: {rewardMoney}");
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

        // ���� �ݾ׿� ���� �ش��ϴ� �� ��� �������� ���� ��ġ���� �ν��Ͻ�ȭ
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

        Debug.Log("Enemy defeated! Reward money: " + rewardMoney);

    }

}
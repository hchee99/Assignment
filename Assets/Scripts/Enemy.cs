using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyDieObject;

    private int enemyHealth;
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

        Debug.Log(gameObject.name + "ÀÇ Ã¼·Â: " + enemyHealth);

        if (enemyDieObject != null)
        {
            enemyDieObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        void Die()
        {
            if (enemyDieObject != null)
            {
                enemyDieObject.transform.position = transform.position;
                enemyDieObject.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}

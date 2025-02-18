using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox_E : MonoBehaviour
{
    // E 스킬 데미지
    public int damage = 30;
    public LayerMask enemyLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((enemyLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
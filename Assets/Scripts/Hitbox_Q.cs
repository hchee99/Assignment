using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox_Q : MonoBehaviour
{
    // Q 스킬 데미지 (Inspector에서 조정 가능)
    public int damage = 10;
    // 적들이 있는 레이어 (예: "Enemy")
    public LayerMask enemyLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // enemyLayer에 속하는 오브젝트와 충돌했는지 확인
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    // 기본 데미지는 PlayerSkill에서 동적으로 설정됩니다.
    public int damage = 10;

    // 적들이 속한 레이어 (예: "Enemy")
    public LayerMask enemyLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision 오브젝트가 enemyLayer에 속하는지 확인
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
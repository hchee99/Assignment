using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox_Q : MonoBehaviour
{
    // Q ��ų ������ (Inspector���� ���� ����)
    public int damage = 10;
    // ������ �ִ� ���̾� (��: "Enemy")
    public LayerMask enemyLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // enemyLayer�� ���ϴ� ������Ʈ�� �浹�ߴ��� Ȯ��
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
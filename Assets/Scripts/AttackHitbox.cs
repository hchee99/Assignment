using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    // �⺻ �������� PlayerSkill���� �������� �����˴ϴ�.
    public int damage = 10;

    // ������ ���� ���̾� (��: "Enemy")
    public LayerMask enemyLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision ������Ʈ�� enemyLayer�� ���ϴ��� Ȯ��
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    // �⺻ �������� PlayerSkill���� �������� �����˴ϴ�.
    public int damage = 10;

    // ������ ���� ���̾� (��: "Enemy")
    public LayerMask enemyLayer;

    public float baseOffsetX = 1f;

    void Update()
    {
        // �θ� ������Ʈ�� SpriteRenderer.flipX ���� �����ɴϴ�.
        SpriteRenderer parentSR = transform.parent.GetComponent<SpriteRenderer>();
        if (parentSR != null)
        {
            Vector3 localPos = transform.localPosition;
            // �θ� �����Ǿ� ������ x���� ����, �׷��� ������ ����� ����
            localPos.x = Mathf.Abs(baseOffsetX) * (parentSR.flipX ? -1f : 1f);
            transform.localPosition = localPos;
        }
    }

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
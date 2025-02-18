using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    // 기본 데미지는 PlayerSkill에서 동적으로 설정됩니다.
    public int damage = 10;

    // 적들이 속한 레이어 (예: "Enemy")
    public LayerMask enemyLayer;

    public float baseOffsetX = 1f;

    void Update()
    {
        // 부모 오브젝트의 SpriteRenderer.flipX 값을 가져옵니다.
        SpriteRenderer parentSR = transform.parent.GetComponent<SpriteRenderer>();
        if (parentSR != null)
        {
            Vector3 localPos = transform.localPosition;
            // 부모가 반전되어 있으면 x값을 음수, 그렇지 않으면 양수로 설정
            localPos.x = Mathf.Abs(baseOffsetX) * (parentSR.flipX ? -1f : 1f);
            transform.localPosition = localPos;
        }
    }

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
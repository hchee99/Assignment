using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ĳ������ �±װ� "Player"���� Ȯ���մϴ�.
        if (collision.CompareTag("Player"))
        {
            // �ʿ信 ���� ĳ������ �� ȹ�� ���� �߰�
            // ��: collision.GetComponent<PlayerMoneyManager>().AddMoney(coinValue);

            // �� ������ ����
            Destroy(gameObject);
        }
    }
}

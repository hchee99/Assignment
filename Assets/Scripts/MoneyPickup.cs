using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 캐릭터의 태그가 "Player"인지 확인합니다.
        if (collision.CompareTag("Player"))
        {
            // 필요에 따라 캐릭터의 돈 획득 로직 추가
            // 예: collision.GetComponent<PlayerMoneyManager>().AddMoney(coinValue);

            // 돈 프리팹 삭제
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    public string targetSceneName = "MainScene";

    // 포탈에 진입한 오브젝트의 태그가 "Player"라면 씬을 전환합니다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 씬 전환 전에 전환 효과(페이드 등)를 넣을 수도 있습니다.
            SceneManager.LoadScene(targetSceneName);
        }
    }
}

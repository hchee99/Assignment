using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    public string targetSceneName = "MainScene";

    // ��Ż�� ������ ������Ʈ�� �±װ� "Player"��� ���� ��ȯ�մϴ�.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // �� ��ȯ ���� ��ȯ ȿ��(���̵� ��)�� ���� ���� �ֽ��ϴ�.
            SceneManager.LoadScene(targetSceneName);
        }
    }
}

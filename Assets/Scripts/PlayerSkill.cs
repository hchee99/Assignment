using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private Animator animator;

    public int damageQ = 20;
    public int damageW = 20;
    public int damageE = 20;

    public GameObject Hitbox_Q;
    public GameObject Hitbox_W;
    public GameObject Hitbox_E;

    public float hitboxActiveTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        // 시작 시 히트박스 비활성화
        if (Hitbox_Q != null) Hitbox_Q.SetActive(false);
        if (Hitbox_W != null) Hitbox_W.SetActive(false);
        if (Hitbox_E != null) Hitbox_E.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Skill_Q");
            StartCoroutine(ActivateHitbox(Hitbox_Q, hitboxActiveTime));
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Skill_W");
            StartCoroutine(ActivateHitbox(Hitbox_W, hitboxActiveTime));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Skill_E");
            StartCoroutine(ActivateHitbox(Hitbox_E, hitboxActiveTime));
        }
    }

    IEnumerator ActivateHitbox(GameObject hitbox, float duration)
    {
        if (hitbox != null)
        {
            hitbox.SetActive(true);
            yield return new WaitForSeconds(duration);
            hitbox.SetActive(false);
        }
    }
}

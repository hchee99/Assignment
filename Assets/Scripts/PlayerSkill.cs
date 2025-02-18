using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public int damageQ = 10;
    public int damageW = 20;
    public int damageE = 30;

    public GameObject Hitbox;


    public float hitboxActiveTime = 0.1f;

    public Vector3 hitboxPositionRight = new Vector3(1, 0, 0);

    private Vector3 hitboxPositionLeft;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (Hitbox != null)
        {
            Hitbox.SetActive(false);
            hitboxPositionLeft = new Vector3(-hitboxPositionRight.x, hitboxPositionRight.y, hitboxPositionRight.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Hitbox != null)
        {
            if (spriteRenderer.flipX)
                Hitbox.transform.localPosition = hitboxPositionLeft;
            else
                Hitbox.transform.localPosition = hitboxPositionLeft;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Skill_Q");
            AttackHitbox hitboxscript = Hitbox.GetComponent<AttackHitbox>();
            if (hitboxscript != null)
                hitboxscript.damage= damageQ;
            StartCoroutine(ActivateHitbox(Hitbox, hitboxActiveTime));
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Skill_W");
            AttackHitbox hitboxscript = Hitbox.GetComponent<AttackHitbox>();
            if (hitboxscript != null)
                hitboxscript.damage= damageW;
            StartCoroutine(ActivateHitbox(Hitbox, hitboxActiveTime));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Skill_E");
            AttackHitbox hitboxscript = Hitbox.GetComponent<AttackHitbox>();
            if (hitboxscript != null)
                hitboxscript.damage= damageE;
            StartCoroutine(ActivateHitbox(Hitbox, hitboxActiveTime));
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{
    private Collider2D Collider2D;

    void Awake()
    {
        Collider2D = GetComponent<Collider2D>();
    }

    public void DisableCollision()
    {
        if (Collider2D != null)
        {
            Collider2D.enabled = false;
        }
    }
    public void EnableCollision()
    {
        if (Collider2D != null)
        {
            Collider2D.enabled = true;
            Debug.Log("EnableCollision »£√‚µ ");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public bool hasKnockBack = true;
    public bool isJumpKillable = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (hasKnockBack)
            {
                collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, 2.5f);
            }
            collision.transform.GetComponent<PlayerDamaged>().RecieveDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Transform parent = collision.transform.parent;
            Rigidbody2D parentRB = parent.GetComponent<Rigidbody2D>();

            if (hasKnockBack)
            {
                parentRB.velocity = new Vector2(parentRB.velocity.x, 2.5f);
            }
            parent.GetComponent<PlayerDamaged>().RecieveDamage();
        }
    }
}

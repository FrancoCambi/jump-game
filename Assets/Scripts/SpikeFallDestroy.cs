using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFallDestroy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerDamaged>().RecieveDamage();
        }
        Destroy(transform.parent.gameObject);
    }
}

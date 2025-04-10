using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeTriggerFall : MonoBehaviour
{
    Rigidbody2D spikeRB;

    private void Start()
    {
        spikeRB = transform.parent.GetChild(0).GetComponent<Rigidbody2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spikeRB.bodyType = RigidbodyType2D.Dynamic;
            spikeRB.mass = 1.5f;
        }
    }
}

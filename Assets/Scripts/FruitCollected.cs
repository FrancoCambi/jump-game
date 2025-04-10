using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollected : MonoBehaviour
{

    public FruitManager fruitManager;
    public PortalLogic portalLogic;

    // Esto sirve para evitar agarrar la manzana
    // dos veces cuando primero se agarra con los pies
    // y luego con el cuerpo.
    private bool alreadyCollected = false;

    public void Start()
    {
        fruitManager = GetComponentInParent<FruitManager>();
        portalLogic = FindObjectOfType<PortalLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !alreadyCollected)
        {
            alreadyCollected = true;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            if (fruitManager)
            {
                fruitManager.UpdateFruitsText();
            }
            if (portalLogic)
            {
                portalLogic.TryOpenPortal();
            }
            Destroy(gameObject, 0.5f);


        }
    }
}

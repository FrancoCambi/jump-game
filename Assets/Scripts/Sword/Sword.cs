using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private BoxCollider2D myBoxCollider;
    private SpriteRenderer playerSR;

    public Animator myAnimator;
    public GameObject swordFather;
    public int swordDamage = 20;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        playerSR = transform.root.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (playerSR.flipX == true)
        {
            swordFather.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            swordFather.transform.rotation = Quaternion.Euler(0, 0, 0);

        }

    }

    private void Attack()
    {
        myAnimator.Play("Attack");
        myBoxCollider.enabled = true;
        Invoke(nameof(DisableAttack), 0.5f);
    }

    private void DisableAttack()
    {
        myBoxCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<RecieveDamage>().LoseLifeAndHit(swordDamage);
            myBoxCollider.enabled = false;
        }
    }
}

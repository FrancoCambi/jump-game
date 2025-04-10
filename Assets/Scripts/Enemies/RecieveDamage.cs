using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveDamage : MonoBehaviour
{
    public PortalLogic portalLogic;
    public BoxCollider2D collider;
    public Animator myAnimator;
    public SpriteRenderer mySpriteRenderer;
    public GameObject destroyParticle;
    public HealthBar healthBar;
    public float jumpForce = 2.5f;
    public int lives = 2;
    public bool hasHealthBar = false;

    private bool alive = true;

    public void Start()
    {
        portalLogic = FindObjectOfType<PortalLogic>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

        if (hasHealthBar)
        {
            healthBar.SetMaxHealth(lives);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.parent != null && collision.transform.parent.CompareTag("Player"))
        {
            collision.gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            LoseLifeAndHit(FindObjectOfType<CharacterStats>().jumpDamage);
        }
    }


    public void LoseLifeAndHit(int damage)
    {
        lives -= damage;
        CheckLife();

        if (hasHealthBar)
        {
            healthBar.SetHealth(lives);
        }
        else
        {
            myAnimator.Play("Hit");
        }
    }

    public void CheckLife()
    {
        if (lives <= 0 && alive)
        {
            alive = false;
            destroyParticle.SetActive(true);
            mySpriteRenderer.enabled = false;
            Invoke(nameof(EnemyDie), 0.2f);
            GetComponentInParent<LootBag>().InstantiateLoot(transform.position);
            if (portalLogic != null) {
                portalLogic.TryOpenPortal();
            }

            if (hasHealthBar)
            {
                Destroy(healthBar.gameObject);
            }
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class JumpEnemy : MonoBehaviour
{
    public float jumpHeight;
    public float disableTime;
    public LayerMask groundLayer;
    public Transform player;
    public Transform groundCheck;
    public Vector2 boxSize;
    public Rigidbody2D myRigidbody;
    public SpriteRenderer mySpriteRenderer;
    public Animator myAnimator;
    private bool isGrounded;
    private bool attackCD = false;
    public bool weakened = false;

    public Vector2 LineOfSight;
    public LayerMask playerLayer;
    private bool canSeePlayer;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }
     

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, LineOfSight, 0, playerLayer);

        if (myRigidbody.velocity.y < 0)
        {
            myAnimator.SetBool("Falling", true);
        }
        else
        {
            myAnimator.SetBool("Falling", false);
        }

        if (!isGrounded)
        {
            myAnimator.SetBool("isGrounded", false);
        }
        else
        {
            myAnimator.SetBool("isGrounded", true);

        }

        if (canSeePlayer && !attackCD && !weakened)
        {
            FlipTowardsPlayer();
            StartCoroutine(AttackAndDisable());
            JumpAttack();
        }

    }


    IEnumerator AttackAndDisable()
    {
        attackCD = true;
        yield return new WaitForSeconds(disableTime);
        attackCD = false;

    }

    private void JumpAttack()
    {
        float playerPositionX = player.position.x;
        float distanceFromPlayer = playerPositionX - transform.position.x;

        if (isGrounded)
        {

            myRigidbody.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);

        }
    }

    private void FlipTowardsPlayer()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if (distanceFromPlayer > 0)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck.position, boxSize);


        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, LineOfSight);
    }

    private void SetWeakenedFalse ()
    {
        myAnimator.SetBool("Weakened", false);
    }
}

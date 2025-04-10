using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{

    Rigidbody2D myRigidBody;
    SpriteRenderer mySpriteRenderer;
    Animator myAnimator;

    public float runSpeed = 1.5f;
    public float jumpSpeed = 3.2f;
    public float doubleJumpSpeed = 2.5f;

    private bool canDoubleJump;

    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update()

    {

        // Salto y doble salto
        if (Input.GetKey(KeyCode.Space))
        {

            if (CheckGround.isGrounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
                myAnimator.SetBool("Running", false);

                // si tenemos el bonus, podemos hacer doble salto
                canDoubleJump = GameObject.FindObjectOfType<CharacterBonus>().doubleJump;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
                {
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, doubleJumpSpeed);
                    myAnimator.SetBool("DoubleJump", true);
                    canDoubleJump = false;
                }

            }
        }
        // Activamos animacion de salto
        if (!CheckGround.isGrounded)
        {
            myAnimator.SetBool("Jumping", true);
            myAnimator.SetBool("Running", false);
        }
        else
        {
            myAnimator.SetBool("Jumping", false);
            //myAnimator.SetBool("Falling", false);
            myAnimator.SetBool("DoubleJump", false);
        }

        // Animacion de caida
        /*if (myRigidBody.velocity.y < 0)
        {
            myAnimator.SetBool("Falling", true);
        }
        else if (myRigidBody.velocity.y > -0.1)
        {
            myAnimator.SetBool("Falling", false);
        }*/

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        { 
            // Reducimos la velocidad si estamos en el aire
            float finalSpeed = CheckGround.isGrounded ? runSpeed : runSpeed * 0.8f;

            myRigidBody.velocity = new Vector2(-finalSpeed, myRigidBody.velocity.y);
            mySpriteRenderer.flipX = true;
            myAnimator.SetBool("Running", true);

        }
        else if (Input.GetKey(KeyCode.D))
        { 
            // Reducimos la velocidad si estamos en el aire
            float finalSpeed = CheckGround.isGrounded ? runSpeed : runSpeed * 0.8f;

            myRigidBody.velocity = new Vector2(finalSpeed, myRigidBody.velocity.y);
            mySpriteRenderer.flipX = false;
            myAnimator.SetBool("Running", true);

        }
        else
        {
            myRigidBody.velocity = new Vector2(0, myRigidBody.velocity.y);
            myAnimator.SetBool("Running", false);

        }


        // Estos dos ifs mejoran las fisicas del salto.

        // Subiendo apretando espacio (salto mas)
        if (myRigidBody.velocity.y < 0)
        {
            myRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
        }

        // Dejar de apretar espacio (caigo rapido)
        if (myRigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            myRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingAnim : StateMachineBehaviour
{
    Transform player;
    Transform myTransform;
    Rigidbody2D myRigidbody;

    public float fallForce;
    public int weakenedAfter = 3;
    private int jumpCount;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       myTransform = animator.transform;
       myRigidbody = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float playerPositionX = player.position.x;

        if (Mathf.Abs(playerPositionX - myTransform.position.x) <= 0.5)
        {
            myRigidbody.AddForce(new Vector2(0, -fallForce), ForceMode2D.Force);

        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jumpCount++;
        if (jumpCount == weakenedAfter)
        {
            animator.Play("Weak");
            jumpCount = 0;
        }
    }

}

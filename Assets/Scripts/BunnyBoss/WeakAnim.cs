using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakAnim : StateMachineBehaviour
{

    BoxCollider2D myCollider;
    JumpEnemy bossScript;
    public GameObject fruitsGO;
    public Vector3 fruitOffset1;
    public Vector3 fruitOffset2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossScript = animator.GetComponent<JumpEnemy>();
        myCollider = animator.GetComponent<BoxCollider2D>();

        myCollider.enabled = true;
        bossScript.weakened = true;
        animator.SetBool("Weakened", true);

        Instantiate(fruitsGO, animator.transform.position + fruitOffset1, Quaternion.identity);
        Instantiate(fruitsGO, animator.transform.position + fruitOffset2, Quaternion.identity);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Weakened", false);
        myCollider.enabled = false;
        bossScript.weakened = false;
    }

}

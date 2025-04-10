using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicAI : MonoBehaviour
{

    public Animator myAnimator;
    public SpriteRenderer mySpriteRenderer;
    public Transform[] moveSpots;
    public float speed = 0.5f;
    public float startWaitTime = 2f;

    private float waitTime;
    private int i = 0;
    private Vector2 actualPos;




    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > actualPos.x)
        {
            mySpriteRenderer.flipX = true;
            myAnimator.SetBool("Idle", false);
        }
        else if (transform.position.x < actualPos.x)
        {
            mySpriteRenderer.flipX = false;
            myAnimator.SetBool("Idle", false);

        }
        else
        {
            myAnimator.SetBool("Idle", true);
        }
    }
}

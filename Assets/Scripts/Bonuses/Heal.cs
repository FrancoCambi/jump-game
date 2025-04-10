using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField]
    private IntSO dataToKeep;
    private bool used = false;

    public float bounceSpeed;
    public Rigidbody2D myRigidBody;
    public BoxCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        Physics2D.IgnoreCollision(enemy.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !used)
        {
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, bounceSpeed);
            if (dataToKeep.life < dataToKeep.totalLives)
            {
                dataToKeep.life++;
                FindObjectOfType<KeepLevelData>().Start();
            }
            Destroy(gameObject, 0.3f);
            used = true;

            
        }
    }
}

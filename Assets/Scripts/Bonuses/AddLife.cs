using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLife : MonoBehaviour
{
    [SerializeField]
    private IntSO dataToKeep;
    private bool used = false;

    public int lifeNumber;
    public float bounceSpeed;
    public BoxCollider2D myBoxCollider;
    public Rigidbody2D myRigidBody;
    public GameObject text;
    public Camera mainCamera;


    public void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        if (dataToKeep.totalLives >= lifeNumber)
        {
            gameObject.SetActive(false);
        }
        myBoxCollider = GetComponent<BoxCollider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !used)
        {
            Instantiate(text, mainCamera.transform.position, Quaternion.identity, mainCamera.transform);
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, bounceSpeed);
            dataToKeep.totalLives++;
            dataToKeep.life++;
            FindObjectOfType<KeepLevelData>().Start();
            Destroy(gameObject, 0.3f);
            used = true;
        }
    }
}

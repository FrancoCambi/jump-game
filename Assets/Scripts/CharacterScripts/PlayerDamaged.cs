using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamaged : MonoBehaviour
{
    public GameObject[] hearts;
    public Animator myAnimator;
    Rigidbody2D myRigidbody;
    public float invulTime = 0.5f;
    //public float knockdown = 2500f;

    private int life;
    private int totalLives;
    private bool invulnerable = false;

    [SerializeField]
    private IntSO dataToKeep;

    public void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    public void RecieveDamage()
    {
        life = dataToKeep.life;
        if (!invulnerable)
        {
            hearts[--life].GetComponent<Image>().color = Color.black;
            dataToKeep.life--;

            if (life <= 0)
            {
                dataToKeep.life = dataToKeep.respawnLife;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            StartCoroutine(JustHurt());
        }
    }

    IEnumerator JustHurt()
    {
        invulnerable = true;
        myAnimator.Play("Hit");
        yield return new WaitForSeconds(invulTime);
        myAnimator.Play("Idle");
        invulnerable = false;
    }
}

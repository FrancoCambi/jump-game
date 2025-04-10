using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpBonus : MonoBehaviour
{
    [SerializeField]
    private IntSO dataToKeep;
    private bool used = false;
    private float textCD = 3f;
    private bool textInCD = false;

    public GameObject pickParticle;
    public GameObject textPrefab;
    public GameObject alreadyTakenTextPrefab;
    public GameObject mainCamera;
    public CharacterBonus charBonus;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>().gameObject;
        charBonus = FindObjectOfType<CharacterBonus>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !used && !charBonus.doubleJump)
        {
            ShowText(textPrefab);
            used = true;
            charBonus.doubleJump = true;
            dataToKeep.doubleJump = true;

            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            pickParticle.SetActive(true);


            Destroy(gameObject, 0.5f);

        }

        else if (collision.CompareTag("Player") && (used || charBonus.doubleJump))
        {
            if (!textInCD)
            {
                ShowText(alreadyTakenTextPrefab);
                StartCoroutine(TextJustShowed());
            }
        }
    }


    private void ShowText(GameObject text)
    {
        Instantiate(text, mainCamera.transform.position, Quaternion.identity, mainCamera.transform);

    }

    IEnumerator TextJustShowed()
    {
        textInCD = true;
        yield return new WaitForSeconds(textCD);
        textInCD = false;
    }
}

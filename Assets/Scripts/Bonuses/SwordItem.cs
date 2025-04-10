using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordItem : MonoBehaviour
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
    public GameObject sword;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>().gameObject;
        charBonus = FindObjectOfType<CharacterBonus>();
    }

    private void Update()
    {

        if (charBonus.hasSword)
        {
            gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !used && !charBonus.hasSword)
        {
            ShowText(textPrefab);
            used = true;
            charBonus.hasSword = true;
            dataToKeep.hasSword = true;
            sword.SetActive(true);

            GetComponent<BoxCollider2D>().enabled = false;
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

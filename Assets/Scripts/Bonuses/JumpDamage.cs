using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    [SerializeField]
    private IntSO dataToKeep;
    private bool used = false;
    private float textCD = 3f;
    private bool textInCD = false;

    public int bonus;
    public int bonusIndex;
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
        if (collision.CompareTag("Player") && !used && charBonus.jumpDamageBonuses[bonusIndex] == 0)
        {
            ShowText(textPrefab);
            used = true;
            charBonus.jumpDamageBonuses[bonusIndex] = 1;

            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            pickParticle.SetActive(true);

            dataToKeep.jumpDamage += bonus;
            dataToKeep.jumpDamageBonuses = charBonus.jumpDamageBonuses;
            FindObjectOfType<CharacterStats>().jumpDamage = dataToKeep.jumpDamage;

            Destroy(gameObject, 0.5f);

        }

        else if (collision.CompareTag("Player") && (used || charBonus.jumpDamageBonuses[bonusIndex] == 1))
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

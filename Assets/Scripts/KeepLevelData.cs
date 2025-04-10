using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeepLevelData : MonoBehaviour
{

    [SerializeField]
    private IntSO dataToKeep;

    private GameObject hearts;

    public CharacterBonus charBonus;

    public GameObject sword;

    [SerializeField]
    private GameObject character;


    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            dataToKeep.life = dataToKeep.respawnLife;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            character.transform.SetParent(null);

        }
    }

    public void Start()
    {
        charBonus = FindObjectOfType<CharacterBonus>();
        charBonus.jumpDamageBonuses = dataToKeep.jumpDamageBonuses;
        charBonus.doubleJump = dataToKeep.doubleJump;
        charBonus.hasSword = dataToKeep.hasSword;

        if (charBonus.hasSword || dataToKeep.hasSword)
        {
            sword.SetActive(true);
        }


        hearts = GetChildWithTag(gameObject, "Hearts");
        // Activo los corazones que teniamos
        for (int i = 0; i < dataToKeep.totalLives; i++)
        {
            hearts.transform.GetChild(i).gameObject.SetActive(true);    
        }

        // Reduzco a la vida que teniamos o queda igual

        for (int i = 0; i < dataToKeep.totalLives; i++)
        {   if (i >= dataToKeep.life && i < dataToKeep.totalLives) 
            {
                hearts.transform.GetChild(i).GetComponent<Image>().color = Color.black;
            }
            else
            {
                hearts.transform.GetChild(i).GetComponent<Image>().color = Color.red;

            }
        }
    }

    public static GameObject GetChildWithTag(GameObject parent, string tag)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).CompareTag(tag))
            {
                return t.GetChild(i).gameObject;
            }
        }

        return null;
    }
}

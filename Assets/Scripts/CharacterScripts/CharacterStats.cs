using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    private IntSO dataToKeep;

    public int totalLives;
    public int life;
    public int jumpDamage;


    public void Start()
    {
        totalLives = dataToKeep.totalLives;
        life = dataToKeep.life;
        jumpDamage = dataToKeep.jumpDamage;
    }
}

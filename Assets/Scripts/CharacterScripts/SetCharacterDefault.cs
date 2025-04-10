using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacterDefault : MonoBehaviour
{

    [SerializeField]
    private IntSO dataToKeep;

    public int defaultLives = 2;
    public int defaultTotalLives = 2;
    public int defaultJumpDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        dataToKeep.totalLives = defaultTotalLives;
        dataToKeep.life = defaultLives;
        dataToKeep.respawnLife = defaultLives;
        dataToKeep.jumpDamage = defaultJumpDamage;
        dataToKeep.hasSword = false;
        dataToKeep.doubleJump = false;

        for (int i = 0; i < dataToKeep.jumpDamageBonuses.Count; i++)
        {
            dataToKeep.jumpDamageBonuses[i] = 0;
        }

    }


}

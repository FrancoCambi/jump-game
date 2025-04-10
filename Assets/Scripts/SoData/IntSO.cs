using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntSO : ScriptableObject
{
    [SerializeField]
    private int _totalLives;

	public int totalLives
	{
		get { return _totalLives; }
		set { _totalLives = value; }
	}

	[SerializeField]
	private int _life;

	public int life
	{
		get { return _life; }
		set { _life = value; }
	}

    [SerializeField]
    private int _respawnLife;

    public int respawnLife
    {
        get { return _respawnLife; }
        set { _respawnLife = value; }
    }

    [SerializeField]
	private int _jumpDamage;

	public int jumpDamage
	{
		get { return _jumpDamage; }
		set { _jumpDamage = value; }
	}

	public List<int> jumpDamageBonuses;

	public bool doubleJump;

	public bool hasSword;


}

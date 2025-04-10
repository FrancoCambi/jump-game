using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public bool AllEnemiesKilled()
    {
        return transform.childCount == 0;
    }
}

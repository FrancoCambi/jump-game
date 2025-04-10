using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyToSpawn;

    void Update()
    {
        if (transform.childCount == 0)
        {
            GameObject spawned = Instantiate(enemyToSpawn, gameObject.transform.position - new Vector3(1, 0, 0), Quaternion.identity);
            spawned.transform.parent = transform;

        }

    }
}

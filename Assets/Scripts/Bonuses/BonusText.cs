using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusText : MonoBehaviour
{
    public float destroyTime = 3f;
    public Vector3 offset = new Vector3(0, 1f, 10);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);

        transform.position += offset;
    }

 
}

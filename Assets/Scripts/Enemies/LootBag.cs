using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public List<GameObject> lootList = new List<GameObject>();
    public int[] chances;

    public bool hasLootOffset;
    public Vector2 lootOffset;

    private GameObject GetDroppedItem()
    {
        int randomNumber = Random.Range(0, 101);
        List<GameObject> possibleItems = new List<GameObject>();
        for (int i = 0; i < lootList.Count; i++)
        {
            if (randomNumber <= chances[i])
            {
                possibleItems.Add(lootList[i]);
                
            }
        }
        if (possibleItems.Count > 0)
        {
            GameObject droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem; 
        }

        return null;

    }

    public void InstantiateLoot(Vector2 spawnPos)
    {
        GameObject droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            Vector2 finalSpawnPos = hasLootOffset ? spawnPos + lootOffset : spawnPos;
            GameObject lootGameObject = Instantiate(droppedItem, finalSpawnPos, Quaternion.identity);
            //lootGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(lootGameObject.GetComponent<Rigidbody2D>().velocity.x, 4f);
        }
    }
}

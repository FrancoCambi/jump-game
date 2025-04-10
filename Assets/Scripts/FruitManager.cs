using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FruitManager : MonoBehaviour
{

    public Text fruitsText;

    public int totalFruitsInLevel;
    public int currentFruits = 0;
    
    public void Start()
    {
        totalFruitsInLevel = transform.childCount;
        fruitsText.text = $"Frutas: 0 / {totalFruitsInLevel}";
    }

    public bool AllFruitsCollected()
    {
        if (currentFruits == totalFruitsInLevel)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void UpdateFruitsText()
    {
        currentFruits++;
        fruitsText.text = $"Frutas: {currentFruits} / {totalFruitsInLevel}";
    }
}

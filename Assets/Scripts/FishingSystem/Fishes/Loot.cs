using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Loot : MonoBehaviour
{
    private int _currentHealth;
    public enum LootType
    {
        Common,
        Uncommon,
        Rare,
        GoldenFish
    }

    public LootType lootType;
    [SerializeField] private int score;
    public Image image;

    private void Start()
    {
        if (lootType == LootType.Common) _currentHealth = Random.Range(5, 15);
        if (lootType == LootType.Uncommon) _currentHealth = Random.Range(15, 25);
        if (lootType == LootType.Rare) _currentHealth = Random.Range(25, 35);
        if (lootType == LootType.GoldenFish) _currentHealth = Random.Range(50, 75);
    }
    
    public void ClickToDestroy()
    {
        _currentHealth--;
        if (_currentHealth <= 0)
        {
            //Instantiate(image);
            //effect
            //scorePoints
            Destroy(gameObject);
        }
    }
}

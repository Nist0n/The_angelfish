using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Loot : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private GameObject effect;
    [SerializeField] private int score;
    [SerializeField] private GameObject image;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI currentHealthText;

    private Fishing _fishing;
    public enum LootType
    {
        Common,
        Uncommon,
        Rare,
        GoldenFish
    }

    public LootType lootType;

    private void Start()
    {
        _fishing = FindObjectOfType<Fishing>();
        
        if (lootType == LootType.Common) _currentHealth = Random.Range(5, 15);
        if (lootType == LootType.Uncommon) _currentHealth = Random.Range(15, 25);
        if (lootType == LootType.Rare) _currentHealth = Random.Range(25, 35);
        if (lootType == LootType.GoldenFish) _currentHealth = Random.Range(50, 75);
    }

    private void Update()
    {
        currentHealthText.text = $"{_currentHealth}";
    }

    public void ClickToDestroy()
    {
        _currentHealth--;
        
        StartCoroutine(EffectActive());
        
        if (_currentHealth <= 0)
        {
            gameObject.GetComponent<Image>().color = Color.clear;
            text.color = Color.clear;
            currentHealthText.color = Color.clear;
            gameObject.GetComponent<Button>().enabled = false;
            image.SetActive(true);
            //scorePoints
            _fishing.GetOutRod();
            Destroy(gameObject, 2.2f);
        }
    }

    IEnumerator EffectActive()
    {
        GameObject temp = Instantiate(effect, transform);
        yield return new WaitForSeconds(0.5f);
        Destroy(temp);
    }
}

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
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameUI;

    private Fishing _fishing;
    private FishManager _fishManager;

    private bool _timeIsRunning = true;
    [SerializeField] private float timeRemaining;
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
        _fishManager = FindObjectOfType<FishManager>();
        scoreText.text = $"{score}";
        
        if (lootType == LootType.Common) _currentHealth = Random.Range(5, 15);
        if (lootType == LootType.Uncommon) _currentHealth = Random.Range(20, 29);
        if (lootType == LootType.Rare) _currentHealth = Random.Range(35, 50);
        if (lootType == LootType.GoldenFish) _currentHealth = Random.Range(65, 85);
    }

    private void Update()
    {
        if (_timeIsRunning)
        {
            timeRemaining -= Time.deltaTime;
            timeText.text = timeRemaining.ToString("0.00");

            if (timeRemaining <= 0)
            {
                TimeIsOut();
            }
        }
        currentHealthText.text = $"{_currentHealth}";
    }

    public void ClickToDestroy()
    {
        AudioManager.instance.PlaySFX("Bulk");
        
        _currentHealth--;
        
        StartCoroutine(EffectActive());
        
        if (_currentHealth <= 0)
        {
            if (lootType == LootType.GoldenFish)
            {
                StartCoroutine(GoldenFish());
            }
            else
            {
                CatchFish();
            }
        }
    }

    IEnumerator EffectActive()
    {
        GameObject temp = Instantiate(effect);
        yield return new WaitForSeconds(0.5f);
        Destroy(temp);
    }

    private void CatchFish()
    {
        AudioManager.instance.PlaySFX("catch");
        _timeIsRunning = false;
        gameObject.GetComponent<Image>().color = Color.clear;
        text.color = Color.clear;
        currentHealthText.color = Color.clear;
        timeText.color = Color.clear;
        gameObject.GetComponent<Button>().enabled = false;
        image.SetActive(true);
        _fishManager.Score += score;
        _fishing.GetOutRod();
        Destroy(gameObject, 2.2f);
    }

    IEnumerator GoldenFish()
    {
        CatchFish();
        yield return new WaitForSeconds(1f);
        _fishManager.Wish.SetActive(true);
        _fishManager.Wish.GetComponent<ChooseAWish>().CreateAWish();
        Time.timeScale = 0;
    }

    private void TimeIsOut()
    {
        _fishing.GetOutRod();
        Destroy(gameObject);
    }
}

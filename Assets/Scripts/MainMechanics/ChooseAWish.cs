using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseAWish : MonoBehaviour
{
    public static ChooseAWish instance;
    
    [SerializeField] GameObject firstOption;
    [SerializeField] GameObject secondOption;
    [SerializeField] GameObject thirdOption;

    private FishManager _fish;

    public List<string> good;
    public List<string> bad;

    private void Start()
    {
        _fish = FindObjectOfType<FishManager>();
    }

    public void CreateAWish()
    {
        firstOption.GetComponentInChildren<TMP_Text>().text = good[UnityEngine.Random.Range(0, good.Count)];
        secondOption.GetComponentInChildren<TMP_Text>().text = bad[UnityEngine.Random.Range(0, bad.Count)];
        thirdOption.GetComponentInChildren<TMP_Text>().text = bad[UnityEngine.Random.Range(0, bad.Count)];
    }

    public void GoodChoose()
    {
        _fish.Score += 5000;
        Time.timeScale = 1;
        AudioManager.instance.PlaySFX("babkaLose");
    }

    public void BadChoose()
    {
        AudioManager.instance.PlaySFX("badWish");
        _fish.Score -= 4000;
        Time.timeScale = 1;
        AudioManager.instance.PlaySFX("meh");
    }
}

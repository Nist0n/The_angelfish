using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maxScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private FishManager _fishManager;

    private void Start()
    {
        _fishManager = FindObjectOfType<FishManager>();
    }

    private void Update()
    {
        maxScoreText.text = $"Рекорд: {PlayerPrefs.GetInt("score")}";
        scoreText.text = $"Очки: {_fishManager.Score}";
        if (_fishManager.Score >= PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", _fishManager.Score);
        }
    }
}

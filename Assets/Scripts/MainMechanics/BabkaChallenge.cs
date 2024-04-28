using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabkaChallenge : MonoBehaviour
{
    private Timer _timer;
    private BabkaEnterteiment _babka;
    [SerializeField] private GameObject gameUI;

    public bool IsStarted = false;
    void Start()
    {
        _timer = FindObjectOfType<Timer>();
        _babka = FindObjectOfType<BabkaEnterteiment>();
    }

    private void Update()
    {
        if (!IsStarted)
        {
            _timer.StartTimer(_babka.ChallengeTimer);
            AudioManager.instance.PlaySFX("clean");
            IsStarted = true;
        }
    }

    public void HideUI()
    {
        gameUI.SetActive(false);
        gameObject.GetComponent<Button>().enabled = false;
    }
    
    public void ShowUI()
    {
        gameUI.SetActive(true);
        gameObject.GetComponent<Button>().enabled = true;
    }
}

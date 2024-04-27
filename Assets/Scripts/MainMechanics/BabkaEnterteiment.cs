using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabkaEnterteiment : MonoBehaviour
{
    [SerializeField] private GameObject babka;
    
    private float _timer;
    private bool _timerIsActivated;
    public float ChallengeTimer;
    
    void Start()
    {
        ChallengeTimer = 12.5f;
        _timerIsActivated = false;
        StartTimer();
    }
    
    void Update()
    {
        ChallengeTimer = Mathf.Clamp(ChallengeTimer, 2f, 100f);
        
        if (_timerIsActivated)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                babka.SetActive(true);
            }
        }
    }

    public void StartTimer()
    {
        _timerIsActivated = true;
        _timer = Random.Range(40, 60);
    }

    public void DecreaseTime()
    {
        ChallengeTimer -= 1.5f;
    }
}

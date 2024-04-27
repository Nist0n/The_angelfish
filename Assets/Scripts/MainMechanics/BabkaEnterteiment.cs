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
        ChallengeTimer = 20f;
        _timerIsActivated = false;
        StartTimer();
    }
    
    void Update()
    {
        if (_timerIsActivated)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                Instantiate(babka);
            }
        }
    }

    public void StartTimer()
    {
        _timerIsActivated = true;
        _timer = Random.Range(40, 60);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabkaChallenge : MonoBehaviour
{
    private Timer _timer;
    void Start()
    {
        _timer = FindObjectOfType<Timer>();
        _timer.StartTimer();
    }
}

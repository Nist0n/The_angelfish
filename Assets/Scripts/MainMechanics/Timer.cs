using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;
    public bool start;
    public TextMeshProUGUI value;

    void Update()
    {
        if (start == true)
        {
            time -= Time.deltaTime;
            value.text = time.ToString("0.00");
        }
        if (time == 0)
        {
            StopTimer();
        }
    }

    public void StartTimer()
    {
        start = true;
    }

    public void PauseTimer()
    {
        start = false;
    }

    public void StopTimer()
    {
        start = false;
        time = 0;
        value.text = time.ToString("0.00");
    }

}

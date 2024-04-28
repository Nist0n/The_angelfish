using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class randWaveAudio : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Wave());
    }

    IEnumerator Wave()
    {
        var rand = Random.Range(1, 3);
        AudioManager.instance.PlaySFX("wave" + rand.ToString());
        rand = Random.Range(5, 8);
        yield return new WaitForSeconds(rand);
        StartCoroutine(Wave());
    }
}
